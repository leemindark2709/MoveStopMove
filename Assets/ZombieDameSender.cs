using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDameSender : MonoBehaviour
{
    public Transform Player;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Playerr")) // Sử dụng CompareTag thay vì so sánh trực tiếp
        {
            Player = collision.transform;
            Debug.Log("Va chạm với Player");
            collision.gameObject.GetComponent<PlayerAttack>().anim.Play("Dead");
            collision.gameObject.GetComponent<PlayerAttack>().isDead = true;
            collision.gameObject.GetComponent<PlayerAttack>().End = true;
            foreach (Transform ZomBie in GameManager.Instance.Zombies)
            {
                if (ZomBie != null)
                {
                    //GameManager.Instance.Armature.GetComponent<PlayerAttack>().enabled = false;
                    GameManager.Instance.PLayer.GetComponent<PlayerMovement>().enabled = false;
                    ZomBie.GetComponent<ZombirManager>().anim.Play("Win");
                    ZomBie.GetComponent<ZombieMoving>().zombieSpeed = 0;
                    GameManager.Instance.IsStartZomBie = false;
                }
            }
        }
        else
        {
            //Debug.Log("Va chạm với đối tượng khác");
        }
    }
}

