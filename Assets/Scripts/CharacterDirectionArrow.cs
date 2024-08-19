using UnityEngine;

public class CharacterDirectionArrow : MonoBehaviour
{
    public Transform character; // Nhân vật cần chỉ hướng
    public Transform targetObject; // Đối tượng mà mũi tên sẽ chỉ về
    public RectTransform arrowUI; // UI của mũi tên trên Canvas
    public Canvas canvas; // Canvas chứa mũi tên

    void Update()
    {
        // Kiểm tra nếu đối tượng nằm ngoài màn hình
        Vector3 screenPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, targetObject.position);
        bool isOffScreen = screenPosition.x <= 0 || screenPosition.x >= Screen.width || screenPosition.y <= 0 || screenPosition.y >= Screen.height;

        // Nếu đối tượng nằm ngoài màn hình
        if (isOffScreen)
        {
            arrowUI.gameObject.SetActive(true);

            // Tính toán góc quay của mũi tên
            Vector3 direction = targetObject.position - character.position;
            direction.z = 0; // Chỉ sử dụng hai chiều x và y
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Đặt vị trí và góc quay của mũi tên trên Canvas
            arrowUI.position = screenPosition;
            arrowUI.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            // Ẩn mũi tên nếu đối tượng nằm trong màn hình
            arrowUI.gameObject.SetActive(false);
        }
    }
}
