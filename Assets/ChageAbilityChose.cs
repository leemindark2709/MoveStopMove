using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageAbilityChose : MonoBehaviour
{
    public void OnButtonClick()
    {
        GameManager.Instance.Home.GetComponent<Home>().ZombieMode.GetComponent<ZombieMode>().ExchangeAbility();
    }
}
