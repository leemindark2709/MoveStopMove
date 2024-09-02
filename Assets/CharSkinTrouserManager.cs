using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSkinTrouserManager : MonoBehaviour
{
    public Transform SelectTrousersItem;
    public Transform UnequipTrousersItem;
    public static CharSkinTrouserManager instance;
    public Transform ADSTrousersItem;
    public Transform GoldTrousersItem;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SelectTrousersItem = GameManager.Instance.TrousersSelectUnequip.Find("SelectTrousers").transform;
        UnequipTrousersItem = GameManager.Instance.TrousersSelectUnequip.Find("UnequipTrousers").transform;
        UnequipTrousersItem.gameObject.SetActive(false);

    }
}
