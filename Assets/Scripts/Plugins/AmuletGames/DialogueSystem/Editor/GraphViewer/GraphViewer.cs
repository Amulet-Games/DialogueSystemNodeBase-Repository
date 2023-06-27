using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphViewer : GraphView
    {
        /// <summary>
        /// Reference of the node create connector window.
        /// </summary>
        public NodeCreateConnectorWindow NodeCreateConnectorWindow;


        /// <summary>
        /// Is the graph viewer in focus at the moment?
        /// </summary>
        public bool IsFocus;


        /// <summary>
        /// Cache of the nodes that are on the graph.
        /// </summary>
        public List<NodeBase> Nodes;


        /// <summary>
        /// Cache of the edges that are on the graph.
        /// </summary>
        public List<EdgeBase> Edges;


        /// <summary>
        /// Cache of the ports that are on the graph.
        /// </summary>
        public Dictionary<string, PortBase> PortByPortGUID;


        /// <summary>
        /// The current mouse position on screen whenever an unity's event is invoked.
        /// <para>Note that NullReferenceException will occur if there's no event invoked</para>
        /// </summary>
        public Vector2 MouseScreenPosition => GUIUtility.GUIToScreenPoint(Event.current.mousePosition);


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the graph viewer element class.
        /// </summary>
        public GraphViewer()
        {
            Nodes = new();
            Edges = new();
            PortByPortGUID = new();
        }


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Get all ports compatible with given port under certain conditions, 
        /// <br>to limit which nodes can connect to each other.</br>
        /// <para>Read More https://docs.unity3d.com/ScriptReference/Experimental.GraphView.GraphView.GetCompatiblePorts.html</para>
        /// </summary>
        /// <param name="connectFromPort">The starting port to validate against.</param>
        /// <param name="nodeAdapter">Parameter can be ignored.</param>
        /// <returns>List of compatible ports.</returns>
        public override List<Port> GetCompatiblePorts(Port connectFromPort, NodeAdapter nodeAdapter)
        {
            List<Port> compatiblePorts = new();

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


        // ----------------------------- Services -----------------------------
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
        /// <param name="edge">The targeting edge.</param>
        public void Remove(NodeBase node)
        {
            RemoveElement(node);
            Nodes.Remove(node);
        }


        /// <summary>
        /// Remove the given edge from the graph.
        /// </summary>
        /// <param name="edge">The targeting edge.</param>
        public void Remove(EdgeBase edge)
        {
            RemoveElement(edge);
            Edges.Remove(edge);
        }


        /// <summary>
        /// Remove the port with the give port name(GUID) from the graph viewer's port cache.
        /// </summary>
        /// <param name="node">The targeting port.</param>
        public void Remove(PortBase port)
        {
            if (PortByPortGUID.ContainsKey(port.name))
            {
                PortByPortGUID.Remove(port.name);
            }
            else
            {
                Debug.LogWarning($"Can't remove the port {port} because it can't be found in the cache.");
            }
        }


        /// <summary>
        /// Add the given node to the graph.
        /// </summary>
        /// <param name="node">The target node.</param>
        public void Add(NodeBase node)
        {
            AddElement(node);
            Nodes.Add(node);
        }


        /// <summary>
        /// Add the given edge to the graph.
        /// </summary>
        /// <param name="edge">The targeting edge.</param>
        public void Add(EdgeBase edge)
        {
            AddElement(edge);
            Edges.Add(edge);
        }


        /// <summary>
        /// Add the given port to the graph viewer's port cache.
        /// </summary>
        /// <param name="node">The targeting port.</param>
        public void Add(PortBase port)
        {
            if (!PortByPortGUID.ContainsKey(port.name))
            {
                PortByPortGUID.Add(key: port.name, value: port);
            }
            else
            {
                Debug.LogWarning("A port with the same cache key has already been added!");
            }
        }


        /// <summary>
        /// Remove all the graph elements and clear each of their internal cache.
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