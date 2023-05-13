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
        /// <param name="details">The node creation details to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public DialogueNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.DialogueNode_TitleText, graphViewer)
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
                Presenter.CreateContentElements();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessSetWidthValues
                (
                    minWidth: NodeConfig.DialogueNodeMinWidth,
                    widthBuffer: NodeConfig.DialogueNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSDialogueNodeStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
                styleSheets.Add(styleSheetConfig.DSModifierStyle);
                styleSheets.Add(styleSheetConfig.DSFolderStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the dialogue node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The node data to load from.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public DialogueNode
        (
            DialogueNodeData data,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.DialogueNode_TitleText, graphViewer)
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
                Presenter.CreateContentElements();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessSetWidthValues
                (
                    minWidth: NodeConfig.DialogueNodeMinWidth,
                    widthBuffer: NodeConfig.DialogueNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSDialogueNodeStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
                styleSheets.Add(styleSheetConfig.DSModifierStyle);
                styleSheets.Add(styleSheetConfig.DSFolderStyle);
            }
        }
    }
}