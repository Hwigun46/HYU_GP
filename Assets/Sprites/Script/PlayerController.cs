using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 0.5f;
    public float fallMultiplier = 2.5f;
    public bool isReversal = false;

    public AudioClip jumpSound;             // 점프 효과음
    private AudioSource audioSource;        // 사운드 재생기

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded = false;

    [Header("Ground Check")]
    public Transform groundCheckPoint;      // 발밑 체크용 Transform
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        // AudioSource 연결 (없으면 자동 추가)
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
    }

    void Update()
    {
        // 바닥 체크
        CheckGround();

        // 좌우 이동 처리
        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;
        transform.position += new Vector3(moveX, 0f, 0f) * moveSpeed * Time.deltaTime;

        // 캐릭터 반전 처리
        if (!isReversal && moveX != 0)
        {
            sr.flipX = moveX < 0;
        }
        else if (isReversal && moveX != 0)
        {
            sr.flipX = !(moveX < 0);
        }

        // 점프 처리
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // 점프 사운드 재생
            if (jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }

        // 낙하 시 중력 추가 가속 적용
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    // 바닥 감지
    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheckPoint.position,
            groundCheckRadius,
            groundLayer
        );
    }

    // 디버그용: 바닥 체크 시각화
    void OnDrawGizmosSelected()
    {
        if (groundCheckPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    }
}