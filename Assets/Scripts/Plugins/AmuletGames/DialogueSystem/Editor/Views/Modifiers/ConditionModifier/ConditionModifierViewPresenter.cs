using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    using SwitchButton = ConditionModifierView.VariableGroup.SwitchButton;
    using VariableGroup = ConditionModifierView.VariableGroup;

    public class ConditionModifierViewPresenter
    {
        class VariableGroupPresenter
        {
            class SwitchButtonPresenter
            {
                /// <summary>
                /// Create a new switch button element.
                /// </summary>
                /// <param name="buttonText">The button text to set for.</param>
                /// <param name="buttonIconSprite">The button icon sprite to set for.</param>
                /// <param name="buttonUSS">The button USS to set for.</param>
                /// <param name="buttonLabelUSS">The button Label USS to set for.</param>
                /// <param name="buttonIconUSS">The button icon USS to set for.</param>
                /// <returns>A new switch button element.</returns>
                public static SwitchButton CreateElement
                (
                    string buttonText,
                    Sprite buttonIconSprite,
                    string buttonUSS,
                    string buttonLabelUSS,
                    string buttonIconUSS
                )
                {
                    SwitchButton button;
                    Image iconImage;

                    CreateButton();

                    CreateTextLabel();

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
                        iconImage = ImagePresenter.CreateElement
                        (
                            sprite: buttonIconSprite,
                            USS01: buttonIconUSS
                        );
                    }

                    void CreateTextLabel()
                    {
                        button.TextLabel = LabelPresenter.CreateElement
                        (
                            text: buttonText,
                            USS: buttonLabelUSS
                        );
                    }

                    void SetupDetails()
                    {
                        button.TextLabel.pickingMode = PickingMode.Position;
                    }

                    void AddElementsToContentButton()
                    {
                        button.Add(iconImage);
                        button.Add(button.TextLabel);
                    }

                    void AddStyleSheet()
                    {
                        button.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.ConditionModifierStyle);
                    }
                }
            }


            /// <summary>
            /// Create a new variable group element.
            /// </summary>
            /// <param name="view">The condition modifier view to set for.</param>s
            /// <param name="mainLabelText">The main label text to set for.</param>
            /// <param name="textFieldPlaceholderText">The text field placeholder text to set for.</param>
            /// <returns>A new variable group element.</returns>
            public static VariableGroup CreateElement
            (
                ConditionModifierView view,
                string mainLabelText,
                string textFieldPlaceholderText,
                string floatFieldHintLabelText
            )
            {
                VariableGroup group;

                VisualElement mainLabelContainer;

                Label mainLabel;
                Label floatFieldHintLabel;
                Label fieldInfoLabel;

                CreateGroup();

                CreateContainers();

                CreateSwitchButton();

                CreateMainLabel();

                CreateVariableSearchWindowSelector();

                CreateFieldInfoLabel();

                CreateFieldInfoSearchWindowSelector();

                CreateTextField();

                CreateFloatField();

                CreateFloatFieldHintLabel();

                AddElementsToGroup();

                AddStyleSheet();

                return group;

                void CreateGroup()
                {
                    group = new(view);
                    group.AddToClassList(StyleConfig.ConditionModifier_VariableGroup);
                }

                void CreateContainers()
                {
                    mainLabelContainer = new();
                    mainLabelContainer.AddToClassList(StyleConfig.ConditionModifier_VariableGroup_MainLabelContainer);

                    group.SceneElementsContainer = new();

                    group.FieldInfoContainer = new();
                    group.FieldInfoContainer.AddToClassList(StyleConfig.ConditionModifier_VariableGroup_FieldInfo_Container);

                    group.FloatFieldContainer = new();
                    group.FloatFieldContainer.AddToClassList(StyleConfig.ConditionModifier_VariableGroup_FloatField_Container);

                }

                void CreateSwitchButton()
                {
                    group.m_SwitchButton = SwitchButtonPresenter.CreateElement
                    (
                        buttonText: StringConfig.ConditionModifierView.SwitchButton_ToSceneObject_LabelText,
                        buttonIconSprite: ConfigResourcesManager.SpriteConfig.SwitchButtonIconSprite,
                        buttonUSS: StyleConfig.ConditionModifier_SwitchButton,
                        buttonLabelUSS: StyleConfig.ConditionModifier_SwitchButton_TextLabel,
                        buttonIconUSS: StyleConfig.ConditionModifier_SwitchButton_IconImage
                    );
                }

                void CreateMainLabel()
                {
                    mainLabel = LabelPresenter.CreateElement
                    (
                        text: mainLabelText,
                        USS: StyleConfig.ConditionModifier_VariableGroup_Label
                    );
                }

                void CreateVariableSearchWindowSelector()
                {
                    group.VariableSearchWindowSelector = SearchWindowSelectorPresenter.CreateElement
                    (
                        group.VariableSearchWindowView,
                        selectorButtonIconSprite: ConfigResourcesManager.SpriteConfig.SceneObjectFieldIconSprite,
                        nullValueSelectorButtonLabelText: StringConfig.ConditionModifierView.VariableSearchWindowSelector_PlaceholderText
                    );
                }

                void CreateFieldInfoLabel()
                {
                    fieldInfoLabel = LabelPresenter.CreateElement
                    (
                        text: StringConfig.ConditionModifierView.FieldInfo_LabelText,
                        USS: StyleConfig.ConditionModifier_VariableGroup_FieldInfo_Label
                    );
                }

                void CreateFieldInfoSearchWindowSelector()
                {
                    group.FieldInfoSearchWindowSelector = SearchWindowSelectorPresenter.CreateElement
                    (
                        group.FieldInfoSearchWindowView,
                        selectorButtonIconSprite: ConfigResourcesManager.SpriteConfig.SceneObjectFieldIconSprite,
                        nullValueSelectorButtonLabelText: StringConfig.ConditionModifierView.FieldInfoSearchWindowSelector_PlaceholderText
                    );
                }

                void CreateTextField()
                {
                    CommonTextFieldViewPresenter.CreateElement
                    (
                        view: group.TextFieldView,
                        placeholderText: textFieldPlaceholderText,
                        multiline: false,
                        fieldUSS: StyleConfig.ConditionModifier_VariableGroup_TextField_Field,
                        fieldImageSprite: ConfigResourcesManager.SpriteConfig.MessageTextFieldSprite
                    );
                }

                void CreateFloatField()
                {
                    CommonFloatFieldPresenter.CreateElement
                    (
                        view: group.FloatFieldView,
                        fieldUSS: StyleConfig.ConditionModifier_VariableGroup_FloatField_Field
                    );
                }

                void CreateFloatFieldHintLabel()
                {
                    floatFieldHintLabel = LabelPresenter.CreateElement
                    (
                        text: floatFieldHintLabelText,
                        USS: StyleConfig.ConditionModifier_VariableGroup_FloatField_HintLabel
                    );
                }

                void AddElementsToGroup()
                {
                    mainLabelContainer.Add(mainLabel);
                    mainLabelContainer.Add(group.m_SwitchButton);

                    group.SceneElementsContainer.Add(group.VariableSearchWindowSelector);
                    group.SceneElementsContainer.Add(group.FieldInfoContainer);

                    group.FieldInfoContainer.Add(fieldInfoLabel);
                    group.FieldInfoContainer.Add(group.FieldInfoSearchWindowSelector);

                    group.FloatFieldContainer.Add(group.FloatFieldView.Field);
                    group.FloatFieldContainer.Add(floatFieldHintLabel);

                    group.Add(mainLabelContainer);
                    group.Add(group.SceneElementsContainer);
                    group.Add(group.TextFieldView.Field);
                    group.Add(group.FloatFieldContainer);

                }

                void AddStyleSheet()
                {
                    group.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.ConditionModifierStyle);
                }
            }
        }


        /// <summary>
        /// Create the elements for the condition modifier view.
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
            VisualElement dropdownsContainer;
            VisualElement operationContainer;
            VisualElement chainWithContainer;

            Label operationLabel;
            Label chainWithLabel;

            CreateFolder();

            CreateContainers();

            CreateMoveUpButton();

            CreateMoveDownButton();

            CreateRenameButton();

            CreateRemoveButton();

            CreateFirstVariableGroup();

            CreateSecondVariableGroup();

            CreateOperationLabel();

            CreateOperationDropdown();

            CreateChainWithLabel();

            CreateChainWithDropdown();

            AddElementsToModifier();

            void CreateFolder()
            {
                view.Folder = FolderPresenter.CreateElement
                (
                    folderTitle: StringConfig.ConditionModifierView.FolderTitleField_DefaultText.Append(index.ToString())
                );
            }

            void CreateContainers()
            {
                helperButtonsContainer = new();
                helperButtonsContainer.AddToClassList(StyleConfig.ConditionModifier_HelperButtons_Container);

                dropdownsContainer = new();
                dropdownsContainer.AddToClassList(StyleConfig.ConditionModifier_Dropdowns_Container);

                operationContainer = new();
                operationContainer.AddToClassList(StyleConfig.ConditionModifier_Operation_Container);

                chainWithContainer = new();
                chainWithContainer.AddToClassList(StyleConfig.ConditionModifier_ChainWith_Container);
            }

            void CreateMoveUpButton()
            {
                view.MoveUpButton = ButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.MoveUpButtonIconSprite,
                    USS: StyleConfig.ConditionModifier_MoveUp_Button
                );

                view.MoveUpButton.AddBackgroundHighlighter();
            }

            void CreateMoveDownButton()
            {
                view.MoveDownButton = ButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.MoveDownButtonIconSprite,
                    USS: StyleConfig.ConditionModifier_MoveDown_Button
                );

                view.MoveDownButton.AddBackgroundHighlighter();
            }

            void CreateRenameButton()
            {
                view.RenameButton = ButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    USS: StyleConfig.ConditionModifier_Rename_Button
                );

                view.RenameButton.AddBackgroundHighlighter();
            }

            void CreateRemoveButton()
            {
                view.RemoveButton = ButtonPresenter.CreateElement
                (
                    sprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    USS: StyleConfig.ConditionModifier_Remove_Button
                );

                view.RemoveButton.AddBackgroundHighlighter();
            }

            void CreateFirstVariableGroup()
            {
                view.FirstVariableGroup = VariableGroupPresenter.CreateElement
                (
                    view: view,
                    mainLabelText: StringConfig.ConditionModifierView.FirstVariable_LabelText,
                    textFieldPlaceholderText: StringConfig.ConditionModifierView.FirstTextField_PlaceholderText,
                    floatFieldHintLabelText: StringConfig.ConditionModifierView.FirstFloatField_HintLabelText
                );

                // First Variable Group's Label and SwitchButton has extra style
                var mainLabel = view.FirstVariableGroup.Q(className: StyleConfig.ConditionModifier_VariableGroup_Label);
                var switchButton = view.FirstVariableGroup.Q(className: StyleConfig.ConditionModifier_SwitchButton);

                mainLabel.AddToClassList(StyleConfig.ConditionModifier_VariableGroup_Label_First);
                switchButton.AddToClassList(StyleConfig.ConditionModifier_SwitchButton_First);
            }

            void CreateSecondVariableGroup()
            {
                view.SecondVariableGroup = VariableGroupPresenter.CreateElement
                (
                    view: view,
                    mainLabelText: StringConfig.ConditionModifierView.SecondVariable_LabelText,
                    textFieldPlaceholderText: StringConfig.ConditionModifierView.SecondTextField_PlaceholderText,
                    floatFieldHintLabelText: StringConfig.ConditionModifierView.SecondFloatField_HintLabelText
                );
            }

            void CreateOperationLabel()
            {
                operationLabel = LabelPresenter.CreateElement
                (
                    text: StringConfig.ConditionModifierView.Operation_LabelText,
                    USS: StyleConfig.ConditionModifier_Operation_Label
                );
            }

            void CreateOperationDropdown()
            {
                var matchDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifierView.Match_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.MatchOperatorIconSprite,
                    additionalInfo: "Match"
                );

                var equalDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifierView.Equal_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.EqualOperatorIconSprite,
                    additionalInfo: "Equal"
                );

                var equalOrBiggerDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifierView.EqualOrBigger_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.EqualOrBiggerOperatorIconSprite,
                    additionalInfo: "EqualOrBigger"
                );

                var equalOrSmallerDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifierView.EqualOrSmaller_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.EqualOrSmallerOperatorIconSprite,
                    additionalInfo: "EqualOrSmaller"
                );

                var biggerDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifierView.Bigger_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.BiggerOperatorIconSprite,
                    additionalInfo: "Bigger"
                );

                var smallerDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifierView.Smaller_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.SmallerOperatorIconSprite,
                    additionalInfo: "Smaller"
                );

                var customLogicDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifierView.CustomLogic_LabelText,
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
                    dropdownMenuHeader: StringConfig.ConditionModifierView.Operators_LabelText,
                    dropdownElements,
                    graphViewer
                );
            }

            void CreateChainWithLabel()
            {
                chainWithLabel = LabelPresenter.CreateElement
                (
                    text: StringConfig.ConditionModifierView.ChainWith_LabelText,
                    USS: StyleConfig.ConditionModifier_ChainWith_Label
                );
            }

            void CreateChainWithDropdown()
            {
                var noneDropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifierView.None_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.UnlinkConditionIconSprite,
                    additionalInfo: "All"
                );

                var group1DropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifierView.Group1_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.LinkConditionIconSprite,
                    additionalInfo: "Group1"
                );

                var group2DropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifierView.Group2_LabelText,
                    iconSprite: ConfigResourcesManager.SpriteConfig.LinkConditionIconSprite,
                    additionalInfo: "Group2"
                );

                var group3DropdownElement = DropdownItemPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifierView.Group3_LabelText,
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
                    dropdownMenuHeader: StringConfig.ConditionModifierView.Group_LabelText,
                    dropdownElements,
                    graphViewer
                );
            }

            void AddElementsToModifier()
            {
                // Helper buttons
                view.Folder.AddElementToTitle(helperButtonsContainer);
                helperButtonsContainer.Add(view.MoveUpButton);
                helperButtonsContainer.Add(view.MoveDownButton);
                helperButtonsContainer.Add(view.RenameButton);
                helperButtonsContainer.Add(view.RemoveButton);

                // Variable Groups
                view.Folder.AddElementToContent(view.FirstVariableGroup);
                view.Folder.AddElementToContent(view.SecondVariableGroup);

                // Operation
                dropdownsContainer.Add(operationContainer);
                operationContainer.Add(operationLabel);
                operationContainer.Add(view.OperationDropdown);

                // Chain With
                dropdownsContainer.Add(chainWithContainer);
                chainWithContainer.Add(chainWithLabel);
                chainWithContainer.Add(view.ChainWithDropdown);

                // Operation & Chain With
                view.Folder.AddElementToContent(dropdownsContainer);
            }
        }
    }
}