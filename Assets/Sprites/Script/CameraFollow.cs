using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // 따라갈 대상 (Player)
    public Vector3 offset;          // X축 거리 유지 (Y는 무시)
    public float followSpeed = 5f;  // 따라가는 속도

    private float fixedY;           // 고정된 Y값 저장

    void Start()
    {
        // 시작할 때 Y 위치 저장
        fixedY = transform.position.y;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // X만 따라가고 Y는 고정
            Vector3 desiredPos = new Vector3(target.position.x + offset.x, fixedY, offset.z);
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);
            transform.position = smoothedPos;
        }
    }
}