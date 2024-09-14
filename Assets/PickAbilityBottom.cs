using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PickAbilityBottom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Tham chiếu đến Image cần thay đổi màu sắc
    public Image imageAbility;

    // Màu sắc khi nhấn
    public Color pressedColor = Color.red;

    // Màu sắc mặc định (khi không nhấn)
    private Color originalColor;

    void Start()
    {
        if (imageAbility != null)
        {
            // Lưu lại giá trị màu sắc gốc
            originalColor = imageAbility.color;
        }
    }

    // Hàm sẽ được gọi khi nhấn chuột xuống
    public void OnPointerDown(PointerEventData eventData)
    {
        if (imageAbility != null)
        {
            // Đổi màu khi nhấn nút
            SetImageColor(pressedColor);
            Debug.Log("Button pressed! Image color changed.");
        }
    }

    // Hàm sẽ được gọi khi thả nút chuột
    public void OnPointerUp(PointerEventData eventData)
    {
        if (imageAbility != null)
        {
            // Trả lại màu ban đầu khi thả nút
            SetImageColor(originalColor);
            Debug.Log("Button released! Image color reset.");
        }
    }

    // Hàm để thay đổi màu của hình ảnh
    void SetImageColor(Color color)
    {
        imageAbility.color = color;
    }
}
