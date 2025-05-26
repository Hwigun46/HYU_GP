using UnityEngine;

public class MovingTile : MonoBehaviour
{

    public float speed = 5.0f;
    public float distance = 10.0f;
    private float startPositionX;
    private float endPositionX;
    private int reverse = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPositionX = transform.position.x;
        endPositionX = startPositionX + distance;
    }

    // Update is called once per frame
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
}
