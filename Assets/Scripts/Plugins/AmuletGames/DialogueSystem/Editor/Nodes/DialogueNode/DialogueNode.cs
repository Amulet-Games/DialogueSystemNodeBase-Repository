namespace AG.DS
{
    public class DialogueNode : NodeFrameBase
    <
        DialogueNode,
        DialogueNodeModel,
        DialogueNodePresenter,
        DialogueNodeSerializer,
        DialogueNodeCallback,
        DialogueNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue node component class.
        /// </summary>
        /// <param name="details">The connecting creation details to set for.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public DialogueNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringsConfig.DialogueNodeDefaultTitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            PostProcessNodeWidth();

            PostProcessNodePosition();

            AddStyleSheet();

            NodeCreatedAction();

            void SetupFrameFields()
            {
                DialogueNodeModel model = new();

                Presenter = new(node: this, model: model);
                Serializer = new(node: this, model: model);
                Callback = new(node: this, model: model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateNodeElements();
            }

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessNodeWidth
                (
                    minWidth: NodesConfig.DialogueNodeMinWidth,
                    widthBuffer: NodesConfig.DialogueNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSDialogueNodeStyle);
                styleSheets.Add(StylesConfig.DSIntegrantsStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the dialogue node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The given node data to load from.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public DialogueNode
        (
            DialogueNodeData data,
            GraphViewer graphViewer
        )
            : base(StringsConfig.DialogueNodeDefaultTitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            PostProcessNodeWidth();

            AddStyleSheet();

            LoadNode(data);

            NodeCreatedAction();

            void SetupFrameFields()
            {
                DialogueNodeModel model = new();

                Presenter = new(node: this, model: model);
                Serializer = new(node: this, model: model);
                Callback = new(node: this, model: model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateNodeElements();
            }

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessNodeWidth
                (
                    minWidth: NodesConfig.DialogueNodeMinWidth,
                    widthBuffer: NodesConfig.DialogueNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSDialogueNodeStyle);
                styleSheets.Add(StylesConfig.DSIntegrantsStyle);
            }
        }
    }
}