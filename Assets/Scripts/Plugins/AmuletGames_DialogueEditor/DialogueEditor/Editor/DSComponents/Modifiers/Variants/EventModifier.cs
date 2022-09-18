using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public class EventModifier : DSModifierFrameBase<EventModifier>
    {
        /// <summary>
        /// Object container for the dialogue event's scriptable object.
        /// </summary>
        public ObjectContainer<DialogueEventSO> DialogueEventSO_ObjectContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of event modifier
        /// </summary>
        public EventModifier()
        {
            DialogueEventSO_ObjectContainer = new ObjectContainer<DialogueEventSO>();
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void SetupRootModifier(DSNodeBase node)
        {
            ObjectField eventObjectField;

            SetupModifierBox();

            SetupEventObjectField();

            AddFieldsToBox();

            AddBoxToSegmentContentContainer();

            void SetupModifierBox()
            {
                MainBox = new Box();
                MainBox.AddToClassList(DSStylesConfig.Modifier_Event_Rooted_MainBox);
            }

            void SetupEventObjectField()
            {
                eventObjectField = DSObjectFieldsMaker.GetNewObjectField(DialogueEventSO_ObjectContainer, DSStylesConfig.Modifier_Event_Rooted_ObjectField);
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
        public override void SaveModifierValue(EventModifier source)
        {
            DialogueEventSO_ObjectContainer.SaveContainerValue(source.DialogueEventSO_ObjectContainer);
        }


        /// <inheritdoc />
        public override void LoadModifierValue(EventModifier source)
        {
            DialogueEventSO_ObjectContainer.LoadContainerValue(source.DialogueEventSO_ObjectContainer);
        }
    }
}