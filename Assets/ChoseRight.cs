using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseRight : MonoBehaviour
{
    public void OnButtonClick()
    {
        transform.parent.parent.GetComponent<ChoseLefftRight>().isChoseRight = true;
        transform.parent.parent.GetComponent<ChoseLefftRight>().isChoseLeft = false;
        transform.parent.parent.GetComponent<ChoseLefftRight>().ChoseLeft.parent.GetComponent<Image>().enabled = false;
        transform.parent.parent.GetComponent<ChoseLefftRight>().ChoseRight.parent.GetComponent<Image>().enabled = true;



    }
}
