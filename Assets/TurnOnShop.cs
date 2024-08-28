using System.Collections;
using UnityEngine;

public class TurnOnShop : MonoBehaviour
{
    public static TurnOnShop instance;
    public RectTransform NotPayUI;
    public RectTransform NotPayUI2Point;
    public RectTransform LeftHome;
    public RectTransform Panel;
  

    public RectTransform StartingPointPanel;
    private void Awake()
    {
       instance = this;
    }
    private void Start()
    {
       
        NotPayUI = GameObject.Find("NOTPayADS").GetComponent<RectTransform>();
        NotPayUI2Point = GameObject.Find("NOTPayADS2").GetComponent<RectTransform>();
        LeftHome = GameObject.Find("Home").transform.Find("Canvas").Find("Left0").GetComponent<RectTransform>();
        Panel = GameManager.Instance.Shop.Find("Canvas").Find("Panel").GetComponent<RectTransform>();
        StartingPointPanel = GameManager.Instance.Shop.Find("Canvas").Find("StartingPointPanel").GetComponent<RectTransform>();
    }

    public void OnButtonClick()
    {
        // Move Panel to the starting position
        
        if (GameManager.Instance.ShopWeapon.gameObject.activeSelf)
        {
           
            GameManager.Instance.Shop.gameObject.SetActive(true);
            GameManager.Instance.ShopWeapon.gameObject.SetActive(false);

        }
        if (!GameManager.Instance.ShopWeapon.gameObject.activeSelf)
        {
            Panel.anchoredPosition = StartingPointPanel.anchoredPosition;
            // Ensure the Shop panel is active
            GameManager.Instance.Shop.gameObject.SetActive(true);
            // Start moving UI elements with animations
            StartCoroutine(MoveUI(NotPayUI, NotPayUI2Point.anchoredPosition, 0.1f));
            StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Left1").GetComponent<RectTransform>().anchoredPosition, 0.1f));

        }

    }

    private IEnumerator MoveUI(RectTransform uiElement, Vector2 targetPosition, float duration)
    {
        Vector2 startingPosition = uiElement.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Smoothly move the UI element from start to target position
            uiElement.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final position is set accurately
        uiElement.anchoredPosition = targetPosition;
    }
}
