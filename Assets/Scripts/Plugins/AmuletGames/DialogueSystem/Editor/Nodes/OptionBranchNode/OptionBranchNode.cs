using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionBranchNode : NodeFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeView,
        OptionBranchNodeObserver,
        OptionBranchNodeSerializer,
        OptionBranchNodeCallback,
        OptionBranchNodeModel
    >
    {
        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        public HeadBar HeadBar;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="observer">The node observer to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        public OptionBranchNode
        (
            OptionBranchNodeView view,
            OptionBranchNodeObserver observer,
            GraphViewer graphViewer,
            HeadBar headBar
        )
        {
            // Setup details
            {
                View = view;
                GraphViewer = graphViewer;
                HeadBar = headBar;

                Serializer = new(node: this, View);
                m_Callback = new(View, observer);

                style.minWidth = NumberConfig.OPTION_BRANCH_NODE_MIN_WIDTH;
            }

            // Add style sheet
            {
                var styleSheetConfig = ConfigResourcesManager.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSOptionBranchNodeStyle);
                styleSheets.Add(styleSheetConfig.DSModifierStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
            }
        }


        // ----------------------------- Override -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var optionInput = View.InputOptionPort;
            var defaultOutput = View.OutputDefaultPort;

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