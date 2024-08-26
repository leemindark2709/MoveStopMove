using UnityEngine;

public class TouchMove : MonoBehaviour
{
    public float moveSpeed = 1.3f; // Tốc độ di chuyển của nhân vật
    private Vector2 startPoint;
    private Vector2 direction;
    private bool isInteracting;

    void Update()
    {
        // Kiểm tra nếu đang sử dụng cảm ứng trên thiết bị di động
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Lưu vị trí bắt đầu của lần chạm
                startPoint = touch.position;
                isInteracting = true;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Tính toán hướng di chuyển dựa trên khoảng cách kéo
                direction = touch.position - startPoint;
                direction.Normalize();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // Ngừng chạm, reset giá trị
                isInteracting = false;
                direction = Vector2.zero;
            }
        }

        // Kiểm tra nếu đang sử dụng chuột trên máy tính
        if (Input.GetMouseButtonDown(0))
        {
            // Lưu vị trí bắt đầu của lần nhấp chuột
            startPoint = Input.mousePosition;
            isInteracting = true;
        }
        else if (Input.GetMouseButton(0))
        {
            // Tính toán hướng di chuyển dựa trên khoảng cách kéo chuột
            direction = (Vector2)Input.mousePosition - startPoint;
            direction.Normalize();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Ngừng nhấp chuột, reset giá trị
            isInteracting = false;
            direction = Vector2.zero;
        }

        // Di chuyển nhân vật
        if (isInteracting)
        {
            Vector3 move = new Vector3(direction.x, 0, direction.y);
            transform.position += move * moveSpeed * Time.deltaTime;
        }
    }
}
