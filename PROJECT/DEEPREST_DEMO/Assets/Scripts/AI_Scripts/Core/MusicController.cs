using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DR.US;

namespace DR.Core
{
    public class MusicController : MonoBehaviour
    {
        public AudioController audioController { get; set; }
        public AIBrain aiBrain { get; set; }
        public Action[] actionsAvailable;
        void Start()
        {
            audioController = GetComponent<AudioController>();
            aiBrain = GetComponent<AIBrain>();
        }

        // Update is called once per frame
        void Update()
        {
            if (aiBrain.finishedDeciding)
            {
                aiBrain.finishedDeciding = false;

                aiBrain.bestAction.Execute(this); // Dependency injection
            }
        }

        private void OnFinishedAction()
        {
            aiBrain.DecideBestAction(actionsAvailable);
        }

        #region [Coroutines]
        public void DistortedMusic(string songName)
        {
            StartCoroutine(DistortedCoroutine(songName));
        }

        public void MinorScaledMusic(string songName)
        {
            StartCoroutine(MinorScaledCoroutine(songName));
        }

        public void SlowedMusic(string songName)
        {
            StartCoroutine(SlowedCoroutine(songName));
        }

        public void StridentMusic(string songName)
        {
            StartCoroutine(StridentCoroutine(songName));
        }

        // The actual coroutines

        IEnumerator DistortedCoroutine(string songName)
        {
            // TODO: Implement correct behaviour of coroutine

            yield return new WaitForSeconds(0.5f);
            Debug.Log("SONG " + songName + " IS PLAYING NOW!");

            OnFinishedAction();
        }

        IEnumerator MinorScaledCoroutine(string songName)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("SONG " + songName + " IS PLAYING NOW!");

            OnFinishedAction();
        }

        IEnumerator SlowedCoroutine(string songName)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("SONG " + songName + " IS PLAYING NOW!");

            OnFinishedAction();
        }

        IEnumerator StridentCoroutine(string songName)
        {
            yield return new WaitForSeconds(0.5f);
            //yield return null;
            Debug.Log("SONG " + songName + " IS PLAYING NOW!");

            OnFinishedAction();
        }

        #endregion
    }
}

