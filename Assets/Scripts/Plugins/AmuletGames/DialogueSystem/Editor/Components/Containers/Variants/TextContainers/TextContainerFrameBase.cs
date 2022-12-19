using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public abstract class TextContainerFrameBase : ContainerFrameBase
    {
        /// <summary>
        /// The text that'll show up in the field when there's no actual content within it.
        /// </summary>
        [NonSerialized] public string PlaceholderText;


        /// <summary>
        /// Visual element
        /// </summary>
        [NonSerialized] public TextField TextField;
    }
}