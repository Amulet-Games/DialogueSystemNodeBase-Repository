namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodePresenterFrameBase
    <
        TNode,
        TNodeView
    > 
        : NodePresenterBase
        where TNode : NodeFrameBase<TNode, TNodeView>
        where TNodeView : NodeViewFrameBase<TNodeView>
    {
        /// <summary>
        /// Reference of the node element.
        /// </summary>
        protected TNode Node;


        /// <summary>
        /// Reference of the node view.
        /// </summary>
        protected TNodeView View;


        /// <summary>
        /// Create the elements for the node.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <returns>A new node element.</returns>
        public virtual void CreateElements(TNode node)
        {
            Node = node;
            View = node.View;
        }


        /// <summary>
        /// Create the node's title elements.
        /// </summary>
        protected void CreateTitleElements()
        {
            CreateNodeTitleField();

            CreateEditTitleButton();

            AddElementsToContainer();

            void CreateNodeTitleField()
            {
                NodeTitleTextFieldPresenter.CreateElement
                (
                    view: View.NodeTitleFieldView,
                    fieldUSS: StyleConfig.Node_NodeTitle_Field
                );
            }
            
            void CreateEditTitleButton()
            {
                View.EditTitleButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    buttonUSS: StyleConfig.Node_EditTitle_Button
                );
            }
            
            void AddElementsToContainer()
            {
                Node.titleContainer.Add(View.NodeTitleFieldView.Field);
                Node.titleContainer.Add(View.EditTitleButton);
            }
        }
    }
}