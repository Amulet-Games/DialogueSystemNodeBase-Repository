using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionBranchNode : NodeFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeModel,
        OptionBranchNodePresenter,
        OptionBranchNodeSerializer,
        OptionBranchNodeCallback,
        OptionBranchNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public OptionBranchNode(GraphViewer graphViewer)
        {
            // Setup details
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
                GraphViewer = graphViewer;

                title = StringConfig.OptionBranchNode_TitleTextField_LabelText;

                style.minWidth = NodeConfig.OptionBranchNodeMinWidth;
                style.maxWidth = NodeConfig.OptionBranchNodeMinWidth + NodeConfig.OptionBranchNodeWidthBuffer;
            }

            // Create elements
            {
                Presenter.CreateTitleElements();
                Presenter.CreatePortElements();
                Presenter.CreateContentElements();
            }

            // Setup node width
            //{
            //    Presenter.SetNodeWidth
            //    (
            //        minWidth: NodeConfig.OptionBranchNodeMinWidth,
            //        widthBuffer: NodeConfig.OptionBranchNodeWidthBuffer
            //    );
            //}

            // Add style sheet
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSOptionBranchNodeStyle);
                styleSheets.Add(styleSheetConfig.DSModifierStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
            }
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var optionInput = Model.InputOptionPort;
            var defaultOutput = Model.OutputDefaultPort;

            // Disconnect Option Input
            evt.menu.AppendAction
            (
                actionName: optionInput.GetDisconnectPortContextualMenuItemLabel(),
                action: action => optionInput.Disconnect(GraphViewer),
                status: optionInput.connected
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
            var isAnyConnected = optionInput.connected
                              || defaultOutput.connected;

            evt.menu.AppendAction
            (
                actionName: StringConfig.ContextualMenuItem_DisconnectAllPort_LabelText,
                action: action =>
                {
                    optionInput.Disconnect(GraphViewer);

                    defaultOutput.Disconnect(GraphViewer);
                },
                status: isAnyConnected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );
        }
    }
}