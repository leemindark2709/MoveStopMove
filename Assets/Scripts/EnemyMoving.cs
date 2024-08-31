using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoving : MonoBehaviour
{
    public string name;
    public List<GameObject> combinedList = new List<GameObject>();
    public Animator anim;
    public bool isDead = false;
    public List<Transform> MovePoint = new List<Transform>();
    public float EnemySpeed = 1f;
    public Transform Weapon;
    public GameObject Enemy;
    public Transform pointSpawnWeapon;
    [SerializeField]private Transform targetMovePoint;
    public float detectionRadius = 1f;
    public bool collision;
    public int NumSpawWeapon;
    private Transform originalWeaponParent;
    public float timeToReturn;
    public Vector3 direction;
    private bool isWaiting;
    private Transform canvasTransform;
    private Quaternion initialCanvasRotation;
    public bool isMoving;
    public int torqueAmount;
    public Quaternion localRotation;
    private bool canUpdateMovePoint = true;
    private bool isAttack=false;

    void Start()
    {
        localRotation = Weapon.localRotation;
        //Weapon.GetComponent<Rigidbody>().isKinematic = true;
        Weapon.GetComponent<BoxCollider>().enabled = false;
        Transform canvas = transform.Find("Canvas");
        if (canvas != null)
        {
            Transform isCheckEnemy = canvas.Find("IsCheckEnemy");
            if (isCheckEnemy != null)
            {
                isCheckEnemy.GetComponent<Image>().enabled = false;
            }

            canvasTransform = canvas;
            initialCanvasRotation = canvasTransform.rotation;
        }

        NumSpawWeapon = 1;
        Weapon = FindDeepChild(this.transform, "Hammer");
        anim = transform.Find("Armature").GetComponent<Animator>();
        MovePoint = CheckPointSpawnEnemy.Instance.Enemys;
        targetMovePoint = GetRandomMovePoint();
        pointSpawnWeapon = FindDeepChild(transform, "CheckPointWeapon");
        originalWeaponParent = Weapon.parent;
    }

    void Update()
    {
        if (transform.Find("Armature").gameObject == PlayerAttack.instance.enemy)
        {
            transform.Find("Canvas").Find("IsCheckEnemy").GetComponent<Image>().enabled = true;

        }
        else
        {
            transform.Find("Canvas").Find("IsCheckEnemy").GetComponent<Image>().enabled = false;
        }
        if (CheckEnemy() != null)
        {
            anim.SetFloat("moving", 0);
        }
        else
        {
            anim.SetFloat("moving", 1);
        }
        if (isDead)
        {
            Transform canvas = transform.Find("Canvas");
            if (canvas != null)
            {
                Transform isCheckEnemy = canvas.Find("IsCheckEnemy");
                if (isCheckEnemy != null)
                {
                    isCheckEnemy.GetComponent<Image>().enabled = false;
                }
            }
            anim.Play("Dead");
            StartCoroutine(DelayedDestroy(2.4f));
            return;
        }



        if (CheckEnemy() != null && NumSpawWeapon == 1 && !isDead&& !isAttack)
        {
            isAttack = true;
            direction = (CheckEnemy().transform.position - Weapon.position).normalized;
            direction.y = 0.016f;
            Enemy = CheckEnemy();
            StartCoroutine(PauseMovement());
            Attack();
            NumSpawWeapon = 0;
        }

        //if (targetMovePoint == null || isPoint())
        //{
        //    targetMovePoint = GetRandomMovePoint();
        //}

        if (targetMovePoint != null && CheckEnemy() == null && !isWaiting && !isDead && !isPoint())
        {
            anim.SetFloat("moving", 1);
            EnemySpeed = 1;

            Vector3 moveDirection = (targetMovePoint.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 3f * EnemySpeed);
            // Tính toán vector hướng từ vị trí hiện tại đến điểm mục tiêu
            Vector3 direction = (targetMovePoint.position - transform.position).normalized;

            // Di chuyển đối tượng theo hướng đã tính toán
            transform.position += direction * EnemySpeed * 0.5f * Time.deltaTime;



        }
        if (isPoint())
        {
            anim.SetFloat("moving", 0);
            if (canUpdateMovePoint)
            {
                canUpdateMovePoint = false; // Prevent immediate re-triggering
                StartCoroutine(WaitBeforeUpdateMovePoint(3f)); // Wait 3 seconds before updating the move point
            }
        }


        if (canvasTransform != null)
        {
            canvasTransform.rotation = initialCanvasRotation;
        }
    }
    //private IEnumerator wait02Seconnd(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    targetMovePoint = GetRandomMovePoint();
    //}
    private IEnumerator WaitBeforeUpdateMovePoint(float delay)
    {
        yield return new WaitForSeconds(delay);
        targetMovePoint = GetRandomMovePoint();
        canUpdateMovePoint = true; // Allow the move point to be updated again
    }


    private IEnumerator DelayedDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
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
        combinedList.Clear();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Playerr");

        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<Collider>() != null)
            {
                combinedList.Add(enemy);
            }
        }

        foreach (GameObject player in players)
        {
            if (player.GetComponent<Collider>() != null)
            {
                combinedList.Add(player);
            }
        }

        foreach (GameObject potentialEnemy in combinedList)
        {
            if (potentialEnemy.transform != this.transform && potentialEnemy.transform != this.transform.Find("Armature"))
            {
                float distance = Vector3.Distance(transform.position, potentialEnemy.transform.position);
                if (distance <= detectionRadius)
                {
                    return potentialEnemy;
                }
            }
        }

        return null;
    }

    private IEnumerator PauseMovement()
    {
        anim.SetFloat("moving", 0);
        EnemySpeed = 0;
        yield return new WaitForSeconds(2);
        EnemySpeed = 1;
        isAttack = false;
    }

    private IEnumerator PauseAtPoint(float delay)
    {
        isWaiting = true;
        EnemySpeed = 0;
        anim.SetFloat("moving", 0);
        yield return new WaitForSeconds(delay);
       
        isWaiting = false;
        EnemySpeed = 1;

    }
    private IEnumerator wait02Seconnd(float delay)
    {
        yield return new WaitForSeconds(delay);
        targetMovePoint = GetRandomMovePoint();
    }

    public void SpawnWeapon()
    {
        GameObject spawnedWeapon = Instantiate(Weapon.gameObject, pointSpawnWeapon.position, pointSpawnWeapon.rotation);
        WeaponFly weaponFly = spawnedWeapon.GetComponent<WeaponFly>();

        if (weaponFly != null && Enemy != null)
        {
            Transform enemyTarget = Enemy.transform;
            if (enemyTarget != null)
            {
                weaponFly.SetTarget(enemyTarget);
                weaponFly.enabled = true;
            }
        }
    }

    public void Attack()
    {
        if (isDead) return;
        GameObject enemy = CheckEnemy();
        if (enemy != null)
        {
            StartCoroutine(DelayedAttack(0.2f, enemy));
        }
    }

    private IEnumerator DelayedAttack(float delay, GameObject enemy)
    {
        if (isDead) yield break;

        if (enemy != null)
        {
            Transform enemyTarget = enemy.transform;

            if (enemyTarget != null)
            {
                Vector3 direction = (enemyTarget.position - Weapon.position).normalized;
                direction.y = 0;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                float rotationSpeed = 1.8f;
                float rotationProgress = 0f;

                while (rotationProgress < 0.95f)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationProgress);
                    rotationProgress += Time.deltaTime * rotationSpeed;
                    yield return null;
                }

                if (!isDead)
                {

                    anim.SetFloat("attack", 1);

                    yield return new WaitForSeconds(delay);

                    if (enemyTarget != null && !isDead)
                    {
                        PerformAttack(enemyTarget);
                    }
                }
            }
        }
    }


    private void PerformAttack(Transform enemyTarget)
    {
        if (enemyTarget == null) return;

        Rigidbody weaponRb = Weapon.GetComponent<Rigidbody>();
        if (weaponRb != null)
        {
           
            Vector3 localPosition = Weapon.localPosition;
            localRotation = Weapon.localRotation;
            direction = (enemyTarget.position - Weapon.position).normalized;
            direction.y = 0;  // Ignore the Y axis

            Weapon.transform.rotation = Quaternion.Euler(0, 0, 90); // Đặt rotation cho vũ khí

            Weapon.parent = null;
            Weapon.gameObject.GetComponent<DameSender>().checkTree = false;
            weaponRb.isKinematic = false;
            weaponRb.velocity = Vector3.zero;
            weaponRb.angularVelocity = Vector3.zero;

            float forceMagnitude = 1f;
            float distance = Vector3.Distance(Weapon.position, enemyTarget.position);
            float weaponSpeed = forceMagnitude;

            timeToReturn = distance / weaponSpeed;
            weaponRb.AddForce(direction * forceMagnitude, ForceMode.Impulse);
            Weapon.gameObject.layer = LayerMask.NameToLayer("Default");

            Weapon.localRotation = Quaternion.Euler(270, 0, 90);
            StartCoroutine(RotateWeaponAroundYAxis(timeToReturn));
            Weapon.GetComponent<BoxCollider>().enabled = true;
            //weaponRb.AddTorque(new Vector3(0, 1000000000000f, 0));
           
            StartCoroutine(ReturnToParentAfterDelay(timeToReturn, localPosition, localRotation));
        }
    }

    private IEnumerator ReturnToParentAfterDelay(float delay, Vector3 originalPosition, Quaternion originalRotation)
    {
        yield return new WaitForSeconds(delay);

        Weapon.parent = originalWeaponParent;
        Weapon.localPosition = originalPosition;
        Weapon.localRotation = originalRotation;
        Weapon.GetComponent<Rigidbody>().isKinematic = true;
        Weapon.GetComponent<BoxCollider>().enabled = false;
        Weapon.gameObject.layer = LayerMask.NameToLayer("Enemy");

        StartCoroutine(DelayenableWeaponCollider());
        NumSpawWeapon = 1;
        anim.SetFloat("attack", 0);
    }
    private IEnumerator RotateWeaponAroundYAxis(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Quay vũ khí quanh trục Y với tốc độ nhất định
            Weapon.Rotate(new Vector3(0, 0, 1), torqueAmount * Time.deltaTime); // Xoay quanh trục Y
            elapsedTime += Time.deltaTime;
            yield return null; // Đợi cho đến khung hình tiếp theo
        }
        Weapon.localRotation = localRotation; // Đặt lại góc quay ban đầu của vũ khí
                                              // Đảm bảo vũ khí không còn xoay khi hết thời gian

    }

    private IEnumerator DelayenableWeaponCollider()
    {
        yield return new WaitForSeconds(2.5f);
        if (isDead != true)
        {
            Weapon.GetComponent<Rigidbody>().isKinematic = false;
            Weapon.GetComponent<BoxCollider>().enabled = true;
        }
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
