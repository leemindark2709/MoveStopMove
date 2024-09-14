using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomeZombieButton : MonoBehaviour
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
        //Panel.anchoredPosition = PanelDestination.anchoredPosition;
        //Panel.sizeDelta = PanelDestination.sizeDelta;
        //Panel.pivot = PanelDestination.pivot;

        //GameManager.Instance.Shop.gameObject.SetActive(false);
        //if (!GameManager.Instance.checkShopWeapon)
        //{

        GameManager.Instance.IsStartZomBie = false;
        GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().enabled = true;
        GameManager.Instance.numofSpawnDie = 1;
        GameManager.Instance.EndGame = false;
        PlayerAttack.instance.NumOfDead = 1;
        PlayerAttack.instance.isDead = false;
        PlayerAttack.instance.End = false;
       GameManager.Instance.Armature.tag = "Playerr";
        // Kích hoạt lại PlayerAttack trên Armature
        GameManager.Instance.Dead.GetComponent<Die>().isClickButtonRevive = true;
        var playerAttack = GameManager.Instance.Armature.GetComponent<PlayerAttack>();
        playerAttack.enabled = true;
        playerAttack.NumOfDead = 1;
        playerAttack.anim.Play("Idle");
        foreach (Transform ZomBie in GameManager.Instance.Zombies)
        {
            if (ZomBie != null)
            {
                Destroy(ZomBie.gameObject);
            }

        }
        StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f));
            StartCoroutine(MoveUI(NotPayUI, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f));

        //}
        //else
        //{
        //    GameManager.Instance.ShopWeapon.gameObject.SetActive(true);

        //    Panel.anchoredPosition = PanelDestination.anchoredPosition;
        //}
        GameManager.Instance.PLayer.GetComponent<PlayerMovement>().isMoving = false;
        GameManager.Instance.PLayer.GetComponent<PlayerMovement>().enabled = false;
        GameManager.Instance.Armature.tag = "Playerr";
      
        GameManager.Instance.MainMap.gameObject.SetActive(true);
        GameManager.Instance.ZomBieMap.gameObject.SetActive(false);
        GameManager.Instance.Armature.Find("UiNamePoint").Find("UIPoint").Find("Point").GetComponent<TextMeshProUGUI>().text = 0.ToString();
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.z = -0.6f;
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.y = 0.36f;
        
        GameManager.Instance.Mode = "MainMode";
        GameManager.Instance.NumOfRevice = 2;
        //GameManager.Instance.TurnOnComponentPlayer();
        GameManager.Instance.PlayerCamera.position = new Vector3(0f, 0.58f, 2.24f);
        GameManager.Instance.PLayer.Find("Canvas").Find("Circle").gameObject.SetActive(false);
        GameManager.Instance.Armature.GetComponent<PlayerAttack>().UIName.gameObject.SetActive(false);
        StartCoroutine(GameManager.Instance.Home.GetComponent<Home>().ButtonZombieMode.GetComponent<ZombieCity>().delayZombileMode());

        StartCoroutine(Wait3s());
        GameManager.Instance.Armature.GetComponent<PlayerAttack>().anim.Play("Idle");


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
    public IEnumerator Wait3s()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.Armature.GetComponent<PlayerAttack>().anim.SetFloat("moving", 0);
     
        GameManager.Instance.Home.GetComponent<Home>().PanelWinGameZombie.gameObject.SetActive(false);
        GameManager.Instance.Home.GetComponent<Home>().PanelEndGameZombie.gameObject.SetActive(false);
        GameManager.Instance.Home.GetComponent<Home>().Coin.gameObject.SetActive(true);
       
        GameManager.Instance.Armature.localPosition = GameManager.Instance.StartPoint.transform.localPosition;
        GameManager.Instance.Armature.localRotation = GameManager.Instance.StartPoint.transform.localRotation;
        GameManager.Instance.Home.GetComponent<Home>().ZombieMode.gameObject.SetActive(false);
       
    }

}
