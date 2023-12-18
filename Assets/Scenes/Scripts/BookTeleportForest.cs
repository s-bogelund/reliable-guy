using System.Collections;
using System.Collections.Generic;
using Scenes.Scripts;
using UnityEngine;

public class BookTeleportForest : SceneChangeTrigger
{
    public AudioSource audioSource;
    public float interactionDistance = 2f; // Distance within which interaction is possible
    private PlayerController _playerController; // Reference to the PlayerController script
    private SpriteRenderer _playerSpriteRenderer;
    public GameObject player;
    private bool _isInitialized = false;
    public SpriteRenderer spriteRenderer;
    
    void Start()
    {
        // Find the player's GameObject and get the required components
        player = GameObject.FindGameObjectWithTag("Player"); // Ensure your player GameObject has the "Player" tag
        _playerController = player.GetComponent<PlayerController>();
        _playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        
        // TODO: SHOULD BE FALSE WHEN GAMEMANAGER IS IMPLEMENTED
        spriteRenderer.enabled = false;
    }
    
    void Update()
    {
        // REMOVE COMMENTATION WHEN GAMEMANAGER HAS BEEN IMPLEMENTED
        
        // if (!_isInitialized && GameManager.Instance.SecondLevelCompleted)
        // {
        //     gameObject.SetActive(true);
        //     _isInitialized = true;
        // }
        //
        // if (!GameManager.Instance.SecondLevelCompleted || !gameObject.activeSelf)
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
            StartCoroutine(PlaySoundThenChangeScene());
        }
    }

    IEnumerator PlaySoundThenChangeScene()
    {
        audioSource.Play();

        // Wait for the specified delay
        yield return new WaitForSeconds(0.5f);

        TriggerSceneChange();
    }

    protected override void TriggerSceneChange()
    {
        Vector2 playerPosition = new Vector2(0.602f, -2.494f);    
        player.transform.position = playerPosition;
            
        LoadSceneByName("Town");
    }
}
