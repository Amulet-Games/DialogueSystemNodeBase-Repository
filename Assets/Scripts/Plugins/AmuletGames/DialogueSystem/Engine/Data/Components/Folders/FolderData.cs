using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class FolderData
    {
        /// <summary>
        /// The data's isExpand value.
        /// </summary>
        [SerializeField] public bool IsExpand;


        /// <summary>
        /// The data's title text value.
        /// </summary>
        [SerializeField] public string TitleText;
    }
}