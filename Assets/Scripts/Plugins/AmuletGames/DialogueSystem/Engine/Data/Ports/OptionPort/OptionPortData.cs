using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortData : PortDataBase
    {
        /// <summary>
        /// The data's label text value.
        /// </summary>
        [SerializeField] public string LabelText;
    }
}