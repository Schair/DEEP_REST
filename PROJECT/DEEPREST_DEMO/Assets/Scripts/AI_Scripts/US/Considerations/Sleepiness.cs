using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DR.Core;
using DR.US;

namespace DR.US.Considerations
{
    [CreateAssetMenu(fileName = "Sleepiness", menuName = "AI_Scripts/US/Considerations/Sleepiness")]
    public class Sleepiness : Consideration
    {
        public override float ScoreConsideration()
        {
            return 0.2f;
        }
    }
}