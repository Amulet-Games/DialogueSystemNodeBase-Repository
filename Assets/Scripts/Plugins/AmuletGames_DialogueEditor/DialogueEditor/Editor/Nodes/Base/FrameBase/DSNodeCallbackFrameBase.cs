namespace AG
{
    /// <summary>
    /// Dialogue system node calllback's frame base class.
    /// </summary>
    /// <typeparam name="TNode">Node type</typeparam>
    /// <typeparam name="TNodeModel">Node model type</typeparam>
    public abstract class DSNodeCallbackFrameBase<TNode, TNodeModel>
        : DSNodeCallbackBase
        where TNode : DSNodeBase
        where TNodeModel : DSNodeModelBase
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
    }
}