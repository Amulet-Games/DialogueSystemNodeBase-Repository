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
        /// <summary>
        /// Callback action when the connecting node is added on the graph.
        /// <para>optionNode - Constructor.</para>
        /// </summary>
        public override void NodeAddedAction()
        {
            DSLanguageChangedEvent.Register(LanguageChangedAction);
            Node.GraphView.SerializeHandler.AddNodeToList(Node);
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
            Model.OptionTrack.CheckOpponentConnectedStyle();
        }


        /// <summary>
        /// Callback action when editor window's is changed to a different language.
        /// <para>LanguageChangedEvent - DSHeadBar</para>
        /// </summary>
        protected override void LanguageChangedAction()
        {
            Model.TextlineSegment.ReloadLanguage();
        }
    }
}