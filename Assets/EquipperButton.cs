using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipperButton : MonoBehaviour
{
    public Transform WeaponPrefab; // Prefab của vũ khí sẽ được tạo ra
    public Transform oldWeapon;
    public Transform oldWeaponParent;
    public Transform newPosition;
    public RectTransform NotPayUI;
    public RectTransform NotPayUI2Point;
    public RectTransform LeftHome;
    public RectTransform ShopWeapon;
    public RectTransform ShopWeaponDestination;
    public string TypeWeapon;
    public string Weapon;
    private void Start()
    {
        NotPayUI = GameObject.Find("NOTPayADS").GetComponent<RectTransform>();
        NotPayUI2Point = GameObject.Find("NOTPayADS2").GetComponent<RectTransform>();
        LeftHome = GameObject.Find("Home").transform.Find("Canvas").Find("Left0").GetComponent<RectTransform>();
        ShopWeaponDestination = GameManager.Instance.ShopWeapon.Find("ShopWeaponPoint").GetComponent<RectTransform>();
        ShopWeapon = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();
    }
    public void OnButtonClick()
    {
        GameManager.Instance.PLayer.gameObject.SetActive(true);
        PlayerPrefs.SetFloat("ShopWeaponx", GameManager.Instance.ShopWeapon.GetComponent<RectTransform>().anchoredPosition.x);
        PlayerPrefs.SetFloat("ShopWeapony", GameManager.Instance.ShopWeapon.GetComponent<RectTransform>().anchoredPosition.y);
        PlayerPrefs.SetFloat("ShopWeaponz", GameManager.Instance.ShopWeapon.GetComponent<RectTransform>().anchoredPosition.x);
        PlayerPrefs.Save();
        GameManager.Instance.PLayer.gameObject.SetActive(true);
        ShopWeapon.anchoredPosition = ShopWeaponDestination.anchoredPosition;
        //GameManager.Instance.ShopWeapon.gameObject.SetActive(false);
        StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f));
        StartCoroutine(MoveUI(NotPayUI, GameObject.Find("Home").transform.Find("Canvas").Find("Right0").GetComponent<RectTransform>().anchoredPosition, 0.1f));

        oldWeapon = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon;
        oldWeaponParent = oldWeapon.parent;
        WeaponPrefab = transform.parent.Find("MainWeapon");
        if (WeaponPrefab == null)
        {
            Debug.LogWarning("Vũ khí prefab chưa được gán.");
            return;
        }


        // Tạo bản sao mới của vũ khí và gán nó vào vị trí của "MainWeapon"
        Transform newWeapon = Instantiate(WeaponPrefab);
        //Transform NewWeaponPrefab = Instantiate(WeaponPrefab);
        if (newWeapon.GetComponent<MainWeapon>().TypeWeapon == "Knife")
        {
            newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("KnifePoint");

        }
        else
        {
            newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("HammerPoint");
        }
        newWeapon.name = "Hammer"; // Đặt tên cho vũ khí mới để dễ quản lý
        newWeapon.parent = oldWeapon.parent;
        newWeapon.localScale = oldWeapon.localScale;
        newWeapon.localPosition = newPosition.localPosition;
        newWeapon.localRotation = oldWeapon.localRotation;
        newWeapon.GetComponent<PlayerDameSender>().targetTree = GameManager.Instance.PLayer.Find("Armature").transform;


        PlayerPrefs.SetString("TypeWeapon", TypeWeapon);
        PlayerPrefs.SetString("Weapon", newWeapon.GetComponent<PlayerDameSender>().NameWeapon);
        Debug.Log(PlayerPrefs.GetString("Weapon", newWeapon.GetComponent<PlayerDameSender>().NameWeapon));
        PlayerPrefs.Save();

        Destroy(oldWeapon.gameObject);
        GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon = newWeapon;

    }
    private IEnumerator MoveUI(RectTransform uiElement, Vector2 targetPosition, float duration)
    {
        Vector2 startingPosition = uiElement.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Di chuyển từ từ từ điểm này đến điểm khác
            uiElement.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Chờ 1 frame trước khi tiếp tục
        }

        // Đảm bảo vị trí cuối cùng chính xác
        uiElement.anchoredPosition = targetPosition;
    }

}
