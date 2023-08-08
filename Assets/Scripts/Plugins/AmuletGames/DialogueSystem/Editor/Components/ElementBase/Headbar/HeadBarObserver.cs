using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadBarObserver
    {
        /// <summary>
        /// The targeting headBar element.
        /// </summary>
        HeadBar headBar;


        /// <summary>
        /// Reference of the dialogue system model.
        /// </summary>
        DialogueSystemModel dsModel;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the headBar observer class.
        /// </summary>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        public HeadBarObserver
        (
            HeadBar headBar,
            DialogueSystemModel dsModel,
            DialogueEditorWindow dsWindow
        )
        {
            this.headBar = headBar;
            this.dsModel = dsModel;
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
        /// Register ClickEvent to the headBar's save button.
        /// </summary>
        void RegisterSaveButtonClickEvent()
        {
            new CommonButtonObserver(
                isAlert: false,
                button: headBar.SaveButton,
                clickEvent: SaveButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register ClickEvent to the headBar's load button.
        /// </summary>
        void RegisterLoadButtonClickEvent()
        {
            new CommonButtonObserver(
                isAlert: false,
                button: headBar.LoadButton,
                clickEvent: LoadButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register action to each of the items in the headBar's language toolbar menu.
        /// </summary>
        void RegisterLanguageToolbarMenuAction()
        {
            var languageManager = LanguageManager.Instance;

            foreach (var language in languageManager.SupportLanguageTypes)
            {
                headBar.LanguageToolbarMenu.menu.AppendAction
                (
                    actionName: languageManager.GetFull(language),
                    action: dropdownMenuAction =>
                    {
                        headBar.SetEditorLanguage(language);
                        WindowChangedEvent.Invoke();
                    }
                );
            }
        }


        /// <summary>
        /// Register events to the graph title text field.
        /// </summary>
        void RegisterGraphTitleTextFieldEvents()
        {
            new GraphTitleTextFieldObserver(
                view: headBar.GraphTitleTextFieldView, dsModel, dsWindow).RegisterEvents();
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
        /// The event to invoke when the headBar's save button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void SaveButtonClickEvent(ClickEvent evt)
        {
            dsWindow.Save();
        }


        /// <summary>
        /// The event to invoke when the headBar's load button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void LoadButtonClickEvent(ClickEvent evt)
        {
            dsWindow.Load(isForceLoadWindow: false);
        }
    }
}