using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancel : MonoBehaviour
{
    public RectTransform NotPayUI;
    public RectTransform NotPayUI2Point;
    public RectTransform LeftHome;
    public RectTransform Panel;
    public RectTransform PanelDestination;
    private void Start()
    {
        NotPayUI = GameObject.Find("NOTPayADS").GetComponent<RectTransform>();
        NotPayUI2Point = GameObject.Find("NOTPayADS2").GetComponent<RectTransform>();
        LeftHome = GameObject.Find("Home").transform.Find("Canvas").Find("Left0").GetComponent<RectTransform>();
        Panel = GameManager.Instance.Shop.Find("Canvas").Find("Panel").GetComponent<RectTransform>();
        PanelDestination = GameManager.Instance.Shop.Find("Canvas").Find("PanelDestination").GetComponent<RectTransform>();

    }
    public void OnButtonClick()
    {

        Panel.anchoredPosition = PanelDestination.anchoredPosition;
        //Panel.sizeDelta = PanelDestination.sizeDelta;
        //Panel.pivot = PanelDestination.pivot;

        //GameManager.Instance.Shop.gameObject.SetActive(false);
        if (!GameManager.Instance.checkShopWeapon)
        {
            StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f));
            StartCoroutine(MoveUI(NotPayUI, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f));

        }
        else
        {
            GameManager.Instance.ShopWeapon.gameObject.SetActive(true);

            Panel.anchoredPosition = PanelDestination.anchoredPosition;
        }



    }
    private IEnumerator MoveUI(RectTransform uiElement, Vector2 targetPosition, float duration)
    {
        Vector2 startingPosition = uiElement.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Di chuyển từ từ từ điểm này đến điểm khác
            uiElement.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Chờ 1 frame trước khi tiếp tục
        }

        // Đảm bảo vị trí cuối cùng chính xác
        uiElement.anchoredPosition = targetPosition;
    }
}
