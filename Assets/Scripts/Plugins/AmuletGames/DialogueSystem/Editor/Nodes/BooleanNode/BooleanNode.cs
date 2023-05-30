using UnityEngine.UIElements;

namespace AG.DS
{
    public class BooleanNode : NodeFrameBase
    <
        BooleanNode,
        BooleanNodeModel,
        BooleanNodePresenter,
        BooleanNodeSerializer,
        BooleanNodeCallback,
        BooleanNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public BooleanNode(GraphViewer graphViewer)
        {
            // Setup frame fields
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
                GraphViewer = graphViewer;

                title = StringConfig.BooleanNode_TitleTextField_LabelText;

                style.minWidth = NodeConfig.BooleanNodeMinWidth;
                style.maxWidth = NodeConfig.BooleanNodeMinWidth + NodeConfig.BooleanNodeWidthBuffer;
            }

            // Create elements
            {
                Presenter.CreateTitleElements();
                Presenter.CreatePortElements();
                Presenter.CreateContentElements();
            }

            // Add style sheet
            {
                var styleSheetConfig = ConfigResourcesManager.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSBooleanNodeStyle);
                styleSheets.Add(styleSheetConfig.DSModifierStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
                styleSheets.Add(styleSheetConfig.DSRootedModifierStyle);
            }
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = Model.InputDefaultPort;
            var defaultTrueOutput = Model.TrueOutputDefaultPort;
            var defaultFalseOutput = Model.FalseOutputDefaultPort;

            // Disconnect Input
            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectInputPort_LabelText,
                action: action => defaultInput.Disconnect(GraphViewer),
                status: defaultInput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect True Output
            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectTrueOutputPort_LabelText,
                action: action => defaultTrueOutput.Disconnect(GraphViewer),
                status: defaultTrueOutput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect False Output
            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectFalseOutputPort_LabelText,
                action: action => defaultFalseOutput.Disconnect(GraphViewer),
                status: defaultFalseOutput.connected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );

            // Disconnect All
            var isAnyConnected = defaultInput.connected
                              || defaultTrueOutput.connected
                              || defaultFalseOutput.connected;

            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectAllPort_LabelText,
                action: action =>
                {
                    defaultInput.Disconnect(GraphViewer);

                    defaultTrueOutput.Disconnect(GraphViewer);

                    defaultFalseOutput.Disconnect(GraphViewer);
                },
                status: isAnyConnected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );
        }
    }
}