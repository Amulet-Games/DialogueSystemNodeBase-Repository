using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class StoryNode : NodeFrameBase
    <
        StoryNode,
        StoryNodeView,
        StoryNodeCallback
    >
    {
        /// <summary>
        /// Constructor of the story node class.
        /// </summary>
        /// <param name="view">The story node view to set for.</param>
        /// <param name="callback">The story node callback to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public StoryNode
        (
            StoryNodeView view,
            StoryNodeCallback callback,
            GraphViewer graphViewer
        )
        {
            // Setup references
            {
                View = view;
                m_Callback = callback;
                GraphViewer = graphViewer;
            }

            // Add style sheet
            {
                styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSStoryNodeStyle);
            }
        }


        // ----------------------------- Override -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
        }


        /// TODO: Delete this method once the apply design stage is finished.
        // ----------------------------- Event -----------------------------
        public void GeometryChangedEvent(GeometryChangedEvent evt)
        {
            var margin = 10;

            // Create sample node.
            var target = NodeManager.Instance.Spawn
            (
                GraphViewer,
                nodeType: NodeType.Event
            );

            // Set sample node position
            var createPosition = localBound.position;
            createPosition.x += margin;
            createPosition.y += titleContainer.layout.height + inputContainer.parent.layout.height + margin + 1;

            target.SetPosition(newPos: new Rect(createPosition, Vector2Utility.Zero));

            // Add sample node to graph
            GraphViewer.Add(target);

            // Set sample node details
            target.capabilities = Capabilities.Movable;
            target.SetEnabled(false);
            target.style.opacity = 1;
            target.titleContainer.ElementAt(index: 1).style.backgroundColor = new Color(0.357f, 0.537f, 0.75f, 1);

            target.NodeBorder.style.borderBottomColor = new Color(r: 0, g: 0, b: 0, a: 0);
            target.NodeBorder.style.borderLeftColor = new Color(r: 0, g: 0, b: 0, a: 0);
            target.NodeBorder.style.borderRightColor = new Color(r: 0, g: 0, b: 0, a: 0);
            target.NodeBorder.style.borderTopColor = new Color(r: 0, g: 0, b: 0, a: 0);

            BringToFront();
        }
    }
}