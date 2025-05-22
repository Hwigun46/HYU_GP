using System;
using UnityEngine;

public class UpBadItem : BadItem
{
    public Transform target;
    public float trigPositionX;
    private Boolean isCome = false;
    protected override void Start()
    {
        // 초기 위치 저장
        base.Start();
    }

    protected override void Update()
    {
        if (target.position.x >= trigPositionX)
        {
            isCome = true;
        }
        if (isCome)
        {
            if (transform.position.y < 40)
            {
                transform.Translate(0, 10 * Time.deltaTime, 0);
            }
        }
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
