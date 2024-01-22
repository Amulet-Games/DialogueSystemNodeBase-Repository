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

                for (int i = 0; i < View.OutputOptionPortGroup.GroupCells.Count; i++)
                {
                    graphViewer.Remove(port: View.OutputOptionPortGroup.GroupCells[i].PortCell.Port);
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
        public override void OnCreate()
        {
            // Add language field
            {
                View.RootTitleFieldView.LanguageHandler.Add(View.RootTitleFieldView);
            }
        }
    }
}