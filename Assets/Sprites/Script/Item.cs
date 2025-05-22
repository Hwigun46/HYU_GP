using UnityEngine;

public class Item : MonoBehaviour
{
    public UIManager uiManager;
    public float amplitude = 0.1f;      // 최대 위아래 이동 거리(반폭)
    public float frequency = 1f;        // 1초당 사이클 수
    public AudioClip itemSound;         // 아이템 획득 사운드

    private Vector3 startPos;
    private AudioSource audioSource;

    void Start()
    {
        startPos = transform.position;

        // 현재 오브젝트에 AudioSource가 있으면 가져오고, 없으면 추가
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false; // 자동 재생 방지
    }

    void Update()
    {
        float offsetY = Mathf.Sin(Time.time * Mathf.PI * 2f * frequency) * amplitude;
        transform.position = startPos + Vector3.up * offsetY;
    }

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        if (itemSound != null)
        {
            // 소리를 플레이어(또는 카메라) 위치에서 재생
            AudioSource.PlayClipAtPoint(itemSound, Camera.main.transform.position);
        }

        uiManager.GetItem();

        // 아이템 즉시 제거 (소리는 따로 남아서 끝까지 재생됨)
        Destroy(gameObject);
    }
}
}