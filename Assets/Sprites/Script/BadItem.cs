using UnityEngine;

public class BadItem : MonoBehaviour
{
    public UIManager uiManager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 필요시: 점수 증가, 체력 증가 등 로직 여기에 추가
            uiManager.Damage();
            Destroy(gameObject); // 아이템 제거
        }
    }
}
