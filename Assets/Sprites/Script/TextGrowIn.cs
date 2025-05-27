using UnityEngine;

public class TextGrowIn : MonoBehaviour
{
    public float growTime = 1.0f;
    public float maxScale = 1.2f;
    public float settleScale = 1.0f;

    private RectTransform rect;
    private float timer = 0f;
    private bool animDone = false;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.localScale = Vector3.zero;
    }

    void Update()
    {
        if (animDone) return;

        timer += Time.deltaTime;
        float t = timer / growTime;

        if (t < 1f)
        {
            // 커지는 부분 (부드러운 커브 적용)
            float scale = Mathf.Lerp(0f, maxScale, Mathf.SmoothStep(0f, 1f, t));
            rect.localScale = new Vector3(scale, scale, 1f);
        }
        else
        {
            // 정착 단계
            rect.localScale = Vector3.Lerp(rect.localScale, Vector3.one * settleScale, Time.deltaTime * 5f);
            animDone = true;
        }
    }
}