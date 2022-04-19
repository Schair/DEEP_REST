using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DR.US;
using DR.Core;

namespace DR.US.Actions
{
    [CreateAssetMenu(fileName = "MinorScaled", menuName = "AI_Scripts/US/Actions/MinorScaled")]
    public class MinorScaled : Action
    {
        public override void Execute(MusicController music)
        {
            music.StridentMusic("MINOR_SCALED");
        }
    }
}
