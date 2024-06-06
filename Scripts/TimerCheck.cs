using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class TimerCheck : MonoBehaviour
{
    public float WaitSec;
    private int WaitsecInt;
    public TextMeshProUGUI myText;
    public GameObject collectiblesParent;
    private int remainingCollectibles;
    public GameManager gameManager;

    private void Start()
    {
        remainingCollectibles = collectiblesParent.transform.childCount;
    }
    private void FixedUpdate()
    {
        if (WaitSec > 0)
        {
            WaitSec -= Time.fixedDeltaTime;
            WaitsecInt = (int)WaitSec;
            myText.text = WaitsecInt.ToString();
        }
        else
        {
            CheckRemainingCollectibles();
        }
    }
    private void CheckRemainingCollectibles()
    {
        remainingCollectibles = collectiblesParent.transform.childCount;

        if (remainingCollectibles == 0)
        {
            // All collectibles collected, level success logic here
            // For example, load the next level or display a success message
        }
        else
        {
            // Collectibles remaining, level failure logic here
            // For example, reload the current scene or display a failure message
            gameManager.LevelFail();
        }
    }
}