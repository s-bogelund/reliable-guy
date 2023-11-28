using System.Collections;
using System.Collections.Generic;
using Controls;
using Scenes.Scripts;
using UnityEngine;

public class BookTeleportDungeon : SceneChangeTrigger
{
    public float interactionDistance = 2f; // Distance within which interaction is possible
    private PlayerController _playerController; // Reference to the PlayerController script
    private SpriteRenderer _playerSpriteRenderer;
    private InputHandler _inputHandler;
    
    private bool _isInitialized = false;
    void Start()
    {
        // Find the player's GameObject and get the required components
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Ensure your player GameObject has the "Player" tag
        _playerController = player.GetComponent<PlayerController>();
        _inputHandler = player.GetComponent<InputHandler>();

        _playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        
        // TODO: SHOULD BE FALSE WHEN GAMEMANAGER IS IMPLEMENTED
        gameObject.SetActive(true);
    }
    
    void Update()
    {
        // REMOVE COMMENTATION WHEN GAMEMANAGER HAS BEEN IMPLEMENTED
        
        // if (!_isInitialized && GameManager.Instance.FirstLevelCompleted)
        // {
        //     gameObject.SetActive(true);
        //     _isInitialized = true;
        // }
        //
        // if (!GameManager.Instance.FirstLevelCompleted || !gameObject.activeSelf)
        //     return;
        
        if (Vector3.Distance(transform.position, _playerController.transform.position) <= interactionDistance && IsPlayerFacingItem())
        {
            CheckForInteractionInput();
        }
    }

    bool IsPlayerFacingItem()
    {
        Vector3 directionToItem = (transform.position - _playerController.transform.position).normalized;
        bool isFacingRight = !_playerSpriteRenderer.flipX;
        float dotProduct = Vector3.Dot(isFacingRight ? Vector3.right : Vector3.left, directionToItem);
        return dotProduct > 0;
    }

    void CheckForInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            TriggerSceneChange();
        }
    }

    protected override void TriggerSceneChange()
    {
        LoadSceneByName("Biome2_Forest");
    }
}
