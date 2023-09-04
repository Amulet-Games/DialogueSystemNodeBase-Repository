using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// Register events to the new created node element.
    /// </summary>
    public abstract class NodeCreateObserverFrameBase
    <
        TNodeCreateDetail,
        TNodeCreateObserver
    >
        where TNodeCreateDetail : NodeCreateDetailBase
        where TNodeCreateObserver : NodeCreateObserverFrameBase<TNodeCreateDetail, TNodeCreateObserver>
    {
        /// <summary>
        /// Reference of the node create detail base.
        /// </summary>
        protected TNodeCreateDetail Detail;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        protected GraphViewer GraphViewer;


        /// <summary>
        /// Reference of the node element.
        /// </summary>
        protected NodeBase Node;


        /// <summary>
        /// Reference of the port element that is used as a measure reference when calculating the final create position.
        /// </summary>
        PortBase yAxisReferencePort;


        /// <summary>
        /// The approximate position of where the node will be created on the graph.
        /// </summary>
        Vector2 approxCreatePosition;


        /// <summary>
        /// Setup for the node create observer class.
        /// </summary>
        /// <param name="detail">The node create detail to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>The after setup node create observer class.</returns>
        public virtual TNodeCreateObserver Setup
        (
            TNodeCreateDetail detail,
            GraphViewer graphViewer
        )
        {
            this.Detail = detail;
            this.GraphViewer = graphViewer;

            return null;
        }


        /// <summary>
        /// Post setup for the node create observer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="approxCreatePosition">The approximate create position to set for.</param>
        void PostSetup
        (
            NodeBase node,
            Vector2 approxCreatePosition
        )
        {
            this.Node = node;
            this.approxCreatePosition = approxCreatePosition;

            SetupYAxisReferencePort();
        }


        /// <summary>
        /// Setup the Y axis reference port.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when the node create detail's horizontal alignment type is not left, right or middle.
        /// </exception>
        void SetupYAxisReferencePort()
        {
            PortBase leftAlignmentPort = null;
            PortBase rightAlignmentPort = null;
            PortBase middleAlignmentPort = null;

            switch (Node)
            {
                case BooleanNode booleanNode:
                    leftAlignmentPort = booleanNode.View.TrueOutputDefaultPort;
                    rightAlignmentPort = booleanNode.View.InputDefaultPort;
                    middleAlignmentPort = booleanNode.View.InputDefaultPort;
                    break;

                case DialogueNode dialogueNode:
                    leftAlignmentPort = dialogueNode.View.OutputDefaultPort;
                    rightAlignmentPort = dialogueNode.View.InputDefaultPort;
                    middleAlignmentPort = dialogueNode.View.InputDefaultPort;
                    break;

                case EndNode endNode:
                    leftAlignmentPort = null;
                    rightAlignmentPort = endNode.View.InputDefaultPort;
                    middleAlignmentPort = endNode.View.InputDefaultPort;
                    break;

                case EventNode eventNode:
                    leftAlignmentPort = eventNode.View.OutputDefaultPort;
                    rightAlignmentPort = eventNode.View.InputDefaultPort;
                    middleAlignmentPort = eventNode.View.InputDefaultPort;
                    break;

                case OptionBranchNode optionBranchNode:
                    leftAlignmentPort = optionBranchNode.View.OutputDefaultPort;
                    rightAlignmentPort = optionBranchNode.View.InputOptionPort;
                    middleAlignmentPort = optionBranchNode.View.InputOptionPort;
                    break;

                case OptionRootNode optionRootNode:
                    leftAlignmentPort = optionRootNode.View.OutputOptionPort;
                    rightAlignmentPort = optionRootNode.View.InputDefaultPort;
                    middleAlignmentPort = optionRootNode.View.InputDefaultPort;
                    break;

                case PreviewNode previewNode:
                    leftAlignmentPort = previewNode.View.OutputDefaultPort;
                    rightAlignmentPort = previewNode.View.InputDefaultPort;
                    middleAlignmentPort = previewNode.View.InputDefaultPort;
                    break;

                case StartNode startNode:
                    leftAlignmentPort = startNode.View.OutputDefaultPort;
                    rightAlignmentPort = null;
                    middleAlignmentPort = startNode.View.OutputDefaultPort;
                    break;

                case StoryNode storyNode:
                    leftAlignmentPort = storyNode.View.OutputDefaultPort;
                    rightAlignmentPort = storyNode.View.InputDefaultPort;
                    middleAlignmentPort = storyNode.View.InputDefaultPort;
                    break;
            }

            yAxisReferencePort = Detail.HorizontalAlignmentType switch
            {
                HorizontalAlignmentType.LEFT => leftAlignmentPort,
                HorizontalAlignmentType.RIGHT => rightAlignmentPort,
                HorizontalAlignmentType.MIDDLE => middleAlignmentPort,
                _ => throw new ArgumentException(
                    "Invalid horizontal alignment type when creating a new node: " + Detail.HorizontalAlignmentType.ToString())
            };
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the new created node element.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="approxCreatePosition">The approximate create position to set for.</param>
        public void RegisterEvents
        (
            NodeBase node,
            Vector2 approxCreatePosition
        )
        {
            PostSetup(node, approxCreatePosition);

            RegisterInitializeNewNodePositionEvent();
        }


        /// <summary>
        /// Register the InitializeNewNodePositionEvent to the new created node element.
        /// </summary>
        void RegisterInitializeNewNodePositionEvent()
            => Node.ExecuteOnceOnGeometryChanged(InitializeNewNodePositionEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the new node's position needed to be initialized
        /// </summary>
        /// <param name="evt">The registering event</param>
        protected abstract avoid InitializeNewNodePositionEvent(GeometryChangedEvent evt);


        /// <summary>
        /// Calculate the final position of where to create  the new node element.
        /// </summary>
        /// <returns>The final position of where to create the new node element.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the node create detail's horizontal alignment type is not left, right or middle.
        /// </exception>
        protected Vector2 CalculateFinalCreatePosition()
        {
            var targetPos = approxCreatePosition;

            targetPos.y -= (Node.titleContainer.worldBound.height
                              + yAxisReferencePort.localBound.position.y
                              + NumberConfig.MANUAL_CREATE_Y_OFFSET)
                              / GraphViewer.scale;

            targetPos.x -= Detail.HorizontalAlignmentType switch
            {
                HorizontalAlignmentType.LEFT => Node.localBound.width,
                HorizontalAlignmentType.MIDDLE => Node.localBound.width / 2,
                _ => throw new ArgumentException(
                    "Invalid horizontal alignment type when creating a new node: " + Detail.HorizontalAlignmentType.ToString())
            };

            return targetPos;
        }


        /// <summary>
        /// The event to invoke when a new node has finished all its creation steps.
        /// </summary>
        /// <param name="evt">The registering event</param>
        protected void NewNodeOnPostCreateEvent(GeometryChangedEvent evt)
        {
            Node.Callback.OnPostCreate();
        }
    }
}