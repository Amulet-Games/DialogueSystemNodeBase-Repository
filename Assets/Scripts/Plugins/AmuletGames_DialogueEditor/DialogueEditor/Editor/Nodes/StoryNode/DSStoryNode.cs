namespace AG
{
    public class DSStoryNode : DSNodeFrameBase<
        DSStoryNode,
        DSStoryNodeModel,
        DSStoryNodePresenter,
        DSStoryNodeSerializer,
        DSStoryNodeCallback
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of story node.
        /// </summary>
        /// <param name="creationDetails">Reference of the dialogue system's node creation details.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSStoryNode(DSNodeCreationDetails creationDetails, DSGraphView graphView)
            : base(DSStringsConfig.StoryNodeDefaultLabelText, graphView)
        {
            SetupFrameFields();

            SetupCreationDetail();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPorts();

            AddStyleSheet();

            InitializedAction();

            ManualCreatedAction();

            void SetupFrameFields()
            {
                DSStoryNodeModel model = new DSStoryNodeModel(this);

                Presenter = new DSStoryNodePresenter(this, model);
                Callback = new DSStoryNodeCallback(this, model, new DSStoryNodeSerializer(this, model));
            }

            void SetupCreationDetail()
            {
                Callback.Details = creationDetails;
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
                styleSheets.Add(DSStylesConfig.DSStoryNodeStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of story node.
        /// Specifically used when the node is created by the previously saved model.
        /// </summary>
        /// <param name="sourceModel">Reference of the previous saved node's model.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSStoryNode(DSStoryNodeModel sourceModel, DSGraphView graphView)
            : base(DSStringsConfig.StoryNodeDefaultLabelText, graphView)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            RefreshPorts();

            AddStyleSheet();

            InitializedAction();

            LoadCreatedAction(sourceModel);

            void SetupFrameFields()
            {
                DSStoryNodeModel model = new DSStoryNodeModel(this);

                Presenter = new DSStoryNodePresenter(this, model);
                Callback = new DSStoryNodeCallback(this, model, new DSStoryNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSStoryNodeStyle);
            }
        }
    }
}