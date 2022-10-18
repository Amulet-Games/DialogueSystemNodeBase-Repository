using System.Collections.Generic;
using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class ConditionSegment : DSSegmentFrameBase.T2<ConditionSegment, ConditionModifier>
    {
        /// <summary>
        /// Enum container for the users to choose how they want to display the option if its condition
        /// <br>has not been unmet yet.</br>
        /// </summary>
        [SerializeField] UnmetOptionDisplayTypeEnumContainer unmetOptionDisplayTypeEnumContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of condition segment
        /// </summary>
        public ConditionSegment()
        {
            unmetOptionDisplayTypeEnumContainer = new UnmetOptionDisplayTypeEnumContainer();
            Modifiers = new List<ConditionModifier>();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void SetupSegment(DSNodeBase node)
        {
            Box segmentTitleBox;

            EnumField unmentOptionDisplayTypeEnumField;

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupUnmetOptionDisplayTypeEnumField();

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
                segmentTitleBox = DSSegmentsMaker.AddSegmentTitle
                (
                    DSStringsConfig.ConditionSegmentTitleLabelText,
                    DSStylesConfig.Segment_TitleBox_Condition
                );
            }

            void SetupUnmetOptionDisplayTypeEnumField()
            {
                unmentOptionDisplayTypeEnumField = DSEnumFieldsMaker.GetNewEnumField
                (
                    unmetOptionDisplayTypeEnumContainer,
                    DSStylesConfig.Segment_TitleEnum_EnumField
                );
            }

            void SetupSegmentExpandButton()
            {
                ExpandButton = DSSegmentsMaker.AddSegmentExpandButton(SwitchSegmentIsExpanded);
            }

            void AddFieldsToBox()
            {
                MainBox.Add(segmentTitleBox);
                MainBox.Add(ContentBox);

                segmentTitleBox.Add(unmentOptionDisplayTypeEnumField);
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
        /// <inheritdoc />
        public override void SaveSegmentValues(ConditionSegment source)
        {
            SaveConditionDisplayType();

            SaveConditionModifiers();

            SaveBaseSegmentValue();

            void SaveConditionDisplayType()
            {
                // Save unmet option display type enum container.
                unmetOptionDisplayTypeEnumContainer.SaveContainerValue(source.unmetOptionDisplayTypeEnumContainer);
            }

            void SaveConditionModifiers()
            {
                // Save condition modifiers.
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

            void SaveBaseSegmentValue()
            {
                // Save segment's isExpanded state
                IsExpanded = source.IsExpanded;

                // Save segment's isHidden state
                IsHidden = source.IsHidden;
            }
        }


        /// <inheritdoc />
        public override void SaveMolderSegmentValues(ConditionSegment source)
        {
            SaveConditionDisplayType();

            SaveConditionModifiers();

            SaveBaseSegmentValue();

            void SaveConditionDisplayType()
            {
                // Save unmet option display type enum container.
                unmetOptionDisplayTypeEnumContainer.SaveContainerValue(source.unmetOptionDisplayTypeEnumContainer);
            }

            void SaveConditionModifiers()
            {
                // Save condition modifiers.
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

            void SaveBaseSegmentValue()
            {
                // Save segment's isHidden state
                IsHidden = source.IsHidden;
            }
        }


        /// <inheritdoc />
        public override void LoadSegmentValues(ConditionSegment source)
        {
            LoadConditionDisplayType();

            LoadConditionModifiers();

            LoadBaseSegmentValue();

            void LoadConditionDisplayType()
            {
                // Load unmet option display type enum container.
                unmetOptionDisplayTypeEnumContainer.LoadContainerValue(source.unmetOptionDisplayTypeEnumContainer);
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


        /// <inheritdoc />
        public override void LoadMolderSegmentValues(ConditionSegment source, Action<ConditionModifier> modifierAddedAction, Action<ConditionModifier> modifierRemovedAction)
        {
            LoadConditionDisplayType();

            LoadConditionModifiers();

            LoadBaseSegmentValue();

            void LoadConditionDisplayType()
            {
                // Load unmet option display type enum container.
                unmetOptionDisplayTypeEnumContainer.LoadContainerValue(source.unmetOptionDisplayTypeEnumContainer);
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
                // Load isHidden state.
                LoadIsHiddenValue(source);
            }
        }
    }
}