namespace AG.DS
{
    /// <inheritdoc />
    public class OptionBranchNodeCallback : NodeCallbackFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node callback class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public OptionBranchNodeCallback
        (
            OptionBranchNode node,
            OptionBranchNodeModel model
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
            Model.OptionBranchTitleTextFieldModel.UpdateLanguageField();
        }
    }
}