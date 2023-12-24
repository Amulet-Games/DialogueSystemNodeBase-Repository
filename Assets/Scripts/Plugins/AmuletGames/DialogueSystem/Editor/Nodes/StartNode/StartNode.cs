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
            GraphViewer graphViewer,
            LanguageHandler languageHandler
        )
        {
            base.Setup(view, callback, graphViewer, languageHandler);

            SetupSelectionBorder();

            SetupNodeBorder();

            SetupTopContainer();

            SetupTitleContainer();

            SetupPortContainer();

            SetupInputContainer();

            SetupOutputContainer();

            SetupMainContainer();

            AddDefaultStyleClass();

            AddDefaultStyleSheet();

            SetupDetails();

            AddStyleSheet();

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
        /// Add the style sheet.
        /// </summary>
        void AddStyleSheet()
        {
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.StartNodeStyle);
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