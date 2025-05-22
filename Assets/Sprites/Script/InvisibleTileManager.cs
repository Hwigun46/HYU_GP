using UnityEngine;
using System.Collections.Generic;

public class InvisibleTileManager : MonoBehaviour
{
    private List<GameObject> children = new List<GameObject>();
    private List<SpriteRenderer> renderers = new List<SpriteRenderer>();

    void Start()
    {
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
        }
        foreach (GameObject child in children)
        {
            renderers.Add(child.GetComponent<SpriteRenderer>());
        }
        foreach (var sr in renderers)
            {
                // 2) 투명도 변경
                var c = sr.color;
                c.a = 0;
                sr.color = c;
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