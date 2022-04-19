using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DR.Core;
using DR.US;

namespace DR.US.Considerations
{
    [CreateAssetMenu(fileName = "Happiness", menuName = "AI_Scripts/US/Considerations/Happiness")]
    public class Happiness : Consideration
    {
        public override float ScoreConsideration()
        {
            return 0.95f;
        }
    }
}
