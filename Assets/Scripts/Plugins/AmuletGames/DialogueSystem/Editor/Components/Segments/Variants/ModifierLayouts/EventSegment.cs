using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public class EventSegment : SegmentFrameBase.ModifierLayout
    <
        EventModifier,
        EventModifierData,
        EventSegmentData
    >
    {
        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void SetupSegment(NodeBase node)
        {
            Box segmentTitleBox;

            SetupBoxContainer();

            SetupSegmentTitle();

            SetupSegmentExpandButton();

            AddFieldsToBox();

            AddBoxToMainContainer();

            HideAndExpandSegementUponCreated();

            void SetupBoxContainer()
            {
                MainBox = new Box();
                MainBox.AddToClassList(StylesConfig.Segment_Event_MainBox);

                ContentBox = new Box();
                ContentBox.pickingMode = PickingMode.Ignore;
                ContentBox.AddToClassList(StylesConfig.Segment_Event_ContentBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = SegmentFactory.AddSegmentTitle
                (
                    titleText: StringsConfig.EventSegmentTitleLabelText,
                    titleBoxUSS01: StylesConfig.Segment_TitleBox_Event
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
        public override void SaveSegmentValues(EventSegmentData data)
        {
            SaveEventModifiers();

            SaveBaseSegmentValue();

            void SaveEventModifiers()
            {
                // Modifiers
                for (int i = 0; i < Modifiers.Count; i++)
                {
                    // new modifier data.
                    var newModifierData = new EventModifierData();

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
                    // new modifier data.
                    var newModifierData = new EventModifierData();

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
            EventSegmentData data,
            Action<EventModifier> modifierAddedAction,
            Action<EventModifier> modifierRemovedAction
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