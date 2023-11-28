using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    // This enables us to create a list of ActionCommandPair in the inspector. C# Dicts are not serializable
    [System.Serializable]
    public class ActionCommandPair
    {
        public InputAction key; // "Move", "Attack", etc.
        public BaseCommand val; // "MoveCommand", "AttackCommand", etc.
    }

    public class InputHandler : MonoBehaviour
    {
        List<ActionCommandPair> _actionCommandPairs = new List<ActionCommandPair>();
        // Dicts that map actions to commands and vice versa
        public Dictionary<InputAction, BaseCommand> bindActions = new Dictionary<InputAction, BaseCommand>();
        public Dictionary<BaseCommand, InputAction> reverseBindActions = new Dictionary<BaseCommand, InputAction>();

        private GameObject player;
        
        // Singleton pattern to ensure only one instance of InputHandler exists.
        # region Singleton
        public static InputHandler instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        #endregion Singleton

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            // During each frame, execute the Execute method of each bound command.
            foreach (var action in bindActions)
            {
                action.Value.Execute(action.Key, player);
            }
        }

        private void FixedUpdate()
        {
            // During the physics update, execute the FixedExecute method of each bound command.
            foreach (var action in bindActions)
            {
                action.Value.FixedExecute(action.Key, player);
            }
        }

        // Setup the bindings for the input handler
        public void UpdateActionsCommandsBindings()
        {
            bindActions.Clear();
            reverseBindActions.Clear();
            foreach(var pair in _actionCommandPairs)
            {
                bindActions.Add(pair.key, pair.val);
                reverseBindActions.Add(pair.val, pair.key);
                pair.key.Enable(); // Enable the input
            }
        }

        public void UpdateActionsCommandsList(List<ActionCommandPair> aList)
        {
            _actionCommandPairs = aList;
        }

        // Update bindings on enable
        private void OnEnable()
        {
            UpdateActionsCommandsBindings();
        }

        // Disable all input actions on disable
        private void OnDisable()
        {
            foreach (var action in bindActions)
            {
                action.Key.Disable();
            }
        }
    }
}