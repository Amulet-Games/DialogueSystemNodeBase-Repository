namespace AG
{
    public class DSChoiceNodeCallback : DSNodeCallbackFrameBase<DSChoiceNode, DSChoiceNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of choice node's callback.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSChoiceNodeCallback(DSChoiceNode node, DSChoiceNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Callback action when the connecting node is added on the graph.
        /// <para>ChoiceNode - Constructor.</para>
        /// </summary>
        public override void NodeAddedAction()
        {
            DSLanguageChangedEvent.Register(LanguageChangedAction);
            Node.GraphView.SerializeHandler.AddNodeToList(Node);
        }


        /// <summary>
        /// Callback action when the connecting node is removed from the graph.
        /// <para>GraphDeleteSelectionAction - DSGraphView</para>
        /// </summary>
        public override void NodeRemovedAction()
        {
            DSLanguageChangedEvent.UnRegister(LanguageChangedAction);
            Node.DisconnectAllPorts();
            Node.GraphView.SerializeHandler.RemoveNodeFromList(Node);
        }


        /// <summary>
        /// Callback action when editor window's is changed to a different language.
        /// <para>LanguageChangedEvent - DSHeadBar</para>
        /// </summary>
        public override void LanguageChangedAction()
        {
            Model.TextlineSegment.ReloadLanguage();
        }
    }
}