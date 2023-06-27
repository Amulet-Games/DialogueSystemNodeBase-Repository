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
        /// <param name="data">The given modifier data to load from.</param>
        public void AddInstanceModifier(ConditionModifierData data)
        {
            new ConditionModifier().CreateInstanceElements
            (
                data: data,
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
        /// Save the stitcher values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void SaveStitcherValues(OptionBranchNodeStitcherData data)
        {
            SaveInstanceModifiers();

            SaveSegment();

            SaveUnmetOptionDisplayTypeEnumField();

            void SaveInstanceModifiers()
            {
                for (int i = 0; i < instancesCount; i++)
                {
                    // New modifier data.
                    ConditionModifierData newModifierData = new();

                    // Save values.
                    instanceModifiers[i].SaveModifierValue(newModifierData);

                    // Add to the data list.
                    data.InstanceModifiersData.Add(newModifierData);
                }
            }

            void SaveSegment()
            {
                Segment.SaveSegmentValues(data.SegmentData);
            }

            void SaveUnmetOptionDisplayTypeEnumField()
            {
                // Unmet option display type enum.
                data.UnmetOptionDisplayTypeEnumIndex = unmetOptionDisplayTypeEnumContainer.Value;
            }
        }


        /// <summary>
        /// Load the stitcher values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadStitcherValues(OptionBranchNodeStitcherData data)
        {
            LoadInstanceModifiers();

            LoadSegment();

            LoadUnmetOptionDisplayTypeEnumField();

            StitcherLoadedAction();

            void LoadInstanceModifiers()
            {
                var instanceModifiersDataCount = data.InstanceModifiersData.Count;
                for (int i = 0; i < instanceModifiersDataCount; i++)
                {
                    AddInstanceModifier(data.InstanceModifiersData[i]);
                }
            }

            void LoadSegment()
            {
                Segment.LoadSegmentValues(data.SegmentData);
            }

            void LoadUnmetOptionDisplayTypeEnumField()
            {
                unmetOptionDisplayTypeEnumContainer.Load(data.UnmetOptionDisplayTypeEnumIndex);
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