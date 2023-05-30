using UnityEngine.UIElements;

namespace AG.DS
{
    public class StoryNode : NodeFrameBase
    <
        StoryNode,
        StoryNodeModel,
        StoryNodePresenter,
        StoryNodeSerializer,
        StoryNodeCallback,
        StoryNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the story node class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public StoryNode(GraphViewer graphViewer)
        {
            // Setup frame fields
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
                GraphViewer = graphViewer;

                title = StringConfig.StoryNode_TitleTextField_LabelText;
            }

            // Create elements
            {
                Presenter.CreatePortElements();
            }

            // Add style sheet
            {
                styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSStoryNodeStyle);
            }
        }


        // ----------------------------- Add Contextual Menu Items -----------------------------
        /// <inheritdoc />
        protected override void AddContextualMenuItems(ContextualMenuPopulateEvent evt)
        {
        }
    }
}