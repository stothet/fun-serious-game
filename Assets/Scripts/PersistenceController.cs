using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

/// <summary>
/// This is a static class that handles the persistence of object states between scene transitions
/// </summary>
/// 
[Serializable]
public class PersistenceController
{
    public static PersistenceController instance;
    public PlayerState playerState;
    public DialogueState dialogueState;
    public InventoryState inventoryState;
    public JournalState journalState;
    public static string currentScene = Configuration.mainMenuSceneName; // Not in an inner class because it persists between states

    /// <summary>
    /// Stores the states of the player
    /// </summary>
    [Serializable]
    public class PlayerState
     {
        public SerializableVector3 playerPosition = Configuration.playerPosition;
        public int lives = Configuration.maxLives;
        /// <summary>
        /// Resets the state of the object
        /// </summary>
        public PlayerState()
        {
            Debug.Log("Player.rs");
            playerPosition = Configuration.playerPosition;
            lives = Configuration.maxLives;
        }
    }

    /// <summary>
    /// Store the state of the current dialgue between NPCs
    /// </summary>
    /// 
    [Serializable]
    public class DialogueState
    {
        public Dictionary<string, bool> firstTalk;
        public Dictionary<string, int> currentLine;
        public Dictionary<string, bool> givenEvidence;
        public Dictionary<string, bool> givenEvidenceRequiringTalk;
        public Dictionary<string, bool> givenJournalUpdateEvidenceRequiringTalk;
        public Dictionary<string, bool> journalUpdated;
        public bool autoTalk = true;

        /// <summary>
        /// Resets the state of the object
        /// </summary>
        /// 

        public DialogueState()
        {
            autoTalk = true;
            firstTalk = new Dictionary<string, bool>();
            givenEvidence = new Dictionary<string, bool>();
            journalUpdated = new Dictionary<string, bool>();
            currentLine = new Dictionary<string, int>();
            givenEvidenceRequiringTalk = new Dictionary<string, bool>();
            givenJournalUpdateEvidenceRequiringTalk = new Dictionary<string, bool>();
        }
}

    /// <summary>
    /// Stores the state of the player's inventory
    /// </summary>
    /// 
    [Serializable]
    public class InventoryState
    {
        public int currentLine = 0;
        public List<string> database = new List<string>();
        public bool shouldStartConversation = false;

        /// <summary>
        /// Resets the state of the object
        /// </summary>
        public InventoryState()
        {
            database = new List<string>();
            currentLine = 0;
            shouldStartConversation = false;
    }
    }

    /// <summary>
    /// Stores the state of the player's journal
    /// </summary>
    /// 
    [Serializable]
    public class JournalState
    {
        public List<string> journal;
        //public NPCController NPC = null;
        public JournalState()
        {
            journal = new List<string>();
           // NPC = null;
        }
    }

    // Visible for testing
    public PersistenceController()
    {

        InitialiseState();

        //InitialiseState();
    }

    /// <summary>
    /// Static contructor to state the objects inital states
    /// </summary>
    /// 

    public static void InstantiateInstance()
    {
        if(instance == null)
        {
            ResetState();
        }
    }

    public static void ResetState()
    {
        instance = new PersistenceController();
        instance.InitialiseState();
    }

    /// <summary>
    /// Initialises the states of the objects
    /// </summary>
    private void InitialiseState()
    {
        dialogueState = new DialogueState();
        playerState = new PlayerState();
        journalState = new JournalState();
        inventoryState = new InventoryState();
    }
}