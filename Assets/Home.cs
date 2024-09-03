using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
  
{
    public RectTransform Gold;
    public List<RectTransform> ZombieCity = new List<RectTransform>();
    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
        // Reset the game by reloading the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
