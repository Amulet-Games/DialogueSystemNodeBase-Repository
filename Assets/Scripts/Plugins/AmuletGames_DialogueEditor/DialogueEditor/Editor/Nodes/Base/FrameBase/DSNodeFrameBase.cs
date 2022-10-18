using System;
using UnityEngine.UIElements;

namespace AG
{
    /// <summary>
    /// Dialogue system node's frame base class.
    /// </summary>
    /// <typeparam name="TNode">Node type</typeparam>
    /// <typeparam name="TNodeModel">Node model type</typeparam>
    /// <typeparam name="TNodePresenter">Node presenter type</typeparam>
    /// <typeparam name="TNodeSerializer">Node serializer type</typeparam>
    /// <typeparam name="TNodeCallback">Node callback type</typeparam>
    public abstract class DSNodeFrameBase<
        TNode,
        TNodeModel,
        TNodePresenter,
        TNodeSerializer,
        TNodeCallback
    > 
        : DSNodeBase
        where TNode : DSNodeBase
        where TNodeModel : DSNodeModelFrameBase<TNode>
        where TNodePresenter : DSNodePresenterFrameBase<TNode, TNodeModel>
        where TNodeSerializer : DSNodeSerializerFrameBase<TNode, TNodeModel>
        where TNodeCallback : DSNodeCallbackFrameBase<TNode, TNodeModel, TNodeSerializer>
    {
        /// <summary>
        /// Holds the methods for creating all the visual elements that are required for the node.
        /// <br>And methods that are require to have access to Model class.</br>
        /// </summary>
        public TNodePresenter Presenter;


        /// <summary>
        /// Holds the callback methods for the connecting node,
        /// <br>so that other static event classes can invoked them when the time comes.</br>
        /// </summary>
        public TNodeCallback Callback;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor for node's frame base class.
        /// </summary>
        /// <param name="nodeTitleText">The title label text for this node.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSNodeFrameBase(string nodeTitleText, DSGraphView graphView)
        {
            SetupBaseFields();

            AddElementToGraph();

            AddStyleSheet();

            OverrideContainersDefaultStyle();

            OverrideBorderDefaultStyle();

            void SetupBaseFields()
            {
                // Set a new node GUID.
                NodeGuid = Guid.NewGuid().ToString();

                // Set default title.
                title = nodeTitleText;

                // Implement refs.
                GraphView = graphView;
            }

            void AddElementToGraph()
            {
                GraphView.AddElement(this);
            }

            void AddStyleSheet()
            {
                // Setup the base node's USS styles.
                styleSheets.Add(DSStylesConfig.DSGlobalStyle);
                styleSheets.Add(DSStylesConfig.DSNodesShareStyle);
            }

            void OverrideContainersDefaultStyle()
            {
                // Override defualt picking mode.
                titleContainer.pickingMode = PickingMode.Position;
                mainContainer.pickingMode = PickingMode.Position;

                // Remove the default USS names.
                outputContainer.name = "";
                inputContainer.name = "";

                // Add to custom USS class.
                outputContainer.AddToClassList(DSStylesConfig.Node_Output_Container);
                inputContainer.AddToClassList(DSStylesConfig.Node_Input_Container);
            }

            void OverrideBorderDefaultStyle()
            {
                // Get the node border from node's children.
                VisualElement nodeBorder = ElementAt(0);

                // Brings the it to the front of any children element's under this nodes.
                nodeBorder.BringToFront();

                // Override default properties.
                nodeBorder.style.overflow = Overflow.Visible;
                nodeBorder.focusable = true;

                // Remove the default USS names and add to custom class.
                nodeBorder.name = "";
                nodeBorder.AddToClassList(DSStylesConfig.Node_Border);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        protected override void InitializedAction() => Callback.InitializedAction();


        /// <inheritdoc />
        protected override void ManualCreatedAction() => Callback.ManualCreatedAction();


        /// <summary>
        /// The callback action to invoke when the node is added on the graph by loading the previous
        /// <br>saved values.(by serialize handler).</br>
        /// <para></para>
        /// This action happens after InitalizedAction is called.
        /// </summary>
        /// <param name="source">Reference of the previous saved node's model.</param>
        protected void LoadCreatedAction(TNodeModel source) => Callback.LoadCreatedAction(source);


        /// <inheritdoc />
        public override void PreManualRemovedAction() => Callback.PreManualRemovedAction();


        /// <inheritdoc />
        public override void PostManualRemovedAction() => Callback.PostManualRemovedAction();


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Add menu items to the node contextual menu.
        /// <para>Read More https://docs.unity3d.com/ScriptReference/ContextMenu.html</para>
        /// </summary>
        /// <param name="evt">The event holding the menu to populate.</param>
        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            Presenter.AddContextualManuItems(evt);
            evt.menu.AppendSeparator();
        }


        /// <summary>
        /// Called when the node is selected by users on the graph.
        /// <para>Read More https://docs.unity3d.com/ScriptReference/Experimental.GraphView.GraphElement.OnSelected.html</para>
        /// </summary>
        public override void OnSelected() => base.OnSelected();


        /// <summary>
        /// Called when the node is unselected by users on the graph.
        /// <para>Read more https://docs.unity3d.com/ScriptReference/Experimental.GraphView.GraphElement.html</para>
        /// </summary>
        public override void OnUnselected() => base.OnUnselected();
    }
}