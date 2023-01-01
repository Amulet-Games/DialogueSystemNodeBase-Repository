using UnityEngine;

namespace AG.DS
{
    public abstract class MolderFrameBase
    <
        TModifier,
        TModifierData,
        TSegment,
        TSegmentData,
        TMolderData
    >
        where TModifier : ModifierFrameBase<TModifier, TModifierData>, new()
        where TModifierData : ModifierDataBase, new()
        where TSegment : SegmentFrameBase.ModifierLayout<TModifier, TModifierData, TSegmentData>, new()
        where TSegmentData : SegmentDataFrameBase.ModifierLayout<TModifierData>, new()
        where TMolderData : MolderDataFrameBase<TModifierData, TSegmentData>
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
        /// Temporary use modifier data.
        /// </summary>
        TModifierData temporaryModifierData;


        /// <summary>
        /// Internal modifier's counter.
        /// </summary>
        int modifierCounter = 0;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the molder frame base class.
        /// </summary>
        public MolderFrameBase()
        {
            MolderRootModifier = new();
            MolderSegment = new();
            temporaryModifierData = new();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in the molder.
        /// </summary>
        /// <param name="node">Node of which this molder is created for.</param>
        /// <param name="contentBtnText">The text that'll appear on the content button as a label.</param>
        /// <param name="contentBtnSprite">The sprite icon that'll appear on the content button next to it's text label.</param>
        /// <param name="contentBtnIconImageUSS01">The style for the content button icon image to use when it appeared on the editor window</param>
        public void GetNewMolder
        (
            NodeBase node,
            string contentBtnText,
            Sprite contentBtnSprite,
            string contentBtnIconImageUSS01
        )
        {
            AddContentButton_MolderInstanceModifier();

            AddMolderSegment();

            AddMolderRootModifier();

            AddInitialInstanceModifier();

            void AddContentButton_MolderInstanceModifier()
            {
                ButtonFactory.CreateNewContentButton
                (
                    node: node,
                    buttonText: contentBtnText,
                    buttonIconSprite: contentBtnSprite,
                    buttonClickAction: ContentButtonClickAction,
                    buttonIconUSS01: contentBtnIconImageUSS01
                );
            }

            void AddMolderSegment()
            {
                MolderSegment.CreateRootElements(node);
            }

            void AddMolderRootModifier()
            {
                MolderRootModifier.CreateRootElements(node);
            }

            void AddInitialInstanceModifier()
            {
                AddInstanceModifier();
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked after the content button is clicked.
        /// <para>See: <see cref="GetNewMolder"/></para>
        /// </summary>
        protected void ContentButtonClickAction()
        {
            // If this is the first time user adding a new instance modifier through content button.
            if (modifierCounter == 1)
            {
                // Load the root modifier's data to the initial instance modifier.
                MolderRootModifier.SaveModifierValue(temporaryModifierData);
                MolderSegment.Modifiers[0].LoadModifierValue(temporaryModifierData);

                // and change the molder to mainly show instance modifiers.
                ShowSegmentOnly();
            }
            
            // Lastly, Create a new one as the user wanted.
            AddInstanceModifier();
        }


        /// <summary>
        /// The action to invoke when a modifier is created.
        /// </summary>
        /// <param name="modifier">The new created modifier.</param>
        protected void ModifierCreatedAction(TModifier modifier)
        {
            // Add modifier to node's data
            MolderSegment.Modifiers.Add(modifier);

            // Add box to segment's content box
            MolderSegment.ContentBox.Add(modifier.MainBox);

            // Force expand the segment if it's currently closed.
            MolderSegment.ForceExpand();

            // Increase internal count.
            modifierCounter++;
        }


        /// <summary>
        /// The action to invoke when the modifier's remove button is clicked.
        /// </summary>
        /// <param name="modifier">The modifier that is going to be removed.</param>
        protected void ModifierRemoveButtonClickAction(TModifier modifier)
        {
            // Decrease internal count.
            modifierCounter--;

            // Remove modifier from node's data.
            MolderSegment.Modifiers.Remove(modifier);

            // Delete box from segment's content box
            MolderSegment.ContentBox.Remove(modifier.MainBox);

            // Check if there's only one instance modifier left,
            // if so, switch back to mainly show root modifier only.
            if (modifierCounter == 1)
            {
                // Hide the segment's main box.
                ShowRootModifierOnly();

                // Load data from the last modifier in segment list, to rooted modifier
                MolderSegment.Modifiers[0].SaveModifierValue(temporaryModifierData);
                MolderRootModifier.LoadModifierValue(temporaryModifierData);
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the molder values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void SaveMolderValues(TMolderData data)
        {
            // Save molder's root modifier.
            MolderRootModifier.SaveModifierValue(data.RootModifierData);

            // Save molder's segment.
            MolderSegment.SaveMolderSegmentValues(data.SegmentData);
        }


        /// <summary>
        /// Load the molder values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadMolderValues(TMolderData data)
        {
            // Load molder's root modifier.
            MolderRootModifier.LoadModifierValue(data.RootModifierData);

            // Load molder's segment.
            MolderSegment.LoadMolderSegmentValues
            (
                data: data.SegmentData,
                modifierCreatedAction: ModifierCreatedAction,
                modifierRemoveButtonClickAction: ModifierRemoveButtonClickAction
            );

            // Update molder's cotent.
            ToggleShowSegmentOrRootModifier(isShowSegment: modifierCounter > 1);
        }


        // ----------------------------- Add Modifier Services -----------------------------
        /// <summary>
        /// Create a new instance modifier for the molder.
        /// </summary>
        protected abstract void AddInstanceModifier();


        // ----------------------------- Switch Molder Content Services -----------------------------
        /// <summary>
        /// Show segment and hide root modifier.
        /// </summary>
        void ShowRootModifierOnly()
        {
            VisualElementHelper.HideElement(MolderSegment.MainBox);
            VisualElementHelper.ShowElement(MolderRootModifier.MainBox);
        }


        /// <summary>
        /// Show root modifier and hide segment.
        /// </summary>
        void ShowSegmentOnly()
        {
            VisualElementHelper.ShowElement(MolderSegment.MainBox);
            VisualElementHelper.HideElement(MolderRootModifier.MainBox);
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