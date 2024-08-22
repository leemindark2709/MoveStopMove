using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPickWeapon : MonoBehaviour
{
    public Transform Weapon;
    public Transform MainWeapon;
    private Vector3 originalSize; // Lưu kích thước ban đầu của Weapon

    private void Start()
    {
        Weapon = transform.GetChild(0);

        // Lưu kích thước ban đầu của Weapon
        if (Weapon != null)
        {
            originalSize = Weapon.localScale;
        }
    }

    private void Update()
    {
        if (MainWeapon == null)
        {
            MainWeapon = transform.parent.Find("MainWeapon");
        }
    }

    public void OnButtonClick()
    {
        if (Weapon != null && MainWeapon != null)
        {
            // Xoá MainWeapon hiện tại
            Destroy(MainWeapon.gameObject);

            // Tạo bản sao của Weapon
            Transform weaponCopy = Instantiate(Weapon);

            // Đặt vị trí và góc quay của bản sao tại vị trí của MainWeapon
            weaponCopy.position = MainWeapon.position;
            weaponCopy.rotation = MainWeapon.rotation;

            // Đặt kích thước của bản sao bằng kích thước của Weapon
           

            // Đặt bản sao làm con của cùng một parent với MainWeapon
            weaponCopy.SetParent(MainWeapon.parent, true);

            // Gán tên mới cho bản sao nếu cần
            weaponCopy.name = "MainWeapon";

            // Gán lại biến MainWeapon để tham chiếu đến bản sao mới
            MainWeapon = weaponCopy;
            MainWeapon.localScale = new Vector3(1500, 1500, 1500);
        }
    }
}
