using UnityEngine.UIElements;

namespace AG.DS
{
    public class EndNode : NodeFrameBase
    <
        EndNode,
        EndNodeModel,
        EndNodePresenter,
        EndNodeSerializer,
        EndNodeCallback,
        EndNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node class.
        /// </summary>
        /// <param name="model">The node model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public EndNode(EndNodeModel model, GraphViewer graphViewer)
        {
            // Setup details
            {
                Model = model;
                GraphViewer = graphViewer;

                Callback = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);

                title = StringConfig.EndNode_TitleTextField_LabelText;

                style.minWidth = NodeConfig.EndNodeMinWidth;
                style.maxWidth = NodeConfig.EndNodeMinWidth + NodeConfig.EndNodeWidthBuffer;
            }

            // Add style sheet
            {
                styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSEndNodeStyle);
            }
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = Model.InputDefaultPort;

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