﻿using UnityEngine.UIElements;

namespace AG.DS
{
    public class DialogueNode : NodeFrameBase
    <
        DialogueNode,
        DialogueNodeView,
        DialogueNodeCallback
    >
    {
        /// <summary>
        /// Constructor of the dialogue node class.
        /// </summary>
        /// <param name="view">The dialogue node view to set for.</param>
        /// <param name="callback">The dialogue node callback to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public DialogueNode
        (
            DialogueNodeView view,
            DialogueNodeCallback callback,
            GraphViewer graphViewer
        )
        {
            // Setup references
            {
                View = view;
                m_Callback = callback;
                GraphViewer = graphViewer;
            }

            // Setup details
            {
                style.minWidth = NumberConfig.DIALOGUE_NODE_MIN_WIDTH;
            }

            // Add style sheet
            {
                var styleSheetConfig = ConfigResourcesManager.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSDialogueNodeStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
                styleSheets.Add(styleSheetConfig.DSModifierStyle);
            }
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