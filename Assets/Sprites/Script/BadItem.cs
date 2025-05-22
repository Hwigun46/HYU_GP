using UnityEngine;

public class BadItem : MonoBehaviour
{
    public float amplitude = 0.1f;      // 최대 위아래 이동 거리(반폭)
    public float frequency = 1f;        // 1초당 사이클 수
    private Vector3 startPos;
    public UIManager uiManager;

    public AudioClip badItemSound;      // 부정적인 아이템 사운드

    protected virtual void Start()
    {
        // 초기 위치 저장
        startPos = transform.position;
    }

    protected virtual void Update()
    {
        // 부드러운 위아래 움직임
        float offsetY = Mathf.Sin(Time.time * Mathf.PI * 2f * frequency) * amplitude;
        transform.position = startPos + Vector3.up * offsetY;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 소리 먼저 재생 (플레이어 위치나 카메라 위치 기준)
            if (badItemSound != null)
            {
                AudioSource.PlayClipAtPoint(badItemSound, Camera.main.transform.position);
            }

            uiManager.Damage();

            Destroy(gameObject); // 아이템 즉시 제거
        }
    }
}