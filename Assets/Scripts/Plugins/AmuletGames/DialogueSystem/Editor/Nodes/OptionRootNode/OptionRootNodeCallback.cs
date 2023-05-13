namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeCallback : NodeCallbackFrameBase
    <
        OptionRootNode,
        OptionRootNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node callback module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public OptionRootNodeCallback
        (
            OptionRootNode node,
            OptionRootNodeModel model
        )
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents()
        {
            RegisterPointerEnterEvent();

            RegisterPointerLeaveEvent();

            RegisterPointerMoveEvent();

            RegisterGeometryChangedEvent();

            RegisterLanguageChangedEvent();
        }


        /// <summary>
        /// Register LanguageChangedEvent to the node.
        /// </summary>
        public void RegisterLanguageChangedEvent()
            => LanguageChangedEvent.Register(m_LanguageChangedEvent);


        // ----------------------------- UnRegister Events -----------------------------
        /// <inheritdoc />
        public override void UnregisterEvents()
        {
            UnregisterLanguageChangedEvent();
        }


        /// <summary>
        /// Unregister LanguageChangedEvent from the node.
        /// </summary>
        public void UnregisterLanguageChangedEvent()
            => LanguageChangedEvent.UnRegister(m_LanguageChangedEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// Event to invoke when the editor window's selected language has changed.
        /// </summary>
        private void m_LanguageChangedEvent()
        {
            Model.OptionRootTitleTextFieldModel.UpdateLanguageField();
        }
    }
}