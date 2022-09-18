using System.Collections.Generic;
using System;
using UnityEngine.UIElements;

namespace AG
{
    public abstract partial class DSSegmentFrameBase
    {
        [Serializable]
        public abstract class T2<TSegment, TModifier>
        : DSSegmentBase
        where TSegment : DSSegmentBase
        where TModifier : DSModifierFrameBase<TModifier>
        {
            /// <summary>
            /// Is segment showing or hidden.
            /// </summary>
            public bool IsHidden;


            /// <summary>
            /// A box container that stores the title box and content box.
            /// </summary>
            public Box MainBox;


            /// <summary>
            /// List of modifiers.
            /// </summary>
            public List<TModifier> Modifiers;


            // ----------------------------- Callbacks -----------------------------
            /// <summary>
            /// Action that invoked after modifier is added.
            /// </summary>
            /// <param name="modifier">The new created modifier that'll be added to segment list.</param>
            public void ModifierAddedAction(TModifier modifier)
            {
                // Add modifier to the internal list.
                Modifiers.Add(modifier);

                // Update isHidden status.
                SetIsHiddenToFalse();

                // Add box to segment's content box.
                ContentBox.Add(modifier.MainBox);
            }


            /// <summary>
            /// Action that invoked after modifier is removed.
            /// </summary>
            /// <param name="modifier">The modifier that'll be removed from segment list.</param>
            public void ModifierRemovedAction(TModifier modifier)
            {
                // Remove modifier from the internal list.
                Modifiers.Remove(modifier);

                // Update isHidden status.
                if (Modifiers.Count < 1)
                {
                    SetIsHiddenToTrue();
                }

                // Delete box from segment's content box.
                ContentBox.Remove(modifier.MainBox);
            }


            // ----------------------------- Serialization -----------------------------
            /// <summary>
            /// Save segment's value from another previously created segment.
            /// </summary>
            /// <param name="source">The segment of which it's values are going to be saved in.</param>
            public abstract void SaveSegmentValues(TSegment source);


            /// <summary>
            /// Load segment's value from another previously saved segment.
            /// <para></para>
            /// <br>This method is used for loading values between segments only.</br>
            /// <br>If loading values between molders is what you want, use the LoadMolderSegmentValues method instead.</br>
            /// </summary>
            /// <param name="source">The segment that was previously saved and now it's used to load from.</param>
            public abstract void LoadSegmentValues(TSegment source);


            /// <summary>
            /// Load molder segment's value from another previously saved molder segment.
            /// <para></para>
            /// <br>This method is used for loading values between molders only.</br>
            /// <br>If loading values between segments is what you want, use the LoadSegmentValues method instead.</br>
            /// </summary>
            /// <param name="source">The molder segment that was previously saved and now it's used to load from.</param>
            /// <param name="modifierAddedAction">Action that invoked after modifier is added.</param>
            /// <param name="modifierRemovedAction">Action that invoked after modifier is removed.</param>
            public abstract void LoadMolderSegmentValues(TSegment source, Action<TModifier> modifierAddedAction, Action<TModifier> modifierRemovedAction);


            // ----------------------------- Change IsHidden Status Services -----------------------------
            /// <summary>
            /// Switch the isHidden status and hide itself to show the changes.
            /// </summary>
            protected void SwitchSegmentIsHidden()
            {
                IsHidden = !IsHidden;
                RefreshSegmentIsHidden();
            }


            /// <summary>
            /// Load isHidden status from another saved SegmentFrameBase.T2 and hide or show itself to show the changes.
            /// </summary>
            /// <param name="source">The SegmentFrameBase.T2 that was previously saved and now it's used to load from.</param>
            protected void LoadIsHiddenValue(T2<TSegment, TModifier> source)
            {
                // Load isHidden state and update the changes.
                IsHidden = source.IsHidden;
                RefreshSegmentIsHidden();
            }


            /// <summary>
            /// Set segment isHidden status to true and hide the segment's main box.
            /// </summary>
            void SetIsHiddenToTrue()
            {
                IsHidden = true;
                DSElementDisplayUtility.HideElement(MainBox);
            }


            /// <summary>
            /// Set segment isHidden status to false and unhide the segment's main box.
            /// </summary>
            void SetIsHiddenToFalse()
            {
                IsHidden = false;
                DSElementDisplayUtility.ShowElement(MainBox);
            }


            /// <summary>
            /// Hide or show segment based on its current isHidden status. 
            /// </summary>
            void RefreshSegmentIsHidden()
            {
                DSElementDisplayUtility.ToggleElementDisplay(IsHidden, MainBox);
            }
        }
    }
}