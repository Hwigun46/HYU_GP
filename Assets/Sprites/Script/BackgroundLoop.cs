using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;
    private Camera mainCam;

    private void Awake()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        width = col.size.x;
        mainCam = Camera.main;
    }

    private void Update()
    {
        // 카메라 왼쪽 끝 좌표
        float camLeftEdge = mainCam.transform.position.x - (mainCam.orthographicSize * mainCam.aspect);

        // 이 배경이 화면 완전히 벗어났을 때만 이동
        if (transform.position.x + width < camLeftEdge)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}