using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodePresenterFrameBase
    <
        TNode,
        TNodeModel
    > 
        : NodePresenterBase
        where TNode : NodeBase
        where TNodeModel : NodeModelBase
    {
        /// <summary>
        /// Method for creating the elements for the node.
        /// </summary>
        /// <param name="model">The node model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <returns>The type node element.</returns>
        public abstract TNode CreateElements(TNodeModel model, GraphViewer graphViewer);


        /// <summary>
        /// Method for creating the node's title elements.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        protected void CreateTitleElements
        (
            TNode node,
            TNodeModel model
        )
        {
            // Create container
            VisualElement titleContainer = new();
            titleContainer.AddToClassList(StyleConfig.Node_Title_Container);

            // Title text field
            model.NodeTitleTextFieldModel.TextField = NodeTitleTextFieldPresenter.CreateElement
            (
                titleText: node.title,
                fieldUSS01: StyleConfig.Node_Title_TextField
            );

            // Edit title button
            model.EditTitleButton = CommonButtonPresenter.CreateElement
            (
                buttonSprite: ConfigResourcesManager.SpriteConfig.EditButtonIconSprite,
                buttonUSS01: StyleConfig.Node_EditTitle_Button
            );

            // Add to container
            titleContainer.Add(model.NodeTitleTextFieldModel.TextField);
            titleContainer.Add(model.EditTitleButton);

            // Add to node
            node.titleContainer.Add(titleContainer);
        }
    }
}