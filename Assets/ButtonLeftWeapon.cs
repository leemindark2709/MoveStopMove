using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLeftWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Transform WeaponHammer;
    public void OnButtonClick()
    {

        int index = 0;

        for (int i = 5; i < GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons.Count; i++)
        {
            if (GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[i].GetComponent<ButtonPickWeapon>().Weapon.GetComponent<PlayerDameSender>().NameWeapon
                == PlayerPrefs.GetString("Weapon", "Hammer"))
            {
                index = 1;
                GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().EnableAllPanel();
                GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[i].Find("BorderWeapon").gameObject.SetActive(true);
            }

        }
        Debug.Log(index);
        if (index == 0)
        {
            GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().EnableAllPanel();
            GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[5].Find("BorderWeapon").gameObject.SetActive(true);

        }



        if (PlayerPrefs.GetString("Weapon", "Hammer") == "Hammer" && PlayerPrefs.GetString("TypeWeapon", "Hammer") == "Hammer")
        {
            RectTransform shopWeaponRect = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();

            RectTransform ShopWeaponPoint = GameObject.Find("ShopWeaponPoint0").GetComponent<RectTransform>();
            // Tạo một bản sao của anchoredPosition
            Vector2 newAnchoredPosition = shopWeaponRect.anchoredPosition;

            // Thay đổi giá trị x của anchoredPosition
            newAnchoredPosition.x += 0.26f; // Sử dụng 0.2f vì đây là giá trị float

            // Gán lại giá trị cho anchoredPosition
            shopWeaponRect.anchoredPosition = newAnchoredPosition;
            ShopWeaponPoint.anchoredPosition = newAnchoredPosition;
            WeaponHammer.GetComponent<WeaponHammerManager>().EquipperTop.gameObject.SetActive(false);
            WeaponHammer.GetComponent<WeaponHammerManager>().ChoseCorlor.gameObject.SetActive(true);
            WeaponHammer.GetComponent<WeaponHammerManager>().Equipper.gameObject.SetActive(true);
            GameManager.Instance.SetMainWeapon();
        }
       else if (PlayerPrefs.GetString("Weapon", "Hammer") != "Hammer" && PlayerPrefs.GetString("TypeWeapon", "Hammer") == "Hammer")
        {
            RectTransform shopWeaponRect = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();

            RectTransform ShopWeaponPoint = GameObject.Find("ShopWeaponPoint0").GetComponent<RectTransform>();
            // Tạo một bản sao của anchoredPosition
            Vector2 newAnchoredPosition = shopWeaponRect.anchoredPosition;

            // Thay đổi giá trị x của anchoredPosition
            newAnchoredPosition.x += 0.26f; // Sử dụng 0.2f vì đây là giá trị float

            // Gán lại giá trị cho anchoredPosition
            shopWeaponRect.anchoredPosition = newAnchoredPosition;
            ShopWeaponPoint.anchoredPosition = newAnchoredPosition;
            WeaponHammer.GetComponent<WeaponHammerManager>().EquipperTop.gameObject.SetActive(true);
            WeaponHammer.GetComponent<WeaponHammerManager>().ChoseCorlor.gameObject.SetActive(false);
            WeaponHammer.GetComponent<WeaponHammerManager>().Equipper.gameObject.SetActive(false);
            GameManager.Instance.SetMainWeapon();
        }
        else if (PlayerPrefs.GetString("TypeWeapon", "Hammer") == "Knife")
        {
            WeaponHammerManager.instance.EquipperTop.gameObject.SetActive(false);
            WeaponHammerManager.instance.ChoseCorlor.gameObject.SetActive(true);
            WeaponHammerManager.instance.Equipper.gameObject.SetActive(true);
            RectTransform shopWeaponRect = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();

            RectTransform ShopWeaponPoint = GameObject.Find("ShopWeaponPoint0").GetComponent<RectTransform>();
            // Tạo một bản sao của anchoredPosition
            Vector2 newAnchoredPosition = shopWeaponRect.anchoredPosition;

            // Thay đổi giá trị x của anchoredPosition
            newAnchoredPosition.x += 0.26f; // Sử dụng 0.2f vì đây là giá trị float

            // Gán lại giá trị cho anchoredPosition
            shopWeaponRect.anchoredPosition = newAnchoredPosition;
            ShopWeaponPoint.anchoredPosition = newAnchoredPosition;

            Debug.Log("Here");
            GameManager.Instance.SetMainWeapon();
        }
        else
        {
            WeaponHammerManager.instance.EquipperTop.gameObject.SetActive(false);
            WeaponHammerManager.instance.ChoseCorlor.gameObject.SetActive(true);
            WeaponHammerManager.instance.Equipper.gameObject.SetActive(true);
            RectTransform shopWeaponRect = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();

            RectTransform ShopWeaponPoint = GameObject.Find("ShopWeaponPoint0").GetComponent<RectTransform>();
            // Tạo một bản sao của anchoredPosition
            Vector2 newAnchoredPosition = shopWeaponRect.anchoredPosition;

            // Thay đổi giá trị x của anchoredPosition
            newAnchoredPosition.x += 0.26f; // Sử dụng 0.2f vì đây là giá trị float
            Debug.Log("Here");
            // Gán lại giá trị cho anchoredPosition
            shopWeaponRect.anchoredPosition = newAnchoredPosition;
            ShopWeaponPoint.anchoredPosition = newAnchoredPosition;
         

        }


    }
}
