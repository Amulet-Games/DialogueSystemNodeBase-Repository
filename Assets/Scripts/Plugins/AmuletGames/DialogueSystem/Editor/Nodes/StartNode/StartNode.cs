using UnityEngine.UIElements;

namespace AG.DS
{
    public class StartNode : NodeFrameBase
    <
        StartNode,
        StartNodeView,
        StartNodeCallback
    >
    {
        /// <summary>
        /// Constructor of the start node class.
        /// </summary>
        /// <param name="view">The start node view to set for.</param>
        /// <param name="callback">The start node callback to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public StartNode
        (
            StartNodeView view,
            StartNodeCallback callback,
            GraphViewer graphViewer
        )
        {
            // Setup references
            {
                View = view;
                m_Callback = callback;
                GraphViewer = graphViewer;
            }

            // Setup details
            {
                style.minWidth = NumberConfig.START_NODE_MIN_WIDTH;
            }

            // Add style sheet
            {
                styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSStartNodeStyle);
            }
        }


        // ----------------------------- Override -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultOutput = View.OutputDefaultPort;

            // Disconnect Output
            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectOutputPort_LabelText,
                action: action => defaultOutput.Disconnect(GraphViewer),
                status: defaultOutput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect All
            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectAllPort_LabelText,
                action: action => defaultOutput.Disconnect(GraphViewer),
                status: defaultOutput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );
        }
    }
}