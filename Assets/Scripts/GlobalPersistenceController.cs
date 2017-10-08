using UnityEngine;
using System.Collections;

public class GlobalPersistenceController : MonoBehaviour
{
    public static GlobalPersistenceController instance;

    public static class PlayerState
     {
        public static Vector3 playerPosition;
        public static int lives;
        public static void ResetState()
        {
            playerPosition = Configuration.playerPosition;
            lives = Configuration.maxLives;
        }
    }

    void Awake()
    {
        InitialiseStates();
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private static void InitialiseStates()
    {
        PlayerState.ResetState();

    }
}