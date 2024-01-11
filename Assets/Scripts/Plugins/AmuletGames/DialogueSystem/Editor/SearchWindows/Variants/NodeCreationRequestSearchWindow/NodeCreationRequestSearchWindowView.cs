using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    public class NodeCreationRequestSearchWindowView
    {
        /// <summary>
        /// Reference of the search window.
        /// </summary>
        public SearchWindowBase SearchWindow;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        public GraphViewer GraphViewer;


        /// <summary>
        /// Constructor of the node creation request search window view class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public NodeCreationRequestSearchWindowView(GraphViewer graphViewer)
        {
            GraphViewer = graphViewer;
        }
    }
}