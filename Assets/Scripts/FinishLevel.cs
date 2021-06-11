using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.EndLevel();
    }
}
