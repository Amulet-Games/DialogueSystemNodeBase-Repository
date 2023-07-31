using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class ConditionModifier
    {
        /// <summary>
        /// Variable container for storing the first term value that'll be used to compare from.
        /// </summary>
        public VariableFieldView FirstTermVariableContainer;


        /// <summary>
        /// Enum container for how the users want to compare the value in this condition.
        /// </summary>
        public ConditionComparisonTypeIconicEnumFieldView ConditionComparisonTypeEnumContainer;


        /// <summary>
        /// Text field view for storing the second term value that'll be used to compare to.
        /// </summary>
        public CommonTextFieldView SecondTermTextFieldView;


        /// <summary>
        /// Float field container for storing the second term value that'll be used to compare to.
        /// </summary>
        public CommonDoubleFieldView SecondTermFloatFieldView;


        /// <summary>
        /// Variable container for storing the second term value that'll be used to compare to.
        /// </summary>
        public VariableFieldView SecondTermVariableContainer;


        /// <summary>
        /// Is the in display second term field appearing as the keyboard input field?
        /// </summary>
        bool isShowKeyboardInputField;


        /// <summary>
        /// Button that change the second term field type when clicked.
        /// </summary>
        Button changeFieldTypeButton;


        /// <summary>
        /// Reference of the current in display second term visual element.
        /// </summary>
        VisualElement tempInDisplaySecondTermElement;


        /// <summary>
        /// Reference of the current condition comparison type.
        /// </summary>
        M_Condition_ComparisonType conditionComparisonType;


        /// <summary>
        /// The box UIElement that stores all the visual elements of its content.
        /// </summary>
        public Box MainBox;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the condition modifier component class.
        /// </summary>
        public ConditionModifier()
        {
            // First term
            FirstTermVariableContainer = new();

            // Operator
            ConditionComparisonTypeEnumContainer = new();

            // Second term
            SecondTermTextFieldView = new(placeholderText: StringConfig.ConditionModifierCompareToStringPlaceholderText);
            SecondTermFloatFieldView = new();
            SecondTermVariableContainer = new();

            // Showing keyboard input field is by default.
            isShowKeyboardInputField = true;
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in the root modifier.
        /// </summary>
        /// <param name="node">Node of which this modifier is created for.</param>
        public void CreateRootElements(NodeBase node)
        {
            // First term
            ObjectField firstTermObjectField;

            // Operator
            EnumField conditionComparisonTypeEnumField;

            // Second term
            ObjectField secondTermObjectField;

            // Side buttons
            Box buttonBox;

            SetupModifierBox();

            SetupFirstTermObjectField();

            SetupConditionComparisonTypeEnumField();

            SetupSecondTermTextField();

            SetupSecondTermFloatField();

            SetupSecondTermFloatFieldIcon();

            SetupSecondTermObjectField();

            SetupChangeFieldTypeButton();

            AddFieldsToBox();

            AddBoxToNode();

            ModifierCreatedAction();

            void SetupModifierBox()
            {
                MainBox = new();
                MainBox.AddToClassList(StyleConfig.Modifier_Condition_Rooted_Main_Box);

                buttonBox = new();
                buttonBox.AddToClassList(StyleConfig.Modifier_Condition_Rooted_Button_Box);
            }

            void SetupFirstTermObjectField()
            {
                firstTermObjectField = VariableFieldFactory.GetNewObjectField
                (
                    variableContainer: FirstTermVariableContainer,
                    fieldIcon: ConfigResourcesManager.SpriteConfig.ScriptableObjectFieldIconSprite,
                    fieldUSS01: StyleConfig.Modifier_Condition_Rooted_FirstTerm_ObjectField
                );
            }

            void SetupConditionComparisonTypeEnumField()
            {
                conditionComparisonTypeEnumField = EnumFieldFactory.GetNewIconicEnumField
                (
                    iconicEnumContainer: ConditionComparisonTypeEnumContainer,
                    containerValueChangedAction: EnumContainerValueChangedAction,
                    fieldUSS: StyleConfig.Modifier_Condition_Rooted_Operator_EnumField,
                    iconImageUSS: StyleConfig.Modifier_Condition_Rooted_Operator_Icon
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

                new CommonTextFieldCallback(view: SecondTermTextFieldView).RegisterEvents();
            }

            void SetupSecondTermFloatField()
            {
                CommonDoubleFieldPresenter.CreateElement
                (
                    view: SecondTermFloatFieldView,
                    fieldUSS: StyleConfig.Modifier_Condition_Rooted_SecondTerm_FloatField
                );

                new CommonDoubleFieldCallback(view: SecondTermFloatFieldView).RegisterEvents();
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
                    fieldUSS01: StyleConfig.Modifier_Condition_Rooted_SecondTerm_ObjectField
                );
            }

            void SetupChangeFieldTypeButton()
            {
                changeFieldTypeButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.ChangeFieldTypeButtonIconSprite,
                    buttonUSS: StyleConfig.Modifier_Condition_Rooted_ChangeFieldType_Button
                );

                new CommonButtonCallback(
                    isAlert: true,
                    button: changeFieldTypeButton,
                    clickEvent: ChangeFieldTypeButtonClickEvent).RegisterEvents();
            }

            void AddFieldsToBox()
            {
                // Button side box
                buttonBox.Add(changeFieldTypeButton);

                // Main box
                MainBox.Add(firstTermObjectField);
                MainBox.Add(conditionComparisonTypeEnumField);
                MainBox.Add(SecondTermFloatFieldView.DoubleField);
                MainBox.Add(SecondTermTextFieldView.TextField);
                MainBox.Add(secondTermObjectField);
                MainBox.Add(buttonBox);
            }

            void AddBoxToNode()
            {
                node.ContentContainer.Add(MainBox);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The action to invoke when the modifier is created.
        /// </summary>
        public void ModifierCreatedAction()
        {
            // Update the internal in display second term type.
            UpdateInDisplaySecondTermType();

            // Hide all the second term elements.
            SecondTermTextFieldView.TextField.HideElement();
            SecondTermFloatFieldView.DoubleField.HideElement();
            SecondTermVariableContainer.ObjectField.HideElement();

            // Show the new in display second term element.
            ShowSecondTermElementByComparisonType();

            // Update the variable containers' assigning type according to the
            // current condition comparison type enum container's value.
            UpdateVariableContainerAssigningType();

            // Lock the field type change button 
            LockFieldTypeChangeButton();
        }


        /// <summary>
        /// Action that invoked when the condition comparison type enum container value is changed.
        /// </summary>
        void EnumContainerValueChangedAction()
        {
            // Update the internal in display second term type.
            UpdateInDisplaySecondTermType();

            // Hide the current in display second term element.
            HideInDisplaySecondTermElement();

            // Show the new in display second term element.
            ShowSecondTermElementByComparisonType();

            // Update the variable containers' assigning type according to the
            // current condition comparison type enum container's value.
            UpdateVariableContainerAssigningType();

            // Lock the field type change button 
            LockFieldTypeChangeButton();
        }


        /// <summary>
        /// The event to invoked when the change field type button is clicked.
        /// </summary>
        void ChangeFieldTypeButtonClickEvent(ClickEvent evt)
        {
            // Switch the status.
            isShowKeyboardInputField = !isShowKeyboardInputField;

            // Hide the current in display second term element.
            HideInDisplaySecondTermElement();

            // Show the new in display second term element.
            ShowSecondTermElementByComparisonType();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the modifier values to the condition modifier model.
        /// </summary>
        /// <param name="model">The condition modifier model to set for.</param>
        public void SaveModifierValue(ConditionModifierModel model)
        {
            // Save containers.
            FirstTermVariableContainer.Save(model.FirstTermVariableGroupModel);
            model.ConditionComparisonTypeEnumIndex = ConditionComparisonTypeEnumContainer.Value;
            model.SecondTermText = SecondTermTextFieldView.TextField.value;
            //model.SecondTermFloat = SecondTermFloatFieldView.Value;
            SecondTermVariableContainer.Save(model.SecondTermVariableGroupModel);

            // Save isShowKeyboardInputField
            model.IsShowKeyboardInputField = isShowKeyboardInputField;
        }


        /// <summary>
        /// Load the modifier values from the condition modifier model.
        /// </summary>
        /// <param name="model">The condition modifier model to set for.</param>
        public void LoadModifierValue(ConditionModifierModel model)
        {
            // Load containers.
            FirstTermVariableContainer.Load(model.FirstTermVariableGroupModel);
            ConditionComparisonTypeEnumContainer.Load(model.ConditionComparisonTypeEnumIndex);
            SecondTermTextFieldView.Load(model.SecondTermText);
            SecondTermFloatFieldView.Load(model.SecondTermFloat);
            SecondTermVariableContainer.Load(model.SecondTermVariableGroupModel);

            // Load isShowKeyboardInputField.
            isShowKeyboardInputField = model.IsShowKeyboardInputField;

            // Manually invoke the enumContainerValueChanged action.
            EnumContainerValueChangedAction();
        }


        // ----------------------------- Second Term Field Related Utilities -----------------------------
        /// <summary>
        /// Update the internal condition comparison type value so that we can update
        /// <br>the other parts of the modifier accordingly.</br>
        /// </summary>
        void UpdateInDisplaySecondTermType()
        {
            // Cache the current condition comparison type enum container value internally.
            conditionComparisonType =
                (M_Condition_ComparisonType)ConditionComparisonTypeEnumContainer.Value;
        }


        /// <summary>
        /// Hide the current in display second term element.
        /// </summary>
        void HideInDisplaySecondTermElement()
        {
            if (tempInDisplaySecondTermElement != null)
                tempInDisplaySecondTermElement.HideElement();
        }


        /// <summary>
        /// Show the correct second term field element according to the current
        /// <br>condition comparison type.</br>
        /// </summary>
        void ShowSecondTermElementByComparisonType()
        {
            // Cache reference of the new in display second term element.
            VisualElement secondTermElement = null;

            switch (conditionComparisonType)
            {
                // "True" / "False" doesn't show any second term field.
                case M_Condition_ComparisonType.True:
                case M_Condition_ComparisonType.False:
                    break;

                // "Matches" shows text field.
                case M_Condition_ComparisonType.Matches:

                    secondTermElement = isShowKeyboardInputField
                        ? SecondTermTextFieldView.TextField
                        : SecondTermVariableContainer.ObjectField;

                    secondTermElement.ShowElement();
                    break;

                // "Equals" / "Bigger" / "Smaller" shows float field.
                case M_Condition_ComparisonType.Equals:
                case M_Condition_ComparisonType.EqualsOrBigger:
                case M_Condition_ComparisonType.EqualsOrSmaller:
                case M_Condition_ComparisonType.Bigger:
                case M_Condition_ComparisonType.Smaller:

                    secondTermElement = isShowKeyboardInputField
                        ? SecondTermFloatFieldView.DoubleField
                        : SecondTermVariableContainer.ObjectField;

                    secondTermElement.ShowElement();
                    break;
            }

            // Overwrite the internal reference.
            tempInDisplaySecondTermElement = secondTermElement;
        }


        /// <summary>
        /// Update the modifier's variable containers' assigning type according to the
        /// <br>current condition comparison type.</br>
        /// </summary>
        void UpdateVariableContainerAssigningType()
        {
            switch (conditionComparisonType)
            {
                // "True" and "False" compare type is "Boolean".
                case M_Condition_ComparisonType.True:
                case M_Condition_ComparisonType.False:
                    FirstTermVariableContainer.ChangeAssigningType(VariableType.Boolean);
                    break;


                // "Matches" compare type is "String".
                case M_Condition_ComparisonType.Matches:
                    FirstTermVariableContainer.ChangeAssigningType(VariableType.String);
                    SecondTermVariableContainer.ChangeAssigningType(VariableType.String);
                    break;

                // "Equals" / "Bigger" / "Smaller" compare type is "Float".
                case M_Condition_ComparisonType.Equals:
                case M_Condition_ComparisonType.EqualsOrBigger:
                case M_Condition_ComparisonType.EqualsOrSmaller:
                case M_Condition_ComparisonType.Bigger:
                case M_Condition_ComparisonType.Smaller:
                    FirstTermVariableContainer.ChangeAssigningType(VariableType.Float);
                    SecondTermVariableContainer.ChangeAssigningType(VariableType.Float);
                    break;
            }
        }


        /// <summary>
        /// Lock the modifier's change field type button if the current
        /// <br>condition comparison type is either "True" or "False".</br>
        /// </summary>
        void LockFieldTypeChangeButton()
        {
            var spriteConfig = ConfigResourcesManager.SpriteConfig;

            if (ConditionComparisonTypeEnumContainer.IsTrueOrFalseComparisonType())
            {
                // Disable button.
                changeFieldTypeButton.pickingMode = PickingMode.Ignore;
                changeFieldTypeButton.style.backgroundImage = spriteConfig.ChangeFieldTypeButtonBlockedIconSprite.texture;
            }
            else
            {
                // Enable button.
                changeFieldTypeButton.pickingMode = PickingMode.Position;
                changeFieldTypeButton.style.backgroundImage = spriteConfig.ChangeFieldTypeButtonIconSprite.texture;
            }
        }
    }
}