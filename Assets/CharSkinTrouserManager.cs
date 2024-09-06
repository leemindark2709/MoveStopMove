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
        ADSTrousersItem = GameManager.Instance.TrousersSelectUnequip.Find("ADSTrousersItem").transform;
        GoldTrousersItem = GameManager.Instance.TrousersSelectUnequip.Find("GoldTrousersItem").transform;
    


        if (TrousersSkinManager.instance.IsTrousers != TrousersSkinManager.instance.materials[0])
        {

            UnequipTrousersItem.gameObject.SetActive(true);
            SelectTrousersItem.gameObject.SetActive(false);
            ADSTrousersItem.gameObject.SetActive(false);
            GoldTrousersItem.gameObject.SetActive(false);
        }
        else
        {
            UnequipTrousersItem.gameObject.SetActive(false);
            SelectTrousersItem.gameObject.SetActive(true);
            ADSTrousersItem.gameObject.SetActive(false);
            GoldTrousersItem.gameObject.SetActive(false);
        }
    }
}
