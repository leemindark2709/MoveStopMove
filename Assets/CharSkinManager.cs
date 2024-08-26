using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSkinManager : MonoBehaviour
{
    public Transform SelectHairItem;
    public Transform UnequipHairItem;
    public static CharSkinManager instance;
    private void Awake()
    {
        instance = this;   
    }
    private void Start()
    {
        SelectHairItem = GameObject.Find("SelectHairItem").transform;
        UnequipHairItem = GameObject.Find("UnequipHairItem").transform;
        UnequipHairItem.gameObject.SetActive(false);

    }
}
