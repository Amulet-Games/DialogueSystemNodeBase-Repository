using UnityEngine.UIElements;

namespace AG.DS
{
    public class ConditionModifierView
    {
        public enum OperationType
        {
            String,
            Number,
            CustomLogic,
        }


        public class VariableGroup : VisualElement
        {
            public class SwitchButton : Button
            {
                /// <summary>
                /// Label for the switch button text.
                /// </summary>
                public Label TextLabel;
            }


            /// <summary>
            /// Button that switches the variable field when clicked.
            /// </summary>
            public SwitchButton m_SwitchButton;


            /// <summary>
            /// Element that contains the variable scene elements.
            /// </summary>
            public VisualElement SceneElementsContainer;


            /// <summary>
            /// The property of the scene elements displaying state
            /// </summary>
            public bool IsDisplaySceneElements
            {
                get
                {
                    return isDisplaySceneElements;
                }
                set
                {
                    isDisplaySceneElements = value;

                    UpdateDisplay(view.m_OperationType);
                }
            }


            /// <summary>
            /// The scene elements displaying state.
            /// </summary>
            bool isDisplaySceneElements = false;


            /// <summary>
            /// Selector that opens the variable search window.
            /// </summary>
            public SearchWindowSelector VariableSearchWindowSelector;


            /// <summary>
            /// Element that contains the field info elements.
            /// </summary>
            public VisualElement FieldInfoContainer;


            /// <summary>
            /// Selector that opens the field info search selector.
            /// </summary>
            public SearchWindowSelector FieldInfoSearchWindowSelector;


            /// <summary>
            /// View for the text field.
            /// </summary>
            public CommonTextFieldView TextFieldView;


            /// <summary>
            /// Element that contains the float field elements.
            /// </summary>
            public VisualElement FloatFieldContainer;


            /// <summary>
            /// View for the float field.
            /// </summary>
            public CommonFloatFieldView FloatFieldView;


            /// <summary>
            /// View for the condition modifier.
            /// </summary>
            ConditionModifierView view;


            /// <summary>
            /// Constructor of the variable group element.
            /// </summary>
            /// <param name="view">The condition modifier view to set for.</param>
            /// <param name="textFieldPlaceholderText">The text field placeholder text to set for.</param>
            public VariableGroup
            (
                ConditionModifierView view,
                string textFieldPlaceholderText
            )
            {
                this.view = view;
                TextFieldView = new(placeholderText: textFieldPlaceholderText);
                FloatFieldView = new();
            }


            /// <summary>
            /// Update the variable group's display.
            /// </summary>
            /// <param name="operationType">The operation type to set for.</param>
            public void UpdateDisplay(OperationType operationType)
            {
                this.SetDisplay(
                    operationType == OperationType.String ||
                    operationType == OperationType.Number
                );

                SceneElementsContainer.SetDisplay(IsDisplaySceneElements);

                TextFieldView.Field.SetDisplay(
                    !IsDisplaySceneElements &&
                     operationType == OperationType.String
                );

                FloatFieldContainer.SetDisplay(
                    !IsDisplaySceneElements &&
                     operationType == OperationType.Number
                );

                m_SwitchButton.TextLabel.text = IsDisplaySceneElements
                    ? StringConfig.ConditionModifierView.SwitchButton_ToManualInput_LabelText
                    : StringConfig.ConditionModifierView.SwitchButton_ToSceneObject_LabelText;
            }
        }


        /// <summary>
        /// Folder that contains the modifier's elements.
        /// </summary>
        public Folder Folder;


        /// <summary>
        /// Button that moves the modifier up one position when clicked.
        /// </summary>
        public Button MoveUpButton;


        /// <summary>
        /// Button that moves the modifier down one position when clicked.
        /// </summary>
        public Button MoveDownButton;


        /// <summary>
        /// Button that renames the modifier when clicked.
        /// </summary>
        public Button RenameButton;


        /// <summary>
        /// Button that removes the modifier when clicked.
        /// </summary>
        public Button RemoveButton;


        /// <summary>
        /// Element that contains the first variable group elements.
        /// </summary>
        public VariableGroup FirstVariableGroup;


        /// <summary>
        /// Element that contains the second variable group elements.
        /// </summary>
        public VariableGroup SecondVariableGroup;


        /// <summary>
        /// Dropdown for the operators dropdown items.
        /// </summary>
        public Dropdown OperationDropdown;


        /// <summary>
        /// Dropdown for the chain with dropdown items.
        /// </summary>
        public Dropdown ChainWithDropdown;


        /// <summary>
        /// The property of the current operation type.
        /// </summary>
        public OperationType m_OperationType
        {
            get
            {
                return m_operationType;
            }
            set
            {
                m_operationType = value;

                FirstVariableGroup.UpdateDisplay(m_operationType);
                SecondVariableGroup.UpdateDisplay(m_operationType);
            }
        }


        /// <summary>
        /// The current operation type.
        /// </summary>
        OperationType m_operationType = OperationType.String;


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Changes the move up button enabled state.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public void SetEnabledMoveUpButton(bool value) => MoveUpButton.SetEnabled(value: value);


        /// <summary>
        /// Changes the move down button enabled state.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public void SetEnabledMoveDownButton(bool value) => MoveDownButton.SetEnabled(value: value);


        /// <summary>
        /// Changes the remove button enabled state.
        /// </summary>
        /// <param name="value">The value to set to.</param>
        public void SetEnabledRemoveButton(bool value) => RemoveButton.SetEnabled(value: value);
    }
}