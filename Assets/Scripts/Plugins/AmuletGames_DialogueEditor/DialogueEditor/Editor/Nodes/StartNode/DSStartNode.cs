namespace AG
{
    public class DSStartNode : DSNodeFrameBase<
        DSStartNode,
        DSStartNodeModel,
        DSStartNodePresenter,
        DSStartNodeSerializer,
        DSStartNodeCallback
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of start node.
        /// </summary>
        /// <param name="creationDetails">Reference of the dialogue system's node creation details.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSStartNode(DSNodeCreationDetails creationDetails, DSGraphView graphView)
            : base(DSStringsConfig.StartNodeDefaultLabelText, graphView)
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
                DSStartNodeModel model = new DSStartNodeModel(this);

                Presenter = new DSStartNodePresenter(this, model);
                Callback = new DSStartNodeCallback(this, model, new DSStartNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSStartNodeStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Construtor of start node.
        /// Specifically used when the node is created by the previously saved model.
        /// </summary>
        /// <param name="sourceModel">Reference of the previous saved node's model.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSStartNode(DSStartNodeModel sourceModel, DSGraphView graphView)
            : base(DSStringsConfig.StartNodeDefaultLabelText, graphView)
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
                DSStartNodeModel model = new DSStartNodeModel(this);

                Presenter = new DSStartNodePresenter(this, model);
                Callback = new DSStartNodeCallback(this, model, new DSStartNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSStartNodeStyle);
            }
        }
    }
}