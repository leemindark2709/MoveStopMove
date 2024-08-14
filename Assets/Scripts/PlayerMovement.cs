using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    Vector2 movevector;
    public float moveSpeed = 2f;
    public bool isMoving = false;
    public float rotationSpeed = 30f; // Tốc độ quay nhân vật

    public void Awake()
    {
        instance = this;
    }

    public void InPutPlayer(InputAction.CallbackContext _context)
    {
        movevector = _context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Vector3 movement = new Vector3(movevector.x, 0f, movevector.y);
        movement.Normalize();

        isMoving = movevector.sqrMagnitude > 0;

        transform.Translate(moveSpeed * movement * Time.deltaTime, Space.World);

        if (isMoving)
        {
            // Tính toán hướng di chuyển và xoay Armature theo trục Y
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            Transform armature = transform.Find("Armature");
            if (armature != null)
            {
                armature.rotation = Quaternion.Slerp(armature.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }

}
