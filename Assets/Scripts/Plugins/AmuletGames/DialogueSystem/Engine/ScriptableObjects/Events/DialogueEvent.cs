using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable, CreateAssetMenu(menuName = "### AG ###/Dialogue System/New Dialogue Event")]
    public abstract class DialogueEvent : ScriptableObject
    {
        public abstract void Execute();
    }
}