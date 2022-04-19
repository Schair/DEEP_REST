using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DR.Core;
using DR.US;

namespace DR.US.Considerations
{
    [CreateAssetMenu(fileName = "Hunger", menuName = "AI_Scripts/US/Considerations/Hunger")]
    public class Hunger : Consideration
    {
        public override float ScoreConsideration()
        {
            return 0.2f;
        }
    }
}
