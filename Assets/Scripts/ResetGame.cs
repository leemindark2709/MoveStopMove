using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void OnResetButtonClick()
    {
        // Reset the time scale to normal in case the game was paused
        Time.timeScale = 1f;

        // Reload the current scene to reset the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Debug.Log("Game Reset");
    }
}
