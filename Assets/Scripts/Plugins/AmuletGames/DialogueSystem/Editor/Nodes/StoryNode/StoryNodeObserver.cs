using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeObserver : NodeObserverFrameBase
    <
        StoryNode,
        StoryNodeView
    >
    {
        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        HeadBar headBar;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the story node observer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        public StoryNodeObserver
        (
            StoryNode node,
            StoryNodeView view,
            HeadBar headBar
        )
        {
            Node = node;
            View = view;
            this.headBar = headBar;
        }


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents()
        {
            base.RegisterEvents();
        }


        // ----------------------------- Event -----------------------------
        public void GeometryChangedEvent(GeometryChangedEvent evt)
        {
            var margin = 10;

            // Create sample node.
            var target = NodeManager.Instance.Spawn
            (
                Node.GraphViewer,
                headBar,
                nodeType: NodeType.Event
            );

            // Set sample node position
            var createPosition = Node.localBound.position;
            createPosition.x += margin;
            createPosition.y += Node.titleContainer.layout.height + Node.inputContainer.parent.layout.height + margin + 1;

            target.SetPosition(newPos: new Rect(createPosition, Vector2Utility.Zero));

            // Add sample node to graph
            Node.GraphViewer.Add(target);

            // Set sample node details
            target.capabilities = Capabilities.Movable;
            target.SetEnabled(false);
            target.style.opacity = 1;
            target.titleContainer.ElementAt(index: 1).style.backgroundColor = new Color(0.357f, 0.537f, 0.75f, 1);

            target.NodeBorder.style.borderBottomColor = new Color(r: 0, g: 0, b: 0, a: 0);
            target.NodeBorder.style.borderLeftColor = new Color(r: 0, g: 0, b: 0, a: 0);
            target.NodeBorder.style.borderRightColor = new Color(r: 0, g: 0, b: 0, a: 0);
            target.NodeBorder.style.borderTopColor = new Color(r: 0, g: 0, b: 0, a: 0);

            Node.BringToFront();
        }
    }
}