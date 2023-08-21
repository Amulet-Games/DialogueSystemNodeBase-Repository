using UnityEngine.UIElements;

namespace AG.DS
{
    public class StartNode : NodeFrameBase
    <
        StartNode,
        StartNodeView
    >
    {
        /// <inheritdoc />
        public override StartNode Setup
        (
            StartNodeView view,
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
            style.minWidth = NumberConfig.START_NODE_MIN_WIDTH;
        }


        /// <summary>
        /// Setup the style sheets.
        /// </summary>
        void SetupStyleSheets()
        {
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSStartNodeStyle);
        }


        // ----------------------------- Override -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
            var defaultOutput = View.OutputDefaultPort;

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