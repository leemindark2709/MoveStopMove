﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{   public static PlayerAttack instance;
    public Animator anim;
    public bool isDead=false;
    public bool End=false;

    public int numOfAttacks = 1; // Số lượng tấn công
    public float detectionRadius = 0.1f; // Bán kính phát hiện
    public Transform weapon; // Đối tượng vũ khí
   [SerializeField] public GameObject enemy; // Kẻ địch gần nhất
    private Transform originalWeaponParent; // Vị trí ban đầu của vũ khí
    public float timeToReturn; // Thời gian để vũ khí trở về
    public Transform enemyTarget; // Mục tiêu của kẻ địch
    public int NumOfDead;

    private Coroutine returnCoroutine; // Tham chiếu đến coroutine trở về

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        NumOfDead = 1;
        anim = GetComponent<Animator>(); // Lấy component Animator
        weapon = FindDeepChild(transform, "Hammer"); // Tìm đối tượng vũ khí "Hammer"
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
            weapon.GetComponent<Rigidbody>().isKinematic = true;
            transform.gameObject.GetComponent<PlayerAttack>().enabled=false;
            //transform.GetComponent<Rigidbody>().gameObject.SetActive(false);
            //transform.GetComponent<BoxCollider>().gameObject.SetActive(false);


        }
        if (isDead && NumOfDead==1)
        {
            GameManager.Instance.TouchToContinue.Find("Canvas").Find("PanelRank").Find("Top").GetComponent<TextMeshProUGUI>().text = "#"+(GameManager.Instance.counyEnemy+1).ToString();
            GameManager.Instance.EndGame = true;
            NumOfDead =0;
           
            //PlayerAttack.instance.End = false;
            anim.Play("Dead");
            //transform.gameObject.SetActive(false);
            GameManager.Instance.PLayer.Find("Armature").tag = "DeadPlayer";
            GameManager.Instance.PLayer.GetComponent<PlayerMovement>().enabled = false;
            GameManager.Instance.PLayer.GetComponent<PlayerAttack>().enabled = false;



        }
        enemy = CheckEnemy(); // Kiểm tra kẻ địch gần nhất

        if (enemy != null && numOfAttacks > 0 && !PlayerMovement.instance.isMoving)
        {
            //CheckEnemy().transform.parent.Find("Canvas").Find("IsCheckEnemy").GetComponent<Image>().enabled = true;
            Attack(enemy); // Tấn công kẻ địch
            Debug.Log("Kẻ địch gần, tấn công");
            numOfAttacks = 0; // Đặt lại số lượng tấn công sau khi tấn công
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

        StartCoroutine(DelayedAttack(0.2f, enemy)); // Tạo độ trễ khi tấn công
    }

    private IEnumerator DelayedAttack(float delay, GameObject enemy)
    {
        if (enemy == null)
        {
            Debug.LogWarning("Kẻ địch không còn tồn tại");
            numOfAttacks = 1;
            yield break;
        }

        enemyTarget = FindDeepChild(enemy.transform, "Armature"); // Tìm đối tượng "Armature" của kẻ địch
        if (enemyTarget == null)
        {
            Debug.LogWarning("Mục tiêu kẻ địch không còn tồn tại");
            numOfAttacks = 1;
            yield break;
        }

        Vector3 direction = (enemyTarget.position - transform.position).normalized; // Hướng tấn công
        Quaternion lookRotation = Quaternion.LookRotation(direction); // Góc quay để đối diện với kẻ địch
        float rotationSpeed = 2f; // Tốc độ quay
        float rotationProgress = 0f; // Tiến trình quay

        while (rotationProgress < 1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationProgress); // Quay dần dần
            rotationProgress += Time.deltaTime * rotationSpeed;
            yield return null;
        }
        anim.SetFloat("attack", 1); // Chơi animation tấn công
        yield return new WaitForSeconds(delay); // Đợi trong khoảng thời gian delay

        if (enemyTarget != null)
        {
            PerformAttack(enemyTarget); // Thực hiện tấn công
        }
        else
        {
            Debug.LogWarning("Mục tiêu kẻ địch không còn tồn tại");
            numOfAttacks = 1;
        }

        // Thực hiện kiểm tra liên tục trong 2 giây
        float elapsedTime = 0f;
        while (elapsedTime < 0.9f)
        {
            if (PlayerMovement.instance.isMoving)
            {
                anim.SetFloat("attackMoving", 1);
            }
            else
            {
                //anim.SetFloat("attack", 0.1f);
            }

            elapsedTime += Time.deltaTime;
            yield return null; // Đợi mỗi frame
        }

        anim.SetFloat("attack", 0); // Đặt lại animation khi hết 2 giây
    }


    private void PerformAttack(Transform enemyTarget)
    {
        if (enemyTarget == null)
        {
            numOfAttacks = 1;
            Debug.Log("Mục tiêu kẻ địch null");
            return;
        }
        Quaternion localRotation = weapon.localRotation; // Lưu trữ góc quay hiện tại của vũ khí

        Vector3 direction = (enemyTarget.position - weapon.position).normalized; // Hướng của vũ khí
        direction.y = 0; // Không thay đổi hướng dọc
        weapon.transform.rotation = Quaternion.Euler(0, 0, 90); // Đặt rotation cho vũ khí

        Rigidbody weaponRb = weapon.GetComponent<Rigidbody>(); // Lấy component Rigidbody của vũ khí
        if (weaponRb != null)
        {
            Vector3 localPosition = weapon.localPosition; // Lưu trữ vị trí hiện tại của vũ khí
         

            weapon.parent = null; // Đặt parent của vũ khí thành null

            weaponRb.isKinematic = false; // Đặt isKinematic của Rigidbody thành false
            weaponRb.velocity = Vector3.zero; // Đặt vận tốc thành 0
            weaponRb.angularVelocity = Vector3.zero; // Đặt vận tốc góc thành 0

            float forceMagnitude = 1.25f; // Lực tác động lên vũ khí
            weaponRb.AddForce(direction * forceMagnitude, ForceMode.Impulse); // Tác động lực lên vũ khí
            weaponRb.AddTorque(new Vector3(0, 1000000000000f, 0) );
            float distance = detectionRadius; // Khoảng cách tấn công
            float weaponSpeed = forceMagnitude; // Tốc độ vũ khí
            timeToReturn = distance / weaponSpeed; // Tính thời gian trở về

            if (returnCoroutine != null)
            {
                StopCoroutine(returnCoroutine); // Dừng coroutine nếu đã chạy
            }

            returnCoroutine = StartCoroutine(ReturnToParentAfterDelay(timeToReturn, localPosition, localRotation)); // Trở về vị trí ban đầu sau khoảng thời gian delay
            
        }
        StartCoroutine(WaitForAttackToEnd());
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

            weapon.GetComponent<Rigidbody>().isKinematic=true;
        }
        Rigidbody weaponRb = weapon.GetComponent<Rigidbody>();
        float elapsedTime = 0f;

        while (elapsedTime < delay)
        {
            bool ischeck = weapon.GetComponent<PlayerDameSender>().check; // Kiểm tra điều kiện

            if (ischeck) // Nếu ischeck trở thành true, dừng coroutine
            {
                //weaponRb.AddTorque(new Vector3(0, 0f, 0));
                weapon.parent = originalWeaponParent; // Gán lại parent ban đầu cho vũ khí
                weapon.localPosition = originalPosition; // Đặt lại vị trí ban đầu của vũ khí
                weapon.localRotation = originalRotation; // Đặt lại góc quay ban đầu của vũ khí

                // Tăng scale của vũ khí khi trở về
                weapon.localScale += new Vector3(2f, 2f, 2f);
                

                if (weaponRb != null)
                {
                    weaponRb.isKinematic = true; // Đặt isKinematic của Rigidbody thành true
                }
                numOfAttacks = 1;
                weapon.GetComponent<PlayerDameSender>().check = false;
               // Lấy component Rigidbody của vũ khí

                yield break;
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (weapon != null)
        {
            weapon.parent = originalWeaponParent; // Gán lại parent ban đầu cho vũ khí
            weapon.localPosition = originalPosition; // Đặt lại vị trí ban đầu của vũ khí
            weapon.localRotation = originalRotation; // Đặt lại góc quay ban đầu của vũ khí

            // Tăng scale của vũ khí khi trở về
            weapon.localScale += new Vector3(2f, 2f, 2f);

            // Lấy component Rigidbody của vũ khí
            if (weaponRb != null)
            {
                weaponRb.isKinematic = true; // Đặt isKinematic của Rigidbody thành true
            }
        }
        else
        {
            Debug.LogWarning("Vũ khí không còn tồn tại");
        }

        numOfAttacks = 1; // Đặt lại số lần tấn công
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
