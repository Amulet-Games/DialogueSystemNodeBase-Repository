using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodePresenterFrameBase
    <
        TNode,
        TNodeView
    > 
        : NodePresenterBase
        where TNode : NodeBase
        where TNodeView : NodeViewBase
    {
        /// <summary>
        /// Method for creating the elements for the node.
        /// </summary>
        /// <param name="view">The node view to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <returns>The type node element.</returns>
        public abstract TNode CreateElements
        (
            TNodeView view,
            GraphViewer graphViewer,
            HeadBar headBar = null
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
            titleContainer.AddToClassList(StyleConfig.Node_Title_Container);

            view.NodeTitleTextFieldView.TextField = NodeTitleTextFieldPresenter.CreateElement
            (
                titleText: node.title,
                fieldUSS: StyleConfig.Node_Title_TextField
            );

            view.EditTitleButton = CommonButtonPresenter.CreateElement
            (
                buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                buttonUSS: StyleConfig.Node_EditTitle_Button
            );

            titleContainer.Add(view.NodeTitleTextFieldView.TextField);
            titleContainer.Add(view.EditTitleButton);

            node.titleContainer.Add(titleContainer);
        }
    }
}