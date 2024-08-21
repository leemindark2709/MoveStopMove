using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonSettingInGame : MonoBehaviour
{
    // Start is called before the first frame update
   public void  OnButtonClick()
    {
        GameManager.Instance.PLayer.GetComponent<PlayerMovement>().enabled = false;
        StartCoroutine(Die.Instance.MoveRankAndSetting());
        GameManager.Instance.SettingTouch.gameObject.SetActive(true);

    }
}
