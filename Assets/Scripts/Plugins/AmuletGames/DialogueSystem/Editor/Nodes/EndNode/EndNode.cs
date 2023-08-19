using UnityEngine.UIElements;

namespace AG.DS
{
    public class EndNode : NodeFrameBase
    <
        EndNode,
        EndNodeView
    >
    {
        /// <inheritdoc />
        public override EndNode Setup
        (
            EndNodeView view,
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
        /// Setup the details
        /// </summary>
        void SetupDetails()
        {
            style.minWidth = NumberConfig.END_NODE_MIN_WIDTH;
        }


        /// <summary>
        /// Setup the style sheets.
        /// </summary>
        void SetupStyleSheets()
        {
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSEndNodeStyle);
        }


        // ----------------------------- Override -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultInput = View.InputDefaultPort;

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