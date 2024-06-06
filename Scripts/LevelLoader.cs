using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Button button;
    public Animator transition;
    public float transitionTime;

    private void Start()
    {
        button.onClick.AddListener(OnButtonPressed);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed()
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
