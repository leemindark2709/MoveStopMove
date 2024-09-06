  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSkinManager : MonoBehaviour
{
    public Transform SelectHairItem;
    public Transform UnequipHairItem;
    public static CharSkinManager instance;
    public Transform ADSHairItem;
    public Transform GoldHairItem;
    private void Awake()
    {
        instance = this;    
    }
    private void Start()
    {
        //SelectHairItem = GameObject.Find("SelectHairItem").transform;
        ////UnequipHairItem = GameObject.Find("UnequipHairItem").transform;
        //ADSHairItem = GameObject.Find("ADSHairItem").transform;
        //GoldHairItem = GameObject.Find("GoldHairItem").transform;
        if (HairSkinManager.instance.IsHair != HairSkinManager.instance.HairItemPosition[4])
        {
            GoldHairItem.gameObject.SetActive(false);
            UnequipHairItem.gameObject.SetActive(true);
            ADSHairItem.gameObject.SetActive(false);
            SelectHairItem.gameObject.SetActive(false);
        }
        else
        {
            GoldHairItem.gameObject.SetActive(false);
            UnequipHairItem.gameObject.SetActive(false);
            ADSHairItem.gameObject.SetActive(false);
        }
    
    }
}
