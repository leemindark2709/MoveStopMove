using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeapon : MonoBehaviour
{
    public Transform MainWeaponHammer;
    public string TypeWeapon;
    private void Start()
    {
       
    }
    private void Update()
    {
        //MainWeaponHammer = GameManager.Instance.ShopWeapon.GetChild(1).Find("MainWeapon");
        //MeshRenderer weaponRenderer = transform.GetComponent<MeshRenderer>();

        //// Lấy MeshRenderer của MainWeaponHammer
        //MeshRenderer hammerRenderer2 = MainWeaponHammer.GetComponent<MeshRenderer>();

        //if (weaponRenderer != null && hammerRenderer2 != null)
        //{
        //    // Gán toàn bộ các materials từ hammerRenderer sang weaponRenderer
        //    weaponRenderer.materials = hammerRenderer2.materials;
        //}
    }
}
