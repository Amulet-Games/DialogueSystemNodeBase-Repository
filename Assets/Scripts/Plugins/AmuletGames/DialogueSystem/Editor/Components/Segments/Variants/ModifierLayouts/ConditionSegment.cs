using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class ConditionSegment : SegmentFrameBase.ModifierLayout
    <
        ConditionModifier,
        ConditionModifierData,
        ConditionSegmentData
    >
    {
        /// <summary>
        /// Enum container for the users to choose how they want to display the option if its condition
        /// <br>has not been unmet yet.</br>
        /// </summary>
        [SerializeField] UnmetOptionDisplayTypeEnumContainer unmetOptionDisplayTypeEnumContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the condition segment component class.
        /// </summary>
        public ConditionSegment()
        {
            unmetOptionDisplayTypeEnumContainer = new UnmetOptionDisplayTypeEnumContainer();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void SetupSegment(NodeBase node)
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
                MainBox.AddToClassList(StylesConfig.Segment_Condition_MainBox);

                ContentBox = new Box();
                ContentBox.pickingMode = PickingMode.Ignore;
                ContentBox.AddToClassList(StylesConfig.Segment_Condition_ContentBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = SegmentFactory.AddSegmentTitle
                (
                    titleText: StringsConfig.ConditionSegmentTitleLabelText,
                    titleBoxUSS01: StylesConfig.Segment_TitleBox_Condition
                );
            }

            void SetupUnmetOptionDisplayTypeEnumField()
            {
                unmentOptionDisplayTypeEnumField = EnumFieldFactory.GetNewEnumField
                (
                    enumContainer: unmetOptionDisplayTypeEnumContainer,
                    fieldUSS01: StylesConfig.Segment_TitleEnum_EnumField
                );
            }

            void SetupSegmentExpandButton()
            {
                ExpandButton = SegmentFactory.AddSegmentExpandButton
                (
                    action: SwitchSegmentIsExpanded
                );
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
        public override void SaveSegmentValues(ConditionSegmentData data)
        {
            SaveConditionDisplayType();

            SaveConditionModifiers();

            SaveBaseSegmentValue();

            void SaveConditionDisplayType()
            {
                // Unmet option display type enum.
                data.UnmetOptionDisplayTypeEnumIndex = unmetOptionDisplayTypeEnumContainer.Value;
            }

            void SaveConditionModifiers()
            {
                // Modifiers
                for (int i = 0; i < Modifiers.Count; i++)
                {
                    // new modifier data.
                    var newModifierData = new ConditionModifierData();

                    // Save values.
                    Modifiers[i].SaveModifierValue(newModifierData);

                    // Add to the data list.
                    data.ModifierDataList.Add(newModifierData);
                }
            }

            void SaveBaseSegmentValue()
            {
                // isExpanded.
                data.IsExpanded = IsExpanded;

                // isHidden.
                data.IsHidden = IsHidden;
            }
        }


        /// <inheritdoc />
        public override void SaveMolderSegmentValues(ConditionSegmentData data)
        {
            SaveConditionDisplayType();

            SaveConditionModifiers();

            SaveBaseSegmentValue();

            void SaveConditionDisplayType()
            {
                // Unmet option display type enum.
                data.UnmetOptionDisplayTypeEnumIndex = unmetOptionDisplayTypeEnumContainer.Value;
            }

            void SaveConditionModifiers()
            {
                // Modifiers
                for (int i = 0; i < Modifiers.Count; i++)
                {
                    // new modifier data.
                    var newModifierData = new ConditionModifierData();

                    // Save values.
                    Modifiers[i].SaveModifierValue(newModifierData);

                    // Add to the data list.
                    data.ModifierDataList.Add(newModifierData);
                }
            }

            void SaveBaseSegmentValue()
            {
                // isHidden.
                data.IsHidden = IsHidden;
            }
        }


        /// <inheritdoc />
        public override void LoadSegmentValues(ConditionSegmentData data)
        {
            LoadConditionDisplayType();

            LoadConditionModifiers();

            LoadBaseSegmentValue();

            void LoadConditionDisplayType()
            {
                // Unmet option display type enum.
                unmetOptionDisplayTypeEnumContainer.LoadContainerValue
                (
                    data.UnmetOptionDisplayTypeEnumIndex
                );
            }

            void LoadConditionModifiers()
            {
                // Modifiers
                int sourceModifiersCount = data.ModifierDataList.Count;
                for (int i = 0; i < sourceModifiersCount; i++)
                {
                    new ConditionModifier().CreateInstanceElements
                    (
                        data: data.ModifierDataList[i],
                        addToSegmentAction: ModifierAddedAction,
                        removeFromSegmentAction: ModifierRemovedAction
                    );
                }
            }

            void LoadBaseSegmentValue()
            {
                // isExpanded.
                LoadIsExpandedValue(data);

                // isHidden.
                LoadIsHiddenValue(data);
            }
        }


        /// <inheritdoc />
        public override void LoadMolderSegmentValues
        (
            ConditionSegmentData data,
            Action<ConditionModifier> modifierAddedAction,
            Action<ConditionModifier> modifierRemovedAction
        )
        {
            LoadConditionDisplayType();

            LoadConditionModifiers();

            LoadBaseSegmentValue();

            void LoadConditionDisplayType()
            {
                // Unmet option display type enum.
                unmetOptionDisplayTypeEnumContainer.LoadContainerValue
                (
                    data.UnmetOptionDisplayTypeEnumIndex
                );
            }

            void LoadConditionModifiers()
            {
                // Retrieve the data list count.
                int sourceModifiersCount = data.ModifierDataList.Count;

                // Initial instanace modifier is created together with the molder,
                // so here it only need to load its values from the source.
                if (sourceModifiersCount > 0)
                {
                    Modifiers[0].LoadModifierValue(data.ModifierDataList[0]);
                }

                // For the rest of saved instance modifiers, create a new instance modifier and
                // load its saved values from the source.
                for (int i = 1; i < sourceModifiersCount; i++)
                {
                    new ConditionModifier().CreateInstanceElements
                    (
                        data: data.ModifierDataList[i],
                        addToSegmentAction: modifierAddedAction,
                        removeFromSegmentAction: modifierRemovedAction
                    );
                }
            }

            void LoadBaseSegmentValue()
            {
                // isHidden.
                LoadIsHiddenValue(data);
            }
        }
    }
}