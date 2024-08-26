using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSkinManagerShield : MonoBehaviour
{
    public Transform SelectShieldItem;
    public Transform UnequipShieldItem;
    public static CharSkinManagerShield instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SelectShieldItem =  GameManager.Instance.ShieldSelectUnequip.Find("SelectShieldItem").transform;
        UnequipShieldItem =  GameManager.Instance.ShieldSelectUnequip.Find("UnequipShieldItem").transform;
        UnequipShieldItem.gameObject.SetActive(false);

    }
}
