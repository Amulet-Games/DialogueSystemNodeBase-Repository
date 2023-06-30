using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class FolderModel
    {
        /// <summary>
        /// The folder's isExpand value.
        /// </summary>
        [SerializeField] public bool IsExpand;


        /// <summary>
        /// The folder's title text value.
        /// </summary>
        [SerializeField] public string TitleText;
    }
}