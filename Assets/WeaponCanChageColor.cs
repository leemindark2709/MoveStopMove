using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCanChageColor : MonoBehaviour
{
    public Transform MainWeaponHammer;
    public Transform leftColor;
    public Transform rightColor;

    private void Start()
    {

    }
    private void Update()
    {
        //newWeapon.GetComponent<MeshRenderer>().sharedMaterials[0].color = Corlor.GetComponent<ChoseCorlorWeapon>().color;

        transform.GetComponent<MeshRenderer>().sharedMaterials[0].color = leftColor.GetComponent<Image>().color;
        transform.GetComponent<MeshRenderer>().sharedMaterials[1].color = rightColor.GetComponent<Image>().color;
    }
}