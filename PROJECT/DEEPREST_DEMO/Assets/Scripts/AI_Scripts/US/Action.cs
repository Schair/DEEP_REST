using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DR.Core;

namespace DR.US
{
    public abstract class Action : ScriptableObject
    {
        public string name;
        private float _score;
        public float score
        {
            get { return _score; }
            set
            {
                this._score = Mathf.Clamp01(value);
            }
        }

        public Consideration[] considerations;

        public virtual void Awake()
        {
            score = 0.0f;
        }

        public abstract void Execute(MusicController music);
    }
}
