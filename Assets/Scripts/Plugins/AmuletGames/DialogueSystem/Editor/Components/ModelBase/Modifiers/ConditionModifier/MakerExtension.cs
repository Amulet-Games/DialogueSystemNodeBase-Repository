using System;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class ConditionModifier
    {
        /// <summary>
        /// Create all the UIElements that are needed in the instance modifier.
        /// </summary>
        /// <param name="data">The modifier data to load from.</param>
        /// <param name="modifierCreatedAction">The action to invoke when the modifier is created.</param>
        /// <param name="removeButtonClickAction">The action to invoke when the modifier remove button is clicked.</param>
        public void CreateInstanceElements
        (
            ConditionModifierData data,
            Action<ConditionModifier> modifierCreatedAction,
            Action<ConditionModifier> removeButtonClickAction
        )
        {
            // Boxes
            Box buttonSideBox;

            // First term
            ObjectField firstTermObjectField;

            // Operator
            EnumField conditionComparisonTypeEnumField;

            // Second term
            ObjectField secondTermObjectField;

            Button modifierRemoveButton;

            SetupModifierBox();

            SetupFirstTermObjectField();

            SetupConditionComparisonTypeEnumField();

            SetupSecondTermTextField();

            SetupSecondTermFloatField();

            SetupSecondTermFloatFieldIcon();

            SetupSecondTermObjectField();

            SetupChangeFieldTypeButton();

            SetupModifierRemoveButton();

            CheckSourceValues();

            AddFieldsToBox();

            InvokeModifierCreatedAction();

            void SetupModifierBox()
            {
                MainBox = new();
                MainBox.AddToClassList(StyleConfig.Instance.Modifier_Condition_Main_Box);

                buttonSideBox = new();
                buttonSideBox.AddToClassList(StyleConfig.Instance.Modifier_Condition_Button_Box);
            }

            void SetupFirstTermObjectField()
            {
                firstTermObjectField = VariableFieldFactory.GetNewObjectField
                (
                    variableContainer: FirstTermVariableContainer,
                    fieldIcon: ConfigResourcesManager.Instance.SpriteConfig.ScriptableObjectFieldIconSprite,
                    fieldUSS01: StyleConfig.Instance.Modifier_Condition_FirstTerm_ObjectField
                );
            }

            void SetupConditionComparisonTypeEnumField()
            {
                conditionComparisonTypeEnumField = EnumFieldFactory.GetNewIconicEnumField
                (
                    iconicEnumContainer: ConditionComparisonTypeEnumContainer,
                    containerValueChangedAction: EnumContainerValueChangedAction,
                    fieldUSS01: StyleConfig.Instance.Modifier_Condition_Operator_EnumField,
                    iconImageUSS01: StyleConfig.Instance.Modifier_Condition_Operator_Icon
                );
            }

            void SetupSecondTermTextField()
            {
                SecondTermTextFieldModel.TextField = CommonTextFieldPresenter.CreateElements
                (
                    isMultiLine: false,
                    placeholderText: SecondTermTextFieldModel.PlaceholderText,
                    fieldUSS01: StyleConfig.Instance.Modifier_Condition_Rooted_SecondTerm_TextField
                );

                new CommonTextFieldCallback(model: SecondTermTextFieldModel).RegisterEvents();
            }

            void SetupSecondTermFloatField()
            {
                SecondTermFloatFieldModel.FloatField = CommonFloatFieldPresenter.CreateElements
                (
                    fieldUSS01: StyleConfig.Instance.Modifier_Condition_SecondTerm_FloatField
                );

                new CommonFloatFieldCallback(model: SecondTermFloatFieldModel).RegisterEvents();
            }

            void SetupSecondTermFloatFieldIcon()
            {
                SecondTermFloatFieldModel.FloatField.AddFieldIcon
                (
                    iconSprite: ConfigResourcesManager.Instance.SpriteConfig.KeyboardInputFieldIconSprite
                );
            }

            void SetupSecondTermObjectField()
            {
                secondTermObjectField = VariableFieldFactory.GetNewObjectField
                (
                    variableContainer: SecondTermVariableContainer,
                    fieldIcon: ConfigResourcesManager.Instance.SpriteConfig.ScriptableObjectFieldIconSprite,
                    fieldUSS01: StyleConfig.Instance.Modifier_Condition_SecondTerm_ObjectField
                );
            }

            void SetupChangeFieldTypeButton()
            {
                changeFieldTypeButton = CommonButtonPresenter.CreateElements
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.ChangeFieldTypeButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.Modifier_Condition_ChangeFieldType_Button
                );

                new CommonButtonCallback(
                    isAlert: true,
                    button: changeFieldTypeButton,
                    clickEvent: ChangeFieldTypeButtonClickEvent).RegisterEvents();
            }

            void SetupModifierRemoveButton()
            {
                modifierRemoveButton = CommonButtonPresenter.CreateElements
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.RemoveButtonIcon2Sprite,
                    buttonUSS01: StyleConfig.Instance.Modifier_Condition_Remove_Button
                );

                new CommonButtonCallback(
                    isAlert: true,
                    button: modifierRemoveButton,
                    clickEvent: evt => removeButtonClickAction.Invoke(this)).RegisterEvents();
            }

            void CheckSourceValues()
            {
                if (data != null)
                    LoadModifierValue(data);
            }

            void AddFieldsToBox()
            {
                // Button side box
                buttonSideBox.Add(changeFieldTypeButton);
                buttonSideBox.Add(modifierRemoveButton);

                // Main box
                MainBox.Add(firstTermObjectField);
                MainBox.Add(conditionComparisonTypeEnumField);
                MainBox.Add(SecondTermFloatFieldModel.FloatField);
                MainBox.Add(SecondTermTextFieldModel.TextField);
                MainBox.Add(secondTermObjectField);
                MainBox.Add(buttonSideBox);
            }

            void InvokeModifierCreatedAction()
            {
                ModifierCreatedAction();
                modifierCreatedAction.Invoke(this);
            }
        }
    }
}