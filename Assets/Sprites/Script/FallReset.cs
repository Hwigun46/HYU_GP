using UnityEngine;
using UnityEngine.SceneManagement;

public class FallReset : MonoBehaviour
{
    public float resetYThreshold = -5f;

    void Update()
    {
        if (transform.position.y < resetYThreshold)
        {
            // 현재 씬 이름 가져와서 다시 불러오기
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}