using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public class DSModifiersMaker
    {
        public static void GetNewModifier_Condition<T>(T node, ConditionModifier loadedModifier)
            where T : BaseNode, IConditionModifierUtility
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

            SetupButton_RemoveModifier();

            CheckLoadedModifier();

            AddFieldsToBox();

            FinishModifierSetup();

            void CreateNewModifier()
            {
                newConditionModifier = new ConditionModifier();
                node.AddModifierToData(newConditionModifier);
            }

            void SetupModifierBox()
            {
                mainBox = new Box();
                mainBox.AddToClassList(DSStylesConfig.modifier_Condition_MainBox);
            }

            void SetupTextField()
            {
                conditionNameField = DSBuiltInFieldsMaker.GetNewTextField(newConditionModifier.conditionName_TextsContainer, "Condition Name", DSStylesConfig.modifier_Condition_TextField);
            }

            void SetupFloatField()
            {
                conditionNumberField = DSBuiltInFieldsMaker.GetNewFloatField(newConditionModifier.compareNumber_FloatContainer, DSStylesConfig.modifier_Condition_FloatField);
            }

            void SetupEnumField()
            {
                SetupField();

                ToggleVisible_ModifierNumberField();

                void SetupField()
                {
                    conditionEnumField = DSBuiltInFieldsMaker.GetNewEnumField(newConditionModifier.compareMethType_EnumContainer, ToggleVisible_ModifierNumberField, DSStylesConfig.modifier_Condition_EnumField);
                }

                void ToggleVisible_ModifierNumberField()
                {
                    N_Modifier_ConditionComparisonType comparisonType = newConditionModifier.compareMethType_EnumContainer.Value;

                    DSFieldUtilityEditor.ToggleElementDisplay(comparisonType == N_Modifier_ConditionComparisonType.True || comparisonType == N_Modifier_ConditionComparisonType.False, conditionNumberField);
                }
            }

            void SetupButton_RemoveModifier()
            {
                modifierRemoveButton = DSBuiltInFieldsMaker.GetNewButton("X", RemoveModifierFromList, DSStylesConfig.modifier_Common_RemoveButton);
            }

            void CheckLoadedModifier()
            {
                if (loadedModifier != null)
                {
                    newConditionModifier.LoadModifierValue(loadedModifier);
                }
            }

            void AddFieldsToBox()
            {
                mainBox.Add(conditionNameField);
                mainBox.Add(conditionEnumField);
                mainBox.Add(conditionNumberField);
                mainBox.Add(modifierRemoveButton);

                node.mainContainer.Add(mainBox);
            }

            void FinishModifierSetup()
            {
                node.NodeRefreshStateOnly();
            }

            #region Callbacks.
            /// ModifierRemovedEvent - Internal - Condition Modifier
            void RemoveModifierFromList()
            {
                // Remove modifier from node's data.
                node.RemoveModifierFromData(newConditionModifier);

                // Remove modifier from node's container.
                node.DeleteVisualElement(mainBox, N_NodeContainerType.Main);

                // Hide the unmet condition display type enum field.
                node.ToggleUnmetConditionDisplayOptionVisible();
            }
            #endregion
        }

        public static void GetNewModifier_BasicEvent<T>(T node, BasicEventModifier loadedModifier)
            where T : BaseNode, IBasicEventModifierUtility
        {
            BasicEventModifier newBasicEventModifier;

            Box mainBox;

            TextField eventNameField;
            FloatField eventNumberField;
            EnumField eventTypeField;

            Button modifierRemoveButton;

            CreateNewModifier();

            SetupModifierBox();

            SetupTextField();

            SetupFloatField();

            SetupEnumField();

            SetupButton_RemoveModifier();

            AddFieldsToBox();

            CheckLoadedModifier();

            FinishModifierSetup();

            void CreateNewModifier()
            {
                newBasicEventModifier = new BasicEventModifier();
                node.AddModifierToData(newBasicEventModifier);
            }

            void SetupModifierBox()
            {
                mainBox = new Box();
                mainBox.AddToClassList(DSStylesConfig.modifier_BasicEvent_MainBox);
            }

            void SetupTextField()
            {
                eventNameField = DSBuiltInFieldsMaker.GetNewTextField(newBasicEventModifier.eventName_TextsContainer, "Event Name", DSStylesConfig.modifier_BasicEvent_TextField);
            }

            void SetupFloatField()
            {
                eventNumberField = DSBuiltInFieldsMaker.GetNewFloatField(newBasicEventModifier.desireNumber_FloatContainer, DSStylesConfig.modifier_BasicEvent_FloatField);
            }

            void SetupEnumField()
            {
                SetupField();

                void SetupField()
                {
                    eventTypeField = DSBuiltInFieldsMaker.GetNewEnumField(newBasicEventModifier.basicEventType_EnumContainer, ToggleVisible_ModifierNumberField, DSStylesConfig.modifier_BasicEvent_EnumField);
                }

                void ToggleVisible_ModifierNumberField()
                {
                    N_Modifier_BasicEventType currentBasicEventType = newBasicEventModifier.basicEventType_EnumContainer.Value;

                    DSFieldUtilityEditor.ToggleElementDisplay(currentBasicEventType == N_Modifier_BasicEventType.SetTrue || currentBasicEventType == N_Modifier_BasicEventType.SetFalse, eventNumberField);
                }
            }

            void SetupButton_RemoveModifier()
            {
                modifierRemoveButton = DSBuiltInFieldsMaker.GetNewButton("X", RemoveModifierFromList, DSStylesConfig.modifier_Common_RemoveButton);
            }

            void AddFieldsToBox()
            {
                mainBox.Add(eventNameField);
                mainBox.Add(eventTypeField);
                mainBox.Add(eventNumberField);
                mainBox.Add(modifierRemoveButton);

                node.mainContainer.Add(mainBox);
            }

            void CheckLoadedModifier()
            {
                if (loadedModifier != null)
                {
                    newBasicEventModifier.LoadModifierValue(loadedModifier);
                }
            }

            void FinishModifierSetup()
            {
                node.NodeRefreshStateOnly();
            }

            #region Callbacks.
            /// ModifierRemovedEvent - Internal - Basic Event Modifier
            void RemoveModifierFromList()
            {
                // Remove modifier from node's data.
                node.RemoveModifierFromData(newBasicEventModifier);

                // Remove modifier from node's container.
                node.DeleteVisualElement(mainBox, N_NodeContainerType.Main);
            }
            #endregion
        }

        public static void GetNewModifier_ScriptableEvent<T>(T node, ScriptableEventModifier loadedModifier)
            where T : BaseNode, IScriptableEventModifierUtility
        {
            ScriptableEventModifier newScriptableEventModifier;

            Box mainBox;

            ObjectField scriptableObjectField;
            Button modifierRemoveButton;

            CreateNewModifier();

            SetupModifierBox();

            SetupObjectField();

            SetupButton_RemoveModifier();

            AddFieldsToBox();

            CheckLoadedModifier();

            FinishModifierSetup();

            void CreateNewModifier()
            {
                newScriptableEventModifier = new ScriptableEventModifier();
                node.AddModifierToData(newScriptableEventModifier);
            }

            void SetupModifierBox()
            {
                mainBox = new Box();
                mainBox.AddToClassList(DSStylesConfig.modifier_ScriptableEvent_MainBox);
            }

            void SetupObjectField()
            {
                scriptableObjectField = DSBuiltInFieldsMaker.GetNewObjectField(newScriptableEventModifier.dialEventSO_Container, DSStylesConfig.modifier_ScriptableEvent_ObjectField);
            }

            void SetupButton_RemoveModifier()
            {
                modifierRemoveButton = DSBuiltInFieldsMaker.GetNewButton("X", RemoveModifierFromList, DSStylesConfig.modifier_Common_RemoveButton);
            }

            void AddFieldsToBox()
            {
                mainBox.Add(scriptableObjectField);
                mainBox.Add(modifierRemoveButton);

                node.mainContainer.Add(mainBox);
            }

            void CheckLoadedModifier()
            {
                if (loadedModifier != null)
                {
                    newScriptableEventModifier.LoadModifierValue(loadedModifier);
                }
            }

            void FinishModifierSetup()
            {
                node.NodeRefreshStateOnly();
            }

            #region Callbacks.
            /// ModifierRemovedEvent - Internal - Scriptable Event Modifier
            void RemoveModifierFromList()
            {
                // Remove modifier from node's data.
                node.RemoveModifierFromData(newScriptableEventModifier);

                // Remove modifier from node's container.
                node.DeleteVisualElement(mainBox, N_NodeContainerType.Main);
            }
            #endregion
        }

        //<---------------------------------------------------------------->
        /// Branch Node
        public static void GetNewModifier_Condition(BaseNode node, List<ConditionModifier> conditionModifiers, ConditionModifier loadedModifier)
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

            SetupButton_RemoveModifier();

            CheckLoadedModifier();

            AddFieldsToBox();

            FinishModifierSetup();

            void CreateNewModifier()
            {
                newConditionModifier = new ConditionModifier();
                conditionModifiers.Add(newConditionModifier);
            }

            void SetupModifierBox()
            {
                mainBox = new Box();
                mainBox.AddToClassList(DSStylesConfig.modifier_Condition_MainBox);
            }

            void SetupTextField()
            {
                conditionNameField = DSBuiltInFieldsMaker.GetNewTextField(newConditionModifier.conditionName_TextsContainer, "Condition Name", DSStylesConfig.modifier_Condition_TextField);
            }

            void SetupFloatField()
            {
                conditionNumberField = DSBuiltInFieldsMaker.GetNewFloatField(newConditionModifier.compareNumber_FloatContainer, DSStylesConfig.modifier_Condition_FloatField);
            }

            void SetupEnumField()
            {
                SetupField();

                ToggleVisible_ModifierNumberField();

                void SetupField()
                {
                    conditionEnumField = DSBuiltInFieldsMaker.GetNewEnumField(newConditionModifier.compareMethType_EnumContainer, ToggleVisible_ModifierNumberField, DSStylesConfig.modifier_Condition_EnumField);
                }

                void ToggleVisible_ModifierNumberField()
                {
                    N_Modifier_ConditionComparisonType comparisonType = newConditionModifier.compareMethType_EnumContainer.Value;

                    DSFieldUtilityEditor.ToggleElementDisplay(comparisonType == N_Modifier_ConditionComparisonType.True || comparisonType == N_Modifier_ConditionComparisonType.False, conditionNumberField);
                }
            }

            void SetupButton_RemoveModifier()
            {
                modifierRemoveButton = DSBuiltInFieldsMaker.GetNewButton("X", RemoveModifierFromList, DSStylesConfig.modifier_Common_RemoveButton);
            }

            void CheckLoadedModifier()
            {
                if (loadedModifier != null)
                {
                    newConditionModifier.LoadModifierValue(loadedModifier);
                }
            }

            void AddFieldsToBox()
            {
                mainBox.Add(conditionNameField);
                mainBox.Add(conditionEnumField);
                mainBox.Add(conditionNumberField);
                mainBox.Add(modifierRemoveButton);

                node.mainContainer.Add(mainBox);
            }

            void FinishModifierSetup()
            {
                node.NodeRefreshStateOnly();
            }

            #region Callbacks.
            /// ModifierRemovedEvent - Internal - Condition Modifier
            void RemoveModifierFromList()
            {
                // Remove modifier from node's data.
                conditionModifiers.Remove(newConditionModifier);

                // Remove modifier from node's container.
                node.DeleteVisualElement(mainBox, N_NodeContainerType.Main);
            }
            #endregion
        }
    }
}