using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void PauseGame()
    {
        Time.timeScale = 0f; // Set time scale to 0 to pause the game
    }
}
