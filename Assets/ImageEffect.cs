using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Để sử dụng IPointerDownHandler và IPointerUpHandler

public class ImageEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Image buttonImage;    // Hình ảnh cần thay đổi hiệu ứng
    private Color originalColor; // Màu sắc gốc của hình ảnh
    private Color pressedColor;  // Màu sắc khi nhấn nút

    void Start()
    {
        // Kiểm tra nếu hình ảnh đã được gán
        if (buttonImage != null)
        {
            // Lưu màu sắc gốc của hình ảnh
            originalColor = buttonImage.color;
            // Xác định màu sắc khi nhấn nút (màu tối hơn)
            pressedColor = originalColor * new Color(0.8f, 0.8f, 0.8f); // 80% của màu gốc
        }
        else
        {
            Debug.LogError("ButtonImage not assigned!");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Hiệu ứng khi nhấn giữ nút
        if (buttonImage != null)
        {
            buttonImage.color = pressedColor;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Khôi phục màu sắc khi nhả nút
        if (buttonImage != null)
        {
            buttonImage.color = originalColor;
        }
    }
}
