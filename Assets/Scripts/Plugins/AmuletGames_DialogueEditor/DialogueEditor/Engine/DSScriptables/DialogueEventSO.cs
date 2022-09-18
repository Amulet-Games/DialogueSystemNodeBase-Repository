using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    [Serializable]
    public abstract class DialogueEventSO : ScriptableObject
    {
        public abstract void Execute();
    }
}