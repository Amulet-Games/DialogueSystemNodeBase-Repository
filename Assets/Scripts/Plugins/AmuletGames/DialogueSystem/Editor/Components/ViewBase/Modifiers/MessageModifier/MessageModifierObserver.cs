using UnityEngine;

namespace AG.DS
{
    public class MessageModifierObserver
    {
        /// <summary>
        /// The target message modifier view.
        /// </summary>
        MessageModifierView view;


        /// <summary>
        /// Reference of the message modifier group view.
        /// </summary>
        MessageModifierGroupView groupView;


        /// <summary>
        /// Constructor of the message modifier observer class.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <param name="groupView">The message modifier group view to set for,</param>
        public MessageModifierObserver
        (
            MessageModifierView view,
            MessageModifierGroupView groupView
        )
        {
            this.view = view;
            this.groupView = groupView;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the message modifier.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFolderEvents();

            RegisterMoveUpButtonClickEvent();

            RegisterMoveDownButtonClickEvent();

            RegisterRenameButtonClickEvent();

            RegisterRemoveButtonClickEvent();

            RegisterMessageTextFieldEvents();

            RegisterMessageAudioFieldEvents();

            RegisterContinueByRadioGroupEvents();

            RegisterDelaySecondsFieldEvents();
        }


        /// <summary>
        /// Register events to the folder.
        /// </summary>
        void RegisterFolderEvents()
            => new FolderObserver(folder: view.Folder).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the move up button.
        /// </summary>
        void RegisterMoveUpButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: true,
                button: view.MoveUpButton,
                clickEvent: MoveUpButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the move down button.
        /// </summary>
        void RegisterMoveDownButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: true,
                button: view.MoveDownButton,
                clickEvent: MoveDownButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the rename button.
        /// </summary>
        void RegisterRenameButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: true,
                button: view.RenameButton,
                clickEvent: RenameButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the remove button.
        /// </summary>
        void RegisterRemoveButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: true,
                button: view.RemoveButton,
                clickEvent: RemoveButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register events to the message text field.
        /// </summary>
        void RegisterMessageTextFieldEvents()
            => new LanguageTextFieldObserver(view: view.MessageTextFieldView).RegisterEvents();


        /// <summary>
        /// Register events to the message audio field.
        /// </summary>
        void RegisterMessageAudioFieldEvents()
            => new LanguageObjectFieldObserver<AudioClip>(view: view.MessageAudioFieldView).RegisterEvents();


        /// <summary>
        /// Register events to the continue by radio group.
        /// </summary>
        void RegisterContinueByRadioGroupEvents()
            => new RadioGroupObserver(radioGroup: view.ContinueByRadioGroup).RegisterEvents();


        /// <summary>
        /// Register events to the delay seconds field.
        /// </summary>
        void RegisterDelaySecondsFieldEvents()
            => new CommonFloatFieldObserver(view: view.DelaySecondsFieldView).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the move up button is clicked.
        /// </summary>
        void MoveUpButtonClickEvent()
        {
            groupView.Swap(modifier: view, swapUp: true);
        }


        /// <summary>
        /// The event to invoke when the move down button is clicked.
        /// </summary>
        void MoveDownButtonClickEvent()
        {
            groupView.Swap(modifier: view, swapUp: false);
        }


        /// <summary>
        /// The event to invoke when the rename button is clicked.
        /// </summary>
        void RenameButtonClickEvent()
        {
            view.Folder.StartEditingFolderTitle();
        }


        /// <summary>
        /// The event to invoke when the remove button is clicked.
        /// </summary>
        void RemoveButtonClickEvent()
        {
            groupView.Remove(view);
            groupView.UpdateReferences();
        }
    }
}