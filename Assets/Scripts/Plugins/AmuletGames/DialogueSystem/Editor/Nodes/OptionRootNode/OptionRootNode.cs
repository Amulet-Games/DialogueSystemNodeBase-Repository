﻿using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionRootNode : NodeFrameBase
    <
        OptionRootNode,
        OptionRootNodeView,
        OptionRootNodeObserver,
        OptionRootNodeSerializer,
        OptionRootNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        public OptionRootNode(OptionRootNodeView view, GraphViewer graphViewer, HeadBar headBar)
        {
            // Setup details
            {
                View = view;
                GraphViewer = graphViewer;

                Observer = new(node: this, view: View, headBar);
                Serializer = new(node: this, view: View);

                style.minWidth = NumberConfig.OPTION_ROOT_NODE_MIN_WIDTH;
            }

            // Add style sheet
            {
                var styleSheetConfig = ConfigResourcesManager.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSOptionRootNodeStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
            }
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