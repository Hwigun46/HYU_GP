using UnityEngine;

public class MovingItem : MonoBehaviour
{
    public UIManager uiManager;
    public float speed = 5.0f;
    public float distance = 10.0f;
    private float startPositionX;
    private float endPositionX;
    private int reverse = 1;

    public AudioClip itemSound;         // 아이템 획득 사운드

    private AudioSource audioSource;

    void Start()
    {
        startPositionX = transform.position.x;
        endPositionX = startPositionX + distance;

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
        transform.Translate(reverse * speed * Time.deltaTime, 0, 0);
        if (transform.position.x <= startPositionX)
        {
            if (reverse < 0)
            {
                reverse = 1;
            }
        }
        else if (transform.position.x >= endPositionX)
        {
            if (reverse > 0)
            {
                reverse = -1;
            }
        }
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