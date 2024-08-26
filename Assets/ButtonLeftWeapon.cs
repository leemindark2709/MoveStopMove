using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLeftWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public void OnButtonClick()
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
    }
}
