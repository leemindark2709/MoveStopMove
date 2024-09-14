using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        GameManager.Instance.Home.GetComponent<Home>().AbilityBottomPanel.gameObject.SetActive(true);
        GameManager.Instance.Armature.tag = "Playerr";
        GameManager.Instance.Mode = "ZombieCity";
        GameManager.Instance.counyZombie = 10 + PlayerPrefs.GetInt("IsDay", 1);
        GameManager.Instance.NumZombieSpawn = 10 + PlayerPrefs.GetInt("IsDay", 1);
        GameManager.Instance.NumZomBieStart = 10 + PlayerPrefs.GetInt("IsDay", 1);
        GameManager.Instance.Home.GetComponent<Home>().ZombieMode.GetComponent<ZombieMode>().CountZombieAlive.GetComponent<TextMeshProUGUI>().text=GameManager.Instance.counyZombie.ToString();

       GameManager.Instance.Home.GetComponent<Home>().ZombieMode.GetComponent<ZombieMode>().Day.GetChild(0).GetComponent<TextMeshProUGUI>().text ="Day "+ PlayerPrefs.GetInt("IsDay", 1).ToString();
       PlayerPrefs.SetInt("IsDay", PlayerPrefs.GetInt("IsDay", 1));
        Debug.Log(PlayerPrefs.GetInt("IsDay",1));
        GameManager.Instance.Home.GetComponent<Home>().PauseZombie.gameObject.SetActive(false);
        //Vector3 armaturePosition = GameManager.Instance.Armature.position;
        //armaturePosition.y = 0.02675861f;
        //RectTransform circleRectTransform = GameManager.Instance.PLayer.GetComponent<PlayerMovement>().Circle.GetComponent<RectTransform>();
        //Vector2 anchoredPosition = circleRectTransform.anchoredPosition;
        //anchoredPosition.y = 0.227f;
        //circleRectTransform.anchoredPosition = anchoredPosition;


        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.z = -1.45f;
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.y = 1.19f;
        GameManager.Instance.TurnOnComponentPlayer();
        GameManager.Instance.PlayerCamera.position = new Vector3(0.001851806f, 0.6067587f, 2.240096f);
        GameManager.Instance.PLayer.Find("Canvas").localPosition = new Vector3(0.5004948f, 0.4117069f, -0.0002646446f);
        GameManager.Instance.PLayer.Find("Canvas").Find("Circle").GetComponent<RectTransform>().anchoredPosition = new Vector3(0.005999923f, 0.14f, -0.02399993f);

        GameManager.Instance.Dead.GetComponent<Die>().Revive.GetComponent<ReviveNow>().isReviveNow = true;
        GameObject.Find("Circle000").transform.position = GameManager.Instance.PLayer.Find("Canvas").Find("Circle").transform.position;
        GameManager.Instance.PLayer.Find("Canvas").Find("Circle").gameObject.SetActive(true);
        GameManager.Instance.Armature.GetComponent<PlayerAttack>().UIName.gameObject.SetActive(true); 
        GameManager.Instance.Home.GetComponent<Home>().GetRandomZombieCity().gameObject.SetActive(true);

        StartCoroutine(delayZombileMode());
        //Vector3 newPosition = GameManager.Instance.PLayer.transform.position;
        ////newPosition.y =0.58f;  // Tăng tọa độ y
        //GameManager.Instance.PLayer.transform.position = newPosition;  // Gán lại vị trí mới
        Vector3 armaturePosition = GameManager.Instance.Armature.localPosition;
        armaturePosition.y = 0.02675861f;  // Thay đổi chỉ giá trị trục y
        GameManager.Instance.Armature.localPosition = armaturePosition;  // Gán lại vị trí đã cập nhật
        GameManager.Instance.MainMap.gameObject.SetActive(false);
        GameManager.Instance.ZomBieMap.gameObject.SetActive(true);
        StartCoroutine(MoveUI(NotPayUI, NotPayUI2Point.anchoredPosition, 0.1f));
        StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Left1").GetComponent<RectTransform>().anchoredPosition, 0.1f));
        GameManager.Instance.PLayer.GetComponent<PlayerMovement>().enabled = false;
    }
    public IEnumerator delayZombileMode()
    {
        RectTransform Zombile = GameManager.Instance.Home.GetComponent<Home>().GetRandomZombieCity();
        Zombile.gameObject.SetActive(true);
        //Debug.Log("ve thoi");
        yield return new WaitForSeconds(2f); // Đợi 2 giây
        Debug.Log("Action performed after delay.");
        Zombile.gameObject.SetActive(false);
        GameManager.Instance.Home.GetComponent<ScreenFader>().FadeInAndOut();
        GameManager.Instance.ReturnPositionUIZombieModelmd();
        GameManager.Instance.Home.GetComponent<Home>().PanelStartZombileMode.gameObject.SetActive(true);
        GameManager.Instance.Home.GetComponent<Home>().PanelStartZombileMode.GetChild(0).gameObject.SetActive(true);
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
