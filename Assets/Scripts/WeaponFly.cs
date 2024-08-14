using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFly : MonoBehaviour
{
    public float Speed = 0.1f;
    private Transform targetEnemy;
    private Vector3 originalPosition; // Store the original position of the weapon

    void Start()
    {
        originalPosition = this.transform.position; // Save the initial position
    }

    void Update()
    {
        if (targetEnemy != null)
        {
            // Move the weapon towards the enemy
            transform.position = Vector3.MoveTowards(transform.position, targetEnemy.position, Speed * Time.deltaTime);

            // If the weapon reaches the enemy, start the coroutine to return it to the original position
            if (Vector3.Distance(transform.position, targetEnemy.position) < 0.1f)
            {
                StartCoroutine(ReturnToOriginalPosition());
            }
        }
    }

    // Method to set the target for the weapon
    public void SetTarget(Transform target)
    {
        targetEnemy = target;
    }

    // Coroutine to return the weapon to its original position after 1 second
    private IEnumerator ReturnToOriginalPosition()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second
        transform.position = Vector3.MoveTowards(transform.position, originalPosition, Speed * Time.deltaTime);

        // Reset the target to null to stop further movement towards the enemy
        targetEnemy = null;
    }
}
