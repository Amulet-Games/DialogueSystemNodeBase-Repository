using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class MessageModifierGroupModel
    {
        /// <summary>
        /// The group's message modifier models.
        /// </summary>
        [SerializeField] public MessageModifierModel[] ModifierModels;
    }
}