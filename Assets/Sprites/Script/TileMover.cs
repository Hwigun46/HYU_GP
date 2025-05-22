using UnityEngine;

public class TileMover : MonoBehaviour
{
    public float speed = 5.0f; // 움직임의 속도
    public float distance = 10.0f; // 움직일 최대 거리

    private float startPositionY;
    private float endPositionY;
    private bool isCollider = false;

    void Start()
    {
        startPositionY = transform.position.y;
        endPositionY = startPositionY - distance;
    }

    void Update()
    {
        if (isCollider)
        {
            if (transform.position.y > endPositionY)
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCollider = true;
        }
    }
}
