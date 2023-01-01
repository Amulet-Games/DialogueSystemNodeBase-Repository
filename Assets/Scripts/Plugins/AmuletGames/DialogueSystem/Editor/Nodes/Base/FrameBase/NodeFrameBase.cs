using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class NodeFrameBase
    <
        TNode,
        TNodeModel,
        TNodePresenter,
        TNodeSerializer,
        TNodeCallback,
        TNodeData
    > 
        : NodeBase
        where TNode : NodeBase
        where TNodeModel : NodeModelBase
        where TNodePresenter : NodePresenterFrameBase<TNode, TNodeModel>
        where TNodeSerializer : NodeSerializerFrameBase<TNode, TNodeModel, TNodeData>
        where TNodeCallback : NodeCallbackFrameBase<TNode, TNodeModel>
        where TNodeData : NodeDataBase
    {
        /// <summary>
        /// Reference of the connecting serializer module.
        /// </summary>
        protected TNodePresenter Presenter;


        /// <summary>
        /// Reference of the connecting callback module.
        /// </summary>
        protected TNodeCallback Callback;


        /// <summary>
        /// Reference of the connecting serializer module.
        /// </summary>
        protected TNodeSerializer Serializer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the node component frame base class.
        /// </summary>
        /// <param name="nodeTitle">The title text to set for.</param>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
        public NodeFrameBase
        (
            string nodeTitle,
            GraphViewer graphViewer
        )
        {
            SetupBaseFields();

            AddElementToGraph();

            AddStyleSheet();

            OverrideContainersDefaultStyle();

            OverrideBorderDefaultStyle();

            void SetupBaseFields()
            {
                // Set a new node GUID.
                NodeGUID = Guid.NewGuid().ToString();

                // Set default title.
                title = nodeTitle;

                // Implement refs.
                GraphViewer = graphViewer;
            }

            void AddElementToGraph()
            {
                GraphViewer.AddElement(this);
            }

            void AddStyleSheet()
            {
                // Setup the base node's USS styles.
                styleSheets.Add(StylesConfig.DSGlobalStyle);
                styleSheets.Add(StylesConfig.DSNodesShareStyle);
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
                outputContainer.AddToClassList(StylesConfig.Node_Output_Container);
                inputContainer.AddToClassList(StylesConfig.Node_Input_Container);
            }

            void OverrideBorderDefaultStyle()
            {
                // Get the node border from node's children.
                NodeBorder = ElementAt(0);

                // Brings the it to the front of any children element's under this nodes.
                NodeBorder.BringToFront();

                // Override default properties.
                NodeBorder.style.overflow = Overflow.Visible;
                NodeBorder.focusable = true;

                // Remove the default USS names and add to custom class.
                NodeBorder.name = "";
                NodeBorder.AddToClassList(StylesConfig.Node_Border);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        protected override void NodeCreatedAction() => Callback.NodeCreatedAction();


        /// <inheritdoc />
        public override void PreManualRemovedAction() => Callback.PreManualRemovedAction();


        /// <inheritdoc />
        public override void PostManualRemovedAction() => Callback.PostManualRemovedAction();


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void SaveNode(DialogueSystemData dsData) => Serializer.SaveNode(dsData);


        /// <summary>
        /// Load the node values from the given connecting data module class.
        /// </summary>
        /// <param name="data">The given connecting data module class to load from.</param>
        protected void LoadNode(TNodeData data) => Serializer.LoadNode(data);


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
    }
}