using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform Circle;
    public static PlayerMovement instance;
    Vector2 movevector;
    public float moveSpeed = 1f;
    public bool isMoving = false;
    public float rotationSpeed = 30f; // Rotation speed of the character

    private Vector2 startPoint;
    private Vector2 direction;
    public bool isInteracting;

    private Vector3 canvasOffset; // Store the initial offset between Canvas and Armature

    public void Awake()
    {
        instance = this;

        // Calculate and store the initial offset between the Canvas and Armature
        Transform armature = transform.Find("Armature");
        Transform canvas = transform.Find("Canvas");

        if (armature != null && canvas != null)
        {
            canvasOffset = canvas.position - armature.position;
        }
    }

    void Update()
    {
        // Handle touch input for mobile devices
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Save the start position of the touch
                startPoint = touch.position;
                isInteracting = true;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Calculate movement direction based on drag distance
                direction = touch.position - startPoint;
                direction.Normalize();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // End the touch interaction
                isInteracting = false;
                direction = Vector2.zero;
            }
        }
        // Handle mouse input for desktop
        else if (Input.GetMouseButtonDown(0))
        {
            // Save the start position of the mouse click
            startPoint = Input.mousePosition;
            isInteracting = true;
        }
        else if (Input.GetMouseButton(0))
        {
            // Calculate movement direction based on drag distance
            direction = (Vector2)Input.mousePosition - startPoint;
            direction.Normalize();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // End the mouse interaction
            isInteracting = false;
            direction = Vector2.zero;
        }

        // Move the character based on touch or mouse input
        if (isInteracting||GameManager.Instance.Dead.GetComponent<Die>().Revive.GetComponent<ReviveNow>().isReviveNow)
        {
            Vector3 move = new Vector3(direction.x, 0, direction.y).normalized * moveSpeed * 0.5f * Time.deltaTime;

            // Move the Armature
            Transform armature = transform.Find("Armature");
            if (armature != null)
            {
                armature.position += move;
                //PlayerAttack.instance.CanAttack = true;

                // Move the Canvas to follow the Armature
                Transform canvas = transform.Find("Canvas");
                if (canvas != null)
                {
                    // Update Canvas position relative to Armature, maintaining the initial offset
                    canvas.position = armature.position + canvasOffset;
                }

                // Move the PlayerCamera to follow the Armature
                if (GameManager.Instance.PlayerCamera != null)
                {
                    GameManager.Instance.PlayerCamera.position = armature.position;
                }
            }

            // Update isMoving based on direction
            isMoving = direction.sqrMagnitude > 0;
        }
        else
        {
            isMoving = false; // No interaction, not moving
        }

        // Move using the input vector (if necessary, otherwise can be removed)
        Vector3 movement = new Vector3(movevector.x, 0f, movevector.y);
        movement.Normalize();

        if (isMoving)
        {
            transform.Translate(moveSpeed * movement * Time.deltaTime, Space.World);

            // Calculate direction and rotate the Armature
            Vector3 targetDirection = new Vector3(direction.x, 0, direction.y);
            if (targetDirection.sqrMagnitude > 0)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                Transform armature = transform.Find("Armature");
                if (armature != null)
                {
                    armature.rotation = Quaternion.Slerp(armature.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
            }
        }
    }

    // Set movevector directly based on touch/mouse input (if necessary)
    public void SetMoveVector(Vector2 input)
    {
        movevector = input;
    }

    // Method to stop movement directly
    public void StopMovement()
    {
        direction = Vector2.zero;
        movevector = Vector2.zero;
        isMoving = false;
    }
}
