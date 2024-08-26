using UnityEngine;
using UnityEngine.UI;

public class GetUIImageSize : MonoBehaviour
{
    public Image uiImage; // Kéo thả UI Image vào đây từ Inspector

    void Start()
    {
        if (uiImage != null)
        {
            RectTransform rectTransform = uiImage.GetComponent<RectTransform>();
            Vector2 size = rectTransform.sizeDelta;
            //Debug.Log("Width: " + size.x + ", Height: " + size.y);
        }
        else
        {
            //Debug.LogError("UI Image not assigned.");
        }
    }
}
