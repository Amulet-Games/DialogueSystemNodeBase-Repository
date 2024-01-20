using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ConditionModifierPresenter
    {
        /// <summary>
        /// Create the elements for the condition modifier.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <param name="index">The index of the modifier to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        public static void CreateElement
        (
            ConditionModifierView view,
            int index,
            GraphViewer graphViewer
        )
        {
            VisualElement helperButtonsContainer;
            VisualElement secondVariableFieldLabelContainer;
            VisualElement secondBindingFlagsContainer;
            VisualElement secondFieldInfoContainer;
            VisualElement operationChainWithContainer;
            VisualElement operationContainer;
            VisualElement chainWithContainer;

            Label secondVariableLabel;
            Label secondFloatFieldHintLabel;
            Label secondBindingFlagsLabel;
            Label operationLabel;
            Label chainWithLabel;

            Image secondReflectableImage;
            Image secondTextImage;

            CreateFolder();

            CreateContainers();

            CreateMoveUpButton();

            CreateMoveDownButton();

            CreateRenameButton();

            CreateRemoveButton();

            CreateSecondVariableSwitchFieldButton();

            CreateSecondVariableLabel();

            CreateSecondTextField();

            CreateSecondTextImage();

            CreateSecondFloatField();

            CreateSecondFloatHintLabel();

            CreateSecondReflectableObjectField();

            CreateSecondReflectableObjectImage();

            CreateSecondBindingFlagsLabel();

            CreateSecondBindingFlags();

            CreateOperationLabel();

            CreateOperationDropdown();

            CreateChainWithLabel();

            CreateChainWithDropdown();

            AddElementsToContainer();

            void CreateFolder()
            {
                view.Folder = FolderPresenter.CreateElement
                (
                    folderTitle: StringConfig.ConditionModifier_FolderTitleField_DefaultText.Append(index.ToString())
                );
            }

            void CreateContainers()
            {
                helperButtonsContainer = new();
                helperButtonsContainer.AddToClassList(StyleConfig.ConditionModifier_HelperButton_Container);

                view.SecondVariableContainer = new();
                view.SecondVariableContainer.AddToClassList(StyleConfig.ConditionModifier_SecondVariable_Container);

                secondVariableFieldLabelContainer = new();
                secondVariableFieldLabelContainer.AddToClassList(StyleConfig.ConditionModifier_SecondVariable_FieldLabel_Container);

                view.SecondReflectableElementsContainer = new();

                view.SecondBindingFlagsFieldInfoContainer = new();
                view.SecondBindingFlagsFieldInfoContainer.AddToClassList(StyleConfig.ConditionModifier_SecondBindingFlags_FieldInfo_Container);

                secondBindingFlagsContainer = new();
                secondFieldInfoContainer = new();

                view.SecondFloatFieldHintLabelContainer = new();
                view.SecondFloatFieldHintLabelContainer.AddToClassList(StyleConfig.ConditionModifier_SecondFloatField_HintLabel_Container);

                operationChainWithContainer = new();
                operationChainWithContainer.AddToClassList(StyleConfig.ConditionModifier_Operation_ChainWith_Container);

                operationContainer = new();
                operationContainer.AddToClassList(StyleConfig.ConditionModifier_Operation_Container);

                chainWithContainer = new();
                chainWithContainer.AddToClassList(StyleConfig.ConditionModifier_ChainWith_Container);
            }

            void CreateMoveUpButton()
            {
                view.MoveUpButton = CommonButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.MoveUpButtonIconSprite,
                    USS: StyleConfig.ConditionModifier_MoveUp_Button
                );

                view.MoveUpButton.AddBackgroundHighlighter();
            }

            void CreateMoveDownButton()
            {
                view.MoveDownButton = CommonButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.MoveDownButtonIconSprite,
                    USS: StyleConfig.ConditionModifier_MoveDown_Button
                );

                view.MoveDownButton.AddBackgroundHighlighter();
            }

            void CreateRenameButton()
            {
                view.RenameButton = CommonButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    USS: StyleConfig.ConditionModifier_Rename_Button
                );

                view.RenameButton.AddBackgroundHighlighter();
            }

            void CreateRemoveButton()
            {
                view.RemoveButton = CommonButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    USS: StyleConfig.ConditionModifier_Remove_Button
                );

                view.RemoveButton.AddBackgroundHighlighter();
            }

            void CreateSecondVariableSwitchFieldButton()
            {
                view.SecondVariableSwitchFieldButton = SwitchFieldButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.ConditionModifier_SwitchFieldButton_LabelText,
                    buttonIconSprite: ConfigResourcesManager.SpriteConfig.SwitchFieldButtonIconSprite,
                    buttonUSS: StyleConfig.ConditionModifier_SecondVariable_SwitchField_Button,
                    buttonLabelUSS: StyleConfig.ConditionModifier_SecondVariable_SwitchFieldButtonText_Label,
                    buttonIconUSS: StyleConfig.ConditionModifier_SecondVariable_SwitchFieldButtonIcon_Image
                );
            }

            void CreateSecondVariableLabel()
            {
                secondVariableLabel = CommonLabelPresenter.CreateElement
                (
                    text: StringConfig.ConditionModifier_SecondVariable_LabelText,
                    USS: StyleConfig.ConditionModifier_SecondVariable_Label
                );
            }

            void CreateSecondReflectableObjectField()
            {
                ReflectableObjectFieldPresenter.CreateElement
                (
                    view: view.SecondReflectableObjectFieldView,
                    fieldUSS01: StyleConfig.ConditionModifier_SecondReflectableObject_Field
                );
            }

            void CreateSecondReflectableObjectImage()
            {
                secondReflectableImage = CommonImagePresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.UnityObjectFieldIconSprite,
                    USS01: StyleConfig.ConditionModifier_SecondReflectableObject_Image
                );

                view.SecondReflectableObjectFieldView.Field.SetDisplayImage(secondReflectableImage);
            }

            void CreateSecondBindingFlagsLabel()
            {
                secondBindingFlagsLabel = CommonLabelPresenter.CreateElement
                (
                    text: StringConfig.ConditionModifier_SecondBindingFlags_LabelText,
                    USS: StyleConfig.ConditionModifier_SecondBindingFlags_Label
                );
            }

            void CreateSecondBindingFlags()
            {
                view.SecondBindingFlags = BindingFlagsPresenter.CreateElement(graphViewer);
            }

            void CreateSecondTextField()
            {
                CommonTextFieldPresenter.CreateElement
                (
                    view: view.SecondTextFieldView,
                    multiline: false,
                    fieldUSS: StyleConfig.ConditionModifier_SecondText_Field
                );
            }

            void CreateSecondTextImage()
            {
                secondTextImage = CommonImagePresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.MessageTextFieldSprite,
                    USS01: StyleConfig.ConditionModifier_SecondText_Image
                );

                view.SecondTextFieldView.Field.SetDisplayImage(secondTextImage);
            }

            void CreateSecondFloatField()
            {
                CommonFloatFieldPresenter.CreateElement
                (
                    view: view.SecondFloatFieldView,
                    fieldUSS: StyleConfig.ConditionModifier_SecondFloat_Field
                );
            }

            void CreateSecondFloatHintLabel()
            {
                secondFloatFieldHintLabel = CommonLabelPresenter.CreateElement
                (
                    text: StringConfig.ConditionModifier_SecondFloatHint_LabelText,
                    USS: StyleConfig.ConditionModifier_SecondFloatHint_Label
                );
            }

            void CreateOperationLabel()
            {
                operationLabel = CommonLabelPresenter.CreateElement
                (
                    text: StringConfig.ConditionModifier_Operation_LabelText,
                    USS: StyleConfig.ConditionModifier_Operation_Label
                );
            }

            void CreateOperationDropdown()
            {
                var matchDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_Match_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.MatchOperatorIconSprite,
                    additionalInfo: "Match"
                );

                var equalDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_Equal_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.EqualOperatorIconSprite,
                    additionalInfo: "Equal"
                );

                var equalOrBiggerDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_EqualOrBigger_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.EqualOrBiggerOperatorIconSprite,
                    additionalInfo: "EqualOrBigger"
                );

                var equalOrSmallerDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_EqualOrSmaller_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.EqualOrSmallerOperatorIconSprite,
                    additionalInfo: "EqualOrSmaller"
                );

                var biggerDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_Bigger_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.BiggerOperatorIconSprite,
                    additionalInfo: "Bigger"
                );

                var smallerDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_Smaller_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.SmallerOperatorIconSprite,
                    additionalInfo: "Smaller"
                );

                var customLogicDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_CustomLogic_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.CustomLogicOperatorIconSprite,
                    additionalInfo: "CustomLogic"
                );

                var dropdownElements = new[]
                {
                    matchDropdownElement,
                    equalDropdownElement,
                    equalOrBiggerDropdownElement,
                    equalOrSmallerDropdownElement,
                    biggerDropdownElement,
                    smallerDropdownElement,
                    customLogicDropdownElement
                };

                view.OperationDropdown = DropdownPresenter.CreateElement
                (
                    dropdownMenuHeader: StringConfig.ConditionModifier_Operators_LabelText,
                    dropdownElements,
                    graphViewer
                );
            }

            void CreateChainWithLabel()
            {
                chainWithLabel = CommonLabelPresenter.CreateElement
                (
                    text: StringConfig.ConditionModifier_ChainWith_LabelText,
                    USS: StyleConfig.ConditionModifier_ChainWith_Label
                );
            }

            void CreateChainWithDropdown()
            {
                var noneDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_None_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.UnlinkConditionIconSprite,
                    additionalInfo: "All"
                );

                var group1DropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_Group1_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.LinkConditionIconSprite,
                    additionalInfo: "Group1"
                );

                var group2DropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_Group2_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.LinkConditionIconSprite,
                    additionalInfo: "Group2"
                );

                var group3DropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_Group3_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.LinkConditionIconSprite,
                    additionalInfo: "Group3"
                );

                var dropdownElements = new[]
                {
                    noneDropdownElement,
                    group1DropdownElement,
                    group2DropdownElement,
                    group3DropdownElement
                };

                view.ChainWithDropdown = DropdownPresenter.CreateElement
                (
                    dropdownMenuHeader: StringConfig.ConditionModifier_Group_LabelText,
                    dropdownElements,
                    graphViewer
                );
            }

            void AddElementsToContainer()
            {
                // Helper buttons
                view.Folder.AddElementToTitle(helperButtonsContainer);
                helperButtonsContainer.Add(view.MoveUpButton);
                helperButtonsContainer.Add(view.MoveDownButton);
                helperButtonsContainer.Add(view.RenameButton);
                helperButtonsContainer.Add(view.RemoveButton);

                // Second Variable
                view.Folder.AddElementToContent(view.SecondVariableContainer);
                view.SecondVariableContainer.Add(secondVariableFieldLabelContainer);
                view.SecondVariableContainer.Add(view.SecondReflectableElementsContainer);
                view.SecondVariableContainer.Add(view.SecondTextFieldView.Field);
                view.SecondVariableContainer.Add(view.SecondFloatFieldHintLabelContainer);

                secondVariableFieldLabelContainer.Add(secondVariableLabel);
                secondVariableFieldLabelContainer.Add(view.SecondVariableSwitchFieldButton);

                view.SecondReflectableElementsContainer.Add(view.SecondReflectableObjectFieldView.Field);
                view.SecondReflectableElementsContainer.Add(view.SecondBindingFlagsFieldInfoContainer);

                view.SecondBindingFlagsFieldInfoContainer.Add(secondBindingFlagsContainer);
                view.SecondBindingFlagsFieldInfoContainer.Add(secondFieldInfoContainer);

                secondBindingFlagsContainer.Add(secondBindingFlagsLabel);
                secondBindingFlagsContainer.Add(view.SecondBindingFlags);

                view.SecondFloatFieldHintLabelContainer.Add(view.SecondFloatFieldView.Field);
                view.SecondFloatFieldHintLabelContainer.Add(secondFloatFieldHintLabel);

                // Operation & Chain With
                view.Folder.AddElementToContent(operationChainWithContainer);

                // Operation
                operationChainWithContainer.Add(operationContainer);
                operationContainer.Add(operationLabel);
                operationContainer.Add(view.OperationDropdown);

                // Chain With
                operationChainWithContainer.Add(chainWithContainer);
                chainWithContainer.Add(chainWithLabel);
                chainWithContainer.Add(view.ChainWithDropdown);
            }
        }


        class SwitchFieldButtonPresenter
        {
            /// <summary>
            /// Create a new switch field button element.
            /// </summary>
            /// <param name="buttonText">The button text to set for.</param>
            /// <param name="buttonIconSprite">The button icon sprite to set for.</param>
            /// <param name="buttonUSS">The button USS to set for.</param>
            /// <param name="buttonLabelUSS">The button Label USS to set for.</param>
            /// <param name="buttonIconUSS">The button icon USS to set for.</param>
            /// <returns>A new switch field button element.</returns>
            public static CommonButton CreateElement
            (
                string buttonText,
                Sprite buttonIconSprite,
                string buttonUSS,
                string buttonLabelUSS,
                string buttonIconUSS
            )
            {
                CommonButton button;

                Label buttonLabel;
                Image iconImage;

                CreateButton();

                CreateButtonLabel();

                CreateIconImage();

                SetupDetails();

                AddElementsToContentButton();

                AddStyleSheet();

                return button;

                void CreateButton()
                {
                    button = new();
                    button.AddToClassList(buttonUSS);
                }

                void CreateIconImage()
                {
                    iconImage = CommonImagePresenter.CreateElement
                    (
                        sprite: buttonIconSprite,
                        USS01: buttonIconUSS
                    );
                }

                void CreateButtonLabel()
                {
                    buttonLabel = CommonLabelPresenter.CreateElement
                    (
                        text: buttonText,
                        USS: buttonLabelUSS
                    );
                }

                void SetupDetails()
                {
                    button.AddBackgroundHighlighter();

                    buttonLabel.pickingMode = PickingMode.Position;
                }

                void AddElementsToContentButton()
                {
                    button.Add(iconImage);
                    button.Add(buttonLabel);
                }

                void AddStyleSheet()
                {
                    button.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.ConditionModifierStyle);
                }
            }
        }
    }
}