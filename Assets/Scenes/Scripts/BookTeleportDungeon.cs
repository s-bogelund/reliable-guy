using System.Collections;
using Controls;
using Scenes.Scripts;
using UnityEngine;

public class BookTeleportDungeon : SceneChangeTrigger
{
    public AudioSource audioSource;
    public float interactionDistance = 2f; // Distance within which interaction is possible
    private PlayerController _playerController; // Reference to the PlayerController script
    private SpriteRenderer _playerSpriteRenderer;
    private InputHandler _inputHandler;
    public GameObject player;
    private bool _isInitialized = false;
    
    void Start()
    {
        // Find the player's GameObject and get the required components
        player = GameObject.FindGameObjectWithTag("Player");

        _playerController = player.GetComponent<PlayerController>();
        _inputHandler = player.GetComponent<InputHandler>();
        
        _playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        // TODO: SHOULD BE FALSE WHEN GAMEMANAGER IS IMPLEMENTED
        gameObject.SetActive(true);
    }
    
    void Update()
    {
        
        if (Vector3.Distance(transform.position, _playerController.transform.position) <= interactionDistance && IsPlayerFacingItem())
        {
            CheckForInteractionInput();
        }
    }

    bool IsPlayerFacingItem()
    {
        Vector3 directionToItem = (transform.position - player.transform.position).normalized;
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
        Vector2 playerPosition = new Vector2(-0.42f, 4.05f);
        player.transform.position = playerPosition; 
        LoadSceneByName("Biome2_Forest");
    }
}
