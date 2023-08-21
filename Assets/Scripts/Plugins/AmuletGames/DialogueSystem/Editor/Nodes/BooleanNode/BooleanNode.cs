using UnityEngine.UIElements;

namespace AG.DS
{
    public class BooleanNode : NodeFrameBase
    <
        BooleanNode,
        BooleanNodeView
    >
    {
        /// <inheritdoc />
        public override BooleanNode Setup
        (
            BooleanNodeView view,
            INodeCallback callback,
            GraphViewer graphViewer
        )
        {
            base.Setup(view, callback, graphViewer);

            SetupSelectionBorder();

            SetupNodeBorder();

            SetupTitleContainer();

            SetupTopContainer();

            SetupInputContainer();

            SetupOutputContainer();

            SetupMainContainer();

            SetupDefaultStyleClass();

            SetupDefaultStyleSheets();

            SetupDetails();

            SetupStyleSheets();

            return this;
        }


        /// <summary>
        /// Setup the details.
        /// </summary>
        void SetupDetails()
        {
            style.minWidth = NumberConfig.BOOLEAN_NODE_MIN_WIDTH;
        }


        /// <summary>
        /// Setup the style sheets.
        /// </summary>
        void SetupStyleSheets()
        {
            var styleSheetConfig = ConfigResourcesManager.StyleSheetConfig;
            styleSheets.Add(styleSheetConfig.DSBooleanNodeStyle);
            styleSheets.Add(styleSheetConfig.DSModifierStyle);
            styleSheets.Add(styleSheetConfig.DSSegmentStyle);
            styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
            styleSheets.Add(styleSheetConfig.DSRootedModifierStyle);
        }


        // ----------------------------- Override -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = View.InputDefaultPort;
            var defaultTrueOutput = View.TrueOutputDefaultPort;
            var defaultFalseOutput = View.FalseOutputDefaultPort;

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