using UnityEngine;

namespace AG
{
    public class DSNodesMaker
    {
        /// <summary>
        /// Create a new start node on the dialogue system graph.
        /// </summary>
        /// <param name="position">The vector2 position of where the node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        /// <returns>A new start node graph element which created in the given position.</returns>
        public static DSStartNode CreateStartNode(Vector2 position, DSGraphView graphView)
        {
            DSStartNode newNode = new DSStartNode(position, graphView);
            graphView.AddElement(newNode);

            return newNode;
        }


        /// <summary>
        /// Create a new dialogue node on the dialogue system graph.
        /// </summary>
        /// <param name="position">The vector2 position of where the node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        /// <returns>A new dialogue node graph element which created in the given position.</returns>
        public static DSDialogueNode CreateDialogueNode(Vector2 position, DSGraphView graphView)
        {
            DSDialogueNode newNode = new DSDialogueNode(position, graphView);
            graphView.AddElement(newNode);

            return newNode;
        }


        /// <summary>
        /// Create a new choice node on the dialogue system graph.
        /// </summary>
        /// <param name="position">The vector2 position of where the node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        /// <returns>A new choice node graph element which created in the given position.</returns>
        public static DSChoiceNode CreateChoiceNode(Vector2 position, DSGraphView graphView)
        {
            DSChoiceNode newNode = new DSChoiceNode(position, graphView);
            graphView.AddElement(newNode);

            return newNode;
        }


        /// <summary>
        /// Create a new event node on the dialogue system graph.
        /// </summary>
        /// <param name="position">The vector2 position of where the node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        /// <returns>A new event node graph element which created in the given position.</returns>
        public static DSEventNode CreateEventNode(Vector2 position, DSGraphView graphView)
        {
            DSEventNode newNode = new DSEventNode(position, graphView);
            graphView.AddElement(newNode);

            return newNode;
        }


        /// <summary>
        /// Create a new branch node on the dialogue system graph.
        /// </summary>
        /// <param name="position">The vector2 position of where the node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        /// <returns>A new branch node graph element which created in the given position.</returns>
        public static DSBranchNode CreateBranchNode(Vector2 position, DSGraphView graphView)
        {
            DSBranchNode newNode = new DSBranchNode(position, graphView);
            graphView.AddElement(newNode);

            return newNode;
        }


        /// <summary>
        /// Create a new end node on the dialogue system graph.
        /// </summary>
        /// <param name="position">The vector2 position of where the node'll be created on the graph.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        /// <returns>A new end node graph element which created in the given position.</returns>
        public static DSEndNode CreateEndNode(Vector2 position, DSGraphView graphView)
        {
            DSEndNode newNode = new DSEndNode(position, graphView);
            graphView.AddElement(newNode);

            return newNode;
        }
    }
}