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
            VisualElement operationChainWithContainer;
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
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveUpButtonIconSprite,
                    buttonUSS: StyleConfig.ConditionModifier_MoveUp_Button
                );

                view.MoveUpButton.AddBackgroundHighlighter();
            }

            void CreateMoveDownButton()
            {
                view.MoveDownButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveDownButtonIconSprite,
                    buttonUSS: StyleConfig.ConditionModifier_MoveDown_Button
                );

                view.MoveDownButton.AddBackgroundHighlighter();
            }

            void CreateRenameButton()
            {
                view.RenameButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    buttonUSS: StyleConfig.ConditionModifier_Rename_Button
                );

                view.RenameButton.AddBackgroundHighlighter();
            }

            void CreateRemoveButton()
            {
                view.RemoveButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS: StyleConfig.ConditionModifier_Remove_Button
                );

                view.RemoveButton.AddBackgroundHighlighter();
            }

            void CreateOperationLabel()
            {
                operationLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.ConditionModifier_Operation_LabelText,
                    labelUSS: StyleConfig.ConditionModifier_Operation_Label
                );
            }

            void CreateOperationDropdown()
            {
                var matchDropdownElement = DropdownElementPresenter.CreateElement
                (
                    elementText: StringConfig.ConditionModifier_Match_LabelText,
                    elementIconSprite: ConfigResourcesManager.SpriteConfig.MatchOperatorIconSprite
                );

                var equalDropdownElement = DropdownElementPresenter.CreateElement
                (
                    elementText: StringConfig.ConditionModifier_Equal_LabelText,
                    elementIconSprite: ConfigResourcesManager.SpriteConfig.EqualOperatorIconSprite
                );

                var equalOrBiggerDropdownElement = DropdownElementPresenter.CreateElement
                (
                    elementText: StringConfig.ConditionModifier_EqualOrBigger_LabelText,
                    elementIconSprite: ConfigResourcesManager.SpriteConfig.EqualOrBiggerOperatorIconSprite
                );

                var equalOrSmallerDropdownElement = DropdownElementPresenter.CreateElement
                (
                    elementText: StringConfig.ConditionModifier_EqualOrSmaller_LabelText,
                    elementIconSprite: ConfigResourcesManager.SpriteConfig.EqualOrSmallerOperatorIconSprite
                );

                var biggerDropdownElement = DropdownElementPresenter.CreateElement
                (
                    elementText: StringConfig.ConditionModifier_Bigger_LabelText,
                    elementIconSprite: ConfigResourcesManager.SpriteConfig.BiggerOperatorIconSprite
                );

                var smallerDropdownElement = DropdownElementPresenter.CreateElement
                (
                    elementText: StringConfig.ConditionModifier_Smaller_LabelText,
                    elementIconSprite: ConfigResourcesManager.SpriteConfig.SmallerOperatorIconSprite
                );

                var customLogicDropdownElement = DropdownElementPresenter.CreateElement
                (
                    elementText: StringConfig.ConditionModifier_CustomLogic_LabelText,
                    elementIconSprite: ConfigResourcesManager.SpriteConfig.CustomLogicOperatorIconSprite
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
                    labelText: StringConfig.ConditionModifier_ChainWith_LabelText,
                    labelUSS: StyleConfig.ConditionModifier_ChainWith_Label
                );
            }

            void CreateChainWithDropdown()
            {
                var noneDropdownElement = DropdownElementPresenter.CreateElement
                (
                    elementText: StringConfig.ConditionModifier_None_LabelText,
                    elementIconSprite: ConfigResourcesManager.SpriteConfig.UnlinkConditionIconSprite
                );

                var group1DropdownElement = DropdownElementPresenter.CreateElement
                (
                    elementText: StringConfig.ConditionModifier_Group1_LabelText,
                    elementIconSprite: ConfigResourcesManager.SpriteConfig.LinkConditionIconSprite
                );

                var group2DropdownElement = DropdownElementPresenter.CreateElement
                (
                    elementText: StringConfig.ConditionModifier_Group2_LabelText,
                    elementIconSprite: ConfigResourcesManager.SpriteConfig.LinkConditionIconSprite
                );

                var group3DropdownElement = DropdownElementPresenter.CreateElement
                (
                    elementText: StringConfig.ConditionModifier_Group3_LabelText,
                    elementIconSprite: ConfigResourcesManager.SpriteConfig.LinkConditionIconSprite
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
    }
}