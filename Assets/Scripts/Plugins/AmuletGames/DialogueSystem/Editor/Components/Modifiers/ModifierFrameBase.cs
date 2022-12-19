using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public abstract class ModifierFrameBase
    <
        TModifier,
        TModifierData
    >
        where TModifier : ModifierFrameBase<TModifier, TModifierData>
        where TModifierData : ModifierDataBase
    {
        /// <summary>
        /// A box container that store all the visual elements of its content.
        /// </summary>
        public Box MainBox;


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in the root modifier.
        /// </summary>
        /// <param name="node">Node of which this modifier is created for.</param>
        public abstract void CreateRootElements(NodeBase node);


        /// <summary>
        /// Create all the UIElements that are needed in the instance modifier.
        /// <br>Specific which segment to store the modifier in modifierAddedAction.</br>
        /// </summary>
        /// <param name="data">The modifier data to load from.</param>
        /// <param name="addToSegmentAction">Action that invoked at the end when the modifier is created and ready to be added to the segment.</param>
        /// <param name="removeFromSegmentAction">Action to invoke when this modifier is deleted from the segment.</param>
        public abstract void CreateInstanceElements
        (
            TModifierData data,
            Action<TModifier> addToSegmentAction,
            Action<TModifier> removeFromSegmentAction
        );


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked at the end when the modifier is created.
        /// <br>The callback action is optional and depends on the modifier it may not be needed.</br>
        /// </summary>
        public virtual void ModifierCreatedAction() { }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the modifier values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public abstract void SaveModifierValue(TModifierData data);


        /// <summary>
        /// Load the modifier values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public abstract void LoadModifierValue(TModifierData data);
    }
}