using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DR.Core;

namespace DR.US
{
    public class AIBrain : MonoBehaviour
    {
        public Action bestAction { get; set; }
        private MusicController musicController;

        public bool finishedDeciding { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            musicController = GetComponent<MusicController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (bestAction == null)
            {
                DecideBestAction(musicController.actionsAvailable);
            }
        }

        // Iterate through the available actions and choose the highest score of all
        public void DecideBestAction(Action[] actionsAvailable)
        {
            float score = 0.0f;
            int nextBestActionId = 0;
            for (int i = 0; i < actionsAvailable.Length; i++)
            {
                if (ScoreAction(actionsAvailable[i]) > score)
                {
                    nextBestActionId = i;
                    score = actionsAvailable[i].score;
                }
            }

            bestAction = actionsAvailable[nextBestActionId];

            finishedDeciding = true;
        }

        // Iterate thriugh all the considerations of the action given,
        // score the considerations
        // Average the consideration scores resulting in an overall action score.
        public float ScoreAction(Action action)
        {
            float score = 1.0f;

            for (int i = 0; i < action.considerations.Length; i++)
            {
                float considerationScore = action.considerations[i].ScoreConsideration();
                score *= considerationScore;

                if(score == 0)
                {
                    action.score = 0;
                    return action.score; // No point computing further, sonething * 0 is always 0
                }
            }

            // Average scheme of overall score
            float originalScore = score;
            float modificationFactor = 1 - (1 / action.considerations.Length);
            float makeupValue = (1 - originalScore) * modificationFactor;
            action.score = originalScore + (makeupValue * originalScore);

            return action.score;
        }
    }
}
