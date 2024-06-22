using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class EdgeConnectorSearchWindowView
    {
        /// <summary>
        /// Reference of the search window.
        /// </summary>
        public SearchWindow SearchWindow;


        /// <summary>
        /// The property of the connector port reference.
        /// </summary>
        public Port ConnectorPort
        {
            get
            {
                return m_connectorPort;
            }
            set
            {
                m_connectorPort = value;

                SearchWindow.SearchTreeEntries = m_connectorPort.IsInput()
                    ? InputConnectorSearchTreeEntries
                    : OutputConnectorSearchTreeEntries;
            }
        }


        /// <summary>
        /// Reference of the connector port.
        /// </summary>
        Port m_connectorPort;


        /// <summary>
        /// Reference of the input connector search tree entries.
        /// </summary>
        public List<SearchTreeEntry> InputConnectorSearchTreeEntries;


        /// <summary>
        /// Reference of the output connector search tree entries.
        /// </summary>
        public List<SearchTreeEntry> OutputConnectorSearchTreeEntries;


        /// <summary>
        /// Reference of the edge model.
        /// </summary>
        public EdgeModel EdgeModel;


        /// <summary>
        /// Constructor of the edge connector search window view class.
        /// </summary>
        /// <param name="inputConnectorSearchTreeEntries">The input connector search tree entries to set for.</param>
        /// <param name="outputConnectorSearchTreeEntries">The output connector search tree entries to set for.</param>
        public EdgeConnectorSearchWindowView
        (
            List<SearchTreeEntry> inputConnectorSearchTreeEntries,
            List<SearchTreeEntry> outputConnectorSearchTreeEntries
        )
        {
            InputConnectorSearchTreeEntries = inputConnectorSearchTreeEntries;
            OutputConnectorSearchTreeEntries = outputConnectorSearchTreeEntries;
        }
    }
}