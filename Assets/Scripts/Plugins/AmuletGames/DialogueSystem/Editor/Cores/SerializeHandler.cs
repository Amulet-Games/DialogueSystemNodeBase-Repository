﻿using UnityEditor;

namespace AG.DS
{
    public class SerializeHandler
    {
        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save all the edges and nodes that are on the graph.
        /// </summary>
        /// <param name="dialogueSystemWindowAsset">The dialogue system window asset to set for.</param>
        /// <param name="dialogueSystemWindowData">The dialogue system window data to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public void Save
        (
            DialogueSystemWindowAsset dialogueSystemWindowAsset,
            DialogueSystemWindowData dialogueSystemWindowData,
            GraphViewer graphViewer
        )
        {
            SaveEdges(dialogueSystemWindowData, graphViewer);
            SaveNodes(dialogueSystemWindowData, graphViewer);

            // Set dirty when the saving is finished.
            EditorUtility.SetDirty(dialogueSystemWindowAsset);
        }


        /// <summary>
        /// Save all the edges that are on the graph.
        /// </summary>
        /// <param name="dialogueSystemWindowData">The dialogue system window data to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        void SaveEdges
        (
            DialogueSystemWindowData dialogueSystemWindowData,
            GraphViewer graphViewer
        )
        {
            // Clear existing edges data
            {
                dialogueSystemWindowData.ClearEdgesData();
            }

            // Create new edges data
            {
                var edgeCount = graphViewer.Edges.Count;
                for (int i = 0; i < edgeCount; i++)
                {
                    dialogueSystemWindowData.EdgesData.Add(
                        EdgeManager.Instance.Save(graphViewer.Edges[i])
                    );
                }
            }
        }


        /// <summary>
        /// Save all the nodes that are on the graph.
        /// </summary>
        /// <param name="dialogueSystemWindowData">The dialogue system window data to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        void SaveNodes
        (
            DialogueSystemWindowData dialogueSystemWindowData,
            GraphViewer graphViewer
        )
        {
            // Clear existing nodes data
            {
                dialogueSystemWindowData.ClearNodesData();
            }

            // Create new nodes data
            {
                var nodeCount = graphViewer.Nodes.Count;
                for (int i = 0; i < nodeCount; i++)
                {
                    dialogueSystemWindowData.NodesData.Add(
                        NodeManager.Instance.Save(graphViewer.Nodes[i])
                    );
                }
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load all the edges and nodes data that are stored on the scriptable object asset.
        /// </summary>
        /// <param name="dialogueSystemWindowAsset">The dialogue system window asset to set for.</param>
        /// <param name="dialogueSystemWindowData">The dialogue system window data to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        public void Load
        (
            DialogueSystemWindowAsset dialogueSystemWindowAsset,
            DialogueSystemWindowData dialogueSystemWindowData,
            GraphViewer graphViewer,
            LanguageHandler languageHandler
        )
        {
            LoadNodes(dialogueSystemWindowData, graphViewer, languageHandler);
            LoadEdges(dialogueSystemWindowData, graphViewer);

            // Set dirty when the loading is finished.
            EditorUtility.SetDirty(dialogueSystemWindowAsset);
        }


        /// <summary>
        /// Load the nodes data and spawn the nodes to the graph.
        /// </summary>
        /// <param name="dialogueSystemWindowData">The dialogue system window data to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        void LoadNodes
        (
            DialogueSystemWindowData dialogueSystemWindowData,
            GraphViewer graphViewer,
            LanguageHandler languageHandler
        )
        {
            var count = dialogueSystemWindowData.NodesData.Count;
            for (int i = 0; i < count; i++)
            {
                graphViewer.Add(
                    NodeManager.Instance.Spawn(graphViewer, dialogueSystemWindowData.NodesData[i], languageHandler)
                );
            }
        }


        /// <summary>
        /// Load the edges data and connects the ports on the graph.
        /// and attempt to connect the previously linked nodes again.
        /// </summary>
        /// <param name="dialogueSystemWindowData">The dialogue system window data to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        void LoadEdges
        (
            DialogueSystemWindowData dialogueSystemWindowData,
            GraphViewer graphViewer
        )
        {
            var count = dialogueSystemWindowData.EdgesData.Count;

            for (int i = 0; i < count; i++)
            {
                var data = dialogueSystemWindowData.EdgesData[i];

                // Try to find the output port that matches the data's output port GUID.
                if (graphViewer.PortByPortGUID.TryGetValue(data.OutputPortGUID, out PortBase output))
                {
                    // Try to find the input port that matches the data's input port GUID.
                    if (graphViewer.PortByPortGUID.TryGetValue(data.InputPortGUID, out PortBase input))
                    {
                        /// TODO: Refactor the style sheet part.
                        graphViewer.Add(
                            EdgeManager.Instance.Connect(output, input, data.styleSheets[0])
                        );
                    }
                }
            }
        }
    }
}