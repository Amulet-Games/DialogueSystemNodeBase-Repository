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
        /// <param name="details">The node create details to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public EndNode
        (
            NodeCreateDetails details,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.EndNode_TitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            PostProcessNodeWidth();

            PostProcessNodePosition();

            AddStyleSheet();

            CreatedAction();

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
                Presenter.SetNodeWidth
                (
                    minWidth: NodeConfig.EndNodeMinWidth,
                    widthBuffer: NodeConfig.EndNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.SetNodePosition(details);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSEndNodeStyle);
            }
        }


        // ----------------------------- Constructor (New) -----------------------------
        /// <summary>
        /// Constructor of the end node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public EndNode
        (
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.EndNode_TitleText, graphViewer)
        {
            // Setup frame fields
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
            }

            // Create elements
            {
                Presenter.CreateTitleElements();
                Presenter.CreatePortElements();
            }

            // Setup node width
            {
                Presenter.SetNodeWidth
                (
                    minWidth: NodeConfig.EndNodeMinWidth,
                    widthBuffer: NodeConfig.EndNodeWidthBuffer
                );
            }

            // Add style sheet
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSEndNodeStyle);
            }
        }
    }
}