using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 2;
    public bool theDamageWasDone;

    public bool Hit() //игрок стукнулся
    {
        theDamageWasDone = true;
        if (health == 0)
        {
            return false;
        }
        else
        {
            health--;
            return true;
        }

    }
}
