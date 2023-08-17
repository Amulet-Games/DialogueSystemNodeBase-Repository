using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeFrameBase
    <
        TNode,
        TNodeView
    > 
        : NodeBase
        where TNode : NodeBase
        where TNodeView : NodeViewFrameBase<TNodeView>
    {
        /// <summary>
        /// Reference of the node view.
        /// </summary>
        public TNodeView View;


        /// <summary>
        /// Setup for the node frame base class.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="callback">The node callback to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public virtual TNode Setup
        (
            TNodeView view,
            INodeCallback callback,
            GraphViewer graphViewer
        )
        {
            View = view;
            Callback = callback;
            GraphViewer = graphViewer;
            NodeBorder = ElementAt(0);
            Guid = System.Guid.NewGuid().ToString();

            return null;

            //// Setup node border
            //{
            //    // Brings the it to the front of any children element's under this nodes.
            //    NodeBorder.BringToFront();

            //    // Override default properties.
            //    NodeBorder.style.overflow = Overflow.Visible;
            //    NodeBorder.focusable = true;

            //    // Remove the default USS names and add to custom class.
            //    NodeBorder.name = "";
            //    NodeBorder.AddToClassList(StyleConfig.Node_Border);

            //    // Place the top container inside the node border.
            //    NodeBorder.Insert(index: 1, element: topContainer);
            //}

            //// Remove unused elements
            //{
            //    // Remove #selection-border from the node.
            //    Remove(ElementAt(0));

            //    // Remove #title-label from the title container.
            //    titleContainer.Remove(titleContainer.ElementAt(0));

            //    // Remove #title-button-container from the title container.
            //    titleContainer.Remove(titleContainer.ElementAt(0));

            //    // Remove the #divider visual element from the top container.
            //    topContainer.Remove(topContainer.ElementAt(1));

            //    // Remove the #contents visual element from the node's border
            //    NodeBorder.Remove(NodeBorder.ElementAt(2));
            //}

            //// Override containers default style
            //{
            //    // Title
            //    titleContainer.name = "";
            //    titleContainer.AddToClassList(StyleConfig.Node_Title_Container);

            //    topContainer.name = "";
            //    topContainer.AddToClassList(StyleConfig.Node_Top_Container);

            //    // Input
            //    inputContainer.name = "";
            //    inputContainer.AddToClassList(StyleConfig.Node_Input_Container);

            //    // Output
            //    outputContainer.name = "";
            //    outputContainer.AddToClassList(StyleConfig.Node_Output_Container);
            //}

            //// Setup class list
            //{
            //    ClearClassList();
            //    AddToClassList(StyleConfig.Node);
            //}

            //// Add style sheet
            //{
            //    styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSGlobalStyle);
            //    styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSNodeCommonStyle);
            //}
        }


        protected void SetupNodeBorder()
        {
            Reposition();

            RemoveUnusedElements();

            SetupDetail();

            SetupStyleClass();

            void Reposition()
            {
                // Brings it in front of any of the child elements that are under the node.
                NodeBorder.BringToFront();
            }

            void RemoveUnusedElements()
            {
                // Remove #selection-border from the node.
                Remove(ElementAt(0));

                // Remove the #contents visual element.
                NodeBorder.Remove(NodeBorder.ElementAt(1));
            }

            void SetupDetail()
            {
                NodeBorder.style.overflow = Overflow.Visible;
                NodeBorder.focusable = true;
            }

            void SetupStyleClass()
            {
                NodeBorder.name = "";
                NodeBorder.AddToClassList(StyleConfig.Node_Border);
            }
        }


        protected void SetupTitleContainer()
        {
            RemoveUnusedElements();

            SetupDetail();

            SetupStyleClass();

            void RemoveUnusedElements()
            {
                // Remove #title-label.
                titleContainer.Remove(titleContainer.ElementAt(0));

                // Remove #title-button-container.
                titleContainer.Remove(titleContainer.ElementAt(0));
            }

            void SetupDetail()
            {
                titleContainer.SetPickingMode(PickingMode.Position);
            }

            void SetupStyleClass()
            {
                titleContainer.name = "";
                titleContainer.AddToClassList(StyleConfig.Node_Title_Container);
            }
        }


        protected void SetupTopContainer()
        {
            Reposition();

            RemoveUnusedElements();

            SetupStyleClass();

            void Reposition()
            {
                // Place the top container inside the node border.
                NodeBorder.Insert(index: 1, element: topContainer);
            }

            void RemoveUnusedElements()
            {
                // Remove the #divider visual element.
                topContainer.Remove(topContainer.ElementAt(1));
            }

            void SetupStyleClass()
            {
                topContainer.name = "";
                topContainer.AddToClassList(StyleConfig.Node_Top_Container);
            }
        }


        protected void SetupInputContainer()
        {
            // Setup style class
            {
                inputContainer.name = "";
                inputContainer.AddToClassList(StyleConfig.Node_Input_Container);
            }
        }


        protected void SetupOutputContainer()
        {
            // Setup style class
            {
                outputContainer.name = "";
                outputContainer.AddToClassList(StyleConfig.Node_Output_Container);
            }
        }


        protected void SetupMainContainer()
        {
            // Setup detail
            {
                mainContainer.SetPickingMode(PickingMode.Position);
            }
        }


        protected void SetupBaseStyleClass()
        {
            ClearClassList();
            AddToClassList(StyleConfig.Node);
        }


        protected void SetupBaseStyleSheets()
        {
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSGlobalStyle);
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSNodeCommonStyle);
        }


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Add menu items to the node contextual menu.
        /// <para>Read More https://docs.unity3d.com/ScriptReference/ContextMenu.html</para>
        /// </summary>
        /// <param name="evt">The event holding the menu to populate.</param>
        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            AddContextualMenuItems(evt);
            evt.menu.AppendSeparator();
        }


        /// <summary>
        /// Methods for adding menu items to the node contextual menu, items are added at the end of the current item list.
        /// </summary>
        /// <param name="evt">The event holding the menu to populate.</param>
        protected abstract void AddContextualMenuItems(ContextualMenuPopulateEvent evt);
    }
}