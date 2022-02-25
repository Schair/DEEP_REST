using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossfadeAnimation : MonoBehaviour
{
   public Animator transition;
   public bool startFade = false;

   public float transitionTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if(startFade)
        {
            LoadNextLevel();
            startFade = false;
        }
    }

    public void LoadNextLevel(){
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
