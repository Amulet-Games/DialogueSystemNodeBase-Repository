using System;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public abstract class DSModifierFrameBase<TModifier>
        where TModifier : DSModifierFrameBase<TModifier>
    {
        /// <summary>
        /// A box container that store all the visual elements of its content.
        /// </summary>
        public Box MainBox;


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this modifier as root.
        /// </summary>
        /// <param name="node">Node of which this modifier is created for.</param>
        public abstract void SetupRootModifier(DSNodeBase node);


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save modifier's value from another previously create modifier.
        /// </summary>
        /// <param name="source">The modifier of which its values are going to be saved.</param>
        public abstract void SaveModifierValue(TModifier source);


        /// <summary>
        /// Load modifier's value from another previously saved modifier.
        /// </summary>
        /// <param name="source">The modifier that was previously saved and now it's used to load from.</param>
        public abstract void LoadModifierValue(TModifier source);
    }
}