using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShopWeaponButton : MonoBehaviour
{
    //public Transform ShopWeapon = GameManager.Instance.ShopWeapon;
    public RectTransform NotPayUI;
    public RectTransform NotPayUI2Point;
    public RectTransform LeftHome;
    public RectTransform ShopWeapon;
    public RectTransform ShopWeaponDestination;
    public List<Transform> ListWeapon = new List<Transform>();
    public Transform WeaponHammer;
    public Transform WeaponKnife;
    public Transform newPosition;
    public Transform newWeapon;
    public Transform MainWeaponHammer;
    private void Awake()
    {
        
    }
    private void Start()
    {
        NotPayUI = GameObject.Find("NOTPayADS").GetComponent<RectTransform>();
        NotPayUI2Point = GameObject.Find("NOTPayADS2").GetComponent<RectTransform>();
        LeftHome = GameObject.Find("Home").transform.Find("Canvas").Find("Left0").GetComponent<RectTransform>();
        ShopWeaponDestination =GameObject.Find("ShopWeaponPoint0").GetComponent<RectTransform>();
        ShopWeapon = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();
    }
    private IEnumerator MoveUI(RectTransform uiElement, Vector2 targetPosition, float duration)
    {
        Vector2 startingPosition = uiElement.anchoredPosition;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Smoothly move the UI element from start to target position
            uiElement.anchoredPosition = Vector2.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the final position is set accurately
        uiElement.anchoredPosition = targetPosition;
    }
    public void OnButtonClick()
    {
        GameManager.Instance.PLayer.gameObject.SetActive(false);
        Debug.Log(PlayerPrefs.GetString("TypeWeapon", "Hammer"));
        Debug.Log(PlayerPrefs.GetString("Weapon", "Hammer"));
        if (PlayerPrefs.GetString("Weapon", "Hammer") != "Hammer"&& PlayerPrefs.GetString("TypeWeapon", "Hammer")=="Hammer")
        {
            WeaponHammer.GetComponent<WeaponHammerManager>().EquipperTop.gameObject.SetActive(true);
            WeaponHammer.GetComponent<WeaponHammerManager>().ChoseCorlor.gameObject.SetActive(false);
            WeaponHammer.GetComponent<WeaponHammerManager>().Equipper.gameObject.SetActive(false);
            //WeaponHammer.parent.GetComponent<WeaponHammerManager>().ChoseCorlor.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Weapon", "Hammer") == "Hammer" && PlayerPrefs.GetString("TypeWeapon", "Hammer") == "Hammer")
        {
            WeaponHammer.GetComponent<WeaponHammerManager>().EquipperTop.gameObject.SetActive(false);
            WeaponHammer.GetComponent<WeaponHammerManager>().ChoseCorlor.gameObject.SetActive(true);
            WeaponHammer.GetComponent<WeaponHammerManager>().Equipper.gameObject.SetActive(true);
        }



        foreach (Transform weapon in GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons)
        {
            if (weapon.GetChild(0).GetComponent<PlayerDameSender>().NameWeapon == PlayerPrefs.GetString("Weapon", "Knife1"))
            {
                GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().EnableAllPanel();
                weapon.Find("BorderWeapon").gameObject.SetActive(true);
                //Debug.Log(PlayerPrefs.GetString("Weapon", "Knife1"));
                if (PlayerPrefs.GetString("TypeWeapon", "Hammer") == "Hammer")
                {

                    GameManager.Instance.MainWeaponHammer = WeaponHammer.Find("MainWeapon");

                    // Tạo bản sao của Weapon
                    Transform weaponCopy = Instantiate(weapon.GetChild(0));

                    // Đặt vị trí và góc quay của bản sao tại vị trí của MainWeapon
                    weaponCopy.position = GameManager.Instance.MainWeaponHammer.position;
                    weaponCopy.rotation = GameManager.Instance.MainWeaponHammer.rotation;

                    // Đặt bản sao làm con của cùng một parent với MainWeapon
                    weaponCopy.SetParent(GameManager.Instance.MainWeaponHammer.parent, true);
                    Destroy(GameManager.Instance.MainWeaponHammer.gameObject);
                    // Gán tên mới cho bản sao nếu cần
                    weaponCopy.name = "MainWeapon";

                    // Gán lại biến MainWeapon để tham chiếu đến bản sao mới
                    GameManager.Instance.MainWeaponHammer = weaponCopy;
                    GameManager.Instance.MainWeaponHammer.localScale = new Vector3(1200, 1200, 1200);


                    Transform oldWeapon;
                    oldWeapon = GameManager.Instance.Armature.GetComponent<PlayerAttack>().weapon;
                    //oldWeaponParent = oldWeapon.parent;


                    // Tạo bản sao mới của vũ khí và gán nó vào vị trí của "MainWeapon"
                 //  newWeapon = Instantiate(weapon.GetChild(0));
                 //   if (newWeapon.GetComponent<MainWeapon>().TypeWeapon == "Knife")
                 //   {
                 //       newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("KnifePoint");

                 //   }
                 //   else
                 //   {
                 //       newWeapon = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("HammerPoint");
                 //   }
                 // newWeapon.name = "Hammer"; // Đặt tên cho vũ khí mới để dễ quản lý
                 //   newWeapon.parent = oldWeapon.parent;
                 //   newWeapon.localScale = oldWeapon.localScale;
                 //   newWeapon.localPosition = newWeapon.localPosition;
                 // newWeapon.localRotation = oldWeapon.localRotation;
                 //newWeapon.GetComponent<PlayerDameSender>().targetTree = GameManager.Instance.PLayer.Find("Armature").transform;
                 //   GameManager.Instance.Armature.GetComponent<PlayerAttack>().weapon = newWeapon;

                 //   Destroy(oldWeapon.gameObject);

                }
                if (PlayerPrefs.GetString("TypeWeapon", "Hammer") == "Knife")
                {

                    GameManager.Instance.ShopWeapon.gameObject.SetActive(true);
                    //MainWeaponHammer = GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[5].GetComponent<ButtonPickWeapon>().MainWeapon;
                    GameManager.Instance.MainWeaponHammer = WeaponHammer.Find("MainWeapon");
                    // Tạo bản sao của Weapon
                    Transform weaponCopy1 = Instantiate(GameManager.Instance.ShopWeapon.GetComponent<ListWeapon>().ListWeapons[5].GetChild(0));

                    // Đặt vị trí và góc quay của bản sao tại vị trí của MainWeapon
                    weaponCopy1.position = GameManager.Instance.MainWeaponHammer.position;
                    weaponCopy1.rotation = GameManager.Instance.MainWeaponHammer.rotation;

                    // Đặt bản sao làm con của cùng một parent với MainWeapon
                    weaponCopy1.SetParent(GameManager.Instance.MainWeaponHammer.parent, true);
                    Destroy(GameManager.Instance.MainWeaponHammer.gameObject);
                    // Gán tên mới cho bản sao nếu cần
                    weaponCopy1.name = "MainWeapon";

                    // Gán lại biến MainWeapon để tham chiếu đến bản sao mới
                    GameManager.Instance.MainWeaponHammer = weaponCopy1;
                    GameManager.Instance.MainWeaponHammer.localScale = new Vector3(1200, 1200, 1200);


                    Transform oldWeapon1;
                    oldWeapon1 = GameManager.Instance.Armature.GetComponent<PlayerAttack>().weapon;
                    //oldWeaponParent = oldWeapon.parent;


                    // Tạo bản sao mới của vũ khí và gán nó vào vị trí của "MainWeapon"
                    newWeapon = Instantiate(weapon.GetChild(0));
                    if (newWeapon.GetComponent<MainWeapon>().TypeWeapon == "Knife")
                    {
                        newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("KnifePoint");

                    }
                    else
                    {
                        newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("HammerPoint");
                    }
                    newWeapon.name = "Hammer"; // Đặt tên cho vũ khí mới để dễ quản lý
                    newWeapon.parent = oldWeapon1.parent;
                    newWeapon.localScale = oldWeapon1.localScale;
                    newWeapon.localPosition = newPosition.localPosition;
                    newWeapon.localRotation = oldWeapon1.localRotation;
                    newWeapon.GetComponent<PlayerDameSender>().targetTree = GameManager.Instance.PLayer.Find("Armature").transform;
                    GameManager.Instance.Armature.GetComponent<PlayerAttack>().weapon = newWeapon;

                    Destroy(oldWeapon1.gameObject);


                    GameManager.Instance.MainWeaponKnife = WeaponKnife.Find("MainWeapon");
                    // Tạo bản sao của Weapon
                    Transform weaponCopy = Instantiate(weapon.GetChild(0));

                    // Đặt vị trí và góc quay của bản sao tại vị trí của MainWeapon
                    weaponCopy.position = GameManager.Instance.MainWeaponKnife.position;
                    weaponCopy.rotation = GameManager.Instance.MainWeaponKnife.rotation;

                    // Đặt bản sao làm con của cùng một parent với MainWeapon
                    weaponCopy.SetParent(GameManager.Instance.MainWeaponKnife.parent, true);
                    Destroy(GameManager.Instance.MainWeaponKnife.gameObject);
                    // Gán tên mới cho bản sao nếu cần
                    weaponCopy.name = "MainWeapon";

                    // Gán lại biến MainWeapon để tham chiếu đến bản sao mới
                    GameManager.Instance.MainWeaponKnife = weaponCopy;
                    GameManager.Instance.MainWeaponKnife.localScale = new Vector3(1200, 1200, 1200);


                    Transform oldWeapon;
                    oldWeapon = GameManager.Instance.Armature.GetComponent<PlayerAttack>().weapon;
                    //oldWeaponParent = oldWeapon.parent;


                 //   // Tạo bản sao mới của vũ khí và gán nó vào vị trí của "MainWeapon"
                 //   newWeapon = Instantiate(weapon.GetChild(0));
                 //   if (newWeapon.GetComponent<MainWeapon>().TypeWeapon == "Knife")
                 //   {
                 //       newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("KnifePoint");

                 //   }
                 //   else
                 //   {
                 //       newPosition = GameManager.Instance.PLayer.Find("Armature").GetComponent<PlayerAttack>().weapon.parent.Find("HammerPoint");
                 //   }
                 //newWeapon.name = "Hammer"; // Đặt tên cho vũ khí mới để dễ quản lý
                 // newWeapon.parent = oldWeapon.parent;
                 // newWeapon.localScale = oldWeapon.localScale;
                 //  newWeapon.localPosition = newPosition.localPosition;
                 //  newWeapon.localRotation = oldWeapon.localRotation;
                 //   newWeapon.GetComponent<PlayerDameSender>().targetTree = GameManager.Instance.PLayer.Find("Armature").transform;
                 //   GameManager.Instance.Armature.GetComponent<PlayerAttack>().weapon = newWeapon;

                 //   Destroy(oldWeapon.gameObject);

                }
            } 



            }


            //GameManager.Instance.PLayer.gameObject.SetActive(false);
            //GameManager.Instance.checkShopWeapon = true;
            //GameManager.Instance.ShopWeapon.gameObject.SetActive(true);
            if (GameManager.Instance.ShopWeapon.gameObject.activeSelf)
        {
            RectTransform shopWeaponRect = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();

            // Lấy giá trị mới cho vị trí x và y
            float newX = PlayerPrefs.GetFloat("ShopWeaponx", shopWeaponRect.anchoredPosition.x);
            float newY = PlayerPrefs.GetFloat("ShopWeapony", shopWeaponRect.anchoredPosition.y);
            Debug.Log(newX);
            // Cập nhật anchoredPosition với giá trị x và y mới
            shopWeaponRect.anchoredPosition = new Vector2(newX, newY);
            StartCoroutine(MoveUI(NotPayUI, NotPayUI2Point.anchoredPosition, 0.1f));
            StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Left1").GetComponent<RectTransform>().anchoredPosition, 0.1f));
        }
        else
        {
            GameManager.Instance.ShopWeapon.gameObject.SetActive(true);

            RectTransform shopWeaponRect = GameManager.Instance.ShopWeapon.GetComponent<RectTransform>();

            // Lấy giá trị mới cho vị trí x và y
            float newX = PlayerPrefs.GetFloat("ShopWeaponx", shopWeaponRect.anchoredPosition.x);
            float newY = PlayerPrefs.GetFloat("ShopWeapony", shopWeaponRect.anchoredPosition.y);
            Debug.Log(newX);
            // Cập nhật anchoredPosition với giá trị x và y mới
            shopWeaponRect.anchoredPosition = new Vector2(newX, newY);
            // Start moving UI elements with animations
            StartCoroutine(MoveUI(NotPayUI, NotPayUI2Point.anchoredPosition, 0.1f));
        StartCoroutine(MoveUI(LeftHome, GameObject.Find("Home").transform.Find("Canvas").Find("Left1").GetComponent<RectTransform>().anchoredPosition, 0.1f));
    }

        }
      
}
