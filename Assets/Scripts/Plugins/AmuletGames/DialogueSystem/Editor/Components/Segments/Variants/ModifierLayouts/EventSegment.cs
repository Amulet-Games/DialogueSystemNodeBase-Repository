using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventSegment : SegmentFrameBase.ModifierLayout
    <
        EventModifier,
        EventModifierData,
        EventSegmentData
    >
    {
        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateRootElements(NodeBase node)
        {
            // Title
            Box titleBox;
            Label titleLabel;

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupExpandButton();

            AddFieldsToBox();

            AddBoxToMainContainer();

            SegmentCreatedAction();

            void SetupBoxContainer()
            {
                MainBox = new();
                MainBox.AddToClassList(StylesConfig.Segment_Event_Main_Box);

                titleBox = new();
                titleBox.AddToClassList(StylesConfig.Segment_Common_Title_Box);
                titleBox.AddToClassList(StylesConfig.Segment_Event_Title_Box);

                ContentBox = new();
                ContentBox.pickingMode = PickingMode.Ignore;
                ContentBox.AddToClassList(StylesConfig.Segment_Event_Content_Box);
            }

            void SetupSegmentTitle()
            {
                titleLabel = LabelFactory.GetNewLabel
                (
                    labelText: StringsConfig.EventSegmentTitleLabelText,
                    labelUSS01: StylesConfig.Segment_Common_Title_Label
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
        public override void SaveSegmentValues(EventSegmentData data)
        {
            SaveEventModifiers();

            SaveBaseSegmentValue();

            void SaveEventModifiers()
            {
                // Modifiers
                for (int i = 0; i < Modifiers.Count; i++)
                {
                    // New modifier data.
                    EventModifierData newModifierData = new();

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
        public override void SaveMolderSegmentValues(EventSegmentData data)
        {
            SaveEventModifiers();

            SaveBaseSegmentValue();

            void SaveEventModifiers()
            {
                // Modifiers
                for (int i = 0; i < Modifiers.Count; i++)
                {
                    // New modifier data.
                    EventModifierData newModifierData = new();

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
        public override void LoadSegmentValues(EventSegmentData data)
        {
            LoadEventModifiers();

            LoadBaseSegmentValue();

            void LoadEventModifiers()
            {
                // Modifiers
                int sourceModifiersCount = data.ModifierDataList.Count;
                for (int i = 0; i < sourceModifiersCount; i++)
                {
                    new EventModifier().CreateInstanceElements
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
            EventSegmentData data,
            Action<EventModifier> modifierCreatedAction,
            Action<EventModifier> modifierRemoveButtonClickAction
        )
        {
            LoadEventModifiers();

            LoadBaseSegmentValue();

            void LoadEventModifiers()
            {
                // Retrieve the data list count.
                int modifierDataListCount = data.ModifierDataList.Count;

                // Initial instanace modifier is created together with the molder,
                // so here it only need to load its values from the source.
                if (modifierDataListCount > 0)
                {
                    Modifiers[0].LoadModifierValue(data.ModifierDataList[0]);
                }

                // For the rest of saved instance modifiers, create a new instance modifier and
                // load its saved values from the source.
                for (int i = 1; i < modifierDataListCount; i++)
                {
                    new EventModifier().CreateInstanceElements
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