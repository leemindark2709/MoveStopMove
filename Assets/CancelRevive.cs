using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelRevive : MonoBehaviour
{
    // Start is called before the first frame update
  public void OnButtonClick()
    {
        if (GameManager.Instance.Mode!="ZombieCity")
        {
            GameManager.Instance.numofSpawnDie = 0;
            GameManager.Instance.numofSpawnDie = 0;
            GameManager.Instance.Dead.gameObject.SetActive(false);
            GameManager.Instance.TouchToContinue.gameObject.SetActive(true);
        }
        else
        {
            GameManager.Instance.numofSpawnDie = 0;
            GameManager.Instance.numofSpawnDie = 0;
            GameManager.Instance.Dead.gameObject.SetActive(false);
            GameManager.Instance.Home.GetComponent<Home>().PanelEndGameZombie.gameObject.SetActive(true);
        }
    }
}
