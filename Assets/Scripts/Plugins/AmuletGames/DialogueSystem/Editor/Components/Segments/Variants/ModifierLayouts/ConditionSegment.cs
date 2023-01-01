using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
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
        UnmetOptionDisplayTypeEnumContainer unmetOptionDisplayTypeEnumContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the condition segment component class.
        /// </summary>
        public ConditionSegment()
        {
            unmetOptionDisplayTypeEnumContainer = new();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateRootElements(NodeBase node)
        {
            // Title
            Box titleBox;
            Label titleLabel;
            EnumField unmentOptionDisplayTypeEnumField;

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupUnmetOptionDisplayTypeEnumField();

            SetupExpandButton();

            AddFieldsToBox();

            AddBoxToMainContainer();

            SegmentCreatedAction();

            void SetupBoxContainer()
            {
                MainBox = new();
                MainBox.AddToClassList(StylesConfig.Segment_Condition_Main_Box);

                titleBox = new();
                titleBox.AddToClassList(StylesConfig.Segment_Common_Title_Box);
                titleBox.AddToClassList(StylesConfig.Segment_Condition_Title_Box);

                ContentBox = new();
                ContentBox.pickingMode = PickingMode.Ignore;
                ContentBox.AddToClassList(StylesConfig.Segment_Condition_Content_Box);
            }

            void SetupSegmentTitle()
            {
                titleLabel = LabelFactory.GetNewLabel
                (
                    labelText: StringsConfig.ConditionSegmentTitleLabelText,
                    labelUSS01: StylesConfig.Segment_Common_Title_Label
                );
            }

            void SetupUnmetOptionDisplayTypeEnumField()
            {
                unmentOptionDisplayTypeEnumField = EnumFieldFactory.GetNewEnumField
                (
                    enumContainer: unmetOptionDisplayTypeEnumContainer,
                    fieldUSS01: StylesConfig.Segment_Common_Title_EnumField
                );
            }

            void SetupExpandButton()
            {
                ExpandButton = ButtonFactory.GetNewButton
                (
                    isAlert: false,
                    buttonSprite: AssetsConfig.SegmentExpandButtonIconSprite,
                    buttonClickAction: SwitchSegmentIsExpanded,
                    buttonUSS01: StylesConfig.Segment_Common_ExpandSegment_Button
                );
            }

            void AddFieldsToBox()
            {
                MainBox.Add(titleBox);
                MainBox.Add(ContentBox);

                titleBox.Add(titleLabel);
                titleBox.Add(unmentOptionDisplayTypeEnumField);
                titleBox.Add(ExpandButton);
            }

            void AddBoxToMainContainer()
            {
                node.mainContainer.Add(MainBox);
            }

            void SegmentCreatedAction()
            {
                // Hide the segment.
                SwitchSegmentIsHidden();

                // Expand the segment.
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
                    // New modifier data.
                    ConditionModifierData newModifierData = new();

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
                    // New modifier data.
                    ConditionModifierData newModifierData = new();

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
                        modifierCreatedAction: ModifierCreatedAction,
                        removeButtonClickAction: ModifierRemoveButtonClickAction
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
            Action<ConditionModifier> modifierCreatedAction,
            Action<ConditionModifier> modifierRemoveButtonClickAction
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
                        modifierCreatedAction: modifierCreatedAction,
                        removeButtonClickAction: modifierRemoveButtonClickAction
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