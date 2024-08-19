using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform objectA; // Object A
    public Transform objectB; // Object B
    public Camera mainCamera; // Camera chính
    public float screenEdgePadding = 0.1f; // Khoảng cách từ viền màn hình

    void Update()
    {
        if (objectA == null || objectB == null || mainCamera == null) return;

        // Tính toán hướng từ object A đến object B trong mặt phẳng XZ
        Vector3 direction = objectB.position - objectA.position;
        direction.y = 0; // Bỏ qua thành phần Y để quay chỉ theo trục X và Z
        if (direction.magnitude > 0) // Đảm bảo không chia cho 0
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            Vector3 eulerAngles = targetRotation.eulerAngles;
            transform.rotation = Quaternion.Euler(eulerAngles.x, 0, eulerAngles.z);
        }

        Vector3 screenPoint = mainCamera.WorldToViewportPoint(objectA.position);

        if (screenPoint.z < 0) // Nếu object A ở phía sau camera
        {
            // Tính toán điểm viền màn hình gần nhất
            Vector3 edgePosition = GetScreenEdgePosition(screenPoint);
            transform.position = mainCamera.ViewportToWorldPoint(edgePosition);
        }
    }

    private Vector3 GetScreenEdgePosition(Vector3 screenPoint)
    {
        // Tính toán vị trí viền màn hình
        Vector3 edgePosition = new Vector3(
            Mathf.Clamp(screenPoint.x, screenEdgePadding, 1 - screenEdgePadding),
            Mathf.Clamp(screenPoint.y, screenEdgePadding, 1 - screenEdgePadding),
            0
        );
        return edgePosition;
    }
}
