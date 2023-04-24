using System;
using System.Linq;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public partial class DefaultPort : PortFrameBase<PortDataBase>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the default port element class.
        /// </summary>
        /// <param name="orientation">Vertical or horizontal.</param>
        /// <param name="direction">Input or output.</param>
        /// <param name="capacity">Support multiple or only single.</param>
        /// <param name="type">Port data type.</param>
        protected DefaultPort
        (
            Orientation orientation,
            Direction direction,
            Capacity capacity,
            Type type
        )
            : base(orientation, direction, capacity, type)
        {
        }


        // ----------------------------- Serialization -----------------------------
        /// <inheritdoc />
        public override void Save(PortDataBase data)
        {
            data.GUID = name;
        }


        /// <inheritdoc />
        public override void Load(PortDataBase data)
        {
            name = data.GUID;
        }


        // ----------------------------- Disconnect -----------------------------
        /// <inheritdoc />
        public override void Disconnect(GraphViewer graphViewer)
        {
            if (connected)
            {
                if (this.IsSingle())
                {
                    var edge = (DefaultEdge)connections.First();

                    edge.Disconnect();

                    graphViewer.Remove(edge);
                }
                else
                {
                    var edges = (DefaultEdge[])connections.ToArray();

                    for (int i = 0; i < edges.Length; i++)
                    {
                        edges[i].Disconnect();

                        graphViewer.Remove(edges[i]);
                    }
                }
            }
        }
    }
}