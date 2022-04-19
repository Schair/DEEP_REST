using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DR.Core;
using DR.US;

namespace DR.US.Considerations
{
    [CreateAssetMenu(fileName = "Stress", menuName = "AI_Scripts/US/Considerations/Stress")]
    public class Stress : Consideration
    {
        public override float ScoreConsideration()
        {
            return 0.9f;
        }
    }
}
