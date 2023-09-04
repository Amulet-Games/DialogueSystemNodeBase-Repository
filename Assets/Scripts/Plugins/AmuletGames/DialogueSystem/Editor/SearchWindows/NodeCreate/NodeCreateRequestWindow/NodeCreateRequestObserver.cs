using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public override NodeCreateRequestObserver Setup()
        {
            NodeCreateRequestDetail detail,
            GraphView graphViewer
        }
        {
            base.Setup(detail, graphViewer);
            return this;
        }


        // ----------------------------- Event -----------------------------
        /// <inheritdoc />
        public override void InitializeNewNodePositionEvent(GeometryChangedEvent evt)
        {
            Node.SetPosition
            (
                newPos: new Rect
                (
                    position: CalculateFinalCreatePosition(),
                    size: Vector2Utility.Zero
                )
            );

            if (node is StoryNode storyNode)
            {
                storyNode.ExecuteOnceOnGeometryChanged(storyNode.GeometryChangedEvent);
            }
            else
            {
                node.ExecuteOnceOnGeometryChanged(NewNodeOnPostCreateEvent);
            }
        }
    }
}