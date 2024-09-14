using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public RectTransform Gold;
    public List<RectTransform> ZombieCity = new List<RectTransform>();
    public Transform PanelStartZombileMode;
    public Transform ZombieModePanel;
    public Transform PauseZombie;
    public Transform Coin;
    public Transform ZombieMode;
    public Transform PanelEndGameZombie;
    public Transform ButtonZombieMode;
    public Transform PanelWinGameZombie;
    public TextMeshProUGUI WinZombieMode;
    public Transform PausePanel;
    public Transform AbilityBottomPanel;
    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
        PlayerPrefs.SetInt("CountGold", GameManager.Instance.Gold);
        PlayerPrefs.Save();
        // Reset the game by reloading the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Returns a random RectTransform from the ZombieCity list
    public RectTransform GetRandomZombieCity()
    {
        if (ZombieCity.Count == 0)
        {
            Debug.LogWarning("ZombieCity list is empty.");
            return null;
        }

        int randomIndex = Random.Range(0, ZombieCity.Count);
        return ZombieCity[randomIndex];
    }
    public void updateDay()
    {
        DisableAllGreenRed();
        for (int i = 0; i <= (PlayerPrefs.GetInt("IsDay", 0)) % 5; i++)
        {

            PanelWinGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.gameObject.SetActive(true);

           
        }
    }
    public void UImask()
    {
        for (int i = 0; i <= 4; i++)
        {

            PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.GetComponent<Image>().sprite =
 PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Black;
            PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().Skull.gameObject.SetActive(false);
            PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().DayText.GetComponent<TextMeshProUGUI>().text = "Day " + ((PlayerPrefs.GetInt("IsDay", 1) / 5) * 5 + 1 + i);
        }
    }
    public void DisableAllGreenRed()
    {
        for (int i = 0; i <= 4; i++)
        {
            PanelWinGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().DayText.GetComponent<TextMeshProUGUI>().text = "Day " + ((PlayerPrefs.GetInt("IsDay", 1) / 5) * 5 + 1 + i);

            PanelWinGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        UImask();
        Debug.Log("Here...."+PlayerPrefs.GetInt("IsDay", 1));
        Debug.Log("Here...."+PlayerPrefs.GetString("Complete", ""));


        //Debug.Log(PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days.Count - 1);
        //Debug.Log(PlayerPrefs.GetString("Complete", "Yes"));
        PlayerPrefs.SetString("Complete", "No");
        PlayerPrefs.SetInt("IsDay", 0);
        Debug.Log(PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days.Count - 1);
        for (int i = 0; i <= PlayerPrefs.GetInt("IsDay", 1)%5; i++)
        {
            if (i < PlayerPrefs.GetInt("IsDay", 1) % 5 && i > 0)
            {

                PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.GetComponent<Image>().sprite =
                PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Greed;
                PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.gameObject.SetActive(true);

            }
            if (i < PlayerPrefs.GetInt("IsDay", 1) % 5 && i == 0)
            {

                PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.GetComponent<Image>().sprite =
                PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().GreenHead;
                PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.gameObject.SetActive(true);


            }
            if (PlayerPrefs.GetString("Complete", "Yes") == "No" && i == PlayerPrefs.GetInt("IsDay", 1) % 5)
            {
                //Debug.Log(PlayerPrefs.GetInt("IsDay",1));

                if ( i > 0)
                {


                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.GetComponent<Image>().sprite =
                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Red;
                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.gameObject.SetActive(true);
                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().Skull.gameObject.SetActive(true);

                }
                if (i == 0)
                {

                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.GetComponent<Image>().sprite =
                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().RedHead;

                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.gameObject.SetActive(true);
                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().Skull.gameObject.SetActive(true);

                    
                }
                if (i== PlayerPrefs.GetInt("IsDay", 1) % 5&&i==4)
                {
                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.GetComponent<Image>().sprite =
                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().RedHead;

                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().RedGreen.gameObject.SetActive(true);
                    PanelEndGameZombie.GetComponent<PanelEndGameZombie>().Day.GetComponent<DayZombieManager>().Days[i].GetComponent<DayZombie>().Skull.gameObject.SetActive(true);
                }
            }
        }
 
    }
}
