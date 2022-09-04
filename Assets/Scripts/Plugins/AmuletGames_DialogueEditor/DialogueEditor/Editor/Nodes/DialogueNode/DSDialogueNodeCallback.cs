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
        /// <summary>
        /// Callback action when the connecting node is added on the graph.
        /// <para>DialogueNode - Constructor.</para>
        /// </summary>
        public override void NodeAddedAction()
        {
            DSLanguageChangedEvent.Register(LanguageChangedAction);

            DSSerializeHandler serializeHandler = Node.GraphView.SerializeHandler;
            serializeHandler.AddNodeToList(Node);
            serializeHandler.RegisterPostLoadingSetupAction(PostLoadingSetupAction);
        }


        /// <summary>
        /// Callback action when any of the nodes is deleted by users from the graph manually.
        /// <para>GraphDeleteSelectionAction - DSGraphView</para>
        /// </summary>
        public override void NodeRemovedByManualAction()
        {
            DSLanguageChangedEvent.UnRegister(LanguageChangedAction);
            Node.DisconnectAllPorts();
            Node.GraphView.SerializeHandler.RemoveNodeFromList(Node);
            Model.OptionWindow.CheckMultiOpponentsConnectedStyle();
        }


        /// <summary>
        /// Callback action when editor window's is changed to a different language.
        /// <para>LanguageChangedEvent - DSHeadBar</para>
        /// </summary>
        protected override void LanguageChangedAction()
        {
            Model.TextlineSegment.ReloadLanguage();
        }


        /// <summary>
        /// Callback action when the elements on the nodes has some logic to execute after 
        /// <br>the edges loading phrase is finished.</br>
        /// <para>PostLoadingSetupAction - DSSerializeHandler</para>
        /// </summary>
        protected override void PostLoadingSetupAction()
        {
            Model.OptionWindow.PostLoadingSetupAction();
        }
    }
}