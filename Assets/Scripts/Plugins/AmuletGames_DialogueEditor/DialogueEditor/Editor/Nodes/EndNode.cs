using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public class EndNode : BaseNode
    {
        [Header("Data")]
        public EndNodeData nodeData = new EndNodeData();

        [Header("Ports")]
        public Port inputPort;

        public EndNode()
        {
            // GOAL: To be able to find in the node search bar.
        }

        public EndNode(Vector2 position, DialogueEditorWindow dsWindow, DSGraphView graphView)
        {
            SetupRefs();

            SetupNodeDetails();

            SetupEnumField();

            AddStyleSheet();

            AddPorts();

            NodeRefreshAll();

            void SetupRefs()
            {
                this.dsWindow = dsWindow;
                this.graphView = graphView;
            }

            void SetupNodeDetails()
            {
                title = "End";
                SetPosition(new Rect(position, defaultNodeSize));
            }

            void SetupEnumField()
            {
                mainContainer.Add(DSBuiltInFieldsMaker.GetNewEnumField(nodeData.graphEndHandleType_EnumContainer));
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.endNodeStyle);
            }

            void AddPorts()
            {
                inputPort = AddInputPort("Input", Port.Capacity.Multi, N_NodeType.End);
            }
        }
    }
}