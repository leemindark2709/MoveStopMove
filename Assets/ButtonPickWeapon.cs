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
            Debug.Log("Weapon initialized with original size: " + originalSize);
        }
    }

    private void Update()
    {
        if (MainWeapon == null)
        {
            MainWeapon = transform.parent.Find("MainWeapon");
            if (MainWeapon != null)
            {
                Debug.Log("MainWeapon found: " + MainWeapon.name);
            }
        }
    }

    public void OnButtonClick()
        
    {
        //if (transform.tag!="CanChageColor"||transform.name!="KNIFE")
        //{
        //    transform.parent.GetComponent<WeaponHammerManager>().ChoseCorlor.gameObject.SetActive(false);

        //}
        //else if(transform.tag== "CanChageColor") transform.parent.GetComponent<WeaponHammerManager>().ChoseCorlor.gameObject.SetActive(true);
        //Debug.Log("Button clicked. Tag of this object: " + transform.tag);

        GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().EnableAllPanel();
        transform.Find("BorderWeapon").gameObject.SetActive(true);
        if (transform.tag == "CanChageColor")
        {
          
                WeaponHammerManager.instance.EquipperTop.gameObject.SetActive(false);
                WeaponHammerManager.instance.ChoseCorlor.gameObject.SetActive(true);
                WeaponHammerManager.instance.Equipper.gameObject.SetActive(true);
                transform.parent.GetComponent<WeaponHammerManager>().ChoseCorlor.gameObject.SetActive(true);
                Debug.Log("Switched to color change mode.");
           
          
            
        }
        else if (transform.tag != "CanChageCorlor")
        {
            Debug.Log("Switching to default mode.");
            WeaponHammerManager.instance.EquipperTop.gameObject.SetActive(true);
            WeaponHammerManager.instance.ChoseCorlor.gameObject.SetActive(false);
            WeaponHammerManager.instance.Equipper.gameObject.SetActive(false);
        }

        if (Weapon != null && MainWeapon != null)
        {
            Debug.Log("MainWeapon and Weapon found. Replacing MainWeapon.");
            // Xoá MainWeapon hiện tại
            

            // Tạo bản sao của Weapon
            Transform weaponCopy = Instantiate(Weapon);
           
            // Đặt vị trí và góc quay của bản sao tại vị trí của MainWeapon
            weaponCopy.position = MainWeapon.position;
            weaponCopy.rotation = MainWeapon.rotation;

            // Đặt bản sao làm con của cùng một parent với MainWeapon
            weaponCopy.SetParent(MainWeapon.parent, true);
            Destroy(MainWeapon.gameObject);
            // Gán tên mới cho bản sao nếu cần
            weaponCopy.name = "MainWeapon";

            // Gán lại biến MainWeapon để tham chiếu đến bản sao mới
            MainWeapon = weaponCopy;
            MainWeapon.localScale = new Vector3(1200, 1200, 1200);

            Debug.Log("MainWeapon replaced and resized.");

            // Cập nhật biến meshRenderer
            if (transform.tag == "CanChageColor")
            {
                transform.parent.Find("ChoseColor").GetComponent<ChoseLefftRight>().meshRenderer = MainWeapon.GetComponent<MeshRenderer>();


            }
        }
        else
        {
            Debug.LogWarning("Weapon or MainWeapon is null. Cannot replace MainWeapon.");
        }
    }
}
 