using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DR.US;
using DR.Core;

namespace DR.US.Actions
{
    [CreateAssetMenu(fileName = "Strident", menuName ="AI_Scripts/US/Actions/Strident")]
    public class Strident : Action
    {
        public override void Execute(MusicController music)
        {
            music.StridentMusic("STRIDENT");
        }
    }
}
