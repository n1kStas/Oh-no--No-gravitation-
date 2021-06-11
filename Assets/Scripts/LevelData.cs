using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public string nameLevel;
    public Vector2 maxPositionCamera;
    public Vector2 minPositionCamera;    
    public bool playerMovementInAllDirections;

    public bool theDamageWasDone;
    public int numberOfMoves;
    public int levelPassingSecond;
}
