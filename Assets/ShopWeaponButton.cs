using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWeaponButton : MonoBehaviour
{
    //public Transform ShopWeapon = GameManager.Instance.ShopWeapon;
    public RectTransform NotPayUI;
    public RectTransform NotPayUI2Point;
    public RectTransform LeftHome;
    public RectTransform ShopWeapon;
    public RectTransform ShopWeaponDestination;
    private void Awake()
    {
        
    }
    private void Start()
    {
        NotPayUI = GameObject.Find("NOTPayADS").GetComponent<RectTransform>();
        NotPayUI2Point = GameObject.Find("NOTPayADS2").GetComponent<RectTransform>();
        LeftHome = GameObject.Find("Home").transform.Find("Canvas").Find("Left0").GetComponent<RectTransform>();
        ShopWeaponDestination =GameObject.Find("ShopWeaponPoint0").GetComponent<RectTransform>();
        ShopWeapon = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();
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
    public void OnButtonClick()
    {
        GameManager.Instance.PLayer.gameObject.SetActive(false);
        GameManager.Instance.checkShopWeapon = true;
        GameManager.Instance.ShopWeapon.gameObject.SetActive(true);
        if (GameManager.Instance.ShopWeapon.gameObject.activeSelf)
        {
            GameManager.Instance.ShopWeapon.GetComponent<RectTransform>().anchoredPosition =
                ShopWeaponDestination.anchoredPosition;
            StartCoroutine(MoveUI(NotPayUI, NotPayUI2Point.anchoredPosition, 0.1f));
            StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Left1").GetComponent<RectTransform>().anchoredPosition, 0.1f));
        }
        else
        {
              GameManager.Instance.ShopWeapon.gameObject.SetActive(true);
        
        // Start moving UI elements with animations
        StartCoroutine(MoveUI(NotPayUI, NotPayUI2Point.anchoredPosition, 0.1f));
        StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Left1").GetComponent<RectTransform>().anchoredPosition, 0.1f));
    }

        }
      
}
