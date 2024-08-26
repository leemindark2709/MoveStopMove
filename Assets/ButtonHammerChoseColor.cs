using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHammerChoseColor : MonoBehaviour
{
 public void OnButtonClick()
    {
        transform.parent.Find("ChoseColor").GetComponent<ChoseLefftRight>().returnChoseColorWeapon();
    }
}
