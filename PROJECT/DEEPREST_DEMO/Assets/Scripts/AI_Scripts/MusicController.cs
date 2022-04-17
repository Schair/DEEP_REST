using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        }
    }
}

