using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionBranchNode : NodeFrameBase
    <
        OptionBranchNode,
        OptionBranchNodeView
    >
    {
        /// <inheritdoc />
        public override OptionBranchNode Setup
        (
            OptionBranchNodeView view,
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
            style.minWidth = NumberConfig.OPTION_BRANCH_NODE_MIN_WIDTH;
        }


        /// <summary>
        /// Add the style sheet.
        /// </summary>
        void AddStyleSheet()
        {
            var styleSheetConfig = ConfigResourcesManager.StyleSheetConfig;
            styleSheets.Add(styleSheetConfig.OptionBranchNodeStyle);
            styleSheets.Add(styleSheetConfig.DSModifierStyle);
            styleSheets.Add(styleSheetConfig.DSSegmentStyle);
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