using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class FolderData
    {
        /// <summary>
        /// The folder's title text value.
        /// </summary>
        [SerializeField] public string TitleText;


        /// <summary>
        /// The folder's expanded value.
        /// </summary>
        [SerializeField] public bool Expanded;
    }
}