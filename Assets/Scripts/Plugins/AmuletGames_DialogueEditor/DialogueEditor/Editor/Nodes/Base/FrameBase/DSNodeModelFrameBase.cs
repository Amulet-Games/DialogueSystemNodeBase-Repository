namespace AG
{
    /// <summary>
    /// Dialogue system node model's frame base class.
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    public class DSNodeModelFrameBase<TNode>
        : DSNodeModelBase
        where TNode: DSNodeBase
    {
        /// <summary>
        /// Responsible for communicating with the other module classes,
        /// <br>and creating the frame base when it's first initialized.</br>
        /// </summary>
        protected TNode Node;
    }
}