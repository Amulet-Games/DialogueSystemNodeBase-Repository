using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract partial class SegmentFrameBase
    {
        public abstract class ModifierLayout
        <
            TModifier,
            TModifierData,
            TSegmentData
        >
            : SegmentBase
            where TModifier : ModifierFrameBase<TModifier, TModifierData>
            where TModifierData : ModifierDataBase
            where TSegmentData : SegmentDataFrameBase.ModifierLayout<TModifierData>
        {
            /// <summary>
            /// The box UIElement that stores the title and content section's visual elements.
            /// </summary>
            public Box MainBox;


            /// <summary>
            /// List of modifiers.
            /// </summary>
            public List<TModifier> Modifiers;


            /// <summary>
            /// Is segment showing or hidden.
            /// </summary>
            protected bool IsHidden;


            // ----------------------------- Constructor -----------------------------
            /// <summary>
            /// Constructor of the segment frame base class.
            /// </summary>
            public ModifierLayout()
            {
                Modifiers = new();
            }


            // ----------------------------- Callbacks -----------------------------
            /// <summary>
            /// The action to invoke when a modifier is created.
            /// </summary>
            /// <param name="modifier">The new created modifier.</param>
            public void ModifierCreatedAction(TModifier modifier)
            {
                // Add modifier to the internal list.
                Modifiers.Add(modifier);

                // Add box to segment's content box.
                ContentBox.Add(modifier.MainBox);

                // Update isHidden status.
                SetIsHiddenToFalse();

                // Force expand the segment if it's currently closed.
                ForceExpand();
            }


            /// <summary>
            /// The action to invoke when the modifier's remove button is clicked.
            /// </summary>
            /// <param name="modifier">The modifier that is going to be removed.</param>
            public void ModifierRemoveButtonClickAction(TModifier modifier)
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
            /// Save the segment values to the given data.
            /// </summary>
            /// <param name="data">The given data to save to.</param>
            public abstract void SaveSegmentValues(TSegmentData data);


            /// <summary>
            /// Load the segment values from the given data.
            /// </summary>
            /// <param name="data">The given data to load from.</param>
            public abstract void LoadSegmentValues(TSegmentData data);


            /// <summary>
            /// Save the segment values to the given data.
            /// <para></para>
            /// <br>This method is used for saving values between molders only.</br>
            /// <br>If saving values between segments is what you want, use the SaveSegmentValues method instead.</br>
            /// </summary>
            /// <param name="data">The given data to save to.</param>
            public abstract void SaveMolderSegmentValues(TSegmentData data);


            /// <summary>
            /// Load the segment values from the given data.
            /// <para></para>
            /// <br>This method is used for loading values between molders only.</br>
            /// <br>If loading values between segments is what you want, use the LoadSegmentValues method instead.</br>
            /// </summary>
            /// <param name="data">The given data to load from.</param>
            /// <param name="modifierCreatedAction">The action to invoke when a modifier is created.</param>
            /// <param name="modifierRemoveButtonClickAction">The action to invoke when the modifier's remove button is clicked.</param>
            public abstract void LoadMolderSegmentValues
            (
                TSegmentData data,
                Action<TModifier> modifierCreatedAction,
                Action<TModifier> modifierRemoveButtonClickAction
            );


            /// <summary>
            /// Load the isHidden value from the given data.
            /// </summary>
            /// <param name="data">The given data to load from.</param>
            protected void LoadIsHiddenValue(TSegmentData data)
            {
                // Load isHidden state and update the changes.
                IsHidden = data.IsHidden;
                UpdateSegmentIsHidden();
            }


            // ----------------------------- IsHidden Utility -----------------------------
            /// <summary>
            /// Switch the isHidden status and hide itself to show the changes.
            /// </summary>
            protected void SwitchSegmentIsHidden()
            {
                IsHidden = !IsHidden;
                UpdateSegmentIsHidden();
            }


            /// <summary>
            /// Set segment isHidden status to true and hide the segment's main box.
            /// </summary>
            void SetIsHiddenToTrue()
            {
                IsHidden = true;
                VisualElementHelper.HideElement(MainBox);
            }


            /// <summary>
            /// Set segment isHidden status to false and unhide the segment's main box.
            /// </summary>
            void SetIsHiddenToFalse()
            {
                IsHidden = false;
                VisualElementHelper.ShowElement(MainBox);
            }


            // ----------------------------- Update Segment IsHidden Tasks -----------------------------
            /// <summary>
            /// Hide or show segment based on its current isHidden status. 
            /// </summary>
            void UpdateSegmentIsHidden()
            {
                VisualElementHelper.UpdateElementDisplay
                (
                    condition: IsHidden,
                    element: MainBox
                );
            }
        }
    }
}