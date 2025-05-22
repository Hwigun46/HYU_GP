using UnityEngine;

public class FallReset : MonoBehaviour
{
    public float resetYThreshold = -5f;
    public AudioClip deathSound;
    public UIManager uiManager;

    private bool isDead = false;
    private AudioSource audioSource;
    private Vector3 startPosition;

    void Start()
    {
        // 시작 위치 저장
        startPosition = transform.position;

        // 오디오 설정
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        if (!isDead && transform.position.y < resetYThreshold)
        {
            isDead = true;

            // 체력 감소
            if (uiManager != null)
            {
                uiManager.Damage();
            }

            // 사망 사운드
            if (deathSound != null)
            {
                audioSource.PlayOneShot(deathSound);
            }

            // 소리 재생 시간 후 위치 복귀
            float delay = (deathSound != null) ? deathSound.length : 1.0f;
            Invoke(nameof(ResetPosition), delay);
        }
    }

    void ResetPosition()
    {
        transform.position = startPosition;
        isDead = false;  // 다시 감지 가능하게
        // 필요하면 속도도 초기화
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}