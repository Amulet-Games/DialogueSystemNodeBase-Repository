using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public partial class DefaultPort : PortFrameBase<PortModelBase>
    {
        public override IEnumerable<Edge> connections
        {
            get
            {
                return null;
            }
        }

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
        public override void Save(PortModelBase model)
        {
            model.GUID = name;
        }


        /// <inheritdoc />
        public override void Load(PortModelBase model)
        {
            name = model.GUID;
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc />
        //public override void Disconnect(Edge edge)
        //{
        //    base.Disconnect(edge);

        //    Debug.Log("edge type = " + connections.First().GetType());
        //}


        /// <inheritdoc />
        public override void Disconnect(GraphViewer graphViewer)
        {
            if (connected)
            {
                if (this.IsSingle())
                {
                    // get connecting edge
                    var edge = (DefaultEdge)connections.First();

                    // Disconnect ports.
                    {
                        if (direction == Direction.Output)
                        {
                            edge.View.Input.Disconnect(edge);
                        }
                        else
                        {
                            edge.View.Output.Disconnect(edge);
                        }

                        base.Disconnect(edge);
                    }

                    // Remove edge from graph viewer.
                    graphViewer.Remove(edge);
                }
                else
                {
                    // get connecting edge
                    var edges = (DefaultEdge[])connections.ToArray();

                    for (int i = 0; i < edges.Length; i++)
                    {
                        // Disconnect ports.
                        {
                            if (direction == Direction.Output)
                            {
                                edges[i].View.Input.Disconnect(edges[i]);
                            }
                            else
                            {
                                edges[i].View.Output.Disconnect(edges[i]);
                            }

                            base.Disconnect(edges[i]);
                        }

                        // Remove edge from graph viewer.
                        graphViewer.Remove(edges[i]);
                    }
                }
            }
        }
    }
}