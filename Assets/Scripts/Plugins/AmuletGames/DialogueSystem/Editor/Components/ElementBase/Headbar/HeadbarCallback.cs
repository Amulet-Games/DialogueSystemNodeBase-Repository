using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadbarCallback
    {
        /// <summary>
        /// The targeting headbar element.
        /// </summary>
        Headbar headbar;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        /// <summary>
        /// The asset instance id of the dialogue system data.
        /// </summary>
        int dsDataInstanceId;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the headbar callback class.
        /// </summary>
        /// <param name="headbar">The headbar element to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        /// <param name="dsDataInstanceId">The dialogue system data asset instance id to set for.</param>
        public HeadbarCallback
        (
            Headbar headbar,
            DialogueEditorWindow dsWindow,
            int dsDataInstanceId
        )
        {
            this.headbar = headbar;
            this.dsWindow = dsWindow;
            this.dsDataInstanceId = dsDataInstanceId;
        }

        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the headbar.
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
        /// Register FocusEvent to the headbar.
        /// </summary>
        void RegisterFocusEvent() =>
            headbar.RegisterCallback<FocusEvent>(FocusEvent);


        /// <summary>
        /// Register BlurEvent to the headbar.
        /// </summary>
        void RegisterBlurEvent() =>
            headbar.RegisterCallback<BlurEvent>(BlurEvent);


        /// <summary>
        /// Register ClickEvent to the headbar's save button.
        /// </summary>
        void RegisterSaveButtonClickEvent()
        {
            new CommonButtonCallback(
                isAlert: false,
                button: headbar.SaveButton,
                clickEvent: SaveButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register ClickEvent to the headbar's load button.
        /// </summary>
        void RegisterLoadButtonClickEvent()
        {
            new CommonButtonCallback(
                isAlert: false,
                button: headbar.LoadButton,
                clickEvent: LoadButtonClickEvent).RegisterEvents();
        }


        /// <summary>
        /// Register action to each of the items in the headbar's language toolbar menu.
        /// </summary>
        void RegisterLanguageToolbarMenuAction()
        {
            var languageManager = LanguageManager.Instance;
            var supportLanguageTypes = LanguageManager.Instance.SupportLanguageTypes;

            for (int i = 0; i < languageManager.SupportLanguageLength; i++)
            {
                headbar.LanguageToolbarMenu.menu.AppendAction
                (
                    actionName: languageManager.GetFull(supportLanguageTypes[i]),
                    action: callback =>
                    {
                        headbar.ChangeGraphLanguage(supportLanguageTypes[i]);
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
                model: headbar.GraphTitleTextFieldModel,
                dsDataInstanceId: dsDataInstanceId).RegisterEvents();
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
        /// The event to invoke when the headbar's save button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void SaveButtonClickEvent(ClickEvent evt)
        {
            dsWindow.Save();
        }


        /// <summary>
        /// The event to invoke when the headbar's load button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void LoadButtonClickEvent(ClickEvent evt)
        {
            dsWindow.Load(isForceLoadWindow: false);
        }
    }
}