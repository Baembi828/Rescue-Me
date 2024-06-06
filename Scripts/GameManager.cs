using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public GameObject levelFailPanel;
    public GameObject levelPassPanel;
    public int totalCollectibles;
    public int collectedCollectibles;
    public AudioSource levelFail;
    public Animator animator1;
    public Animator animator2;


    private void Start()
    {
        
        Time.timeScale = 1f;
        // Disable the level fail and level pass panels initially
        levelFailPanel.SetActive(false);
        levelPassPanel.SetActive(false);

        // Find all collectibles in the scene and count them
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        totalCollectibles = collectibles.Length;

    }

    public void CollectibleCollected()
    {
        collectedCollectibles++;

        // Check if all collectibles have been collected
        if (collectedCollectibles >= totalCollectibles)
        {
            // Activate the level pass panel
            levelPassPanel.SetActive(true);
            Time.timeScale = 0f;
            animator2.SetTrigger("StartAnimation");


            // Add your level pass logic here
        }
    }
  
    public void LevelFail()
    {
        // Activate the level fail panel
        levelFailPanel.SetActive(true);
        Time.timeScale = 0f;
        levelFail.Play();
        animator1.SetTrigger("StartAnimation");


        // Add your level failure logic here
    }
}