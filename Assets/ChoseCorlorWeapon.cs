using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseCorlorWeapon : MonoBehaviour
{
    public Color color;
    public string  NameColor;
   
    public void Awake()
    {
        color = transform.GetComponent<Image>().color;
        if (PlayerPrefs.GetString("HammerLeftColor", "Red")== NameColor)
        {
            transform.parent.GetComponent<ChoseLefftRight>().ChoseLeft.GetComponent<Image>().color = color;
        }
        if(PlayerPrefs.GetString("HammerRightColor", "Red") == NameColor)
        {
            transform.parent.GetComponent<ChoseLefftRight>().ChoseRight.GetComponent<Image>().color = color;
        }
        //Debug.Log(PlayerPrefs.GetString("HammerLeftColor", "Red"));
        //Debug.Log(PlayerPrefs.GetString("HammerRightColor", "Red"));

        
    }
    public void OnButtonClick()
    {
       
        if (transform.parent.GetComponent<ChoseLefftRight>().isChoseLeft) {
            transform.parent.GetComponent<ChoseLefftRight>().ChoseLeft.GetComponent<Image>().color= color;
            PlayerPrefs.SetString("HammerLeftColor", NameColor);
            PlayerPrefs.Save();
        }
        else if(transform.parent.GetComponent<ChoseLefftRight>().isChoseRight)
        {
            PlayerPrefs.SetString("HammerRightColor", NameColor);
            PlayerPrefs.Save();
            transform.parent.GetComponent<ChoseLefftRight>().ChoseRight.GetComponent<Image>().color = color;
        }

    }


}
