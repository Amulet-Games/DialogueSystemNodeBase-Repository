using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodePresenterFrameBase
    <
        TNode,
        TNodeView,
        TNodeCallback
    > 
        : NodePresenterBase
        where TNode : NodeBase
        where TNodeView : NodeViewFrameBase<TNodeView>
        where TNodeCallback : NodeCallbackFrameBase<TNode, TNodeView, TNodeCallback>
    {
        /// <summary>
        /// Method for creating the elements for the node.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="callback">The node callback to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>A new node element.</returns>
        public abstract TNode CreateElements
        (
            TNodeView view,
            TNodeCallback callback,
            GraphViewer graphViewer
        );


        /// <summary>
        /// Method for creating the node's title elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        protected void CreateTitleElements
        (
            TNode node,
            TNodeView view
        )
        {
            VisualElement titleContainer = new();

            NodeTitleTextFieldPresenter.CreateElement
            (
                view: view.NodeTitleTextFieldView,
                fieldUSS: StyleConfig.Node_Title_TextField
            );

            view.EditTitleButton = CommonButtonPresenter.CreateElement
            (
                buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                buttonUSS: StyleConfig.Node_EditTitle_Button
            );

            titleContainer.Add(view.NodeTitleTextFieldView.Field);
            titleContainer.Add(view.EditTitleButton);

            titleContainer.AddToClassList(StyleConfig.node_Title_Main);

            node.titleContainer.Add(titleContainer);
        }
    }
}