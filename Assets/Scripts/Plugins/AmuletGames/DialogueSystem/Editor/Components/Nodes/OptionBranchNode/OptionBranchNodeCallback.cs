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
        public override void OnPreRemoveByUser(GraphViewer graphViewer)
        {
            // Remove, disconnect ports
            {
                graphViewer.Remove(port: View.InputOptionPortCell.Port);
                graphViewer.Remove(port: View.OutputPort);

                View.InputOptionPortCell.Port.Disconnect(graphViewer);
                View.OutputPort.Disconnect(graphViewer);
            }

            // Remove language field
            {
                View.BranchTitleFieldView.LanguageHandler.Remove(View.BranchTitleFieldView);
            }
        }


        /// <inheritdoc />
        public override void OnPostRemoveByUser(GraphViewer graphViewer)
        {
        }


        /// <inheritdoc />
        protected override void _OnCreate(bool byUser)
        {
            if (byUser)
            {
                LanguageTextFieldCallback.OnCreateByUser(View.BranchTitleFieldView);
            }

            View.BranchTitleFieldView.LanguageHandler.Add(View.BranchTitleFieldView);
        }
    }
}