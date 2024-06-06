using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNext : MonoBehaviour
{
    // Start is called before the first frame update
    public int lastLevelBuildIndex = 11; // Change this value to your last level build index
    public int nextSceneLoad; // Set this value to the build index of the next scene to load

    public void OnButtonPressed()
    {
        if (SceneManager.GetActiveScene().buildIndex == lastLevelBuildIndex)
        {
            Debug.Log("You Completed ALL Levels");

            // Show Win Screen or Something
        }
        else
        {
            // Move to next level
            SceneManager.LoadScene(nextSceneLoad);

            // Set Int for Index
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }
}
