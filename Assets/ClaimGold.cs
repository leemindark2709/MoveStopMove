using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClaimGold : MonoBehaviour
{
    public Transform Player;
    public int isX3;
    private void Start()
    {
        Player = GameManager.Instance.PLayer; // Sửa tên 'PLayer' thành 'Player'
    }
    public void onButtonClick()
    {
        GameManager.Instance.Armature.Find("UiNamePoint").Find("UIPoint").Find("Point").GetComponent<TextMeshProUGUI>().text = 0.ToString();
        if (PlayerPrefs.GetString("Complete","Yes")=="Yes")
        {
            PlayerPrefs.SetInt("IsDay", PlayerPrefs.GetInt("IsDay", 1) + 1);
            PlayerPrefs.SetString("Complete", "No");
         
        }
        PlayerPrefs.SetInt("CountGold", (GameManager.Instance.Gold + (GameManager.Instance.NumZomBieStart - GameManager.Instance.counyZombie)*isX3));

        GameManager.Instance.IsStartZomBie=false;
        GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().enabled = true;
        GameManager.Instance.numofSpawnDie = 1;
        GameManager.Instance.EndGame = false;
        PlayerAttack.instance.NumOfDead = 1;
        PlayerAttack.instance.isDead = false;
        PlayerAttack.instance.End = false;
        Player.Find("Armature").tag = "Playerr";
        // Kích hoạt lại PlayerAttack trên Armature
        var playerAttack = Player.Find("Armature").GetComponent<PlayerAttack>();
        playerAttack.enabled = true;
        playerAttack.NumOfDead = 1;
        playerAttack.anim.Play("Idle");
        GameManager.Instance.Dead.GetComponent<Die>().isClickButtonRevive = true;
        GameManager.Instance.EndGame = false;
        GameManager.Instance.numofSpawnDie = 1;

        // Đặt vị trí của nhân vật về điểm hồi sinh



        // Kích hoạt lại PlayerMovement và đảm bảo nhân vật không di chuyển
        var playerMovement = Player.GetComponent<PlayerMovement>();
        GameManager.Instance.PLayer.GetComponent<PlayerMovement>().enabled = true;
        playerMovement.StopMovement(); // Gọi phương thức StopMovement để dừng di chuyển
        Player.Find("Armature").position = GameManager.Instance.PositionZombie0.position;
        Player.Find("Armature").rotation = GameManager.Instance.PositionZombie0.rotation;
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.z = -1.45f;
        GameObject.Find("MainCamera").GetComponent<CameraFollow>().offset.y = 1.19f;
        Debug.Log("................???................");
        GameManager.Instance.PlayerCamera.position = new Vector3(0.001851806f, 0.6067587f, 2.240096f);
        //GameManager.Instance.PLayer.Find("Canvas").position = new Vector3(0.5004948f, 0.4117069f, 0);
        //GameManager.Instance.PLayer.Find("Canvas").position = new Vector3(0.5004948f, 0.4117069f, 0.000264883f);
        //GameManager.Instance.PLayer.Find("Canvas").Find("Circle").position = new Vector3(0.005999923f, 0.14f, -0.02399993f);
        GameManager.Instance.Dead.GetComponent<Die>().Revive.GetComponent<ReviveNow>().isReviveNow = true;
        // Ẩn màn hình chạm để tiếp tục
        GameManager.Instance.TouchToContinue.gameObject.SetActive(false);
        GameManager.Instance.Dead.GetComponent<Die>().isClickButtonRevive = true;
        GameManager.Instance.EndGame = false;
        GameManager.Instance.numofSpawnDie = 1;
        GameManager.Instance.Home.GetComponent<Home>().PauseZombie.gameObject.SetActive(false);
        GameManager.Instance.Home.GetComponent<Home>().Coin.gameObject.SetActive(true);
       
        
        //GameManager.Instance.counyZombie = GameManager.Instance.numZombieAlive;
        for (int i = GameManager.Instance.Zombies.Count - 1; i >= 0; i--)
        {
            Transform Zombie = GameManager.Instance.Zombies[i];
            if (Zombie != null)
            {
                Destroy(Zombie.gameObject);
                GameManager.Instance.Zombies.RemoveAt(i); // Xóa Zombie khỏi danh sách
            }
        }
        GameManager.Instance.counyZombie = 10 + PlayerPrefs.GetInt("IsDay", 1);
        GameManager.Instance.NumZombieSpawn = 10 + PlayerPrefs.GetInt("IsDay", 1);
        GameManager.Instance.NumZomBieStart = 10 + PlayerPrefs.GetInt("IsDay", 1);
        
        GameManager.Instance.Home.GetComponent<Home>().ZombieMode.GetComponent<ZombieMode>().CountZombieAlive.GetComponent<TextMeshProUGUI>().text =
                GameManager.Instance.counyZombie.ToString();

        Debug.Log("alo");
        GameManager.Instance.Home.GetComponent<Home>().GetRandomZombieCity().gameObject.SetActive(true);
        GameManager.Instance.MovePositionUIZombieModelmd();
        StartCoroutine(wait011s());
        //StartCoroutine( GameManager.Instance.Home.GetComponent<Home>().ButtonZombieMode.GetComponent<ZombieCity>().delayZombileMode());
        StartCoroutine(wait3s());

    }
    public IEnumerator wait3s()
    {

        yield return new WaitForSeconds(3f);
        GameManager.Instance.Home.GetComponent<Home>().GetRandomZombieCity().gameObject.SetActive(false);
        GameManager.Instance.ReturnPositionUIZombieModelmd();
        GameManager.Instance.IsStartZomBie = false;
        GameManager.Instance.Home.GetComponent<ScreenFader>().FadeInAndOut();
        GameManager.Instance.Home.GetComponent<Home>().PanelStartZombileMode.GetComponent<ZombieMode>().Panel.gameObject.SetActive(true);

        GameManager.Instance.Armature.GetComponent<PlayerAttack>().NumOfDead = 1;
        //GameManager.Instance.Dead.GetComponent<Die>().CountdownCoroutine();
        GameManager.Instance.NumOfRevice = 2;
        GameManager.Instance.Home.GetComponent<Home>().PanelEndGameZombie.gameObject.SetActive(false);
        GameManager.Instance.Home.GetComponent<Home>().PanelWinGameZombie.gameObject.SetActive(false);

    }
    public IEnumerator wait011s()
    {

        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.PLayer.GetComponent<PlayerMovement>().enabled = false;
    }

}
