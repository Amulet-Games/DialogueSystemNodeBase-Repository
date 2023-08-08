using UnityEngine.UIElements;

namespace AG.DS
{
    public class StoryNode : NodeFrameBase
    <
        StoryNode,
        StoryNodeView,
        StoryNodeObserver,
        StoryNodeSerializer,
        StoryNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the story node class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        public StoryNode(StoryNodeView view, GraphViewer graphViewer, HeadBar headBar)
        {
            // Setup frame fields
            {
                View = view;
                GraphViewer = graphViewer;

                Observer = new(node: this, View, headBar);
                Serializer = new(node: this, View);
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
    }
}