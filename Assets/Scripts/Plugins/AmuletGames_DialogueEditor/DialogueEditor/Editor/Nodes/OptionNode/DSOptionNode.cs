namespace AG
{
    public class DSOptionNode : DSNodeFrameBase<
        DSOptionNode,
        DSOptionNodeModel,
        DSOptionNodePresenter,
        DSOptionNodeSerializer,
        DSOptionNodeCallback
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of option node.
        /// </summary>
        /// <param name="creationDetails">Reference of the dialogue system's node creation details.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSOptionNode(DSNodeCreationDetails creationDetails, DSGraphView graphView) 
            : base(DSStringsConfig.OptionNodeDefaultLabelText, graphView)
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
                DSOptionNodeModel model = new DSOptionNodeModel(this);

                Presenter = new DSOptionNodePresenter(this, model);
                Callback = new DSOptionNodeCallback(this, model, new DSOptionNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSOptionNodeStyle);
                styleSheets.Add(DSStylesConfig.DSModifiersStyle);
                styleSheets.Add(DSStylesConfig.DSSegmentsStyle);
                styleSheets.Add(DSStylesConfig.DSIntegrantsStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Construtor of option node.
        /// Specifically used when the node is created by the previously saved model.
        /// </summary>
        /// <param name="sourceModel">Reference of the previous saved node's model.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSOptionNode(DSOptionNodeModel sourceModel, DSGraphView graphView)
            : base(DSStringsConfig.OptionNodeDefaultLabelText, graphView)
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
                DSOptionNodeModel model = new DSOptionNodeModel(this);

                Presenter = new DSOptionNodePresenter(this, model);
                Callback = new DSOptionNodeCallback(this, model, new DSOptionNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSOptionNodeStyle);
                styleSheets.Add(DSStylesConfig.DSModifiersStyle);
                styleSheets.Add(DSStylesConfig.DSSegmentsStyle);
                styleSheets.Add(DSStylesConfig.DSIntegrantsStyle);
            }
        }
    }
}