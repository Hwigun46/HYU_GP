using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public Transform player;
    public Transform bg1, bg2;    // 배경 오브젝트
    private float backgroundWidth;

    void Start()
    {
        // bg1에 붙은 SpriteRenderer 컴포넌트 가져오기
        SpriteRenderer sr = bg1.GetComponent<SpriteRenderer>();
        // 로컬 스케일을 곱해서 실제 월드 단위 크기 계산
        backgroundWidth = sr.bounds.size.x;
        Debug.Log("배경 너비 (월드 단위): " + backgroundWidth);
    }
    void Update()
    {
        // 플레이어가 bg1의 오른쪽 경계를 넘었을 때
        if (player.position.x < bg1.position.x && player.position.x > (bg1.position.x - backgroundWidth / 2f))
        {
            // bg1을 bg2의 오른쪽으로 옮기고 swap
            bg2.position = new Vector3(bg1.position.x - backgroundWidth, bg1.position.y, bg1.position.z);
        }
        // 플레이어가 bg2의 왼쪽 경계를 넘었을 때
        else if (player.position.x < (bg1.position.x + backgroundWidth / 2f) && player.position.x > bg1.position.x)
        {
            // bg2를 bg1의 왼쪽으로 옮기고 swap
            bg2.position = new Vector3(bg1.position.x + backgroundWidth, bg2.position.y, bg2.position.z);
        }
        else if (player.position.x < bg1.position.x - backgroundWidth / 2f)
        {
            SwapBackgrounds();
        }
        else if (player.position.x > bg1.position.x + backgroundWidth / 2f)
        {
            SwapBackgrounds();
        }

    }

    // bg1, bg2 참조를 서로 바꿔 줘야 다음 경계 체크가 올바르게 동작
    void SwapBackgrounds()
    {
        Transform tmp = bg1;
        bg1 = bg2;
        bg2 = tmp;
    }
}