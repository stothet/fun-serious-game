using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// This is a static class that handles the persistence of object states between scene transitions
/// </summary>
public class PersistenceController
{
    public static PersistenceController instance;

    /// <summary>
    /// Stores the states of the player
    /// </summary>
    public static class PlayerState
     {
        public static Vector3 playerPosition = Configuration.playerPosition;
        public static int lives = Configuration.maxLives;
        /// <summary>
        /// Resets the state of the object
        /// </summary>
        public static void ResetState()
        {
            Debug.Log("Player.rs");
            playerPosition = Configuration.playerPosition;
        
       
            lives = Configuration.maxLives;
        }
    }

    /// <summary>
    /// Store the state of the current dialgue between NPCs
    /// </summary>
    public static class DialogueState
    {
        public static Dictionary<string, bool> firstTalk;
        public static Dictionary<string, bool> givenEvidence;
        public static Dictionary<string, bool> journalUpdated;
        public static bool autoTalk = true;

        /// <summary>
        /// Resets the state of the object
        /// </summary>
        public static void ResetState()
        {
            autoTalk = true;
            firstTalk = new Dictionary<string, bool>();
            givenEvidence = new Dictionary<string, bool>();
            journalUpdated = new Dictionary<string, bool>();
        }
    }

    /// <summary>
    /// Stores the state of the player's inventory
    /// </summary>
    public static class InventoryState
    {
        public static int currentLine = 0;
        public static bool shouldStartConversation = false;
        public static Dictionary<string, Item> database = new Dictionary<string, Item>();

        /// <summary>
        /// Resets the state of the object
        /// </summary>
        public static void ResetState()
        {
            database = new Dictionary<string, Item>();
            currentLine = 0;
            shouldStartConversation = false;
        }
    }

    /// <summary>
    /// Stores the state of the player's journal
    /// </summary>
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

    /// <summary>
    /// Static contructor to state the objects inital states
    /// </summary>
    static PersistenceController()
    {
        Debug.Log("Constructor");
        InitialiseState();

    }

    /// <summary>
    /// Initialises the states of the objects
    /// </summary>
    public static void InitialiseState()
    {
        PlayerState.ResetState();
        DialogueState.ResetState();
        InventoryState.ResetState();
        JournalState.ResetState();
    }
}