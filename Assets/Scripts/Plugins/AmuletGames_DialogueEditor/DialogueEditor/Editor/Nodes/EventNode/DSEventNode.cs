namespace AG
{
    public class DSEventNode : DSNodeFrameBase<
        DSEventNode,
        DSEventNodeModel,
        DSEventNodePresenter,
        DSEventNodeSerializer,
        DSEventNodeCallback
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of event node.
        /// </summary>
        /// <param name="creationDetails">Reference of the dialogue system's node creation details.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSEventNode(DSNodeCreationDetails creationDetails, DSGraphView graphView)
            : base(DSStringsConfig.EventNodeDefaultLabelText, graphView)
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
                DSEventNodeModel model = new DSEventNodeModel(this);

                Presenter = new DSEventNodePresenter(this, model);
                Callback = new DSEventNodeCallback(this, model, new DSEventNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSEventNodeStyle);
                styleSheets.Add(DSStylesConfig.DSModifiersStyle);
                styleSheets.Add(DSStylesConfig.DSSegmentsStyle);
                styleSheets.Add(DSStylesConfig.DSIntegrantsStyle);
                styleSheets.Add(DSStylesConfig.DSRootedModifiersStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of event node.
        /// Specifically used when the node is created by the previously saved model.
        /// </summary>
        /// <param name="sourceModel">Reference of the previous saved node's model.</param>
        /// <param name="graphView">Reference of the dialogue system's graph view module.</param>
        public DSEventNode(DSEventNodeModel sourceModel, DSGraphView graphView)
            : base(DSStringsConfig.EventNodeDefaultLabelText, graphView)
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
                DSEventNodeModel model = new DSEventNodeModel(this);

                Presenter = new DSEventNodePresenter(this, model);
                Callback = new DSEventNodeCallback(this, model, new DSEventNodeSerializer(this, model));
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
                styleSheets.Add(DSStylesConfig.DSEventNodeStyle);
                styleSheets.Add(DSStylesConfig.DSModifiersStyle);
                styleSheets.Add(DSStylesConfig.DSSegmentsStyle);
                styleSheets.Add(DSStylesConfig.DSIntegrantsStyle);
                styleSheets.Add(DSStylesConfig.DSRootedModifiersStyle);
            }
        }
    }
}