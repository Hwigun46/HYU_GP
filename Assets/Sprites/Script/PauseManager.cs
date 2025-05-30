using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseUI;

    private static bool _isPaused = false;      // 내부 상태
    public static bool isPaused => _isPaused;   // 외부에서 읽기용

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
                Pause();
            else
                Resume();
        }
    }

    public void Pause()
    {
        _isPaused = true;
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        _isPaused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        _isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMain()
    {
        Time.timeScale = 1f;
        _isPaused = false;
        SceneManager.LoadScene("Intro");
    }
}