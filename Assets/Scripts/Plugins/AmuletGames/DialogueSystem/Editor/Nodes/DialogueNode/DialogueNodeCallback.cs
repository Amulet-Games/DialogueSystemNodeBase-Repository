using UnityEngine;

namespace AG.DS
{
    public class DialogueNodeCallback : NodeCallbackFrameBase
    <
        DialogueNode,
        DialogueNodeView,
        DialogueNodeCallback
    >
    {
        /// <inheritdoc />
        public override DialogueNodeCallback Setup(DialogueNodeView view)
        {
            View = view;
            return this;
        }


        // ----------------------------- Callback -----------------------------
        /// <inheritdoc />
        public override void OnPreRemoveByUser(GraphViewer graphViewer)
        {
            // Remove, disconnect ports
            {
                graphViewer.Remove(port: View.InputPort);
                graphViewer.Remove(port: View.OutputPort);

                View.InputPort.Disconnect(graphViewer);
                View.OutputPort.Disconnect(graphViewer);
            }
        }


        /// <inheritdoc />
        public override void OnPostRemoveByUser(GraphViewer graphViewer)
        {
        }


        /// <inheritdoc />
        public override void OnCreate()
        {
            // If there's no modifier being created after loading, create a new one by default.
            if (View.MessageModifierGroupView.FirstModifier == null)
            {
                View.ContentButton.Click();
            }
        }
    }
}