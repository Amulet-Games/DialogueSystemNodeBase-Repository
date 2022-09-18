using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public class DSModifiersMaker
    {
        /// <summary>
        /// Create a new condition modifier within any nodes that are specified in the modifierAddedAction.
        /// </summary>
        /// <param name="source">The another modifier that has the values to this new modifier to load from if it's provided.</param>
        /// <param name="conditionModifierAddedAction">Action that will invoked at the end of this setup process.</param>
        /// <param name="conditionModifierRemovedAction">Action that will invoked when this modifier is deleted from the node.</param>
        public static void GetNewConditionModifier
            (ConditionModifier source, Action<ConditionModifier> conditionModifierAddedAction, Action<ConditionModifier> conditionModifierRemovedAction)
        {
            ConditionModifier newConditionModifier;

            Box mainBox;

            TextField conditionNameField;
            FloatField conditionNumberField;
            EnumField conditionEnumField;

            Button modifierRemoveButton;

            CreateNewModifier();

            SetupModifierBox();

            SetupTextField();

            SetupFloatField();

            SetupEnumField();

            SetupModifierRemoveButton();

            CheckSourceValues();

            AddFieldsToBox();

            AssignReferencesToModifier();

            ConditionModifierAddedAction();

            void CreateNewModifier()
            {
                newConditionModifier = new ConditionModifier();
            }

            void SetupModifierBox()
            {
                mainBox = new Box();
                mainBox.AddToClassList(DSStylesConfig.Modifier_Condition_MainBox);
            }

            void SetupTextField()
            {
                conditionNameField = DSTextFieldsMaker.GetNewTextField(newConditionModifier.ConditionName_TextContainer, "Condition Name", DSStylesConfig.Modifier_Condition_TextField);
            }

            void SetupFloatField()
            {
                conditionNumberField = DSFloatFieldsMaker.GetNewFloatField(newConditionModifier.ComparisonNumber_FloatContainer, DSStylesConfig.Modifier_Condition_FloatField);
            }

            void SetupEnumField()
            {
                conditionEnumField = DSEnumFieldsMaker.GetNewEnumField(newConditionModifier.ComparisonType_EnumContainer, ConditionCompareTypeChangedAction, DSStylesConfig.Modifier_Condition_EnumField);
            }

            void SetupModifierRemoveButton()
            {
                modifierRemoveButton = GetNewModifierRemoveButton(ConditionModifierRemovedAction);
            }

            void CheckSourceValues()
            {
                if (source != null)
                {
                    newConditionModifier.LoadModifierValue(source);
                }
            }

            void AddFieldsToBox()
            {
                mainBox.Add(conditionNameField);
                mainBox.Add(conditionEnumField);
                mainBox.Add(conditionNumberField);
                mainBox.Add(modifierRemoveButton);
            }

            void AssignReferencesToModifier()
            {
                newConditionModifier.MainBox = mainBox;
            }

            void ConditionModifierAddedAction()
            {
                conditionModifierAddedAction.Invoke(newConditionModifier);
                ConditionCompareTypeChangedAction();
            }

            void ConditionModifierRemovedAction()
            {
                conditionModifierRemovedAction.Invoke(newConditionModifier);
            }

            void ConditionCompareTypeChangedAction()
            {
                newConditionModifier.ToggleFloatFieldVisibleAction();
            }
        }


        /// <summary>
        /// Create a new event modifier within any nodes that are specified in the modifierAddedAction.
        /// </summary>
        /// <param name="source">The another modifier that has the values to this new modifier to load from if it's provided.</param>
        /// <param name="eventModifierAddedAction">Action that will invoked at the end of this setup process.</param>
        /// <param name="eventModifierRemovedAction">Action that will invoked when this modifier is deleted from the node.</param>
        public static void GetNewEventModifier
            (EventModifier source, Action<EventModifier> eventModifierAddedAction, Action<EventModifier> eventModifierRemovedAction)
        {
            EventModifier newEventModifier;

            Box mainBox;

            ObjectField eventObjectField;

            Button modifierRemoveButton;

            CreateNewModifier();

            SetupModifierBox();

            SetupEventObjectField();

            SetupModifierRemvoeButton();

            CheckSourceValues();

            AddFieldsToBox();

            AssignReferencesToModifier();

            EventModifierAddedAction();

            void CreateNewModifier()
            {
                newEventModifier = new EventModifier();
            }

            void SetupModifierBox()
            {
                mainBox = new Box();
                mainBox.AddToClassList(DSStylesConfig.Modifier_Event_MainBox);
            }

            void SetupEventObjectField()
            {
                eventObjectField = DSObjectFieldsMaker.GetNewObjectField(newEventModifier.DialogueEventSO_ObjectContainer, DSStylesConfig.Modifier_Event_ObjectField);
            }

            void SetupModifierRemvoeButton()
            {
                modifierRemoveButton = GetNewModifierRemoveButton(EventModifierRemovedAction);
            }

            void CheckSourceValues()
            {
                if (source != null)
                {
                    newEventModifier.LoadModifierValue(source);
                }
            }

            void AddFieldsToBox()
            {
                mainBox.Add(eventObjectField);
                mainBox.Add(modifierRemoveButton);
            }

            void AssignReferencesToModifier()
            {
                newEventModifier.MainBox = mainBox;
            }

            void EventModifierAddedAction()
            {
                eventModifierAddedAction.Invoke(newEventModifier);
            }

            void EventModifierRemovedAction()
            {
                eventModifierRemovedAction.Invoke(newEventModifier);
            }
        }


        /// <summary>
        /// Create a new modifier's remove button within each modifier.
        /// </summary>
        /// <param name="ModifierRemovedAction">The action to invoke when remove button is pressed.</param>
        /// <returns>A new button to remove the modifier that it's connecting to.</returns>
        static Button GetNewModifierRemoveButton(Action ModifierRemovedAction)
        {
            return DSButtonsMaker.GetNewButton(DSAssetsConfig.RemoveModifierButtonIconImage, ModifierRemovedAction, DSStylesConfig.Modifier_RemoveModifier_Button);
        }
    }
}