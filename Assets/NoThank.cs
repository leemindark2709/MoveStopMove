using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoThank : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        GameManager.Instance.SpawnZombie();
        GameManager.Instance.SpawnZombie();
        GameManager.Instance.SpawnZombie();
        GameManager.Instance.Mode = "ZombieCity";
        GameManager.Instance.IsStartZomBie = true;
        GameManager.Instance.Home.GetComponent<Home>().ZombieModePanel.gameObject.SetActive(false);
        GameManager.Instance.Home.GetComponent<Home>().Coin.gameObject.SetActive(false);
        GameManager.Instance.Home.GetComponent<Home>().PauseZombie.gameObject.SetActive(true);
        foreach (Transform zombie in GameManager.Instance.Zombies)
        {
            //zombie.GetComponent<ZombieMoving>().zombieSpeed = 0.5f;
            //zombie.GetComponent<ZombirManager>().Walk();
            //zombie.GetComponent<ZombirManager>().Wait();        
        }
    }
}
