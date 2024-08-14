using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public Animator anim;
    public List<Transform> MovePoint = new List<Transform>();
    public float EnemySpeed = 2f;
    public Transform Weapon;
    public GameObject Enemy;
    public Transform pointSpawnWeapon; // Biến để lưu đối tượng PointSpawnWeapon
    private Transform targetMovePoint;
    public float detectionRadius = 1f; // Đặt giá trị mặc định cho bán kính phát hiện
    public bool collision; // Giả định rằng biến này theo dõi trạng thái va chạm
    public int NumSpawWeapon;
    private Transform originalWeaponParent; // Biến để lưu cha gốc của vũ khí
    public float timeToReturn;

    private bool isWaiting; // Biến để theo dõi trạng thái dừng lại

    void Start()
    {
        NumSpawWeapon = 1;

        Weapon = FindDeepChild(this.transform, "Hammer");
        anim = transform.Find("Armature").GetComponent<Animator>();
        MovePoint = CheckPointSpawnEnemy.Instance.Enemys;
        targetMovePoint = GetRandomMovePoint();

        pointSpawnWeapon = FindDeepChild(transform, "CheckPointWeapon");

        if (pointSpawnWeapon != null)
        {
            //Debug.Log("Tìm thấy PointSpawnWeapon.");
        }
        else
        {
            //Debug.LogWarning("Không tìm thấy PointSpawnWeapon.");
        }

        originalWeaponParent = Weapon.parent;
    }

    void Update()
    {
        if (CheckEnemy() && NumSpawWeapon == 1)
        {
            Enemy = CheckEnemy();
            StartCoroutine(PauseMovement(1f));
            Attack();
            NumSpawWeapon = 0;
        }

        if (targetMovePoint == null || isPoint())
        {
            targetMovePoint = GetRandomMovePoint();
        }

        if (targetMovePoint != null && CheckEnemy() == null && !isWaiting)
        {
            anim.SetFloat("moving", 1);

            Vector3 direction = (targetMovePoint.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * EnemySpeed);

            transform.position = Vector3.MoveTowards(transform.position, targetMovePoint.position, EnemySpeed * 0.5f * Time.deltaTime);

            if (isPoint())
            {
                StartCoroutine(PauseAtPoint(1f)); // Dừng lại 0.5 giây khi đến điểm đích
            }
        }
    }

    public Transform GetRandomMovePoint()
    {
        if (MovePoint.Count == 0)
        {
            return null;
        }
        int randomIndex = Random.Range(0, MovePoint.Count);
        return MovePoint[randomIndex];
    }

    public bool isPoint()
    {
        return Vector3.Distance(transform.position, targetMovePoint.position) < 0.1f;
    }

    public GameObject CheckEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = System.Array.FindAll(enemies, enemy => enemy != this.gameObject);

        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform != this.transform && enemy.transform != this.transform.Find("Armature"))
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance <= detectionRadius)
                {
                    return enemy;
                }
            }
        }

        return null;
    }

    private IEnumerator PauseMovement(float duration)
    {
        EnemySpeed = 0;
        anim.SetFloat("moving", 0);
        yield return new WaitForSeconds(duration);
        EnemySpeed = 2;
    }

    private IEnumerator PauseAtPoint(float delay)
    {
        isWaiting = true;
        EnemySpeed = 0;
        anim.SetFloat("moving", 0);
        yield return new WaitForSeconds(delay);
        isWaiting = false;
        EnemySpeed = 2;
    }

    public void SpawnWeapon()
    {
        GameObject spawnedWeapon = Instantiate(Weapon.gameObject, pointSpawnWeapon.position, pointSpawnWeapon.rotation);
        WeaponFly weaponFly = spawnedWeapon.GetComponent<WeaponFly>();

        if (weaponFly != null && Enemy != null)
        {
            Transform enemyTarget = FindDeepChild(Enemy.transform, "Armature");
            if (enemyTarget != null)
            {
                weaponFly.SetTarget(enemyTarget);
                weaponFly.enabled = true;
            }
        }
    }

    public void Attack()
    {
        GameObject enemy = CheckEnemy();
        if (enemy != null)
        {
            StartCoroutine(DelayedAttack(0.5f, enemy));
        }
    }

    private IEnumerator DelayedAttack(float delay, GameObject enemy)
    {
        if (enemy != null)
        {
            // Tìm vị trí của mục tiêu
            Transform enemyTarget = FindDeepChild(enemy.transform, "Armature");

            if (enemyTarget != null)
            {
                // Tính toán hướng từ đối tượng đến mục tiêu
                Vector3 direction = (enemyTarget.position - transform.position).normalized;

                // Quay đối tượng để hướng về phía mục tiêu
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                float rotationSpeed = 2f; // Tốc độ quay
                float rotationProgress = 0f;

                while (rotationProgress < 1f)
                {
                    // Quay từ từ về phía mục tiêu
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationProgress);
                    rotationProgress += Time.deltaTime * rotationSpeed;
                    yield return null; // Chờ cho đến khi quá trình quay hoàn tất
                }

                // Đợi thêm 0.5 giây trước khi tấn công
                yield return new WaitForSeconds(delay);

                // Kiểm tra nếu enemyTarget vẫn còn tồn tại trước khi thực hiện tấn công
                if (enemyTarget != null)
                {
                    // Thực hiện hành động tấn công
                    PerformAttack(enemyTarget);
                }
            }
        }
    }

    private void PerformAttack(Transform enemyTarget)
    {
        if (enemyTarget == null)
        {
            return; // Kết thúc sớm nếu mục tiêu không tồn tại
        }

        // Tính toán hướng từ vũ khí đến mục tiêu
        Vector3 direction = (enemyTarget.position - Weapon.position).normalized;

        // Chỉ giữ lại các thành phần X và Z, đặt Y về 0
        direction.y = 0.016f;

        Rigidbody weaponRb = Weapon.GetComponent<Rigidbody>();
        if (weaponRb != null)
        {
            // Tạo một vị trí và rotation mới cho weapon không bị ảnh hưởng bởi cha
            Vector3 localPosition = Weapon.localPosition;
            Quaternion localRotation = Weapon.localRotation;

            // Tách đối tượng ra khỏi cha của nó
            Weapon.parent = null;
            Weapon.gameObject.GetComponent<DameSender>().checkTree = false;

            // Hủy trạng thái kinematic để đối tượng chịu tác dụng của lực
            weaponRb.isKinematic = false;

            // Reset velocity và angular velocity của Rigidbody
            weaponRb.velocity = Vector3.zero;
            weaponRb.angularVelocity = Vector3.zero;

            // Áp dụng lực để di chuyển Weapon theo hướng mục tiêu
            float forceMagnitude = 1f; // Tăng độ lớn của lực nếu cần thiết
            weaponRb.AddForce(direction * forceMagnitude, ForceMode.Impulse);

            // Tính toán khoảng cách giữa weapon và Armature
            float distance = Vector3.Distance(Weapon.position, enemyTarget.position);

            // Tính toán vận tốc dựa trên lực áp dụng
            float weaponSpeed = forceMagnitude; // Sử dụng forceMagnitude làm vận tốc tạm thời

            // Tính toán thời gian di chuyển
            timeToReturn = distance / weaponSpeed;

            // Đưa đối tượng lại vị trí ban đầu sau thời gian tính toán
            StartCoroutine(ReturnToParentAfterDelay(timeToReturn, localPosition, localRotation));
        }
    }

    private IEnumerator ReturnToParentAfterDelay(float delay, Vector3 originalPosition, Quaternion originalRotation)
    {
        yield return new WaitForSeconds(delay);

        Weapon.parent = originalWeaponParent;
        Weapon.localPosition = originalPosition;
        Weapon.localRotation = originalRotation;

        Rigidbody weaponRb = Weapon.GetComponent<Rigidbody>();
        if (weaponRb != null)
        {
            weaponRb.isKinematic = true;
        }
        NumSpawWeapon = 1;
    }

    Transform FindDeepChild(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                return child;
            }

            Transform found = FindDeepChild(child, name);
            if (found != null)
            {
                return found;
            }
        }
        return null;
    }
}
