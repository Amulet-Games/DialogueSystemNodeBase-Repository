using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public class EventModifier : DSModifierFrameBase<EventModifier>
    {
        /// <summary>
        /// Object container for the dialogue system's event scriptable object.
        /// </summary>
        public DSObjectContainer<DSEvent> EventObjectContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of event modifier
        /// </summary>
        public EventModifier()
        {
            EventObjectContainer = new DSObjectContainer<DSEvent>();
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
                eventObjectField = DSObjectFieldsMaker.GetNewObjectField
                (
                    EventObjectContainer,
                    DSAssetsConfig.InputHintIconSprite,
                    DSStylesConfig.Modifier_Event_Rooted_ObjectField
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
        public override void SaveModifierValue(EventModifier source)
        {
            EventObjectContainer.SaveContainerValue(source.EventObjectContainer);
        }


        /// <inheritdoc />
        public override void LoadModifierValue(EventModifier source)
        {
            EventObjectContainer.LoadContainerValue(source.EventObjectContainer);
        }
    }
}