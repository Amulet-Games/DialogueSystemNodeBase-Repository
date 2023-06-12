using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventNode : NodeFrameBase
    <
        EventNode,
        EventNodeModel,
        EventNodePresenter,
        EventNodeSerializer,
        EventNodeCallback,
        EventNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node class.
        /// </summary>
        /// <param name="model">The node model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public EventNode(EventNodeModel model, GraphViewer graphViewer)
        {
            // Setup details
            {
                Model = model;
                GraphViewer = graphViewer;

                Callback = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);

                title = StringConfig.EventNode_TitleTextField_LabelText;

                style.minWidth = NodeConfig.EventNodeMinWidth;
                style.maxWidth = NodeConfig.EventNodeMinWidth + NodeConfig.EventNodeWidthBuffer;
            }

            // Add style sheet
            {
                var styleSheetConfig = ConfigResourcesManager.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSEventNodeStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
                styleSheets.Add(styleSheetConfig.DSFolderStyle);
                styleSheets.Add(styleSheetConfig.DSEventModifierStyle);
                styleSheets.Add(styleSheetConfig.DSEventModifierGroupStyle);
            }
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = Model.InputDefaultPort;
            var defaultOutput = Model.OutputDefaultPort;

            // Disconnect Input
            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectInputPort_LabelText,
                action: action => defaultInput.Disconnect(GraphViewer),
                status: defaultInput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

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
            var isAnyConnected = defaultInput.connected
                              || defaultOutput.connected;

            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectAllPort_LabelText,
                action: action =>
                {
                    defaultInput.Disconnect(GraphViewer);

                    defaultOutput.Disconnect(GraphViewer);
                },
                status: isAnyConnected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );
        }
    }
}