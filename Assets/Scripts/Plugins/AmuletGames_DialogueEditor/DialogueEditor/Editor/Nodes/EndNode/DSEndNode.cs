namespace AG
{
    public class DSEndNode : DSNodeFrameBase<
        DSEndNode,
        DSEndNodeModel,
        DSEndNodePresenter,
        DSEndNodeSerializer,
        DSEndNodeCallback
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of end node.
        /// </summary>
        /// <param name="creationDetails">Reference of the dialogue system's node creation details.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSEndNode(DSNodeCreationDetails creationDetails, DSGraphView graphView)
            : base(DSStringsConfig.EndNodeDefaultLabelText, graphView)
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
                DSEndNodeModel model = new DSEndNodeModel(this);

                Presenter = new DSEndNodePresenter(this, model);
                Callback = new DSEndNodeCallback(this, model, new DSEndNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSEndNodeStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Construtor of end node.
        /// Specifically used when the node is created by the previously saved model.
        /// </summary>
        /// <param name="sourceModel">Reference of the previous saved node's model.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSEndNode(DSEndNodeModel sourceModel, DSGraphView graphView)
            : base(DSStringsConfig.EndNodeDefaultLabelText, graphView)
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
                DSEndNodeModel model = new DSEndNodeModel(this);

                Presenter = new DSEndNodePresenter(this, model);
                Callback = new DSEndNodeCallback(this, model, new DSEndNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSEndNodeStyle);
            }
        }
    }
}