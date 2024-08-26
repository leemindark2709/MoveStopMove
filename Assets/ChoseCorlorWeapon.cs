using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseCorlorWeapon : MonoBehaviour
{
    public Color color;
   
    private void Start()
    {
        color = transform.GetComponent<Image>().color;

        
    }
    public void OnButtonClick()
    {
        if (transform.parent.GetComponent<ChoseLefftRight>().isChoseLeft) {
            transform.parent.GetComponent<ChoseLefftRight>().ChoseLeft.GetComponent<Image>().color= color;
        }
        else if(transform.parent.GetComponent<ChoseLefftRight>().isChoseRight)
        {
            transform.parent.GetComponent<ChoseLefftRight>().ChoseRight.GetComponent<Image>().color = color;
        }

    }


}
