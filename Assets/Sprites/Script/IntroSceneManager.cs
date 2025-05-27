using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;


    void Start()
    {
        videoPlayer.loopPointReached += VideoPlayer_loopPointReached;
    }

    void VideoPlayer_loopPointReached(VideoPlayer source)
    {
        SceneManager.LoadScene("stage1");
    }
}
