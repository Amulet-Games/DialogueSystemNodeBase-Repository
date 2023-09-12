namespace AG.DS
{
    public class OptionBranchNodeCallback : NodeCallbackFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeView,
        OptionBranchNodeCallback
    >
    {
        /// <inheritdoc />
        public override OptionBranchNodeCallback Setup(OptionBranchNodeView view)
        {
            View = view;
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreManualRemove(GraphViewer graphViewer)
        {
            // Remove, disconnect ports
            {
                graphViewer.Remove(port: View.InputOptionPort);
                graphViewer.Remove(port: View.OutputDefaultPort);

                View.InputOptionPort.Disconnect(graphViewer);
                View.OutputDefaultPort.Disconnect(graphViewer);
            }

            // Remove language field
            {
                View.BranchTitleFieldView.LanguageHandler.Remove(View.BranchTitleFieldView);
            }
        }


        /// <inheritdoc />
        public override void OnPostManualRemove(GraphViewer graphViewer)
        {
        }


        /// <inheritdoc />
        public override void OnPostCreate()
        {
            // Add language field
            {
                View.BranchTitleFieldView.LanguageHandler.Add(View.BranchTitleFieldView);
            }
        }
    }
}