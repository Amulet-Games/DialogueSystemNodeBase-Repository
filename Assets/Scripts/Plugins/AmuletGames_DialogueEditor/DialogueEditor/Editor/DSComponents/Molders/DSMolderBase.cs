using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public abstract class DSMolderBase<TSegment, TModifier>
        where TSegment : DSSegmentFrameBase.T2<TSegment, TModifier>
        where TModifier : DSModifierFrameBase<TModifier>
    {
        /// <summary>
        /// Root condition modifier.
        /// <br>Appears when there's only one condition modifier on the node.</br>
        /// </summary>
        protected TModifier MolderRootModifier;


        /// <summary>
        /// Condition Segment.
        /// <br>Appears when there's are multiple condition modifiers on the node.</br>
        /// <br>This segment requires to have one condition modifier always.</br>
        /// </summary>
        protected TSegment MolderSegment;


        /// <summary>
        /// Internal condition modifiers' count.
        /// </summary>
        [NonSerialized] int molderInternalCount = 0;


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this molder.
        /// </summary>
        /// <param name="node">Node of which this molder is created for.</param>
        /// <param name="contentButtonName">The text that'll appear on the content button as a label.</param>
        /// <param name="contentButtonSprite">The sprite icon that'll appear on the content button next to it's text label.</param>
        /// <param name="contentButtonIconImageUSS01">The style for the content button icon image to use when it appeared on the editor window</param>
        public void GetNewMolder(DSNodeBase node, string contentButtonName, Sprite contentButtonSprite, string contentButtonIconImageUSS01)
        {
            AddContentButton_MolderInstanceModifier();

            AddMolderRootModifier();

            AddMolderSegment();

            void AddContentButton_MolderInstanceModifier()
            {
                DSIntegrantsMaker.GetNewContentButton(node, contentButtonName, contentButtonSprite, contentButtonIconImageUSS01, () => IntegrantButtonPressedAction(node));
            }

            void AddMolderRootModifier()
            {
                MolderRootModifier.SetupRootModifier(node);
            }

            void AddMolderSegment()
            {
                MolderSegment.SetupSegment(node);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked after content button is pressed.
        /// </summary>
        protected void IntegrantButtonPressedAction(DSNodeBase node)
        {
            // If this is the first time adding a new instance modifier,
            // create a default one first to represent the root modifier. 
            if (molderInternalCount == 0)
            {
                AddInstanceModifier();
            }

            // Then create the second one as the user wanted.
            AddInstanceModifier();

            // Change the molder to mainly show instance modifiers
            ShowSegmentOnly();

            // Lastly, load the data from the rooted modifier to the first instance modifier.
            MolderSegment.Modifiers[0].LoadModifierValue(MolderRootModifier);
        }


        /// <summary>
        /// Action that invoked after modifier is added.
        /// </summary>
        /// <param name="modifier">The modifier that'll be added to the molder's segment list.</param>
        protected void ModifierAddedAction(TModifier modifier)
        {
            // Add modifier to node's data
            MolderSegment.Modifiers.Add(modifier);

            // Add box to segment's content box
            MolderSegment.ContentBox.Add(modifier.MainBox);

            // Increase internal count.
            molderInternalCount++;
        }


        /// <summary>
        /// Action that invoked after modifier is removed.
        /// </summary>
        /// <param name="modifier">The modifier that'll be removed from the molder's segment list.</param>
        protected void ModifierRemovedAction(TModifier modifier)
        {
            // Decrease internal count.
            molderInternalCount--;

            // Remove modifier from node's data.
            MolderSegment.Modifiers.Remove(modifier);

            // Delete box from segment's content box
            MolderSegment.ContentBox.Remove(modifier.MainBox);

            // Check if there's only one instance modifier left,
            // if so, switch back to mainly show root modifier only.
            if (molderInternalCount == 1)
            {
                // Hide the segment's main box.
                ShowRootModifierOnly();

                // Load data from the last modifier in segment list, to rooted modifier
                MolderRootModifier.LoadModifierValue(MolderSegment.Modifiers[0]);
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save molder's value from another previously created molder.
        /// </summary>
        /// <param name="source">The molder of which it's values are going to be saved in.</param>
        public void SaveMolderValues(DSMolderBase<TSegment, TModifier> source)
        {
            // Save molder's root modifier.
            MolderRootModifier.SaveModifierValue(source.MolderRootModifier);

            // Save molder's segment.
            MolderSegment.SaveSegmentValues(source.MolderSegment);
        }


        /// <summary>
        /// Load molder's value from another previously saved segment.
        /// </summary>
        /// <param name="node">The selected node where the new molder is loading for.</param>
        /// <param name="source">The molder that were previously saved and now it's going to be to load from.</param>
        public void LoadMolderValues(DSMolderBase<TSegment, TModifier> source)
        {
            // Load molder's root modifier.
            MolderRootModifier.LoadModifierValue(source.MolderRootModifier);

            // Load molder's segment.
            MolderSegment.LoadSegmentValues(source.MolderSegment, ModifierAddedAction, ModifierRemovedAction);

            // Update molder's cotent.
            ToggleShowSegmentOrRootModifier(molderInternalCount > 1);
        }


        // ----------------------------- Add Modifier Services -----------------------------
        /// <summary>
        /// Ask DSModifierMaker to create a new instance modifier for the molder.
        /// </summary>
        protected abstract void AddInstanceModifier();


        // ----------------------------- Switch Molder Content Services -----------------------------
        /// <summary>
        /// Show segment and hide root modifier.
        /// </summary>
        void ShowRootModifierOnly()
        {
            DSFieldUtility.HideElement(MolderSegment.MainBox);
            DSFieldUtility.ShowElement(MolderRootModifier.MainBox);
        }


        /// <summary>
        /// Show root modifier and hide segment.
        /// </summary>
        void ShowSegmentOnly()
        {
            DSFieldUtility.ShowElement(MolderSegment.MainBox);
            DSFieldUtility.HideElement(MolderRootModifier.MainBox);
        }


        /// <summary>
        /// Show either segment or root modifier based on given boolean value.
        /// </summary>
        /// <param name="isShowSegment">Is show segmet and hide root modifier?</param>
        void ToggleShowSegmentOrRootModifier(bool isShowSegment)
        {
            if (isShowSegment)
            {
                ShowSegmentOnly();
            }
            else
            {
                ShowRootModifierOnly();
            }
        }
    }
}