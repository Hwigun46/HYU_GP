using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession instance;

    public string previousStage;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}