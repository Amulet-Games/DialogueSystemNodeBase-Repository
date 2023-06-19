using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionRootNode : NodeFrameBase
    <
        OptionRootNode,
        OptionRootNodeModel,
        OptionRootNodeSerializer,
        OptionRootNodeCallback,
        OptionRootNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node class.
        /// </summary>
        /// <param name="model">The node model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public OptionRootNode(OptionRootNodeModel model, GraphViewer graphViewer)
        {
            // Setup details
            {
                Model = model;
                GraphViewer = graphViewer;

                Callback = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);

                title = StringConfig.OptionRootNode_TitleTextField_LabelText;

                style.minWidth = NodeConfig.OptionRootNodeMinWidth;
                style.maxWidth = NodeConfig.OptionRootNodeMinWidth + NodeConfig.OptionRootNodeWidthBuffer;
            }

            // Add style sheet
            {
                var styleSheetConfig = ConfigResourcesManager.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSOptionRootNodeStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
            }
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = Model.InputDefaultPort;
            var optionOutput = Model.OutputOptionPort;
            var optionGroupOutput = Model.OutputOptionPortGroupModel;

            // Disconnect Input
            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectInputPort_LabelText,
                action: action => defaultInput.Disconnect(GraphViewer),
                status: defaultInput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect Option Output
            evt.menu.AppendAction
            (
                actionName: optionOutput.GetDisconnectPortContextualMenuItemLabel(),
                action: action => optionOutput.Disconnect(GraphViewer),
                status: optionOutput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect Option Output Group
            optionGroupOutput.AddContextualMenuItems(GraphViewer, evt);

            // Disconnect All
            var isAnyConnected = defaultInput.connected
                              || optionOutput.connected
                              || optionGroupOutput.connected;

            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectAllPort_LabelText,
                action: action =>
                {
                    defaultInput.Disconnect(GraphViewer);

                    optionOutput.Disconnect(GraphViewer);

                    optionGroupOutput.Disconnect(GraphViewer);
                },
                status: isAnyConnected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );
        }
    }
}