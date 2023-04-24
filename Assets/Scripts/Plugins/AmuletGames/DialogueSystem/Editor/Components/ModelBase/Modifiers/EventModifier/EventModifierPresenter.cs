using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventModifierPresenter
    {
        /// <summary>
        /// Create all the UIElements for the event modifier.
        /// </summary>
        /// <param name="model">The targeting event modifier model to set for.</param>
        /// <param name="index">The index of the modifier to set for.</param>
        public static void CreateElements
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
                FolderPresenter.CreateElements
                (
                    model: model.FolderModel,
                    titleText: StringUtility.New(
                               text01: StringConfig.Instance.EventModifier_Folder_TitleText,
                               text02: index.ToString()).ToString()
                );
            }

            void SetupHelperButtonContainer()
            {
                helperButtonsContainer = new();
                helperButtonsContainer.AddToClassList(StyleConfig.Instance.EventModifier_HelperButton_Container);
            }

            void SetupMoveUpButton()
            {
                model.MoveUpButton = CommonButtonPresenter.CreateElements
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.MoveUpButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.EventModifier_MoveUp_Button
                );
            }

            void SetupMoveDownButton()
            {
                model.MoveDownButton = CommonButtonPresenter.CreateElements
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.MoveDownButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.EventModifier_MoveDown_Button
                );
            }

            void SetupRenameButton()
            {
                model.RenameButton = CommonButtonPresenter.CreateElements
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.EditButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.EventModifier_Rename_Button
                );
            }

            void SetupRemoveButton()
            {
                model.RemoveButton = CommonButtonPresenter.CreateElements
                (
                    buttonSprite: ConfigResourcesManager.Instance.SpriteConfig.RemoveButtonIconSprite,
                    buttonUSS01: StyleConfig.Instance.EventModifier_Remove_Button
                );
            }

            void SetupDialogueEventContainer()
            {
                dialogueEventContainer = new();
                dialogueEventContainer.AddToClassList(StyleConfig.Instance.EventModifier_DialogueEvent_Container);
            }

            void SetupDialogueEventLabel()
            {
                dialogueEventLabel = CommonLabelPresenter.CreateElements
                (
                    labelText: StringConfig.Instance.EventModifier_DialogueEvent_LabelText,
                    labelUSS01: StyleConfig.Instance.EventModifier_DialogueEvent_Label
                );
            }

            void SetupDialogueEventObjectField()
            {
                model.DialogueEventObjectFieldModel.ObjectField =
                    CommonObjectFieldPresenter.CreateElements<DialogueEvent>
                    (
                        fieldUSS01: StyleConfig.Instance.EventModifier_DialogueEvent_ObjectField
                    );
            }

            void SetupDialogueEventObjectFieldIcon()
            {
                model.DialogueEventObjectFieldModel.ObjectField.RemoveFieldIcon();
                model.DialogueEventObjectFieldModel.ObjectField.AddFieldIcon
                (
                    iconSprite: ConfigResourcesManager.Instance.SpriteConfig.EventFieldIconSprite
                );
            }

            void SetupStartDelayContainer()
            {
                startDelayContainer = new();
                startDelayContainer.AddToClassList(StyleConfig.Instance.EventModifier_DelaySeconds_Container);
            }

            void SetupStartDelayLabel()
            {
                startDelayLabel = CommonLabelPresenter.CreateElements
                (
                    labelText: StringConfig.Instance.EventModifier_StartDelay_LabelText,
                    labelUSS01: StyleConfig.Instance.EventModifier_StartDelay_Label
                );
            }

            void SetupDelaySecondsContainer()
            {
                delaySecondsContainer = new();
                delaySecondsContainer.AddToClassList(StyleConfig.Instance.EventModifier_DelaySeconds_Container);
            }

            void SetupDelaySecondsIntegerField()
            {
                model.DelaySecondsIntegerFieldModel.IntegerField =
                    CommonIntegerFieldPresenter.CreateElements
                    (
                        fieldUSS01: StyleConfig.Instance.EventModifier_DelaySeconds_IntegerField
                    );
            }

            void SetupDelaySecondsLabel()
            {
                delaySecondsLabel = CommonLabelPresenter.CreateElements
                (
                    labelText: StringConfig.Instance.EventModifier_DelaySeconds_LabelText,
                    labelUSS01: StyleConfig.Instance.EventModifier_DelaySeconds_Label
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