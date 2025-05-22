using Unity.VisualScripting;
using UnityEngine;

public class UpHitTIleController : MonoBehaviour
{
    private Collider2D platformCollider;
    private SpriteRenderer platformSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        platformSprite = GetComponent<SpriteRenderer>();
        var c = platformSprite.color;
        c.a = 0f;
        platformSprite.color = c;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var c = platformSprite.color;
        c.a = 1f;
        platformSprite.color = c;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            platformCollider.isTrigger = false;
        }
    }
}
