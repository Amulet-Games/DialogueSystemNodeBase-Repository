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
        /// Constructor of the story node component class.
        /// </summary>
        /// <param name="details">The node creation details to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public StoryNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(nodeTitle: StringConfig.Instance.StoryNode_TitleText, graphViewer: graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            PostProcessNodePosition();

            AddStyleSheet();

            NodeCreatedAction();

            void SetupFrameFields()
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
            }

            void CreateNodeElements()
            {
                Presenter.CreatePortElements();
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSStoryNodeStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the story node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The node data to load from.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public StoryNode
        (
            StoryNodeData data,
            GraphViewer graphViewer
        )
            : base(nodeTitle: StringConfig.Instance.StoryNode_TitleText, graphViewer: graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            AddStyleSheet();

            Serializer.Load(data);

            NodeCreatedAction();

            void SetupFrameFields()
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
            }

            void CreateNodeElements()
            {
                Presenter.CreatePortElements();
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSStoryNodeStyle);
            }
        }
    }
}