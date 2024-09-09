using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ButtonRightWeapon : MonoBehaviour
{
    // Start is called before the first frame update
   public void OnButtonClick()
    {
        int index = 0;
        
        for (int i = 0; i < 4; i++)
        {
            if (GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[i].GetComponent<ButtonPickWeapon>().Weapon.GetComponent<PlayerDameSender>().NameWeapon
                ==PlayerPrefs.GetString("Weapon","Hammer"))
            {
                index = 1;
                GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().EnableAllPanel();
                GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[i].Find("BorderWeapon").gameObject.SetActive(true);
            }

        }
        Debug.Log(index);
        if (index==0)
        {
            GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[0].Find("BorderWeapon").gameObject.SetActive(true);

        }
        if (PlayerPrefs.GetString("TypeWeapon", "Hammer") == "Knife")
        {
            RectTransform shopWeaponRect = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();

            RectTransform ShopWeaponPoint = GameObject.Find("ShopWeaponPoint0").GetComponent<RectTransform>();
            // Tạo một bản sao của anchoredPosition
            Vector2 newAnchoredPosition = shopWeaponRect.anchoredPosition;

            // Thay đổi giá trị x của anchoredPosition
            newAnchoredPosition.x -= 0.26f; // Sử dụng 0.2f vì đây là giá trị float

            // Gán lại giá trị cho anchoredPosition
            shopWeaponRect.anchoredPosition = newAnchoredPosition;
            ShopWeaponPoint.anchoredPosition = newAnchoredPosition;
        }

        else if (PlayerPrefs.GetString("TypeWeapon", "Hammer") == "Hammer")
        {
            RectTransform shopWeaponRect = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();

            RectTransform ShopWeaponPoint = GameObject.Find("ShopWeaponPoint0").GetComponent<RectTransform>();
            // Tạo một bản sao của anchoredPosition
            Vector2 newAnchoredPosition = shopWeaponRect.anchoredPosition;

            // Thay đổi giá trị x của anchoredPosition
            newAnchoredPosition.x -= 0.26f; // Sử dụng 0.2f vì đây là giá trị float

            // Gán lại giá trị cho anchoredPosition
            shopWeaponRect.anchoredPosition = newAnchoredPosition;
            ShopWeaponPoint.anchoredPosition = newAnchoredPosition;
            GameManager.Instance.SetMainWeapon();
        }





    }
}
