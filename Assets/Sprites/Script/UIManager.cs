using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text count;
    public Image fillImage;
    public float maxHealth = 100f;
    private float currentHealth;

    public string deathEndingScene; // ← 여기에 엔딩 씬 이름 지정 가능
    private bool isDead = false;    // 중복 방지

    private int needItem;
    private int getItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        needItem = 5;
        getItem = 0;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        count.text = getItem + "/" + needItem;
        UpdateHealthBar();

        // 피 0일 때 한 번만 엔딩 씬 로딩
        if (!isDead && currentHealth <= 0f)
        {
            isDead = true;

            if (GameSession.instance != null)
            {
                GameSession.instance.previousStage = SceneManager.GetActiveScene().name;
            }

            if (!string.IsNullOrEmpty(deathEndingScene))
            {
                SceneManager.LoadScene(deathEndingScene);
            }
            else
            {
                Debug.LogWarning("deathEndingScene이 설정되지 않았습니다.");
            }
        }
    }

    void UpdateHealthBar()
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = currentHealth / maxHealth;
        }
    }

    public void GetItem()
    {
        if (getItem < needItem)
        {
            getItem++;
        }
    }

    public void Damage()
    {
        currentHealth = Mathf.Clamp(currentHealth - 20f, 0, maxHealth);
    }

    // 아이템을 다 모았는지 확인하는 함수
    public bool HasCollectedAllItems()
    {
        return getItem >= needItem;
    }

    // 다음 스테이지 진입 시 아이템 수 초기화
    public void ResetItemCount()
    {
        getItem = 0;
    }
}