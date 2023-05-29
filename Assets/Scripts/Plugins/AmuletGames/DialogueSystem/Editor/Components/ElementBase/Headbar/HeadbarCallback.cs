using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadBarCallback
    {
        /// <summary>
        /// The targeting headBar element.
        /// </summary>
        HeadBar headBar;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        /// <summary>
        /// The asset instance id of the dialogue system data.
        /// </summary>
        int dsDataInstanceId;


        /// <summary>
        /// Reference of the project manager.
        /// </summary>
        ProjectManager projectManager;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the headBar callback class.
        /// </summary>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        /// <param name="dsDataInstanceId">The dialogue system data asset instance id to set for.</param>
        /// <param name="projectManager">The project manager to set for.</param>
        public HeadBarCallback
        (
            HeadBar headBar,
            DialogueEditorWindow dsWindow,
            int dsDataInstanceId,
            ProjectManager projectManager
        )
        {
            this.headBar = headBar;
            this.dsWindow = dsWindow;
            this.dsDataInstanceId = dsDataInstanceId;
            this.projectManager = projectManager;
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
            new CommonButtonCallback(
                isAlert: false,
                button: headBar.SaveButton,
                clickEvent: SaveButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register ClickEvent to the headBar's load button.
        /// </summary>
        void RegisterLoadButtonClickEvent()
        {
            new CommonButtonCallback(
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
            var supportLanguageTypes = LanguageManager.Instance.SupportLanguageTypes;

            for (int i = 0; i < languageManager.SupportLanguageLength; i++)
            {
                headBar.LanguageToolbarMenu.menu.AppendAction
                (
                    actionName: languageManager.GetFull(supportLanguageTypes[i]),
                    action: callback =>
                    {
                        headBar.ChangeGraphLanguage(supportLanguageTypes[i]);
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
            new GraphTitleTextFieldCallback(
                model: headBar.GraphTitleTextFieldModel,
                dsDataInstanceId: dsDataInstanceId).RegisterEvents();
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
            projectManager.Save();
        }


        /// <summary>
        /// The event to invoke when the headBar's load button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void LoadButtonClickEvent(ClickEvent evt)
        {
            projectManager.Load(isForceLoadWindow: false);
        }
    }
}