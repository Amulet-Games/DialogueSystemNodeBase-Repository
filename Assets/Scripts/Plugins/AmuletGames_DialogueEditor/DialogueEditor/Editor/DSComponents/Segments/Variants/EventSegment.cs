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
        /// <summary>
        /// Create all the UIElements that are needed in this segment.
        /// </summary>
        /// <param name="node">Node of which this segment is created for.</param>
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
                MainBox.AddToClassList(DSStylesConfig.segment_Event_MainBox);

                ContentBox = new Box();
                ContentBox.AddToClassList(DSStylesConfig.segment_Event_ContentBox);
            }

            void SetupSegmentTitle()
            {
                segmentTitleBox = DSSegmentsMaker.AddSegmentTitle("Scriptable Events", DSStylesConfig.segment_TitleBox_Event);
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
        /// <summary>
        /// Save segment's value from another previously created segment.
        /// </summary>
        /// <param name="source">The segment of which it's values are going to be saved in.</param>
        public override void SaveSegmentValues(EventSegment source)
        {
            // Save segment's isExpanded state
            IsExpanded = source.IsExpanded;

            // Save segment's isHidden state
            IsHidden = source.IsHidden;

            // Save segment's modifiers
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


        /// <summary>
        /// Load segment's value from another previously saved segment.
        /// </summary>
        /// <param name="source">The segment that was previously saved and now it's used to load from.</param>
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


        /// <summary>
        /// Load segment's value from another previously saved segment.
        /// <br>This is used by molder component and should only be called within molder's class. </br>
        /// </summary>
        /// <param name="source">The segment that was previously saved and now it's used to load from.</param>
        /// <param name="modifierAddedAction">Action that invoked after modifier is added.</param>
        /// <param name="modifierRemovedAction">Action that invoked after modifier is removed.</param>
        public override void LoadSegmentValues(EventSegment source, Action<EventModifier> modifierAddedAction, Action<EventModifier> modifierRemovedAction)
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