using UnityEngine.UIElements;

namespace AG.DS
{
    public class EventNode : NodeFrameBase
    <
        EventNode,
        EventNodeView
    >
    {
        /// <inheritdoc />
        public override EventNode Setup
        (
            EventNodeView view,
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
            style.minWidth = NumberConfig.EVENT_NODE_MIN_WIDTH;
        }


        /// <summary>
        /// Setup the style sheets.
        /// </summary>
        void SetupStyleSheets()
        {
            var styleSheetConfig = ConfigResourcesManager.StyleSheetConfig;
            styleSheets.Add(styleSheetConfig.DSEventNodeStyle);
            styleSheets.Add(styleSheetConfig.DSEventModifierStyle);
            styleSheets.Add(styleSheetConfig.DSEventModifierGroupStyle);
        }


        // ----------------------------- Override -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = View.InputDefaultPort;
            var defaultOutput = View.OutputDefaultPort;

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