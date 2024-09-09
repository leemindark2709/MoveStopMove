using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelReadyGoZombie : MonoBehaviour
{
    public Transform NumberGo;

    private void OnEnable()
    {
        NumberGo.GetComponent<TextMeshProUGUI>().text ="3";
        int i = 2;
        while (i>0)
        {
            if (i==1)
            {
                NumberGo.GetComponent<TextMeshProUGUI>().text = "Go";
            }
            i--;
        }
         
    }

}
