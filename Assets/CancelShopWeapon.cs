using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelShopWeapon : MonoBehaviour
{
    public RectTransform NotPayUI;
    public RectTransform NotPayUI2Point;
    public RectTransform LeftHome;
    public RectTransform ShopWeapon;
    public RectTransform ShopWeaponDestination;
    private void Start()
    {
        NotPayUI = GameObject.Find("NOTPayADS").GetComponent<RectTransform>();
        NotPayUI2Point = GameObject.Find("NOTPayADS2").GetComponent<RectTransform>();
        LeftHome = GameObject.Find("Home").transform.Find("Canvas").Find("Left0").GetComponent<RectTransform>();
        ShopWeaponDestination = GameManager.Instance.ShopWeapon.Find("ShopWeaponPoint").GetComponent<RectTransform>();
        ShopWeapon  = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();

    }
    public void OnButtonClick()
    {
        GameManager.Instance.PLayer.gameObject.SetActive(true);
        GameManager.Instance.PLayer.gameObject.SetActive(true);
        GameManager.Instance.checkShopWeapon = false;
        ShopWeapon.anchoredPosition = ShopWeaponDestination.anchoredPosition;
        //GameManager.Instance.ShopWeapon.gameObject.SetActive(false);
        StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f));
        StartCoroutine(MoveUI(NotPayUI, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f)); 
    
    
    
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
