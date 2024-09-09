using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCity : MonoBehaviour
{


    public RectTransform NotPayUI;
    public RectTransform NotPayUI2Point;
    public RectTransform LeftHome;
    //public RectTransform Panel;

    private void Start()
    {

        NotPayUI = GameObject.Find("NOTPayADS").GetComponent<RectTransform>();
        NotPayUI2Point = GameObject.Find("NOTPayADS2").GetComponent<RectTransform>();
        LeftHome = GameObject.Find("Home").transform.Find("Canvas").Find("Left0").GetComponent<RectTransform>();
        //Panel = GameManager.Instance.Shop.Find("Canvas").Find("Panel").GetComponent<RectTransform>();
        //StartingPointPanel = GameManager.Instance.Shop.Find("Canvas").Find("StartingPointPanel").GetComponent<RectTransform>();
    }

    public RectTransform StartingPointPanel;
    public void OnButtonClick()
    {
        
        GameManager.Instance.Home.GetComponent<Home>().PauseZombie.gameObject.SetActive(false);

        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.z = -1.45f;
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.y = 1.19f;
        GameManager.Instance.TurnOnComponentPlayer();
        GameManager.Instance.Home.GetComponent<Home>().GetRandomZombieCity().gameObject.SetActive(true);

        StartCoroutine(delayZombileMode());
        Vector3 newPosition = GameManager.Instance.PLayer.transform.position;
        newPosition.y =0.58f;  // Tăng tọa độ y
        GameManager.Instance.PLayer.transform.position = newPosition;  // Gán lại vị trí mới

        GameManager.Instance.MainMap.gameObject.SetActive(false);
        GameManager.Instance.ZomBieMap.gameObject.SetActive(true);
        StartCoroutine(MoveUI(NotPayUI, NotPayUI2Point.anchoredPosition, 0.1f));
        StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Left1").GetComponent<RectTransform>().anchoredPosition, 0.1f));

    }
    public IEnumerator delayZombileMode()
    {
        RectTransform Zombile = GameManager.Instance.Home.GetComponent<Home>().GetRandomZombieCity();
        Zombile.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f); // Đợi 2 giây
        Debug.Log("Action performed after delay.");
        Zombile.gameObject.SetActive(false);
        GameManager.Instance.Home.GetComponent<ScreenFader>().FadeInAndOut();
        GameManager.Instance.Home.GetComponent<Home>().PanelStartZombileMode.gameObject.SetActive(true);
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
