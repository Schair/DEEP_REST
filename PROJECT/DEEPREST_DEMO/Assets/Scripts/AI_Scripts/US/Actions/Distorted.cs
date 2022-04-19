using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DR.US;
using DR.Core;

namespace DR.US.Actions
{
    [CreateAssetMenu(fileName = "Distorted", menuName = "AI_Scripts/US/Actions/Distorted")]
    public class Distorted : Action
    {
        public override void Execute(MusicController music)
        {
            music.StridentMusic("DISTORTED");
        }
    }
}
