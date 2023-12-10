using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadBarObserver
    {
        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        HeadBar headBar;


        /// <summary>
        /// Reference of the headBar view class.
        /// </summary>
        HeadBarView headBarView;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueSystemWindow dsWindow;


        /// <summary>
        /// Constructor of the headBar observer class.
        /// </summary>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="headBarView">The headBar view class to set for.</param>
        /// <param name="dsWindow">The dialogue system window to set for.</param>
        public HeadBarObserver
        (
            HeadBar headBar,
            HeadBarView headBarView,
            DialogueSystemWindow dsWindow
        )
        {
            this.headBar = headBar;
            this.headBarView = headBarView;
            this.dsWindow = dsWindow;
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
            headBar.RegisterCallback<FocusEvent>(FocusEvent);


        /// <summary>
        /// Register BlurEvent to the headBar.
        /// </summary>
        void RegisterBlurEvent() =>
            headBar.RegisterCallback<BlurEvent>(BlurEvent);


        /// <summary>
        /// Register ClickEvent to the save button.
        /// </summary>
        void RegisterSaveButtonClickEvent()
        {
            new CommonButtonObserver(
                isAlert: false,
                button: headBarView.SaveButton,
                clickEvent: SaveButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register ClickEvent to the load button.
        /// </summary>
        void RegisterLoadButtonClickEvent()
        {
            new CommonButtonObserver(
                isAlert: false,
                button: headBarView.LoadButton,
                clickEvent: LoadButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register action to each of the items in the language toolbar menu.
        /// </summary>
        void RegisterLanguageToolbarMenuAction()
        {
            foreach (var language in LanguageProvider.SupportTypes)
            {
                headBarView.LanguageToolbarMenu.menu.AppendAction
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
                view: headBarView.GraphTitleTextFieldView, dsWindow).RegisterEvents();
        }


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the headBar has given focus.
        /// <para></para>
        /// <br>Different than "Focus In", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusEvent(FocusEvent evt)
        {
            headBar.IsFocus = true;
        }


        /// <summary>
        /// The event to invoke when the headBar has lost focus.
        /// <para></para>
        /// <br>Different than "Focus Out", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void BlurEvent(BlurEvent evt)
        {
            headBar.IsFocus = false;
        }


        /// <summary>
        /// The event to invoke when the save button is clicked.
        /// </summary>
        void SaveButtonClickEvent()
        {
            dsWindow.Save();
        }


        /// <summary>
        /// The event to invoke when the load button is clicked.
        /// </summary>
        void LoadButtonClickEvent()
        {
            dsWindow.Load(isForceLoadWindow: false);
        }


        // ----------------------------- Action -----------------------------
        /// <summary>
        /// The action to invoke when the language toolbar menu item is clicked.
        /// </summary>
        /// <param name="action">The registering action.</param>
        void LanguageToolbarMenuItemClickAction(DropdownMenuAction action)
        {
            var selectedLanguageType = LanguageProvider.GetType(value: action.name);

            headBarView.LanguageToolbarMenu.text = LanguageProvider.GetShort(type: selectedLanguageType);

            dsWindow.ChangeLanguage(selectedLanguageType);
        }
    }
}