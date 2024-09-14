using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZombieMode : MonoBehaviour
{
    public Transform CountZombieAlive;
    public Transform Day;
    public Transform Day1;
    public Transform Day0;
    public Transform CountZomBie;
    public Transform CountZomBie1;
    public Transform CountZomBie0;
    public Transform Pause;
    public Transform Pause1;
    public Transform Pause0;
    public Transform Panel;
    public Transform Ability1; // Biến để lưu Transform 1
    public Transform Ability2; // Biến để lưu Transform 2
    public Transform AbilityRandom1; // Biến để lưu Transform 2
    public Transform AbilityRandom2; // Biến để lưu Transform 2
    public List<Transform> Abilitys = new List<Transform>();
    public string nameOfAbilityRandom1;
    public string nameOfAbilityRandom2 ;


    // Hàm để lấy 2 Transform ngẫu nhiên và khác nhau
    public void GetTwoRandomAbilities()
    {
        if (Abilitys.Count < 2)
        {
            //Debug.LogError("Danh sách Abilitys không có đủ phần tử để chọn.");
            return;
        }

        // Kiểm tra nếu Ability1 và Ability2 đều null
        if (PlayerPrefs.GetString("AbilityRandom1", "NoneAbility1") == "NoneAbility" && PlayerPrefs.GetString("AbilityRandom1", "NoneAbility2") == "NoneAbility")
        {
            // Chọn 2 số ngẫu nhiên khác nhau
            int firstIndex = Random.Range(0, Abilitys.Count);
            int secondIndex;

            do
            {
                secondIndex = Random.Range(0, Abilitys.Count);
            }
            while (secondIndex == firstIndex);

            // Lấy 2 Transform ngẫu nhiên khác nhau và gán vào Ability1 và Ability2
            AbilityRandom1 = Abilitys[firstIndex];
            AbilityRandom2 = Abilitys[secondIndex];

            // Hiển thị kết quả trên Console để kiểm tra
            //Debug.Log("Ability 1: " + Ability1.name + " - Ability 2: " + Ability2.name);
        }
        else
        {
            AbilityRandom1 = FindAbilityByName(PlayerPrefs.GetString("AbilityRandom1", "NoneAbility1"));
            AbilityRandom2= FindAbilityByName(PlayerPrefs.GetString("AbilityRandom2", "NoneAbility1"));
        }
    }

    public Transform FindAbilityByName(string name)
    {
        foreach (Transform ability in Abilitys)
        {
            if (ability.name.Equals(name))
            {
                return ability;
            }
        }

        Debug.LogWarning("Không tìm thấy Ability với tên: " + name);
        return null;
    }
    public void ExchangeAbility()
    {
        // Kiểm tra nếu Ability1 và Ability2 không phải là null
        if (AbilityRandom1 != null && AbilityRandom2 != null)
        {
            // Hoán đổi giá trị của Ability1 và Ability2
            Transform temp = AbilityRandom1;
            AbilityRandom1 = AbilityRandom2;
            AbilityRandom2 = temp;

            //// Hiển thị kết quả trên Console để kiểm tra
            //Debug.Log("Đã hoán đổi Ability1 với Ability2.");
            Debug.Log("Ability1 hiện tại: " + AbilityRandom1.name);
            Debug.Log("Ability2 hiện tại: " + AbilityRandom2.name);
        }
        else
        {
            Debug.LogWarning("Không thể hoán đổi vì một trong hai Ability là null.");
        }
    }

    public void SetChoseAbility()
    {
        Ability1.GetComponent<Image>().sprite = AbilityRandom1.GetComponent<Ability>().ImageAbility;
        Ability1.GetChild(0).GetComponent<TextMeshProUGUI>().text = AbilityRandom1.GetComponent<Ability>().NameAbility     ;

    }
    private void Start()
    {
        
        PlayerPrefs.SetString("AbilityRandom1", "NoneAbility");
        GetTwoRandomAbilities();
    }
    public void Update()
    {
        // Gọi hàm lấy 2 Transform ngẫu nhiên khi cần
        if (Input.GetKeyDown(KeyCode.Space)) // Nhấn phím Space để thử nghiệm
        {
            GetTwoRandomAbilities();
        }
        if (Ability1!=null)
        {
            SetChoseAbility();

        }
        if (PlayerPrefs.GetString("AbilityRandom1", "NoneAbility1")== "NoneAbility")
        {
            GameManager.Instance.Home.GetComponent<Home>().PausePanel.GetComponent<ZombiePause>().PanelSmall.GetComponent<PauseSmallPanel>()
             .image.gameObject.SetActive(true);
            GameManager.Instance.Home.GetComponent<Home>().PausePanel.GetComponent<ZombiePause>().PanelSmall.GetComponent<PauseSmallPanel>()
          .NameAbility.gameObject.SetActive(true);
            GameManager.Instance.Home.GetComponent<Home>().PausePanel.GetComponent<ZombiePause>().PanelSmall.GetComponent<PauseSmallPanel>()
               .image.GetComponent<Image>().sprite = AbilityRandom1.GetComponent<Ability>().ImageAbility;
            GameManager.Instance.Home.GetComponent<Home>().PausePanel.GetComponent<ZombiePause>().PanelSmall.GetComponent<PauseSmallPanel>()
                .NameAbility.GetComponent<TextMeshProUGUI>().text= AbilityRandom1.GetComponent<Ability>().NameAbility;
        }
        else {
            GameManager.Instance.Home.GetComponent<Home>().PausePanel.GetComponent<ZombiePause>().PanelSmall.GetComponent<PauseSmallPanel>()
               .image.gameObject.SetActive(false);
            GameManager.Instance.Home.GetComponent<Home>().PausePanel.GetComponent<ZombiePause>().PanelSmall.GetComponent<PauseSmallPanel>()
          .NameAbility.gameObject.SetActive(false);

        }


    }
}
