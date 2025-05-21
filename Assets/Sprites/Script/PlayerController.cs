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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
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

        // 점프 (Ground에 있을 때만)
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        // 낙하 속도 강화
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Layer가 Ground일 때만 isGrounded = true
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    isGrounded = true;
                    break;
                }
            }
        }
    }
}