using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public partial class EventModifier
        : ModifierFrameBase<EventModifier, EventModifierData>
    {
        /// <summary>
        /// Object container for the dialogue system's event scriptable object.
        /// </summary>
        public ObjectContainer<DialogueEvent> EventObjectContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event modifier component class.
        /// </summary>
        public EventModifier()
        {
            EventObjectContainer = new();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateRootElements(NodeBase node)
        {
            ObjectField eventObjectField;

            SetupModifierBox();

            SetupEventObjectField();

            AddFieldsToBox();

            AddBoxToSegmentContentContainer();

            void SetupModifierBox()
            {
                MainBox = new Box();
                MainBox.AddToClassList(StylesConfig.Modifier_Event_Rooted_MainBox);
            }

            void SetupEventObjectField()
            {
                eventObjectField = ObjectFieldFactory.GetNewObjectField
                (
                    objectContainer: EventObjectContainer,
                    fieldIcon: AssetsConfig.LanguageFieldHintIconSprite,
                    fieldUSS01: StylesConfig.Modifier_Event_Rooted_ObjectField
                );
            }

            void AddFieldsToBox()
            {
                MainBox.Add(eventObjectField);
            }

            void AddBoxToSegmentContentContainer()
            {
                node.mainContainer.Add(MainBox);
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void SaveModifierValue(EventModifierData data) => 
            data.DialogueEvent = EventObjectContainer.Value;


        /// <inheritdoc />
        public override void LoadModifierValue(EventModifierData data) =>
            EventObjectContainer.LoadContainerValue(data.DialogueEvent);
    }
}