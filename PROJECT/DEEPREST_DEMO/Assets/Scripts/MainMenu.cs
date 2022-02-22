using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public Animator transition;

    public float transitionTime = 1.0f;

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().FadeOutOne("THEME");
        LoadNextLevel();
    }

    public void QuitGame()
    {
        Debug.Log("GAME CLOSED");
        Application.Quit();
    }

    public void LoadNextLevel(){
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){
        // Play animation
        transition.SetTrigger("Start");
        // Wait
        yield return new WaitForSeconds(transitionTime);
        // Load Scene
        SceneManager.LoadScene(levelIndex);
    }
}

