using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListWeapon : MonoBehaviour
{
  public List<Transform> ListWeapons = new List<Transform>();


    public void EnableAllPanel() {
        foreach (Transform item in ListWeapons)
        {

            item.Find("BorderWeapon").gameObject.SetActive(false);
        }
    }
}
