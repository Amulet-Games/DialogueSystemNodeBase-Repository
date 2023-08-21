using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class PortBase : Port
    {
        /// <summary>
        /// The property of the port's connector box visual element.
        /// </summary>
        public VisualElement ConnectorBox => m_ConnectorBox;


        /// <summary>
        /// The property of the port's connector text visual element.
        /// </summary>
        public VisualElement ConnectorText => m_ConnectorText;


        /// <summary>
        /// The property of the port's connector box cap visual element.
        /// </summary>
        public VisualElement ConnectorBoxCap => m_ConnectorBoxCap;


        /// <summary>
        /// The Guid of the port.
        /// </summary>
        public Guid Guid;


        /// <summary>
        /// Constructor of the port base class.
        /// </summary>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="capacity">The capacity to set for.</param>
        public PortBase(Direction direction, Capacity capacity)
            : base(Orientation.Horizontal, direction, capacity, null) { }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Disconnect any edges that are connecting with the port.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public abstract void Disconnect(GraphViewer graphViewer);
    }
}