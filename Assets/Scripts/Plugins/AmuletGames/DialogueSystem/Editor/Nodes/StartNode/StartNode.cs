using UnityEngine.UIElements;

namespace AG.DS
{
    public class StartNode : NodeFrameBase
    <
        StartNode,
        StartNodeModel,
        StartNodePresenter,
        StartNodeSerializer,
        StartNodeCallback,
        StartNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public StartNode(GraphViewer graphViewer)
        {
            // Setup frame fields
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
                GraphViewer = graphViewer;

                title = StringConfig.StartNode_TitleTextField_LabelText;

                style.minWidth = NodeConfig.StartNodeMinWidth;
                style.maxWidth = NodeConfig.StartNodeMinWidth + NodeConfig.StartNodeWidthBuffer;
            }

            // Create elements
            {
                Presenter.CreateTitleElements();
                Presenter.CreatePortElements();
                Presenter.CreateContentElements();
            }

            // Add style sheet
            {
                styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSStartNodeStyle);
            }
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultOutput = Model.OutputDefaultPort;

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