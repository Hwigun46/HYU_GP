using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagTrigger : MonoBehaviour
{
    [Header("현재 스테이지 이름")]
    public string currentStage = "stage1"; // 예시

    [Header("이게 마지막 스테이지인가요?")]
    public bool isFinalStage = false;

    [Header("엔딩 씬 이름")]
    public string goodEndingScene = "GoodEnding";
    public string badEndingScene = "BadEnding";

    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("UIManager를 찾을 수 없습니다!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (uiManager == null) return;

        // 1. 아이템 충족 여부 판단
        bool hasAllItems = uiManager.HasCollectedAllItems();

        // 2. 아이템 부족 → 무조건 배드엔딩
        if (!hasAllItems)
        {
            SceneManager.LoadScene(badEndingScene);
            return;
        }

        // 3. 아이템 충족 + 마지막 스테이지 → 굿엔딩
        if (isFinalStage)
        {
            SceneManager.LoadScene(goodEndingScene);
            return;
        }

        // 4. 아이템 충족 + 일반 스테이지 → 다음 스테이지 로딩
        if (currentStage.StartsWith("stage"))
        {
            string numStr = currentStage.Substring(5);
            if (int.TryParse(numStr, out int num))
            {
                string nextStage = $"stage{num + 1}";
                if (Application.CanStreamedLevelBeLoaded(nextStage))
                {
                    uiManager.ResetItemCount();
                    SceneManager.LoadScene(nextStage);
                }
                else
                {
                    Debug.LogWarning("다음 스테이지가 존재하지 않음: " + nextStage);
                }
            }
        }
    }
}