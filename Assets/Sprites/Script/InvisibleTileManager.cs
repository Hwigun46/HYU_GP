using UnityEngine;
using System.Collections.Generic;

public class InvisibleTileManager : MonoBehaviour
{
    [Header("찾을 인스턴스의 Tag")]
    [Tooltip("프리팹에 지정한 Tag와 동일하게 설정하세요.")]
    public string targetTag = "InvisibleTile";

    [Header("투명도")]
    public float alpha = 0f;

    private List<GameObject> instances = new List<GameObject>();
    private List<SpriteRenderer> renderers = new List<SpriteRenderer>();

    void Start()
    {
        RefreshInstances();
        foreach (var sr in renderers)
        {
            // 2) 투명도 변경
            var c = sr.color;
            c.a = alpha;
            sr.color = c;
        }
    }

    /// <summary>
    /// 씬에 있는 targetTag 인스턴스를 찾아서 리스트에 저장합니다.
    /// 동적으로 인스턴스를 추가/삭제할 수 있다면, 필요 시 이 메서드를 호출하세요.
    /// </summary>
    public void RefreshInstances()
    {
        instances.Clear();
        renderers.Clear();

        var objs = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (var go in objs)
        {
            instances.Add(go);
            var sr = go.GetComponent<SpriteRenderer>();
            if (sr != null) renderers.Add(sr);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (var sr in renderers)
        {
            // 2) 투명도 변경
            var c = sr.color;
            c.a = 1f;
            sr.color = c;
        }
    }
}