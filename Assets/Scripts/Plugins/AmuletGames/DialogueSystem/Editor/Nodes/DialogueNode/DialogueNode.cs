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
        /// <param name="details">The node create details to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public DialogueNode
        (
            NodeCreateDetails details,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.DialogueNode_TitleText, graphViewer)
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
                Presenter.CreateContentElements();
            }

            void PostProcessNodeWidth()
            {
                Presenter.SetNodeWidth
                (
                    minWidth: NodeConfig.DialogueNodeMinWidth,
                    widthBuffer: NodeConfig.DialogueNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.SetNodePosition(details);
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


        // ----------------------------- Constructor (New) -----------------------------
        /// <summary>
        /// Constructor of the dialogue node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public DialogueNode
        (
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.DialogueNode_TitleText, graphViewer)
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
                Presenter.CreateContentElements();
            }

            // Setup node width
            {
                Presenter.SetNodeWidth
                (
                    minWidth: NodeConfig.DialogueNodeMinWidth,
                    widthBuffer: NodeConfig.DialogueNodeWidthBuffer
                );
            }

            // Add style sheet
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