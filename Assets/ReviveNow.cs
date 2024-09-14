using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveNow : MonoBehaviour
{
    public bool isReviveNow=false;
    public Transform Player;

    private void Start()
    {
        Player = GameManager.Instance.PLayer; // Sửa tên 'PLayer' thành 'Player'
    }

    public void OnButtonClick()
    {
        isReviveNow = true;
        if (GameManager.Instance.Mode!="ZombieCity")
        {

            GameManager.Instance.ReturnPositionRankAndSettinglmd();
            // Khôi phục trạng thái của PlayerAttack
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

            // Đặt vị trí của nhân vật về điểm hồi sinh
            Player.Find("Armature").position = GameObject.Find("RevivePoint").transform.position;

            // Kích hoạt lại PlayerMovement và đảm bảo nhân vật không di chuyển
            var playerMovement = Player.GetComponent<PlayerMovement>();
            playerMovement.enabled = true;
            playerMovement.StopMovement(); // Gọi phương thức StopMovement để dừng di chuyển

            // Ẩn màn hình chạm để tiếp tục
            GameManager.Instance.TouchToContinue.gameObject.SetActive(false);
            GameManager.Instance.Dead.GetComponent<Die>().isClickButtonRevive = true;
            GameManager.Instance.EndGame = false;
            GameManager.Instance.numofSpawnDie = 1;
        }
        else
        {
            GameManager.Instance.ReturnPositionUIZombieModelmd();
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

            // Đặt vị trí của nhân vật về điểm hồi sinh
            Player.Find("Armature").position = GameObject.Find("RevivePoint").transform.position;

            // Kích hoạt lại PlayerMovement và đảm bảo nhân vật không di chuyển
            var playerMovement = Player.GetComponent<PlayerMovement>();
            playerMovement.enabled = true;
            playerMovement.StopMovement(); // Gọi phương thức StopMovement để dừng di chuyển

            // Ẩn màn hình chạm để tiếp tục
            GameManager.Instance.TouchToContinue.gameObject.SetActive(false);
            GameManager.Instance.Dead.GetComponent<Die>().isClickButtonRevive = true;
            GameManager.Instance.EndGame = false;
            GameManager.Instance.numofSpawnDie = 1;
            foreach (Transform ZomBie in GameManager.Instance.Zombies)
            {
                if (ZomBie != null)
                {
                    Destroy(ZomBie.gameObject);
                }

            }
            GameManager.Instance.IsStartZomBie = true;
            GameManager.Instance.NumZombieSpawn = GameManager.Instance.counyZombie;
            //GameManager.Instance.counyZombie = GameManager.Instance.numZombieAlive;

        }




    }
}
