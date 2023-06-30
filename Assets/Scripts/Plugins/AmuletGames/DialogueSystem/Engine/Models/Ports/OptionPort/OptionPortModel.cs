using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortModel : PortModelBase
    {
        /// <summary>
        /// The port's label text value.
        /// </summary>
        [SerializeField] public string LabelText;
    }
}