using System;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Dialogue system node model base class.
    /// </summary>
    [Serializable]
    public abstract class DSNodeModelBase
    {
        // ----------------------------- Serialized Base -----------------------------
        /// <summary>
        /// The serialized node's Guid id.
        /// </summary>
        public string SavedNodeGuid;


        /// <summary>
        /// The serialized node's position. 
        /// </summary>
        public Vector2 SavedNodePosition;
    }
}
