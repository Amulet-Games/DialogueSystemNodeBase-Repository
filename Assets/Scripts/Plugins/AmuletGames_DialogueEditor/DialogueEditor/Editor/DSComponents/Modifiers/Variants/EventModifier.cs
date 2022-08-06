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
        /// <summary>
        /// Create all the UIElements that are needed in this modifier as root.
        /// </summary>
        /// <param name="node">Node of which this modifier is created for.</param>
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
                MainBox.AddToClassList(DSStylesConfig.modifier_Event_MainBox);
            }

            void SetupEventObjectField()
            {
                eventObjectField = DSObjectFieldsMaker.GetNewObjectField(DialogueEventSO_ObjectContainer, DSStylesConfig.modifier_Event_Rooted_ObjectField);
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
        /// <summary>
        /// Save modifier's value from another previously create modifier.
        /// </summary>
        /// <param name="source">The modifier of which it's values are going to be saved.</param>
        public override void SaveModifierValue(EventModifier source)
        {
            DialogueEventSO_ObjectContainer.SaveContainerValue(source.DialogueEventSO_ObjectContainer);
        }


        /// <summary>
        /// Load modifier's value from another previously saved modifier.
        /// </summary>
        /// <param name="source">The modifier that was previously saved and now it's used to load from.</param>
        public override void LoadModifierValue(EventModifier source)
        {
            DialogueEventSO_ObjectContainer.LoadContainerValue(source.DialogueEventSO_ObjectContainer);
        }
    }
}