using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierPresenter
    {
        /// <summary>
        /// Create all the elements for the event modifier.
        /// </summary>
        /// <param name="model">The targeting event modifier model to set for.</param>
        /// <param name="index">The index of the modifier to set for.</param>
        public static void CreateElement
        (
            EventModifierModel model,
            int index
        )
        {
            VisualElement helperButtonsContainer;
            VisualElement dialogueEventContainer;
            VisualElement dialogueEventLabel;
            VisualElement startDelayContainer;
            VisualElement startDelayLabel;
            VisualElement delaySecondsContainer;
            VisualElement delaySecondsLabel;

            SetupFolder();

            SetupHelperButtonContainer();

            SetupMoveUpButton();

            SetupMoveDownButton();

            SetupRenameButton();

            SetupRemoveButton();

            SetupDialogueEventContainer();

            SetupDialogueEventLabel();

            SetupDialogueEventObjectField();

            SetupDialogueEventObjectFieldIcon();

            SetupStartDelayContainer();

            SetupStartDelayLabel();

            SetupDelaySecondsContainer();

            SetupDelaySecondsIntegerField();

            SetupDelaySecondsLabel();

            AddElementsToContainer();

            void SetupFolder()
            {
                FolderPresenter.CreateElement
                (
                    model: model.FolderModel,
                    titleText: StringUtility.New(
                               text01: StringConfig.EventModifier_Folder_TitleText,
                               text02: index.ToString()).ToString()
                );
            }

            void SetupHelperButtonContainer()
            {
                helperButtonsContainer = new();
                helperButtonsContainer.AddToClassList(StyleConfig.EventModifier_HelperButton_Container);
            }

            void SetupMoveUpButton()
            {
                model.MoveUpButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveUpButtonIconSprite,
                    buttonUSS01: StyleConfig.EventModifier_MoveUp_Button
                );
            }

            void SetupMoveDownButton()
            {
                model.MoveDownButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.MoveDownButtonIconSprite,
                    buttonUSS01: StyleConfig.EventModifier_MoveDown_Button
                );
            }

            void SetupRenameButton()
            {
                model.RenameButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    buttonUSS01: StyleConfig.EventModifier_Rename_Button
                );
            }

            void SetupRemoveButton()
            {
                model.RemoveButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS01: StyleConfig.EventModifier_Remove_Button
                );
            }

            void SetupDialogueEventContainer()
            {
                dialogueEventContainer = new();
                dialogueEventContainer.AddToClassList(StyleConfig.EventModifier_DialogueEvent_Container);
            }

            void SetupDialogueEventLabel()
            {
                dialogueEventLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.EventModifier_DialogueEvent_LabelText,
                    labelUSS01: StyleConfig.EventModifier_DialogueEvent_Label
                );
            }

            void SetupDialogueEventObjectField()
            {
                model.DialogueEventObjectFieldModel.ObjectField =
                    CommonObjectFieldPresenter.CreateElement<DialogueEvent>
                    (
                        fieldUSS01: StyleConfig.EventModifier_DialogueEvent_ObjectField
                    );
            }

            void SetupDialogueEventObjectFieldIcon()
            {
                model.DialogueEventObjectFieldModel.ObjectField.RemoveFieldIcon();
                model.DialogueEventObjectFieldModel.ObjectField.AddFieldIcon
                (
                    iconSprite: ConfigResourcesManager.SpriteConfig.EventFieldIconSprite
                );
            }

            void SetupStartDelayContainer()
            {
                startDelayContainer = new();
                startDelayContainer.AddToClassList(StyleConfig.EventModifier_DelaySeconds_Container);
            }

            void SetupStartDelayLabel()
            {
                startDelayLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.EventModifier_StartDelay_LabelText,
                    labelUSS01: StyleConfig.EventModifier_StartDelay_Label
                );
            }

            void SetupDelaySecondsContainer()
            {
                delaySecondsContainer = new();
                delaySecondsContainer.AddToClassList(StyleConfig.EventModifier_DelaySeconds_Container);
            }

            void SetupDelaySecondsIntegerField()
            {
                model.DelaySecondsIntegerFieldModel.IntegerField =
                    CommonIntegerFieldPresenter.CreateElement
                    (
                        fieldUSS01: StyleConfig.EventModifier_DelaySeconds_IntegerField
                    );
            }

            void SetupDelaySecondsLabel()
            {
                delaySecondsLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: StringConfig.EventModifier_DelaySeconds_LabelText,
                    labelUSS01: StyleConfig.EventModifier_DelaySeconds_Label
                );
            }

            void AddElementsToContainer()
            {
                // Helper buttons
                model.FolderModel.AddElementToTitle(helperButtonsContainer);
                helperButtonsContainer.Add(model.MoveUpButton);
                helperButtonsContainer.Add(model.MoveDownButton);
                helperButtonsContainer.Add(model.RenameButton);
                helperButtonsContainer.Add(model.RemoveButton);

                // Dialogue Event Container
                model.FolderModel.AddElementToContent(dialogueEventContainer);
                dialogueEventContainer.Add(dialogueEventLabel);
                dialogueEventContainer.Add(model.DialogueEventObjectFieldModel.ObjectField);

                // Start Delay Container.
                model.FolderModel.AddElementToContent(startDelayContainer);
                startDelayContainer.Add(startDelayLabel);
                startDelayContainer.Add(delaySecondsContainer);

                // Delay Seconds Container.
                delaySecondsContainer.Add(model.DelaySecondsIntegerFieldModel.IntegerField);
                delaySecondsContainer.Add(delaySecondsLabel);
            }
        }
    }
}

/*
 //Button modifierRemoveButton = null;

            //SetupModifierBox();

            //SetupEventSOField();

            //SetupModifierRemoveButton();

            //CheckSourceValues();

            //AddFieldsToBox();

            //InvokeModifierCreatedAction();

            //void SetupModifierBox()
            //{
            //    MainBox = new();
            //    MainBox.AddToClassList(StyleConfig.Instance.EventModifier_HelperButton_Container);
            //}

            //void SetupEventSOField()
            //{
            //    EventObjectFieldModel.ObjectField =
            //        CommonObjectFieldPresenter.CreateElements<DialogueEvent>
            //        (
            //            fieldUSS01: StyleConfig.Instance.EventModifier_DialogueEvent_ObjectField,
            //            iconSprite: SpriteConfig.Instance.EventFieldIconSprite
            //        );

            //    new CommonObjectFieldCallback<DialogueEvent>(
            //        model: EventObjectFieldModel).RegisterEvents();
            //}

            //void SetupModifierRemoveButton()
            //{
            //    modifierRemoveButton = CommonButtonPresenter.CreateElements
            //    (
            //        buttonUSS01: StyleConfig.Instance.Modifier_Event_Remove_Button,
            //        buttonSprite: SpriteConfig.Instance.RemoveButtonIcon2Sprite
            //    );

            //    new CommonButtonCallback(
            //        isAlert: true,
            //        button: modifierRemoveButton,
            //        clickEvent: evt => removeButtonClickAction.Invoke(this)).RegisterEvents();
            //}

            //void CheckSourceValues()
            //{
            //    if (data != null)
            //        LoadModifierValue(data);
            //}

            //void AddFieldsToBox()
            //{
            //    // Main box
            //    MainBox.Add(EventObjectFieldModel.ObjectField);
            //    MainBox.Add(modifierRemoveButton);
            //}

            //void InvokeModifierCreatedAction()
            //{
            //    modifierCreatedAction.Invoke(this);
            //}
 */