namespace AG
{
    public class DSDialogueNodeCallback : DSNodeCallbackFrameBase<DSDialogueNode, DSDialogueNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue node's callback.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSDialogueNodeCallback(DSDialogueNode node, DSDialogueNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void InitializedAction()
        {
            DSLanguageChangedEvent.Register(LanguageChangedAction);

            DSSerializeHandler serializeHandler = Node.GraphView.SerializeHandler;
            serializeHandler.AddNodeToList(Node);
            serializeHandler.RegisterEdgeLoadedSetupAction(PostLoadingSetupElementsAction);
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
            Model.OptionWindow.CheckOpponentTracksConnectedStyle();
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


        /// <inheritdoc />
        protected override void PostLoadingSetupElementsAction()
        {
            Model.OptionWindow.PostLoadingSetupElementsAction();
        }
    }
}