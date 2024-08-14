using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int numOfAttacks = 1;
    public float detectionRadius = 0.1f;
    public Transform weapon;
    private GameObject enemy;
    private Transform originalWeaponParent;
    public float timeToReturn;

    void Start()
    {
        weapon = FindDeepChild(this.transform, "Hammer");
        if (weapon == null)
        {
            //Debug.LogWarning("Không tìm thấy đối tượng vũ khí 'Hammer'.");
        }
        else
        {
            originalWeaponParent = weapon.parent;
        }
    }

    void Update()
    {
        enemy = CheckEnemy();
        if (enemy != null && numOfAttacks > 0)
        {
            Attack(enemy);
            Debug.Log("Kẻ địch gần, tấn công");
            numOfAttacks--;
        }
    }

    public GameObject CheckEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.Find("Armature").position, enemy.transform.position);
            if (distance <= detectionRadius)
            {
                Debug.Log("tìm thấy enemy");
                return enemy;
            }
        }
        return null;
    }

    public void Attack(GameObject enemy)
    {
        if (weapon == null)
        {
            Debug.LogWarning("Vũ khí chưa được gán.");
            return;
        }

        StartCoroutine(DelayedAttack(0.5f, enemy));
    }

    private IEnumerator DelayedAttack(float delay, GameObject enemy)
    {
        if (enemy != null)
        {
            Transform enemyTarget = FindDeepChild(enemy.transform, "Armature");
            if (enemyTarget != null)
            {
                Vector3 direction = (enemyTarget.position - transform.Find("Armature").position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                float rotationSpeed = 2f;
                float rotationProgress = 0f;

                while (rotationProgress < 1f)
                {
                    transform.Find("Armature").rotation = Quaternion.Slerp(transform.Find("Armature").rotation, lookRotation, rotationProgress);
                    rotationProgress += Time.deltaTime * rotationSpeed;
                    yield return null;
                }

                yield return new WaitForSeconds(delay);

                if (enemyTarget != null)
                {
                    PerformAttack(enemyTarget);
                }
            }
        }
    }

    private void PerformAttack(Transform enemyTarget)
    {
        if (enemyTarget == null)
        {
            Debug.Log("ENEMY target null");
            return;
        }

        Vector3 direction = (enemyTarget.position - weapon.position).normalized;
        direction.y = 0.016f;

        Rigidbody weaponRb = weapon.GetComponent<Rigidbody>();
        if (weaponRb != null)
        {
            Vector3 localPosition = weapon.localPosition;
            Quaternion localRotation = weapon.localRotation;

            weapon.parent = null;

            weaponRb.isKinematic = false;
            weaponRb.velocity = Vector3.zero;
            weaponRb.angularVelocity = Vector3.zero;

            float forceMagnitude = 1f;
            weaponRb.AddForce(direction * forceMagnitude, ForceMode.Impulse);

            float distance = Vector3.Distance(weapon.position, enemyTarget.position);
            float weaponSpeed = forceMagnitude;
            timeToReturn = distance / weaponSpeed;

            StartCoroutine(ReturnToParentAfterDelay(timeToReturn, localPosition, localRotation));
        }
    }

    private IEnumerator ReturnToParentAfterDelay(float delay, Vector3 originalPosition, Quaternion originalRotation)
    {
        yield return new WaitForSeconds(delay);

        weapon.parent = originalWeaponParent;
        weapon.localPosition = originalPosition;
        weapon.localRotation = originalRotation;

        Rigidbody weaponRb = weapon.GetComponent<Rigidbody>();
        if (weaponRb != null)
        {
            weaponRb.isKinematic = true;
        }

        numOfAttacks = 1;
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
