using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingUI : MonoBehaviour
{
    public GameObject retryButton;
    public GameObject mainButton;
    public float delay = 2f;

    private bool isGoodEnding = false;

    void Start()
    {
        // 현재 씬 이름을 확인해서 goodEnding인지 판단
        string currentScene = SceneManager.GetActiveScene().name;
        isGoodEnding = currentScene.ToLower().Contains("good");

        // 버튼 미리 숨기기
        if (retryButton != null) retryButton.SetActive(false);
        if (mainButton != null) mainButton.SetActive(false);

        Invoke(nameof(ShowButtons), delay);
    }

    void ShowButtons()
    {
        if (!isGoodEnding && retryButton != null)
        {
            retryButton.SetActive(true);
        }

        if (mainButton != null)
        {
            mainButton.SetActive(true);
        }
    }

    public void OnRetryClicked()
    {
        if (!string.IsNullOrEmpty(GameSession.instance?.previousStage))
        {
            SceneManager.LoadScene(GameSession.instance.previousStage);
        }
        else
        {
            Debug.LogWarning("GameSession이나 previousStage가 없습니다. 기본 씬으로 돌아갑니다.");
            SceneManager.LoadScene("Intro");
        }
    }

    public void OnMainClicked()
    {
        SceneManager.LoadScene("Intro");
    }
}