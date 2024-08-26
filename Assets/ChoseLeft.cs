using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class ChoseLeft : MonoBehaviour
{
    // Start is called before the first frame update
  public void OnButtonClick()
    {
        transform.parent.parent.GetComponent<ChoseLefftRight>().isChoseLeft = true;
        transform.parent.parent.GetComponent<ChoseLefftRight>().isChoseRight = false;
        transform.parent.parent.GetComponent<ChoseLefftRight>().ChoseRight.parent.GetComponent<Image>().enabled = false;
        transform.parent.parent.GetComponent<ChoseLefftRight>().ChoseLeft.parent.GetComponent<Image>().enabled = true;

    }
}
