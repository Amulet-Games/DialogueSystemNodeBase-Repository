namespace AG.DS
{
    public class EndNode : NodeFrameBase
    <
        EndNode,
        EndNodeModel,
        EndNodePresenter,
        EndNodeSerializer,
        EndNodeCallback,
        EndNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node component class.
        /// </summary>
        /// <param name="details">The node creation details to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public EndNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.EndNode_TitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            PostProcessNodeWidth();

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
                Presenter.CreateTitleElements();
                Presenter.CreatePortElements();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessSetWidthValues
                (
                    minWidth: NodeConfig.EndNodeMinWidth,
                    widthBuffer: NodeConfig.EndNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSEndNodeStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the end node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The node data to load from.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public EndNode
        (
            EndNodeData data,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.EndNode_TitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            PostProcessNodeWidth();

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
                Presenter.CreateTitleElements();
                Presenter.CreatePortElements();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessSetWidthValues
                (
                    minWidth: NodeConfig.EndNodeMinWidth,
                    widthBuffer: NodeConfig.EndNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSEndNodeStyle);
            }
        }
    }
}