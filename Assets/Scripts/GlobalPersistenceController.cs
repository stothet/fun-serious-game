using UnityEngine;
using System.Collections;

public class GlobalPersistenceController
{
    public static GlobalPersistenceController instance;

    public static class PlayerState
     {
        public static Vector3 playerPosition = Configuration.lunchLadyPositionTest;
        public static int lives = Configuration.maxLives;
        public static void ResetState()
        {
            Debug.Log("Player.rs");
             playerPosition = Configuration.lunchLadyPositionTest;
        
       
            lives = Configuration.maxLives;
        }
    }

    public static class DialogueState
    {
        public static int currentLine = 0;
        public static bool shouldStartConversation = false;

        public static void ResetState()
        {
            currentLine = 0;
            shouldStartConversation = false;
        }
    }

    static GlobalPersistenceController()
    {
        Debug.Log("Constructor");
        InitialiseStates();

    }

    private static void InitialiseStates()
    {
        PlayerState.ResetState();
        DialogueState.ResetState();
    }
}