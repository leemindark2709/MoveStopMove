using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public GameObject panel; // Kéo và thả Panel vào đây từ Inspector
    public float fadeDuration = 2f; // Thời gian để hoàn tất hiệu ứng sáng lên

    private Image panelImage;

    void Start()
    {
        // Lấy component Image từ Panel
        panelImage = panel.GetComponent<Image>();

        // Đảm bảo panel bắt đầu với độ trong suốt là 0 và tắt đi
        Color color = panelImage.color;
        color.a = 0f;
        panelImage.color = color;
        panel.SetActive(false);
    }

    // Phương thức để bật Panel và thực hiện hiệu ứng sáng lên
    public void FadeInAndOut()
    {
        StartCoroutine(FadeInOutCoroutine());
    }

    IEnumerator FadeInOutCoroutine()
    {
        // Kích hoạt Panel
        panel.SetActive(true);

        Color color = panelImage.color;
        float elapsedTime = 0f;

        // Đảm bảo rằng màu bắt đầu là đen và độ trong suốt là 1
        color.a = 1f;
        panelImage.color = color;

        // Làm sáng lên từ từ
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            panelImage.color = color;

            yield return null;
        }

        // Đảm bảo rằng độ trong suốt là 0 khi kết thúc
        color.a = 0f;
        panelImage.color = color;

        // Tắt Panel sau khi hiệu ứng hoàn tất
        panel.SetActive(false);
    }
}
