using Controls;
using UnityEngine;

public class EnableSwordAttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float interactionDistance = 2f; // Distance within which interaction is possible
    private PlayerController _playerController; // Reference to the PlayerController script
    private SpriteRenderer _playerSpriteRenderer;
    private InputHandler _inputHandler;

    public GameObject player;

    void Start()
    {
        // if(gameManager == null)
        //     gameObject.GetComponent<GameManager>();
        
        player = GameObject.FindGameObjectWithTag("Player"); // Ensure your player GameObject has the "Player" tag
        _playerController = player.GetComponent<PlayerController>();
        _playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        _inputHandler = player.GetComponent<InputHandler>();

        
        gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _playerController.transform.position) <= interactionDistance && IsPlayerFacingItem())
        {
            CheckForInteractionInput();
        }
    }
    
    void CheckForInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            gameObject.SetActive(false);
        }
    }
    bool IsPlayerFacingItem()
    {
        Vector3 directionToItem = (transform.position - _playerController.transform.position).normalized;
        bool isFacingRight = !_playerSpriteRenderer.flipX;
        float dotProduct = Vector3.Dot(isFacingRight ? Vector3.right : Vector3.left, directionToItem);
        return dotProduct > 0;
    }
    
}
