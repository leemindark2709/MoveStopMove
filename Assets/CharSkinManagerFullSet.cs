using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSkinManagerFullSet : MonoBehaviour
{
    public Transform SelectFullSetItem;
    public Transform UnequipFullSetItem;
    public static CharSkinManagerFullSet instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SelectFullSetItem = GameManager.Instance.FullSetSelectUnequip.Find("SelectFullSetItem").transform;
        UnequipFullSetItem = GameManager.Instance.FullSetSelectUnequip.Find("UnequipFullSetItem").transform;
        if (PlayerPrefs.GetString("IsFullSet","")=="NoneFullSet")
        {
            SelectFullSetItem.gameObject.SetActive(true);
            UnequipFullSetItem.gameObject.SetActive(false);
        }
        else
        {
            SelectFullSetItem.gameObject.SetActive(false);
            UnequipFullSetItem.gameObject.SetActive(true);
        }

        //UnequipFullSetItem.gameObject.SetActive(false);

    }
}
