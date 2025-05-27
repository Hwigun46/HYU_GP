

using UnityEngine;

public class GameSessionBootstrapper : MonoBehaviour
{
    void Awake()
    {
        if (GameSession.instance == null)
        {
            GameObject go = new GameObject("GameSession");
            go.AddComponent<GameSession>();
        }
    }
}