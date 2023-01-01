using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeCallbackFrameBase
    <
        TNode,
        TNodeModel
    >
        : NodeCallbackBase
        where TNode : NodeBase
        where TNodeModel : NodeModelBase
    {
        /// <summary>
        /// Responsible for communicating with the other module classes,
        /// <br>and creating the frame base when it's first initialized.</br>
        /// </summary>
        protected TNode Node;


        /// <summary>
        /// Holds all the components and data that'll be used on the connecting node,
        /// <br>and allows other framework classes to utilize them for different purposes.</br>.
        /// </summary>
        protected TNodeModel Model;


        /// <summary>
        /// Register new pointer enter actions to the connecting node module.
        /// </summary>
        protected void RegisterPointerEnterEvent()
        {
            Node.RegisterCallback<PointerEnterEvent>(callback =>
            {
                // Add to hover class.
                Node.NodeBorder.AddToClassList(StylesConfig.Node_Border_Hover);
            });
        }


        /// <summary>
        /// Register new pointer leave actions to the connecting node module.
        /// </summary>
        protected void RegisterPointerLeaveEvent()
        {
            Node.RegisterCallback<PointerLeaveEvent>(callback =>
            {
                // Remove from hover class.
                Node.NodeBorder.RemoveFromClassList(StylesConfig.Node_Border_Hover);
            });
        }
    }
}