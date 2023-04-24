using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public abstract class EdgeBase : Edge
    {
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
        /// Save the edge values to the dialogue system data.
        /// </summary>
        /// <param name="dsData">The dialogue system data to save to.</param>
        public abstract void Save(DialogueSystemData dsData);


        // ----------------------------- Disconnect -----------------------------
        /// <summary>
        /// Disconnect any ports.
        /// </summary>
        public abstract void Disconnect();
    }
}