using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // 따라갈 대상 (Player)
    public Vector3 offset;          // 초기 거리 유지
    public float followSpeed = 5f;  // 따라가는 속도

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPos = target.position + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);
            transform.position = smoothedPos;
        }
    }
}
