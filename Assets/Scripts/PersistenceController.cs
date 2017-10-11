﻿using UnityEngine;
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
        public Dictionary<string, bool> givenEvidence;
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
        public bool shouldStartConversation = false;
        public List<string> database = new List<string>();

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
        public string journal = "";
        //public NPCController NPC = null;
        public JournalState()
        {
            journal = "";
           // NPC = null;
        }
    }

    private PersistenceController()
    {

        InitialiseState();

        //InitialiseState();
    }

    /// <summary>
    /// Static contructor to state the objects inital states
    /// </summary>
    /// 

    public static void instantiateInstance()
    {
        if(instance == null)
        {
            instance = new PersistenceController();
            instance.InitialiseState();
        }
    }

    /*static PersistenceController()
    {
        Debug.Log("Constructor");

    }*/

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