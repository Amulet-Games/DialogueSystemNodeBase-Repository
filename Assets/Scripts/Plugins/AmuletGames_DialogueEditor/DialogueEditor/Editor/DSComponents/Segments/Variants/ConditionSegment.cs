using System.Collections.Generic;
using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public class ConditionSegment : DSSegmentFrameBase.T2<ConditionSegment, ConditionModifier>
    {
        /// <summary>
        /// Enum container for how the user want to display each condition modifiers.
        /// </summary>
        ConditionDisplayTypeEnumContainer conditionDisplayType_EnumContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of condition segment
        /// </summary>
        public ConditionSegment()
        {
            conditionDisplayType_EnumContainer = new ConditionDisplayTypeEnumContainer();
            Modifiers = new List<ConditionModifier>();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this segment.
        /// </summary>
        /// <param name="node">Node of which this segment is created for.</param>
        public override void SetupSegment(DSNodeBase node)
        {
            Box segmentTitleBox;

            EnumField conditionDisplayEnumField;

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupConditionDisplayEnumField();

            SetupSegmentExpandButton();

            AddFieldsToBox();

            AddBoxToMainContainer();

            HideAndExpandSegementUponCreated();

            void SetupBoxContainer()
            {
                MainBox = new Box();
                MainBox.AddToClassList(DSStylesConfig.segment_Condition_MainBox);

                ContentBox = new Box();
                ContentBox.AddToClassList(DSStylesConfig.segment_Condition_ContentBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = DSSegmentsMaker.AddSegmentTitle("Conditions", DSStylesConfig.segment_TitleBox_Condition);
            }

            void SetupConditionDisplayEnumField()
            {
                conditionDisplayEnumField = DSEnumFieldsMaker.GetNewEnumField(conditionDisplayType_EnumContainer, DSStylesConfig.segment_Condition_ConditionDisplayEnumField);
            }

            void SetupSegmentExpandButton()
            {
                ExpandButton = DSSegmentsMaker.AddSegmentExpandButton(SwitchSegmentIsExpanded);
            }

            void AddFieldsToBox()
            {
                MainBox.Add(segmentTitleBox);
                MainBox.Add(ContentBox);

                segmentTitleBox.Add(conditionDisplayEnumField);
                segmentTitleBox.Add(ExpandButton);
            }

            void AddBoxToMainContainer()
            {
                node.mainContainer.Add(MainBox);
            }

            void HideAndExpandSegementUponCreated()
            {
                SwitchSegmentIsHidden();
                SwitchSegmentIsExpanded();
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save segment's value from another previously created segment.
        /// </summary>
        /// <param name="source">The segment of which it's values are going to be saved in.</param>
        public override void SaveSegmentValues(ConditionSegment source)
        {
            // Save segment's isExpanded state
            IsExpanded = source.IsExpanded;

            // Save segment's isHidden state
            IsHidden = source.IsHidden;

            // Save segment's condition display enum field
            conditionDisplayType_EnumContainer.SaveContainerValue(source.conditionDisplayType_EnumContainer);

            // Save segment's modifiers
            List<ConditionModifier> sourceConditionModifiers = source.Modifiers;
            for (int i = 0; i < sourceConditionModifiers.Count; i++)
            {
                // Create a new modifier.
                ConditionModifier newConditionModifier = new ConditionModifier();

                // Save the source modifier's values to the new one.
                newConditionModifier.SaveModifierValue(sourceConditionModifiers[i]);

                // Add the new modifier to internal list.
                Modifiers.Add(newConditionModifier);
            }
        }


        /// <summary>
        /// Load segment's value from another previously saved segment.
        /// </summary>
        /// <param name="source">The segment that was previously saved and now it's used to load from.</param>
        public override void LoadSegmentValues(ConditionSegment source)
        {
            LoadConditionDisplayType();

            LoadConditionModifiers();

            LoadBaseSegmentValue();

            void LoadConditionDisplayType()
            {
                // Load condition display type enum container.
                conditionDisplayType_EnumContainer.LoadContainerValue(source.conditionDisplayType_EnumContainer);
            }

            void LoadConditionModifiers()
            {
                // Create a new list of condition modifiers and load each of their values as it's saved.
                int sourceModifiersCount = source.Modifiers.Count;
                for (int i = 0; i < sourceModifiersCount; i++)
                {
                    DSModifiersMaker.GetNewConditionModifier
                    (
                        source.Modifiers[i],
                        ModifierAddedAction,
                        ModifierRemovedAction
                    );
                }
            }

            void LoadBaseSegmentValue()
            {
                // Load isExpanded state.
                LoadIsExpandedValue(source);

                // Load isHidden state.
                LoadIsHiddenValue(source);
            }
        }


        /// <summary>
        /// Load segment's value from another previously saved segment.
        /// <br>This is used by molder component and should only be called within molder's class. </br>
        /// </summary>
        /// <param name="source">The segment that was previously saved and now it's used to load from.</param>
        /// <param name="modifierAddedAction">Action that invoked after modifier is added.</param>
        /// <param name="modifierRemovedAction">Action that invoked after modifier is removed.</param>
        public override void LoadSegmentValues(ConditionSegment source, Action<ConditionModifier> modifierAddedAction, Action<ConditionModifier> modifierRemovedAction)
        {
            LoadConditionDisplayType();

            LoadConditionModifiers();

            LoadBaseSegmentValue();

            void LoadConditionDisplayType()
            {
                // Load condition display type enum container.
                conditionDisplayType_EnumContainer.LoadContainerValue(source.conditionDisplayType_EnumContainer);
            }

            void LoadConditionModifiers()
            {
                // Create a new list of condition modifiers and load each of their values as it's saved.
                int sourceModifiersCount = source.Modifiers.Count;
                //Debug.Log("sourceModifiersCount = " + sourceModifiersCount);
                for (int i = 0; i < sourceModifiersCount; i++)
                {
                    DSModifiersMaker.GetNewConditionModifier
                    (
                        source.Modifiers[i],
                        modifierAddedAction,
                        modifierRemovedAction
                    );
                }
            }

            void LoadBaseSegmentValue()
            {
                // Load isExpanded state.
                LoadIsExpandedValue(source);

                // Load isHidden state.
                LoadIsHiddenValue(source);
            }
        }
    }
}