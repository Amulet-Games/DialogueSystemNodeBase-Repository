using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class FolderData
    {
        /// <summary>
        /// The data's isExpanded value.
        /// </summary>
        [SerializeField] public bool IsExpanded;


        /// <summary>
        /// The data's title text value.
        /// </summary>
        [SerializeField] public string TitleText;
    }
}