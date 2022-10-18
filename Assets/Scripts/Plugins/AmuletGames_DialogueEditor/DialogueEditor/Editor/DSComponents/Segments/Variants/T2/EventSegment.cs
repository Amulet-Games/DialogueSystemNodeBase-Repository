using System.Collections.Generic;
using System;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public class EventSegment : DSSegmentFrameBase.T2<EventSegment, EventModifier>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of event segment
        /// </summary>
        public EventSegment()
        {
            Modifiers = new List<EventModifier>();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void SetupSegment(DSNodeBase node)
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
                MainBox.AddToClassList(DSStylesConfig.Segment_Event_MainBox);

                ContentBox = new Box();
                ContentBox.AddToClassList(DSStylesConfig.Segment_Event_ContentBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = DSSegmentsMaker.AddSegmentTitle
                (
                    DSStringsConfig.EventSegmentTitleLabelText,
                    DSStylesConfig.Segment_TitleBox_Event
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
        public override void SaveSegmentValues(EventSegment source)
        {
            SaveEventModifiers();

            SaveBaseSegmentValue();

            void SaveEventModifiers()
            {
                // Save event modifiers
                List<EventModifier> sourceEventModifiers = source.Modifiers;
                for (int i = 0; i < sourceEventModifiers.Count; i++)
                {
                    // Create a new modifier.
                    EventModifier newEventModifier = new EventModifier();

                    // Save the source modifier's values to the new one.
                    newEventModifier.SaveModifierValue(sourceEventModifiers[i]);

                    // Add the new modifier to internal list.
                    Modifiers.Add(newEventModifier);
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
        public override void SaveMolderSegmentValues(EventSegment source)
        {
            SaveEventModifiers();

            SaveBaseSegmentValue();

            void SaveEventModifiers()
            {
                // Save event modifiers
                List<EventModifier> sourceEventModifiers = source.Modifiers;
                for (int i = 0; i < sourceEventModifiers.Count; i++)
                {
                    // Create a new modifier.
                    EventModifier newEventModifier = new EventModifier();

                    // Save the source modifier's values to the new one.
                    newEventModifier.SaveModifierValue(sourceEventModifiers[i]);

                    // Add the new modifier to internal list.
                    Modifiers.Add(newEventModifier);
                }
            }

            void SaveBaseSegmentValue()
            {
                // Save segment's isHidden state
                IsHidden = source.IsHidden;
            }
        }


        /// <inheritdoc />
        public override void LoadSegmentValues(EventSegment source)
        {
            LoadEventModifiers();

            LoadBaseSegmentValue();

            void LoadEventModifiers()
            {
                // Create a new list of event modifiers and load each of their values as it's saved.
                int sourceModifiersCount = source.Modifiers.Count;
                for (int i = 0; i < sourceModifiersCount; i++)
                {
                    DSModifiersMaker.GetNewEventModifier
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
        public override void LoadMolderSegmentValues(EventSegment source, Action<EventModifier> modifierAddedAction, Action<EventModifier> modifierRemovedAction)
        {
            LoadEventModifiers();

            LoadBaseSegmentValue();

            void LoadEventModifiers()
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
                    DSModifiersMaker.GetNewEventModifier
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