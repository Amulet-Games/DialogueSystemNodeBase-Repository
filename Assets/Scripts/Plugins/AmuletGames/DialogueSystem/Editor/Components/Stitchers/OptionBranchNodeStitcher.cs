using System.Collections.Generic;


namespace AG.DS
{
    public class OptionBranchNodeStitcher
    {
        /// <summary>
        /// Internal instance modifiers cache.
        /// </summary>
        List<ConditionModifier> instanceModifiers;


        /// <summary>
        /// Internal modifiers cache counter.
        /// </summary>
        int instancesCount = 0;


        /// <summary>
        /// Internal segment reference.
        /// </summary>
        Segment Segment;


        /// <summary>
        /// Enum container for the users to choose how they want to display the option if its condition
        /// <br>has not been unmet yet.</br>
        /// </summary>
        UnmetOptionDisplayTypeEnumFieldView unmetOptionDisplayTypeEnumContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node stitcher class.
        /// </summary>
        public OptionBranchNodeStitcher()
        {
            instanceModifiers = new();
            Segment = new();
            unmetOptionDisplayTypeEnumContainer = new();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in the stitcher.
        /// </summary>
        /// <param name="node">Node of which this stitcher is created for.</param>
        public void CreateRootElements(NodeBase node)
        {
            UnityEngine.UIElements.EnumField unmetOptionDisplayTypeEnumField;

            SetupSegment();

            SetupUnmetOptionDisplayTypeEnumField();

            AddFieldsToBox();

            StitcherCreatedAction();

            void SetupSegment()
            {
                // Create new segment.
                Segment.CreateRootElements
                (
                    node: node,
                    titleText: StringConfig.ConditionSegmentTitleLabelText,
                    titleBoxUSS01: StyleConfig.Segment_Condition_Title_Box,
                    contentBoxUSS01: StyleConfig.Segment_Condition_Content_Box
                );
            }

            void SetupUnmetOptionDisplayTypeEnumField()
            {
                unmetOptionDisplayTypeEnumField = EnumFieldFactory.GetNewEnumField
                (
                    enumContainer: unmetOptionDisplayTypeEnumContainer,
                    fieldUSS: StyleConfig.Segment_Condition_UnmetOptionDisplayType_EnumField
                );
            }

            void AddFieldsToBox()
            {
                Segment.TitleButtonBox.Add(unmetOptionDisplayTypeEnumField);
            }

            void StitcherCreatedAction()
            {
                // Hide the segment.
                SetActiveSegment(value: false);
            }
        }


        /// <summary>
        /// Create a new instance modifier for the stitcher.
        /// </summary>
        /// <param name="model">The condition modifier model to set for.</param>
        public void AddInstanceModifier(ConditionModifierModel model)
        {
            new ConditionModifier().CreateInstanceElements
            (
                model: model,
                modifierCreatedAction: ModifierCreatedAction,
                removeButtonClickAction: ModifierRemoveButtonClickAction
            );
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The action to invoke when a modifier is created.
        /// </summary>
        /// <param name="modifier">The new created modifier.</param>
        void ModifierCreatedAction(ConditionModifier modifier)
        {
            // Add box to segment's content box.
            Segment.ContentBox.Add(modifier.MainBox);

            // Expand segment.
            Segment.SetIsExpanded(value: true);

            // Add modifier to the internal list.
            instanceModifiers.Add(modifier);

            // Increase cache count.
            instancesCount++;
        }


        /// <summary>
        /// The action to invoke when the modifier's remove button is clicked.
        /// </summary>
        /// <param name="modifier">The modifier that is going to be removed.</param>
        void ModifierRemoveButtonClickAction(ConditionModifier modifier)
        {
            // Decrease internal count.
            instancesCount--;

            // Remove modifier from the cache.
            instanceModifiers.Remove(modifier);

            if (instancesCount < 1)
            {
                // Hide segment is there's no instances.
                SetActiveSegment(value: false);
            }

            // Delete box from segment's content box.
            Segment.ContentBox.Remove(modifier.MainBox);
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the stitcher values to the option branch node stitcher model.
        /// </summary>
        /// <param name="model">The option branch node stitcher model to set for.</param>
        public void SaveStitcherValues(OptionBranchNodeStitcherModel model)
        {
            SaveInstanceModifiers();

            SaveSegment();

            SaveUnmetOptionDisplayTypeEnumField();

            void SaveInstanceModifiers()
            {
                for (int i = 0; i < instancesCount; i++)
                {
                    // New modifier model.
                    ConditionModifierModel newModifierModel = new();

                    // Save values.
                    instanceModifiers[i].SaveModifierValue(newModifierModel);

                    // Add to the model list.
                    model.InstanceModifierModels.Add(newModifierModel);
                }
            }

            void SaveSegment()
            {
                Segment.SaveSegmentValues(model.SegmentModel);
            }

            void SaveUnmetOptionDisplayTypeEnumField()
            {
                // Unmet option display type enum.
                model.UnmetOptionDisplayTypeEnumIndex = unmetOptionDisplayTypeEnumContainer.Value;
            }
        }


        /// <summary>
        /// Load the stitcher values from the option branch node stitcher model.
        /// </summary>
        /// <param name="model">The option branch node stitcher model to set for.</param>
        public void LoadStitcherValues(OptionBranchNodeStitcherModel model)
        {
            LoadInstanceModifiers();

            LoadSegment();

            LoadUnmetOptionDisplayTypeEnumField();

            StitcherLoadedAction();

            void LoadInstanceModifiers()
            {
                var instanceModifierModelsCount = model.InstanceModifierModels.Count;
                for (int i = 0; i < instanceModifierModelsCount; i++)
                {
                    AddInstanceModifier(model.InstanceModifierModels[i]);
                }
            }

            void LoadSegment()
            {
                Segment.LoadSegmentValues(model.SegmentModel);
            }

            void LoadUnmetOptionDisplayTypeEnumField()
            {
                unmetOptionDisplayTypeEnumContainer.Load(model.UnmetOptionDisplayTypeEnumIndex);
            }

            void StitcherLoadedAction()
            {
                SetActiveSegment(value: instancesCount > 0);
            }
        }


        // ----------------------------- Set Active Segment -----------------------------
        /// <summary>
        /// Activate or deactivate the segment base on the given value state.
        /// </summary>
        /// <param name="value">True for active, false for inactive.</param>
        void SetActiveSegment(bool value)
        {
            Segment.MainBox.SetDisplay(value: value);
        }
    }
}