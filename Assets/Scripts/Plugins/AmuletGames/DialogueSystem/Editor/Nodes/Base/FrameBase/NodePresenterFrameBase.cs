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
            SetupNodeTitleTextField();

            SetupEditTitleButton();

            AddElementsToNode();

            void SetupNodeTitleTextField()
            {
                NodeTitleTextFieldPresenter.CreateElement
                (
                    view: View.NodeTitleTextFieldView,
                    fieldUSS: StyleConfig.Node_TitleText_Field
                );
            }
            
            void SetupEditTitleButton()
            {
                View.EditTitleButton = CommonButtonPresenter.CreateElement
                (
                    buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                    buttonUSS: StyleConfig.Node_EditTitle_Button
                );
            }
            
            void AddElementsToNode()
            {
                Node.titleContainer.Add(View.NodeTitleTextFieldView.Field);
                Node.titleContainer.Add(View.EditTitleButton);
            }
        }
    }
}