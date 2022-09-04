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
        /// Enum container for how the user want to display the option when its condition is unmet.
        /// </summary>
        UnmetOptionDisplayTypeEnumContainer unmetOptionDisplayType_EnumContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of condition segment
        /// </summary>
        public ConditionSegment()
        {
            unmetOptionDisplayType_EnumContainer = new UnmetOptionDisplayTypeEnumContainer();
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

            EnumField unmentOptionDisplayEnumField;

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupUnmetOptionDisplayEnumField();

            SetupSegmentExpandButton();

            AddFieldsToBox();

            AddBoxToMainContainer();

            HideAndExpandSegementUponCreated();

            void SetupBoxContainer()
            {
                MainBox = new Box();
                MainBox.AddToClassList(DSStylesConfig.Segment_Condition_MainBox);

                ContentBox = new Box();
                ContentBox.AddToClassList(DSStylesConfig.Segment_Condition_ContentBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = DSSegmentsMaker.AddSegmentTitle("Conditions", DSStylesConfig.Segment_TitleBox_Condition);
            }

            void SetupUnmetOptionDisplayEnumField()
            {
                unmentOptionDisplayEnumField = DSEnumFieldsMaker.GetNewEnumField(unmetOptionDisplayType_EnumContainer, DSStylesConfig.Segment_Condition_UnmetOptionDisplayEnumField);
            }

            void SetupSegmentExpandButton()
            {
                ExpandButton = DSSegmentsMaker.AddSegmentExpandButton(SwitchSegmentIsExpanded);
            }

            void AddFieldsToBox()
            {
                MainBox.Add(segmentTitleBox);
                MainBox.Add(ContentBox);

                segmentTitleBox.Add(unmentOptionDisplayEnumField);
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
        /// <param name="source">The segment of which its values are going to be saved in.</param>
        public override void SaveSegmentValues(ConditionSegment source)
        {
            // Save segment's isExpanded state
            IsExpanded = source.IsExpanded;

            // Save segment's isHidden state
            IsHidden = source.IsHidden;

            // Save segment's unmet option display enum field
            unmetOptionDisplayType_EnumContainer.SaveContainerValue(source.unmetOptionDisplayType_EnumContainer);

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
                // Load unmet option display type enum container.
                unmetOptionDisplayType_EnumContainer.LoadContainerValue(source.unmetOptionDisplayType_EnumContainer);
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
        public override void LoadMolderSegmentValues(ConditionSegment source, Action<ConditionModifier> modifierAddedAction, Action<ConditionModifier> modifierRemovedAction)
        {
            LoadConditionDisplayType();

            LoadConditionModifiers();

            LoadBaseSegmentValue();

            void LoadConditionDisplayType()
            {
                // Load unmet option display type enum container.
                unmetOptionDisplayType_EnumContainer.LoadContainerValue(source.unmetOptionDisplayType_EnumContainer);
            }

            void LoadConditionModifiers()
            {
                // Check if there're any saved instance modifiers from the source.
                int sourceModifiersCount = source.Modifiers.Count;

                // Initial instanace modifier is created together with the molder,
                // so here it only need to load its values from the source.
                if (sourceModifiersCount > 0)
                {
                    Modifiers[0].LoadModifierValue(source.Modifiers[0]);
                }

                // For the rest of saved instance modifiers, create a new instance modifier and
                // load its saved values from the source.
                for (int i = 1; i < sourceModifiersCount; i++)
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