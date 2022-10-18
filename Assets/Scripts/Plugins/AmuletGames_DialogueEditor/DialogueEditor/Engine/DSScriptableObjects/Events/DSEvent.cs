using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public abstract class DSEvent : ScriptableObject
    {
        public abstract void Execute();
    }
}