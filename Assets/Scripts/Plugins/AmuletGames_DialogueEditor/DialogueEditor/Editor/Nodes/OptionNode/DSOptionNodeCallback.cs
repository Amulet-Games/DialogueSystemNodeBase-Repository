namespace AG
{
    public class DSOptionNodeCallback : DSNodeCallbackFrameBase<DSOptionNode, DSOptionNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of option node's callback.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSOptionNodeCallback(DSOptionNode node, DSOptionNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void InitializedAction()
        {
            DSLanguageChangedEvent.Register(LanguageChangedAction);
            Node.GraphView.SerializeHandler.AddNodeToList(Node);
        }


        /// <inheritdoc />
        public override void ManualCreatedAction()
        {
            Node.SetupNewManualCreatedNode();
        }


        /// <inheritdoc />
        public override void PreManualRemovedAction()
        {
            Node.DisconnectAllPorts();
            Model.OptionTrack.CheckOpponentConnectedStyle();
        }


        /// <inheritdoc />
        public override void PostManualRemovedAction()
        {
            DSLanguageChangedEvent.UnRegister(LanguageChangedAction);
            Node.GraphView.SerializeHandler.RemoveNodeFromList(Node);
        }


        /// <inheritdoc />
        protected override void LanguageChangedAction()
        {
            Model.TextlineSegment.ReloadLanguage();
        }
    }
}