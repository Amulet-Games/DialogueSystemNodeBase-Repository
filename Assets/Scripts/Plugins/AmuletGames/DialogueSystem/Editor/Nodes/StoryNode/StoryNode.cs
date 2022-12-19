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
        /// <param name="details">The connecting creation details to set for.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public StoryNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringsConfig.StoryNodeDefaultTitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPorts();

            AddStyleSheet();

            ManualCreatedAction();

            PostCreatedAction();

            void SetupFrameFields()
            {
                StoryNodeModel model = new(node: this);

                Presenter = new(node: this, model: model);
                Serializer = new(node: this, model: model);
                Callback = new(node: this, model: model, details: details);
            }

            void CreateNodeElements()
            {
                Presenter.CreateNodeElements();
            }

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSStoryNodeStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the story node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The given node data to load from.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public StoryNode
        (
            StoryNodeData data,
            GraphViewer graphViewer
        )
            : base(StringsConfig.StoryNodeDefaultTitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPorts();

            AddStyleSheet();

            LoadNode(data);

            LoadCreatedAction();

            PostCreatedAction();

            void SetupFrameFields()
            {
                StoryNodeModel model = new(node: this);

                Presenter = new(node: this, model: model);
                Serializer = new(node: this, model: model);
                Callback = new(node: this, model: model, details: null);
            }

            void CreateNodeElements()
            {
                Presenter.CreateNodeElements();
            }

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSStoryNodeStyle);
            }
        }
    }
}