namespace AG
{
    public class DSPathNode : DSNodeFrameBase<
        DSPathNode,
        DSPathNodeModel,
        DSPathNodePresenter,
        DSPathNodeSerializer,
        DSPathNodeCallback
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of path node.
        /// </summary>
        /// <param name="creationDetails">Reference of the dialogue system's node creation details.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSPathNode(DSNodeCreationDetails creationDetails, DSGraphView graphView)
            : base(DSStringsConfig.PathNodeDefaultLabelText, graphView)
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
                DSPathNodeModel model = new DSPathNodeModel(this);

                Presenter = new DSPathNodePresenter(this, model);
                Callback = new DSPathNodeCallback(this, model, new DSPathNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSPathNodeStyle);
                styleSheets.Add(DSStylesConfig.DSSegmentsStyle);
                styleSheets.Add(DSStylesConfig.DSIntegrantsStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of path node.
        /// Specifically used when the node is created by the previously saved model.
        /// </summary>
        /// <param name="sourceModel">Reference of the previous saved node's model.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSPathNode(DSPathNodeModel sourceModel, DSGraphView graphView)
            : base(DSStringsConfig.PathNodeDefaultLabelText, graphView)
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
                DSPathNodeModel model = new DSPathNodeModel(this);

                Presenter = new DSPathNodePresenter(this, model);
                Callback = new DSPathNodeCallback(this, model, new DSPathNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSPathNodeStyle);
                styleSheets.Add(DSStylesConfig.DSSegmentsStyle);
                styleSheets.Add(DSStylesConfig.DSIntegrantsStyle);
            }
        }
    }
}