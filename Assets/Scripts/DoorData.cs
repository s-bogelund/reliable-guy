using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "DoorData", menuName="Data/Door Data", order = 1)]
public class DoorData : ScriptableObject
{
    [System.Serializable]
    public struct TilePosition
    {
        public TileBase tile;
        public Vector3Int position;
    }
    
    public TilePosition[] doorTilePositions;
}
