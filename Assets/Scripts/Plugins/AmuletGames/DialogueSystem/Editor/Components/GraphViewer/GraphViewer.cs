using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using GraphViewPort = UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    public class GraphViewer : GraphView
    {
        /// <summary>
        /// Reference of the node creation request search window view.
        /// </summary>
        public NodeCreationRequestSearchWindowView NodeCreationRequestSearchWindowView { get; private set; }


        /// <summary>
        /// Reference of the edge connector search window view.
        /// </summary>
        public EdgeConnectorSearchWindowView EdgeConnectorSearchWindowView { get; private set; }


        /// <summary>
        /// Reference of the option edge connector search window view.
        /// </summary>
        public EdgeConnectorSearchWindowView OptionEdgeConnectorSearchWindowView { get; private set; }


        /// <summary>
        /// Is the graph viewer in focus at the moment?
        /// </summary>
        public bool IsFocus;


        /// <summary>
        /// The node elements cache.
        /// </summary>
        public List<NodeBase> Nodes { get; private set; }


        /// <summary>
        /// The edge elements cache.
        /// </summary>
        public List<Edge> Edges { get; private set; }


        /// <summary>
        /// The ports elements cache.
        /// </summary>
        public Dictionary<Guid, Port> PortByPortGUID { get; private set; }


        /// <summary>
        /// Constructor of the graph viewer element class.
        /// </summary>
        public GraphViewer()
        {
            NodeCreationRequestSearchWindowView = new();
            EdgeConnectorSearchWindowView = new
            (
                inputConnectorSearchTreeEntries: SearchTreeEntryProvider.EdgeConnectorInputSearchTreeEntries,
                outputConnectorSearchTreeEntries: SearchTreeEntryProvider.EdgeConnectorOutputSearchTreeEntries
            );
            OptionEdgeConnectorSearchWindowView = new
            (
                inputConnectorSearchTreeEntries: SearchTreeEntryProvider.OptionEdgeConnectorInputSearchTreeEntries,
                outputConnectorSearchTreeEntries: SearchTreeEntryProvider.OptionEdgeConnectorOutputSearchTreeEntries
            );

            Nodes = new();
            Edges = new();
            PortByPortGUID = new();
        }


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Get all ports compatible with given port.
        /// <para>Read More https://docs.unity3d.com/ScriptReference/Experimental.GraphView.GraphView.GetCompatiblePorts.html</para>
        /// </summary>
        /// <param name="connectFromPort">The starting port to validate against.</param>
        /// <param name="nodeAdapter">Parameter can be ignored.</param>
        /// <returns>List of compatible ports.</returns>
        public override List<GraphViewPort> GetCompatiblePorts
        (
            GraphViewPort connectFromPort,
            NodeAdapter nodeAdapter
        )
        {
            List<GraphViewPort> compatiblePorts = new();

            ports.ForEach((connectToPort) =>
            {
                // Same port cannot connect to itself.
                if (connectFromPort != connectToPort)
                {
                    // Start node cannot connect to start node
                    if (connectFromPort.node != connectToPort.node)
                    {
                        // Port cannot connect to the another port that has the same direction.
                        // *Input Port(A) -> Input Port(B) / Output Port(A) -> Output Port(B)
                        if (connectFromPort.direction != connectToPort.direction)
                        {
                            // Ports that aren't in the same port colors cannot connect.
                            if (connectFromPort.portColor == connectToPort.portColor)
                            {
                                compatiblePorts.Add(connectToPort);
                            }
                        }
                    }
                }
            });

            // return all the acceptable ports.
            return compatiblePorts;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Reframe the graph viewer when the given visual element's GeometryChangedEvent is invoked.
        /// </summary>
        /// <param name="geometryChangedElement">The visual element to register the GeometryChangedEvent on.</param>
        /// <param name="frameType">The frame type to set for.</param>
        public void ReframeGraphOnGeometryChanged(VisualElement geometryChangedElement, FrameType frameType)
        {
            geometryChangedElement.ExecuteOnceOnGeometryChanged(GeometryChangedEvent);

            void GeometryChangedEvent(GeometryChangedEvent evt)
            {
                switch (frameType)
                {
                    case FrameType.All:
                        FrameAll();
                        break;
                    case FrameType.Selection:
                        FrameSelection();
                        break;
                    case FrameType.Origin:
                        FrameOrigin();
                        break;
                }
            }
        }


        /// <summary>
        /// Remove the given node from the graph.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        public void Remove(NodeBase node)
        {
            RemoveElement(node);
            Nodes.Remove(node);
        }


        /// <summary>
        /// Remove the given edge from the graph.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public void Remove(Edge edge)
        {
            RemoveElement(edge);
            Edges.Remove(edge);
        }


        /// <summary>
        /// Remove the port with the give port name(GUID) from the graph viewer's cache.
        /// </summary>
        /// <param name="node">The port element to set for.</param>
        public void Remove(Port port)
        {
            if (PortByPortGUID.ContainsKey(port.Guid))
            {
                PortByPortGUID.Remove(port.Guid);
            }
            else
            {
                Debug.LogWarning($"Can't remove the port {port} because it can't be found in the dictionary.");
            }
        }


        /// <summary>
        /// Add the given node to the graph.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        public void Add(NodeBase node)
        {
            AddElement(node);
            Nodes.Add(node);
        }


        /// <summary>
        /// Add the given edge to the graph.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public void Add(Edge edge)
        {
            AddElement(edge);
            Edges.Add(edge);
        }


        /// <summary>
        /// Add the given port to the graph viewer's cache.
        /// </summary>
        /// <param name="node">The port element to set for.</param>
        public void Add(Port port)
        {
            if (!PortByPortGUID.ContainsKey(port.Guid))
            {
                PortByPortGUID.Add(key: port.Guid, value: port);
            }
            else
            {
                Debug.LogWarning("A port with the same dictionary key has already been added!");
            }
        }


        /// <summary>
        /// Remove all the graph elements and clear the internal cache.
        /// </summary>
        public void ClearGraph()
        {
            // Remove elements.
            {
                // Nodes.
                var nodeCount = Nodes.Count;
                for (int i = 0; i < nodeCount; i++)
                {
                    RemoveElement(Nodes[i]);
                }

                // Edges.
                var edgeCount = Edges.Count;
                for (int i = 0; i < edgeCount; i++)
                {
                    RemoveElement(Edges[i]);
                }
            }

            // Clear caches.
            {
                Nodes.Clear();
                Edges.Clear();
                PortByPortGUID.Clear();
            }
        }
    }
}