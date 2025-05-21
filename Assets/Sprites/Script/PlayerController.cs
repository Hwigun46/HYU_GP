using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 0.5f;
    public float fallMultiplier = 2.5f;
    public bool isReversal = false;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded = false;

    public float groundCheckDistance = 1f; // 바닥과 거리

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Ray로 바닥 감지
        CheckGround();

        // 좌우 이동
        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;
        transform.position += new Vector3(moveX, 0f, 0f) * moveSpeed * Time.deltaTime;

        // flip 처리
        if (!isReversal && moveX != 0)
        {
            sr.flipX = moveX < 0;
        }
        else if (isReversal && moveX != 0)
        {
            sr.flipX = !(moveX < 0);
        }

        // 점프
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // 낙하 가속
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, groundCheckDistance, LayerMask.GetMask("Ground"));
        isGrounded = hit.collider != null;
    }
    
    // 디버그용 Ray 시각화
    void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
}
}