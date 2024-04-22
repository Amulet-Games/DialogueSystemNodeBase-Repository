using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    /// <summary>
    /// Holds the raw data that can be used when creating a new port.
    /// </summary>
    public class PortModel
    {
        /// <summary>
        /// The direction of the port.
        /// </summary>
        public Direction Direction { get; private set; }


        /// <summary>
        /// The capacity of the port.
        /// </summary>
        public Capacity Capacity { get; private set; }


        /// <summary>
        /// The name of the port.
        /// </summary>
        public string Name { get; private set; }


        /// <summary>
        /// The color of the port.
        /// </summary>
        public Color Color { get; private set; }


        /// <summary>
        /// The Guid of the port.
        /// </summary>
        public Guid Guid { get; private set; }


        /// <summary>
        /// Reference of the edge connector search window view.
        /// </summary>
        public EdgeConnectorSearchWindowView EdgeConnectorSearchWindowView { get; private set; }


        /// <summary>
        /// Reference of the edge model.
        /// </summary>
        public EdgeModel EdgeModel { get; private set; }


        /// <summary>
        /// Constructor of the port model class.
        /// </summary>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="capacity">The capacity to set for.</param>
        /// <param name="name">The name to set for.</param>
        /// <param name="color">The color to set for.</param>
        /// <param name="edgeConnectorSearchWindowView">The edge connector search window view to set for.</param>
        /// <param name="edgeModel">The edge model to set for.</param>
        public PortModel
        (
            Direction direction,
            Capacity capacity,
            string name,
            Color color,
            EdgeConnectorSearchWindowView edgeConnectorSearchWindowView,
            EdgeModel edgeModel
        )
        {
            Direction = direction;
            Capacity = capacity;
            Name = name;
            Color = color;
            Guid = Guid.NewGuid();
            EdgeConnectorSearchWindowView = edgeConnectorSearchWindowView;
            EdgeModel = edgeModel;
        }
    }
}