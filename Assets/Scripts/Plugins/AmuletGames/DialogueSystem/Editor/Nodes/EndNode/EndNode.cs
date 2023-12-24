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
            style.minWidth = NumberConfig.END_NODE_MIN_WIDTH;
        }


        /// <summary>
        /// Add the style sheet.
        /// </summary>
        void AddStyleSheet()
        {
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.EndNodeStyle);
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