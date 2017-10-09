using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PersistenceController
{
    public static PersistenceController instance;

    public static class PlayerState
     {
        public static Vector3 playerPosition = Configuration.playerPosition;
        public static int lives = Configuration.maxLives;
        public static void ResetState()
        {
            Debug.Log("Player.rs");
            playerPosition = Configuration.playerPosition;
        
       
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
    public static class InventoryState
    {
        public static int currentLine = 0;
        public static bool shouldStartConversation = false;
        public static Dictionary<string, Item> database = new Dictionary<string, Item>();

        public static void ResetState()
        {
            database = new Dictionary<string, Item>();
            currentLine = 0;
            shouldStartConversation = false;
        }
    }

    public static class JournalState
    {
        public static string journal = "";
        public static NPCController NPC = null;
        public static void ResetState()
        {
            journal = "";
            NPC = null;
        }
    }
    static PersistenceController()
    {
        Debug.Log("Constructor");
        InitialiseState();

    }

    public static void InitialiseState()
    {
        PlayerState.ResetState();
        DialogueState.ResetState();
        InventoryState.ResetState();
        JournalState.ResetState();
    }
}