using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCity : MonoBehaviour
{
 public void OnButtonClick()
    {
        GameManager.Instance.MainMap.gameObject.SetActive(false);
        GameManager.Instance.ZomBieMap.gameObject.SetActive(true);
    }
}
