namespace AG.DS
{
    public class OptionRootNodeCallback : NodeCallbackFrameBase
    <
        OptionRootNode,
        OptionRootNodeView,
        OptionRootNodeCallback
    >
    {
        /// <inheritdoc />
        public override OptionRootNodeCallback Setup(OptionRootNodeView view)
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

                for (int i = 0; i < View.OutputOptionPortGroup.Items.Count; i++)
                {
                    graphViewer.Remove(port: View.OutputOptionPortGroup.Items[i].PortCell.Port);
                }

                View.InputPort.Disconnect(graphViewer);
                View.OutputOptionPortGroup.DisconnectAll();
            }

            // Remove language field
            {
                View.RootTitleFieldView.LanguageHandler.Remove(View.RootTitleFieldView);
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
                LanguageTextFieldCallback.OnCreateByUser(View.RootTitleFieldView);
            }

            View.RootTitleFieldView.LanguageHandler.Add(View.RootTitleFieldView);
        }
    }
}