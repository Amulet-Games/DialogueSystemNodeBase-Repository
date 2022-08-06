using System.Collections.Generic;
using System;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    [Serializable]
    public class ChoiceEntry
    {
        /// <summary>
        /// The serialized Guid id for the port that is used in this entry. 
        /// </summary>
        public string PortGuid;


        /// <summary>
        /// The serialized Guid id for the node that is using this entry.
        /// </summary>
        string outputNodeGuid;


        /// <summary>
        /// The serialized Guid id for the connected node by using this entry.
        /// </summary>
        string inputNodeGuid;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of choice entry
        /// </summary>
        /// <param name="portGuid">The guid id for the port that is used in this entry.</param>
        /// <param name="outputNodeGuid">The guid id for the node that is using this entry</param>
        public ChoiceEntry(string portGuid, string outputNodeGuid)
        {
            PortGuid = portGuid;
            this.outputNodeGuid = outputNodeGuid;
            inputNodeGuid = "";
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save entry's value from another previously created entry.
        /// </summary>
        /// <param name="source">The entry of which it's values are going to be saved in.</param>
        /// <param name="edges">The reference of the edges that are currently on the graph.</param>
        /// <param name="edgesCount">The number of the edges that are currently on the graph.</param>
        /// <returns>A new choice entry that has loaded the source's value and it's ready to be saved.</returns>
        public static ChoiceEntry SaveEntryValue(ChoiceEntry source, List<Edge> edges, int edgesCount)
        {
            // Create a new choice entry and load the source's values into it.
            ChoiceEntry newChoiceEntry = new ChoiceEntry(source.PortGuid, source.outputNodeGuid);

            // To find the inputNodeGuid, first we get all the edges from the graph
            for (int j = 0; j < edgesCount; j++)
            {
                // If the source entry is connecting to a node, 
                // find the edge that is used to connected the two by search through the graph.
                if (edges[j].output.name == source.PortGuid)
                {
                    // And find the connecting node's guid id by the edge's input port's node reference.
                    newChoiceEntry.inputNodeGuid = ((DSNodeBase)edges[j].input.node).NodeGuid;
                    break;
                }
            }

            // Return it as result
            return newChoiceEntry;
        }


        /// <summary>
        /// Load choice entry's value from another previously saved entry.
        /// </summary>
        /// <param name="source">The entry that was previously saved and now it's used to load from.</param>
        public void LoadEntryValue(ChoiceEntry source)
        {
            PortGuid = source.PortGuid;
            outputNodeGuid = source.outputNodeGuid;
            inputNodeGuid = source.inputNodeGuid;
        }
    }
}