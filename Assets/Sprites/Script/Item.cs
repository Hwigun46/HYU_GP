using UnityEngine;

public class Item : MonoBehaviour
{
    public UIManager uiManager;
    public float amplitude = 0.1f;      // 최대 위아래 이동 거리(반폭)
    public float frequency = 1f;        // 1초당 사이클 수
    private Vector3 startPos;
    void Start()
    {
        // 초기 위치 저장
        startPos = transform.position;
    }

    void Update()
    {
        // Time.time * frequency 에 따라 0~2π 사이를 왕복하는 Sine 함수값을 구하고
        // amplitude 를 곱해 위아래로 부드럽게 이동
        float offsetY = Mathf.Sin(Time.time * Mathf.PI * 2f * frequency) * amplitude;
        transform.position = startPos + Vector3.up * offsetY;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 필요시: 점수 증가, 체력 증가 등 로직 여기에 추가
            uiManager.GetItem();
            Destroy(gameObject); // 아이템 제거
        }
    }
}
