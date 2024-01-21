namespace AG.DS
{
    public class BooleanNodeCallback : NodeCallbackFrameBase
    <
        BooleanNode,
        BooleanNodeView,
        BooleanNodeCallback
    >
    {
        /// <inheritdoc />
        public override BooleanNodeCallback Setup(BooleanNodeView view)
        {
            View = view;
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreRemoveByUser(GraphViewer graphViewer)
        {
            // Remove, disconnect ports
            {
                graphViewer.Remove(port: View.InputPort);
                graphViewer.Remove(port: View.TrueOutputPort);
                graphViewer.Remove(port: View.FalseOutputPort);

                View.InputPort.Disconnect(graphViewer);
                View.TrueOutputPort.Disconnect(graphViewer);
                View.FalseOutputPort.Disconnect(graphViewer);
            }
        }


        /// <inheritdoc />
        public override void OnPostRemoveByUser(GraphViewer graphViewer)
        {
        }


        /// <inheritdoc />
        public override void OnCreate()
        {
            // If there's no modifier being created after loading, create a new one by default.
            if (View.ConditionModifierGroupView.FirstModifier == null)
            {
                View.ContentButtonView.Button.Click();
            }
        }
    }
}