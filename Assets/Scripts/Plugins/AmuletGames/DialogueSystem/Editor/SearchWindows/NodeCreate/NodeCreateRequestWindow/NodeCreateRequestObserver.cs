using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateRequestObserver : NodeCreateObserverFrameBase
    <
        NodeCreateRequestDetail,
        NodeCreateRequestObserver
    >
    {
        /// <inheritdoc />
        public override NodeCreateRequestObserver Setup
        (
            NodeCreateRequestDetail detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(detail, graphViewer);
            return this;
        }


        // ----------------------------- Event -----------------------------
        /// <inheritdoc />
        protected override void InitializeNewNodePositionEvent(GeometryChangedEvent evt)
        {
            Node.SetPosition
            (
                newPos: new Rect
                (
                    position: CalculateFinalCreatePosition(),
                    size: Vector2Utility.Zero
                )
            );

            if (Node is StoryNode storyNode)
            {
                storyNode.ExecuteOnceOnGeometryChanged(storyNode.GeometryChangedEvent);
            }
            else
            {
                Node.ExecuteOnceOnGeometryChanged(NewNodeOnPostCreateEvent);
            }
        }
    }
}