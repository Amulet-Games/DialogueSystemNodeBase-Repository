using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public abstract class EdgeBase : Edge
    {
        /// <summary>
        /// The property of the edge callback reference.
        /// </summary>
        public virtual IEdgeCallback Callback { get; }


        /*
        // ----------------------------- Action -----------------------------
        /// <summary>
        /// Action to invoke just before the edge is going to be removed from the graph manually.
        /// </summary>
        public virtual void PreManualRemoveAction() { }


        /// <summary>
        /// Action to invoke right after the edge has been removed from the graph manually.
        /// </summary>
        public virtual void PostManualRemoveAction() { }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the edge values.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        public abstract void Save(DialogueSystemModel dsModel);


        // ----------------------------- Disconnect -----------------------------
        /// <summary>
        /// Disconnect any ports.
        /// </summary>
        public abstract void Disconnect();
        */
    }
}