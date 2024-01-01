using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadbarObserver
    {
        /// <summary>
        /// The targeting headbar element.
        /// </summary>
        Headbar headbar;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueSystemWindow dialogueSystemWindow;


        /// <summary>
        /// Constructor of the headbar observer class.
        /// </summary>
        /// <param name="headbar">The headbar element to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        public HeadbarObserver
        (
            Headbar headbar,
            DialogueSystemWindow dialogueSystemWindow
        )
        {
            this.headbar = headbar;
            this.dialogueSystemWindow = dialogueSystemWindow;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the headBar.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFocusEvent();

            RegisterBlurEvent();

            RegisterSaveButtonClickEvent();

            RegisterLoadButtonClickEvent();

            RegisterLanguageToolbarMenuAction();

            RegisterGraphTitleTextFieldEvents();
        }


        /// <summary>
        /// Register FocusEvent to the headBar.
        /// </summary>
        void RegisterFocusEvent() =>
            headbar.RegisterCallback<FocusEvent>(FocusEvent);


        /// <summary>
        /// Register BlurEvent to the headbar.
        /// </summary>
        void RegisterBlurEvent() =>
            headbar.RegisterCallback<BlurEvent>(BlurEvent);


        /// <summary>
        /// Register ClickEvent to the save button.
        /// </summary>
        void RegisterSaveButtonClickEvent()
        {
            new CommonButtonObserver(
                isAlert: false,
                button: headbar.SaveButton,
                clickEvent: SaveButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register ClickEvent to the load button.
        /// </summary>
        void RegisterLoadButtonClickEvent()
        {
            new CommonButtonObserver(
                isAlert: false,
                button: headbar.LoadButton,
                clickEvent: LoadButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register action to each of the items in the language toolbar menu.
        /// </summary>
        void RegisterLanguageToolbarMenuAction()
        {
            foreach (var language in LanguageProvider.SupportTypes)
            {
                headbar.LanguageToolbarMenu.menu.AppendAction
                (
                    actionName: LanguageProvider.GetFull(language),
                    action: LanguageToolbarMenuItemClickAction,
                    actionStatusCallback: DropdownMenuAction.AlwaysEnabled
                );
            }
        }


        /// <summary>
        /// Register events to the graph title text field.
        /// </summary>
        void RegisterGraphTitleTextFieldEvents()
        {
            new GraphTitleTextFieldObserver(
                view: headbar.GraphTitleTextFieldView, dialogueSystemWindow).RegisterEvents();
        }


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the headbar has given focus.
        /// <para></para>
        /// <br>Different than "Focus In", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusEvent(FocusEvent evt)
        {
            headbar.IsFocus = true;
        }


        /// <summary>
        /// The event to invoke when the headbar has lost focus.
        /// <para></para>
        /// <br>Different than "Focus Out", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void BlurEvent(BlurEvent evt)
        {
            headbar.IsFocus = false;
        }


        /// <summary>
        /// The event to invoke when the save button is clicked.
        /// </summary>
        void SaveButtonClickEvent()
        {
            dialogueSystemWindow.Save();
        }


        /// <summary>
        /// The event to invoke when the load button is clicked.
        /// </summary>
        void LoadButtonClickEvent()
        {
            dialogueSystemWindow.Load(isForceLoadWindow: false);
        }


        // ----------------------------- Action -----------------------------
        /// <summary>
        /// The action to invoke when the language toolbar menu item is clicked.
        /// </summary>
        /// <param name="action">The registering action.</param>
        void LanguageToolbarMenuItemClickAction(DropdownMenuAction action)
        {
            var selectedLanguageType = LanguageProvider.GetType(value: action.name);

            headbar.LanguageToolbarMenu.text = LanguageProvider.GetShort(type: selectedLanguageType);

            dialogueSystemWindow.ChangeLanguage(selectedLanguageType);
        }
    }
}