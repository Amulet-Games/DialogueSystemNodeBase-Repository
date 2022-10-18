using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Dialogue system node calllback's frame base class.
    /// </summary>
    /// <typeparam name="TNode">Node type</typeparam>
    /// <typeparam name="TNodeModel">Node model type</typeparam>
    public abstract class DSNodeCallbackFrameBase<TNode, TNodeModel, TNodeSerializer>
        : DSNodeCallbackBase
        where TNode : DSNodeBase
        where TNodeModel : DSNodeModelBase
        where TNodeSerializer : DSNodeSerializerFrameBase<TNode, TNodeModel>
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
        /// Responsible for serializing the node's data which are located in Model class.
        /// </summary>
        public TNodeSerializer Serializer;


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void ManualCreatedAction()
        {
            SetNodePosition();

            TemporaryHideNode();

            RegisterGeometryChangedEvent();

            void SetNodePosition()
            {
                Node.SetPosition(new Rect(Details.PlacePosition, DSVector2Utility.Zero));
            }

            void TemporaryHideNode()
            {
                Node.AddToClassList(DSStylesConfig.Global_Visible_Hidden);
            }

            void RegisterGeometryChangedEvent()
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


        /// <summary>
        /// Callback action when the node is added on the graph by loading the previous saved data (by serialize handler).
        /// </summary>
        /// <br>This action happens after InitalizedAction is called.</br>
        public void LoadCreatedAction(TNodeModel source)
        {
            LoadPreviousData();

            RegisterGeometryChangedEvent();

            void LoadPreviousData()
            {
                Serializer.LoadNode(source);
            }

            void RegisterGeometryChangedEvent()
            {
                Node.RegisterCallback<GeometryChangedEvent>(GeometryChangedAction);

                void GeometryChangedAction(GeometryChangedEvent evt)
                {
                    // Delay setup the load created node.
                    DelayedLoadCreatedAction();

                    // Unregister the action once the setup is done.
                    Node.UnregisterCallback<GeometryChangedEvent>(GeometryChangedAction);
                }
            }
        }


        /// <inheritdoc />
        public override void SelectedAction() { }


        /// <inheritdoc />
        public override void UnselectedAction() { }
    }
}