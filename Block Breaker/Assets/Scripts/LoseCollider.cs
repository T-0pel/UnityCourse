using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager LevelManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelManager = FindObjectOfType<LevelManager>();
        LevelManager.LoadLevel("Lose");
    }
}
