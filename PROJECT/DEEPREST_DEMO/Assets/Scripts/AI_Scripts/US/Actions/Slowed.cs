using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DR.US;
using DR.Core;

namespace DR.US.Actions
{
    [CreateAssetMenu(fileName = "Slowed", menuName = "AI_Scripts/US/Actions/Slowed")]
    public class Slowed : Action
    {
        public override void Execute(MusicController music)
        {
            music.StridentMusic("SLOWED");
        }
    }
}
