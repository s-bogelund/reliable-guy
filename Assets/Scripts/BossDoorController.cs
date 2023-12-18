using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BossDoorController : MonoBehaviour
{
    public AudioClip doorOpenClip;
    
    public DoorData openDoorData;
    public Tilemap doorTilemap;
    private TilemapCollider2D doorCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        doorCollider = GetComponent<TilemapCollider2D>();
    }

    public void OpenDoor()
    {
        if (doorOpenClip)
            GetComponent<AudioSource>().PlayOneShot(doorOpenClip);
        
        foreach (var tilePosition in openDoorData.doorTilePositions)
        {
            doorTilemap.SetTile(tilePosition.position, tilePosition.tile);
        }
        
        if (doorCollider)
            doorCollider.enabled = false;
    }
}
