using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject noSavePopup; // 팝업 패널 연결

    public void NewGame()
    {
        PlayerPrefs.DeleteKey("LastScene");
        SceneManager.LoadScene("Intro");
    }

    public void ContinueGame()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "");

        if (!string.IsNullOrEmpty(lastScene))
        {
            SceneManager.LoadScene(lastScene);
        }
        else
        {
            Debug.LogWarning("저장된 게임이 없습니다!");
            if (noSavePopup != null)
            {
                noSavePopup.SetActive(true); // 팝업 띄우기
            }
        }
    }

    public void ClosePopup()
    {
        if (noSavePopup != null)
        {
            noSavePopup.SetActive(false);
        }
    }

    public void Options()
    {
        Debug.Log("옵션 창 열기 - 아직 미구현");
    }
}