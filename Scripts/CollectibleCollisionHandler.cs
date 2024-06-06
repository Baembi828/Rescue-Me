using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollisionHandler : MonoBehaviour
{
    // Reference to the game manager script
    public GameManager gameManager;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered");

        if (other.CompareTag("Enemy"))
        {
            // Collided with an enemy, call the level fail method in the game manager
            gameManager.LevelFail();

            // Destroy the collectible
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            gameManager.CollectibleCollected();
            Destroy(gameObject);
        }
    }
}