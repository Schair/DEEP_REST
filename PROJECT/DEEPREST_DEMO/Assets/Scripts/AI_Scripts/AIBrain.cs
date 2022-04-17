using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DR.Core
{
    public class AIBrain : MonoBehaviour
    {
        public Action bestAction { get; set; }
        private MusicController musicController;
        // Start is called before the first frame update
        void Start()
        {
            musicController = GetComponent<MusicController>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void DecideBestAction(Action[] actionsAvailable)
        {

        }

        public void ScoreAction(Action action)
        {

        }
    }
}
