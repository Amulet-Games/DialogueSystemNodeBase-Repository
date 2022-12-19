using UnityEngine.UIElements;
using UnityEngine;

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


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void ManualCreatedAction()
        {
            SetNodePosition();

            SetNodeMinMaxWidth();

            TemporaryHideNode();

            RegisterDelayCreatedAction();

            void SetNodePosition()
            {
                Node.SetPosition(newPos: new Rect(Details.PlacePosition, Vector2Utility.Zero));
            }

            void TemporaryHideNode()
            {
                Node.AddToClassList(StylesConfig.Global_Visible_Hidden);
            }

            void RegisterDelayCreatedAction()
            {
                Node.RegisterCallback<GeometryChangedEvent>(GeometryChangedAction);

                void GeometryChangedAction(GeometryChangedEvent evt)
                {
                    // Delay setup the manual created node.
                    DelayedManualCreatedAction();

                    // Unregister the action once the setup is done.
                    Node.UnregisterCallback<GeometryChangedEvent>(GeometryChangedAction);
                }
            }
        }


        /// <inheritdoc />
        public override void LoadCreatedAction()
        {
            SetNodeMinMaxWidth();
        }
    }
}