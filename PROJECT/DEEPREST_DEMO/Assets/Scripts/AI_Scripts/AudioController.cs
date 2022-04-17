using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DR.Core
{
    public class AudioController : MonoBehaviour
    {
        private AudioManager audioManager;
        
        void Start()
        {
            audioManager = GetComponent<AudioManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SelectAction(Action actionSelected)
        {
            audioManager.Play(actionSelected.name);
        }
    }
}
