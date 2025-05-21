using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 0.5f;
    public float fallMultiplier = 2.5f;
    public Boolean isReversal = false;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>(); // ✅ SpriteRenderer 받아오기
    }

    void Update()
    {
        // 좌우 이동
        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        transform.position += new Vector3(moveX, 0f, 0f) * moveSpeed * Time.deltaTime;

        // ✅ 좌우 방향에 따라 flip 처리
        if (!isReversal && moveX != 0)
        {
            sr.flipX = moveX < 0;
        }
        else if (isReversal && moveX != 0)
        {
            sr.flipX = !(moveX < 0);
        }

        // 점프 (한 번만 가능)
            if (Input.GetKeyDown(KeyCode.W) && !isJumping)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
            }

        // 낙하 속도 강화
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 착지 시 다시 점프 가능하게
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isJumping = false;
        }
    }
}