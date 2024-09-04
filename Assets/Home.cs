using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public RectTransform Gold;
    public List<RectTransform> ZombieCity = new List<RectTransform>();
    public Transform PanelStartZombileMode;

    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
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
}
