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
        /// <param name="model">The modifier model to load from.</param>
        /// <param name="modifierCreatedAction">The action to invoke when the modifier is created.</param>
        /// <param name="removeButtonClickAction">The action to invoke when the modifier remove button is clicked.</param>
        public void CreateInstanceElements
        (
            ConditionModifierModel model,
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
                MainBox.AddToClassList(StyleConfig.Modifier_Condition_Main_Box);

                buttonSideBox = new();
                buttonSideBox.AddToClassList(StyleConfig.Modifier_Condition_Button_Box);
            }

            void SetupFirstTermObjectField()
            {
                firstTermObjectField = VariableFieldFactory.GetNewObjectField
                (
                    variableContainer: FirstTermVariableContainer,
                    fieldIcon: ConfigResourcesManager.SpriteConfig.ScriptableObjectFieldIconSprite,
                    fieldUSS01: StyleConfig.Modifier_Condition_FirstTerm_ObjectField
                );
            }

            void SetupConditionComparisonTypeEnumField()
            {
                conditionComparisonTypeEnumField = EnumFieldFactory.GetNewIconicEnumField
                (
                    iconicEnumContainer: ConditionComparisonTypeEnumContainer,
                    containerValueChangedAction: EnumContainerValueChangedAction,
                    fieldUSS: StyleConfig.Modifier_Condition_Operator_EnumField,
                    iconImageUSS: StyleConfig.Modifier_Condition_Operator_Icon
                );
            }

            void SetupSecondTermTextField()
            {
                SecondTermTextFieldView.TextField = CommonTextFieldPresenter.CreateElement
                (
                    isMultiLine: false,
                    placeholderText: SecondTermTextFieldView.PlaceholderText,
                    fieldUSS: StyleConfig.Modifier_Condition_Rooted_SecondTerm_TextField
                );

                new CommonTextFieldObserver(view: SecondTermTextFieldView).RegisterEvents();
            }

            void SetupSecondTermFloatField()
            {
                CommonDoubleFieldPresenter.CreateElement
                (
                    view: SecondTermFloatFieldView,
                    fieldUSS: StyleConfig.Modifier_Condition_SecondTerm_FloatField
                );

                new CommonDoubleFieldObserver(view: SecondTermFloatFieldView).RegisterEvents();
            }

            void SetupSecondTermFloatFieldIcon()
            {
                //SecondTermFloatFieldView.FloatField.AddFieldIcon
                //(
                //    iconSprite: ConfigResourcesManager.SpriteConfig.KeyboardInputFieldIconSprite
                //);
            }

            void SetupSecondTermObjectField()
            {
                secondTermObjectField = VariableFieldFactory.GetNewObjectField
                (
                    variableContainer: SecondTermVariableContainer,
                    fieldIcon: ConfigResourcesManager.SpriteConfig.ScriptableObjectFieldIconSprite,
                    fieldUSS01: StyleConfig.Modifier_Condition_SecondTerm_ObjectField
                );
            }

            void SetupChangeFieldTypeButton()
            {
                changeFieldTypeButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.ChangeFieldTypeButtonIconSprite,
                    buttonUSS: StyleConfig.Modifier_Condition_ChangeFieldType_Button
                );

                new CommonButtonObserver(
                    isAlert: true,
                    button: changeFieldTypeButton,
                    clickEvent: ChangeFieldTypeButtonClickEvent).RegisterEvents();
            }

            void SetupModifierRemoveButton()
            {
                modifierRemoveButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIcon2Sprite,
                    buttonUSS: StyleConfig.Modifier_Condition_Remove_Button
                );

                new CommonButtonObserver(
                    isAlert: true,
                    button: modifierRemoveButton,
                    clickEvent: evt => removeButtonClickAction.Invoke(this)).RegisterEvents();
            }

            void CheckSourceValues()
            {
                if (model != null)
                    LoadModifierValue(model);
            }

            void AddFieldsToBox()
            {
                // Button side box
                buttonSideBox.Add(changeFieldTypeButton);
                buttonSideBox.Add(modifierRemoveButton);

                // Main box
                MainBox.Add(firstTermObjectField);
                MainBox.Add(conditionComparisonTypeEnumField);
                MainBox.Add(SecondTermFloatFieldView.Field);
                MainBox.Add(SecondTermTextFieldView.TextField);
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