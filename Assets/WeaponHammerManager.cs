using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHammerManager : MonoBehaviour
{
    public static WeaponHammerManager instance;
    public Transform EquipperTop;
    public Transform Equipper;
    public Transform ChoseCorlor;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        EquipperTop = transform.Find("EquipperTop").transform;
        Equipper = transform.Find("Equipper").transform;
        ChoseCorlor = transform.Find("ChoseColor").transform;
        EquipperTop.gameObject.SetActive(false);

    }
}
