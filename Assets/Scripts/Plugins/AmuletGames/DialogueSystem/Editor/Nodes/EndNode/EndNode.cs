using UnityEngine.UIElements;

namespace AG.DS
{
    public class EndNode : NodeFrameBase
    <
        EndNode,
        EndNodeView,
        EndNodeCallback
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public EndNode
        (
            EndNodeView view,
            GraphViewer graphViewer
        )
        {
            // Setup details
            {
                View = view;
                GraphViewer = graphViewer;

                m_Callback = new(View);

                style.minWidth = NumberConfig.END_NODE_MIN_WIDTH;
            }

            // Add style sheet
            {
                styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSEndNodeStyle);
            }
        }


        // ----------------------------- Override -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = View.InputDefaultPort;

            // Disconnect Input
            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectInputPort_LabelText,
                action: action => defaultInput.Disconnect(GraphViewer),
                status: defaultInput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect All
            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectAllPort_LabelText,
                action: action => defaultInput.Disconnect(GraphViewer),
                status: defaultInput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );
        }
    }
}