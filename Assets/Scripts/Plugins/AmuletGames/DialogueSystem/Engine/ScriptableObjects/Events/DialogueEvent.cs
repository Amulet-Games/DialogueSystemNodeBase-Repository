using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public abstract class DialogueEvent : ScriptableObject
    {
        public abstract void Execute();
    }
}