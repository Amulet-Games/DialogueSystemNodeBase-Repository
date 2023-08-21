using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionRootNode : NodeFrameBase
    <
        OptionRootNode,
        OptionRootNodeView
    >
    {
        /// <inheritdoc />
        public override OptionRootNode Setup
        (
            OptionRootNodeView view,
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
            style.minWidth = NumberConfig.OPTION_ROOT_NODE_MIN_WIDTH;
        }


        /// <summary>
        /// Setup the style sheets.
        /// </summary>
        void SetupStyleSheets()
        {
            var styleSheetConfig = ConfigResourcesManager.StyleSheetConfig;
            styleSheets.Add(styleSheetConfig.DSOptionRootNodeStyle);
            styleSheets.Add(styleSheetConfig.DSSegmentStyle);
        }


        // ----------------------------- Override -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = View.InputDefaultPort;
            var optionOutput = View.OutputOptionPort;
            var optionGroupOutput = View.OutputOptionPortGroupView;

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

                    optionGroupOutput.DisconnectAll(GraphViewer);
                },
                status: isAnyConnected
                        ? DropdownMenuAction.Status.Normal
                        : DropdownMenuAction.Status.Disabled
            );
        }
    }
}