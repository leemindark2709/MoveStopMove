using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{   public static PlayerAttack instance;
    public Animator anim;
    public bool isDead=false;
    public bool End=false;
    public ParticleSystem deathParticles;
    public bool IsRotate=false;
    public int numOfAttacks = 1; // Số lượng tấn công
    public float detectionRadius = 0.1f; // Bán kính phát hiện
    public Transform weapon; // Đối tượng vũ khí
   [SerializeField] public GameObject enemy; // Kẻ địch gần nhất
    private Transform originalWeaponParent; // Vị trí ban đầu của vũ khí
    public float timeToReturn; // Thời gian để vũ khí trở về
    public Transform enemyTarget; // Mục tiêu của kẻ địch
    public int NumOfDead;
    public List<GameObject> enemys;
    public Vector3 direction;
    private Coroutine returnCoroutine; // Tham chiếu đến coroutine trở về
    public float torqueAmount = 10;
    public Vector3 localPosition;
    public Quaternion localRotation ;
    public bool isCollidingWithWall = false;
    public bool CanAttack; 
    private void Awake()
    {
        instance = this;
    }
 

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isCollidingWithWall = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("va cham");
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isCollidingWithWall = false;
        }
    }

    // Optional: Method to get the collision status
    public bool IsCollidingWithWall()
    {
        return isCollidingWithWall;
    }
    void Start()
    {

        weapon.GetComponent<BoxCollider>().enabled = false;
        localRotation = weapon.localRotation;
        localPosition = weapon.localPosition;
        NumOfDead = 1;
        anim = GetComponent<Animator>(); // Lấy component Animator
        //weapon = FindDeepChild(transform, "Hammer"); // Tìm đối tượng vũ khí "Hammer"
        if (weapon == null)
        {
            Debug.LogWarning("Không tìm thấy vũ khí 'Hammer'.");
        }
        else
        {
            originalWeaponParent = weapon.parent; // Lưu trữ vị trí ban đầu của vũ khí
        }
    }

    void Update()
    {
        if (isDead)
        {
            //weapon.GetComponent<Rigidbody>().isKinematic = true;
            transform.gameObject.GetComponent<PlayerAttack>().enabled= false;
            //transform.GetComponent<Rigidbody>().gameObject.SetActive(false);
            //transform.GetComponent<BoxCollider>().gameObject.SetActive(false);
            deathParticles.transform.position = transform.position;
            deathParticles.Play(); // Chạy Particle System

        }
        if (GameManager.Instance.counyEnemy==1)
        {
            GameManager.Instance.MovePositionRankAndSettinglmd();
            GameManager.Instance.WinGame.gameObject.SetActive(true);
            NumOfDead = 0; GameManager.Instance.TouchToContinue.Find("Canvas").Find("PanelRank").Find("Top").GetComponent<TextMeshProUGUI>().text = "#" + (GameManager.Instance.counyEnemy).ToString();
            GameManager.Instance.NumOfRevice -= 1;

            //PlayerAttack.instance.End = false;
           
            //transform.gameObject.SetActive(false);
            GameManager.Instance.PLayer.Find("Armature").tag = "DeadPlayer";
            GameManager.Instance.PLayer.GetComponent<PlayerMovement>().enabled = false;
            GameManager.Instance.Armature.GetComponent<PlayerAttack>().anim.Play("Idel");


        }
        if (isDead && NumOfDead==1&&GameManager.Instance.NumOfRevice>1)
        {
            
            GameManager.Instance.EndGame = true;
            NumOfDead =0;
            GameManager.Instance.TouchToContinue.Find("Canvas").Find("PanelRank").Find("Top").GetComponent<TextMeshProUGUI>().text = "#"+(GameManager.Instance.counyEnemy).ToString();
            GameManager.Instance.NumOfRevice -=1;
           
            //PlayerAttack.instance.End = false;
            anim.Play("Dead");
            //transform.gameObject.SetActive(false);
            GameManager.Instance.PLayer.Find("Armature").tag = "DeadPlayer";
            GameManager.Instance.PLayer.GetComponent<PlayerMovement>().enabled = false;
            //GameManager.Instance.PLayer.GetComponent<PlayerAttack>().enabled = false;
        }
        if (isDead &&NumOfDead==1&& GameManager.Instance.NumOfRevice <=1)
        {
            GameManager.Instance.MovePositionRankAndSettinglmd();
            GameManager.Instance.TouchToContinue.gameObject.SetActive(true) ;
            NumOfDead = 0; GameManager.Instance.TouchToContinue.Find("Canvas").Find("PanelRank").Find("Top").GetComponent<TextMeshProUGUI>().text = "#" + (GameManager.Instance.counyEnemy).ToString();
            GameManager.Instance.NumOfRevice -= 1;

            //PlayerAttack.instance.End = false;
            anim.Play("Dead");
            //transform.gameObject.SetActive(false);
            GameManager.Instance.PLayer.Find("Armature").tag = "DeadPlayer";
            GameManager.Instance.PLayer.GetComponent<PlayerMovement>().enabled = false;
            //GameManager.Instance.PLayer.GetComponent<PlayerAttack>().enabled = false;

        }
        enemy = CheckEnemy(); // Kiểm tra kẻ địch gần nhất

        if (enemy != null && numOfAttacks > 0 && !PlayerMovement.instance.isMoving&&enemy.tag!="EnemyDie"&&CanAttack)
        {
            //CheckEnemy().transform.parent.Find("Canvas").Find("IsCheckEnemy").GetComponent<Image>().enabled = true;
            numOfAttacks = 0;
            Attack(enemy); // Tấn công kẻ địch
          
            
            Debug.Log("Kẻ địch gần, tấn công");
        }
    }

    public GameObject CheckEnemy()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Find all objects tagged "Enemy"
       
        GameObject closestEnemy = null; // Closest enemy
        float closestDistance = detectionRadius; // Initialize closest distance with detection radius

        foreach (GameObject enemy in enemies)
        {
            // Check if the enemy has a Collider component
            if (enemy.GetComponent<Collider>() != null)
            {
                float distance = Vector3.Distance(transform.Find("Armature").position, enemy.transform.position); // Calculate distance
                if (distance <= detectionRadius && distance < closestDistance)
                {
                    closestEnemy = enemy;
                    closestDistance = distance;
                }
            }
        }

        if (closestEnemy != null)
        {
            Debug.Log("Found the closest enemy with a collider");
        }

        return closestEnemy;

    }

    public void Attack(GameObject enemy)
    {
        
        if (weapon == null)
        {

            Debug.LogWarning("Vũ khí chưa được gán.");
            return;
        }
        if (enemy == null)
        {
            numOfAttacks = 1;
            return;
        }
        anim.SetFloat("attack", 1); // Play attack animation
        StartCoroutine(DelayedAttack(0.15f, enemy)); // T    ạo độ trễ khi tấn công
       
    }

    private IEnumerator WaitAttack()
    {
        yield return new WaitForSeconds(1f);
        CanAttack = true;
    }
    private IEnumerator DelayedAttack(float delay, GameObject enemy)
    {
        if (enemy == null)
        {
            Debug.LogWarning("Kẻ địch không còn tồn tại");
            numOfAttacks = 1;
            yield break;
        }

        enemyTarget = enemy.transform; // Lưu mục tiêu của kẻ địch

        Vector3 direction = (enemy.transform.position - weapon.position).normalized; // Hướng tấn công
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction); // Xoay để hướng về kẻ địch
        transform.rotation = lookRotation;

        // Bắt đầu thời gian trì hoãn trước khi tấn công
        float elapsedDelay = 0f;
        while (elapsedDelay < delay)
        {
            // Kiểm tra nếu nhân vật đang di chuyển trong thời gian chờ
            if (PlayerMovement.instance.isMoving)
            {
                Debug.Log("Tấn công bị hủy do nhân vật đang di chuyển");
                anim.SetFloat("attack", 0);
                anim.SetFloat("attackMoving", 1); // Đặt lại trạng thái hoạt ảnh tấn công

                numOfAttacks = 1; // Đặt lại số lần tấn công
                yield break; // Thoát khỏi coroutine
            }

            elapsedDelay += Time.deltaTime;
            yield return null;
        }

        // Kiểm tra lần cuối trước khi tấn công
        if (PlayerMovement.instance.isMoving)
        {
            Debug.Log("Tấn công bị hủy do nhân vật di chuyển ngay trước khi tấn công");
            anim.SetFloat("attack", 0);
            anim.SetFloat("attackMoving", 1); // Đặt lại trạng thái hoạt ảnh tấn công

            numOfAttacks = 1; // Đặt lại số lần tấn công
            yield break; // Thoát khỏi coroutine
        }

        // Thực hiện tấn công nếu mục tiêu vẫn còn tồn tại và không có tag "DieEnemy"
        if (enemy.transform != null && enemyTarget.tag != "DieEnemy")
        {
            PerformAttack(enemy.transform); // Thực hiện tấn công
        }
        else
        {
            numOfAttacks = 1;
            Debug.LogWarning("Mục tiêu kẻ địch không còn tồn tại");
        }
    }



    private void PerformAttack(Transform enemyTarget)
    {
        if (enemyTarget == null) return;

        // Lấy Rigidbody của Weapon
        Rigidbody weaponRb = weapon.GetComponent<Rigidbody>();
        if (weaponRb != null)
        {
            // Lưu lại vị trí và rotation ban đầu của vũ khí
            Vector3 localPosition = weapon.localPosition;
            Quaternion localRotation = weapon.localRotation;

            // Kiểm tra loại vũ khí
            string weaponType = weapon.gameObject.GetComponent<PlayerDameSender>().TypeWeapon;

            if (weaponType == "Hammer")
            {
                //if (enemyTarget == null)
                //{
                //    numOfAttacks = 1;
                //    Debug.Log("Mục tiêu kẻ địch null");
                //    return;
                //}
                localRotation = weapon.localRotation; // Lưu trữ góc quay hiện tại của vũ khí


                Vector3 direction = (enemyTarget.position - weapon.position).normalized;
                direction.y = 0.016f;



                if (weaponRb != null)
                {
                    localPosition = weapon.localPosition; // Lưu trữ vị trí hiện tại của vũ khí


                    weapon.parent = null; // Đặt parent của vũ khí thành null

                    weaponRb.isKinematic = false; // Đặt isKinematic của Rigidbody thành false
                    weaponRb.velocity = Vector3.zero; // Đặt vận tốc thành 0
                    weaponRb.angularVelocity = Vector3.zero; // Đặt vận tốc góc thành 0

                    float forceMagnitude = 0.7f; // Lực tác động lên vũ khí

                    float distance = detectionRadius; // Khoảng cách tấn công
                    float weaponSpeed = forceMagnitude; // Tốc độ vũ khí
                    timeToReturn = distance / weaponSpeed; // Tính thời gian trở về

                    weaponRb.AddForce(direction * forceMagnitude, ForceMode.Impulse); // Tác động lực lên vũ khí
                    weapon.gameObject.layer = LayerMask.NameToLayer("Default");

                    weapon.GetComponent<BoxCollider>().enabled = true;
                    Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                    weapon.rotation = targetRotation;
                    weapon.Rotate(-90, 0, 0);

                    StartCoroutine(RotateWeaponAroundYAxis(timeToReturn - 0.12f)); // Thực hiện quay quanh trục Y            weapon.transform.rotation = Quaternion.Euler(270, 0, 90); // Đặt rotation cho vũ khí

                    if (returnCoroutine != null)
                    {
                        StopCoroutine(returnCoroutine); // Dừng coroutine nếu đã chạy
                    }

                    //returnCoroutine = StartCoroutine(ReturnToParentAfterDelay(timeToReturn, localPosition, localRotation)); // Trở về vị trí ban đầu sau khoảng thời gian delay

                }
                StartCoroutine(WaitForAttackToEnd());
            }
            else if (weaponType == "Knife")
            {
                // Cấu hình và tấn công với Knife
                Vector3 direction = (enemyTarget.position - weapon.position).normalized;
                direction.y = 0.016f;

                weapon.parent = null;
                weapon.gameObject.GetComponent<PlayerDameSender>().checkTree = false;

                weaponRb.isKinematic = false;
                weaponRb.velocity = Vector3.zero;
                weaponRb.angularVelocity = Vector3.zero;

                float forceMagnitude = 0.7f;
                float distance = Vector3.Distance(weapon.position, enemyTarget.position);
                float weaponSpeed = forceMagnitude;
                timeToReturn = distance / weaponSpeed;

                weaponRb.AddForce(direction * forceMagnitude, ForceMode.Impulse);
                weapon.gameObject.layer = LayerMask.NameToLayer("Default");

                // Xoay vũ khí hướng về mục tiêu
                Quaternion targetRotation = Quaternion.LookRotation(-direction, Vector3.up);
                weapon.rotation = targetRotation;
                weapon.Rotate(90, 0, 0);

                weapon.GetComponent<BoxCollider>().enabled = true;
            }

            // Bắt đầu Coroutine để vũ khí quay về vị trí ban đầu sau khi tấn công
            StartCoroutine(ReturnToParentAfterDelay(timeToReturn, localPosition, localRotation));
        }
    }


    private IEnumerator WaitForAttackToEnd()
    {
        // Đợi cho đến khi animation "Attack" hoàn thành
        yield return new WaitForSeconds(2f);
        //anim.Play(""); // Chơi animation "Idle" sau khi animation "Attack" hoàn thành
    }


    public IEnumerator ReturnToParentAfterDelay(float delay, Vector3 originalPosition, Quaternion originalRotation)
    {

        if (isDead)
        {
            transform.GetComponent<Rigidbody>().isKinematic = true;
            weapon.GetComponent<Rigidbody>().isKinematic = true;
        }

        Rigidbody weaponRb = weapon.GetComponent<Rigidbody>();
        float elapsedTime = 0f;

        // Tạo bản sao của vũ khí

        // Xoá vũ khí gốc


        //while (elapsedTime < delay)
        //{
        //    bool ischeck = weaponClone.GetComponent<PlayerDameSender>().check; // Kiểm tra điều kiện
        while (elapsedTime < delay )
        {
            
            bool ischeck = weapon.GetComponent<PlayerDameSender>().check; // Kiểm tra điều kiện

            if (ischeck) // Nếu ischeck trở thành true, dừng coroutine
            {
                anim.SetFloat("attack", 0);
                //weaponRb.AddTorque(new Vector3(0, 0f, 0));
                weapon.parent = originalWeaponParent; // Gán lại parent ban đầu cho vũ khí
                weapon.localPosition = originalPosition; // Đặt lại vị trí ban đầu của vũ khí
                weapon.localRotation = originalRotation; // Đặt lại góc quay ban đầu của vũ khí
                weapon.GetComponent<BoxCollider>().enabled = false;
                weapon.gameObject.layer = LayerMask.NameToLayer("Playerr");
                IsRotate = false;
                // Tăng scale của vũ khí khi trở về
                if (GameManager.Instance.Mode!="ZombieCity")
                {
                       weapon.localScale *= 1.1f; // Tăng scale lên 10% theo cả 3 trục
                }
             



                if (weaponRb != null)
                {
                    weaponRb.isKinematic = true; // Đặt isKinematic của Rigidbody thành true
                }
                numOfAttacks = 1;
                weapon.GetComponent<PlayerDameSender>().check = false;
                // Lấy component Rigidbody của vũ khí
                CanAttack = false;
                StartCoroutine(WaitAttack());
                yield break;
            }

            elapsedTime += Time.deltaTime;
           
            yield return null;
        }

        GameObject weaponClone = Instantiate(weapon.gameObject, originalPosition, originalRotation);
        weaponClone.transform.parent = originalWeaponParent; // Gán parent ban đầu cho bản sao vũ khí

        Rigidbody weaponCloneRb = weaponClone.GetComponent<Rigidbody>();
        weaponClone.GetComponent<BoxCollider>().enabled = false;
        if (weaponCloneRb != null)
        {
            weaponCloneRb.isKinematic = false; // Đặt isKinematic của Rigidbody thành true
        }

        if (weaponClone != null)
        {
            weaponClone.transform.localPosition = originalPosition; // Đặt lại vị trí ban đầu của bản sao vũ khí
            weaponClone.transform.localRotation = originalRotation; // Đặt lại góc quay ban đầu của bản sao vũ khí
            IsRotate = false;
            // Tăng scale của bản sao vũ khí khi trở về
            //weaponClone.transform.localScale += new Vector3(1.1f, 1.1f, 1.1f);
            //yield return new WaitForSeconds(0.001f);
            Destroy(weapon.gameObject);
            weapon = weaponClone.transform;
            if (weaponCloneRb != null)
            {
                weaponCloneRb.isKinematic = true; // Đặt isKinematic của Rigidbody thành true
            }
            anim.SetFloat("attack", 0);
        }
        else
        {
            Debug.LogWarning("Vũ khí không còn tồn tại");
        }

        numOfAttacks = 1; // Đặt lại số lần tấn công
        CanAttack = false;
        StartCoroutine(WaitAttack());
    }

    private IEnumerator RotateWeaponAroundYAxis(float duration)
    {
        IsRotate = true;
        float elapsedTime = 0f;

        // Tính toán tổng số góc cần quay để hoàn thành 10 vòng (360 độ * 10 vòng)
        float totalRotation = 2*360f;

        // Tính toán tốc độ quay (góc quay mỗi giây)
        float rotationSpeed = totalRotation / duration;

        while (elapsedTime < duration && IsRotate)
        {
            // Quay vũ khí quanh trục Y (hoặc trục bạn muốn)
            weapon.Rotate(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);

            elapsedTime += Time.deltaTime;
            yield return null; // Đợi đến khung hình tiếp theo
        }

        // Đặt lại góc quay hoặc không, tùy vào yêu cầu của bạn
        IsRotate = false; // Dừng quay sau khi hoàn thành
    }



    Transform FindDeepChild(Transform parent, string name)
    {
        foreach (Transform child in parent) // Duyệt qua tất cả các con của parent
        {
            if (child.name == name) // Nếu tìm thấy đối tượng có tên là name
            {
                return child;
            }
            
            Transform found = FindDeepChild(child, name); // Tìm đối tượng có tên là name trong con của parent
            if (found != null)
            {
                return found;
            }
        }
        return null; // Trả về null nếu không tìm thấy
    }
}
