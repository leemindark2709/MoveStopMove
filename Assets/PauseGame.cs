using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;  // Giao diện hiển thị khi trò chơi bị tạm dừng
    private bool isPaused = false;
    public Transform PauseObject;

    // Hàm gọi khi nhấn nút Pause
    //public void TogglePause()
    //{
    //    isPaused = !isPaused;

    //    if (isPaused)
    //    {
    //        Pause();  // Gọi hàm dừng trò chơi
    //    }
    //    else
    //    {
    //        Resume();  // Gọi hàm tiếp tục trò chơi
    //    }
    //}

    // Hàm dừng trò chơi
    public void Pause()
    {
        // Di chuyển và hiển thị UI trước
        GameManager.Instance.MovePositionUIZombieModelmd();
        PauseObject.gameObject.SetActive(true);

        
        StartCoroutine(WaitMoveUI());

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }
    }

    // Hàm tiếp tục trò chơi
    public void Resume()
    {
        // Khôi phục thời gian ngay lập tức
        Time.timeScale = 1f;

        // Di chuyển UI trở lại vị trí ban đầu và ẩn UI
        GameManager.Instance.ReturnPositionUIZombieModelmd();
        StartCoroutine(WaitReturnUI());  // Gọi Coroutine để đợi 0.35 giây rồi ẩn UI

        // Ẩn menu Pause (nếu có)
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    // Coroutine để đợi trước khi dừng thời gian
    public IEnumerator WaitMoveUI()
    {
        yield return new WaitForSecondsRealtime(0.11f);  // Đợi 0.3 giây (không bị ảnh hưởng bởi Time.timeScale)
        Time.timeScale = 0f;  // Dừng thời gian sau khi UI đã di chuyển
    }

    // Coroutine để đợi trước khi ẩn UI
    public IEnumerator WaitReturnUI()
    {
        yield return new WaitForSecondsRealtime(0.11f);  // Đợi 0.35 giây
        PauseObject.gameObject.SetActive(false);  // Ẩn đối tượng UI sau khi hoàn tất
    }
}
