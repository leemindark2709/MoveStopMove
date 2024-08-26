using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveNow : MonoBehaviour
{
    public Transform Player;

    private void Start()
    {
        Player = GameManager.Instance.PLayer; // Sửa tên 'PLayer' thành 'Player'
    }

    public void OnButtonClick()
    {
        // Khôi phục trạng thái của PlayerAttack
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
        Player.position = GameObject.Find("RevivePoint").transform.position;

        // Kích hoạt lại PlayerMovement và đảm bảo nhân vật không di chuyển
        var playerMovement = Player.GetComponent<PlayerMovement>();
        playerMovement.enabled = true;
        playerMovement.StopMovement(); // Gọi phương thức StopMovement để dừng di chuyển

        // Ẩn màn hình chạm để tiếp tục
        GameManager.Instance.TouchToContinue.gameObject.SetActive(false);
        GameManager.Instance.Dead.GetComponent<Die>().isClickButtonRevive = true;
        GameManager.Instance.EndGame = false;
        GameManager.Instance.numofSpawnDie = 1;

        StartCoroutine(Die.Instance.ReturnPositionRankAndSetting()); 


    }
}
