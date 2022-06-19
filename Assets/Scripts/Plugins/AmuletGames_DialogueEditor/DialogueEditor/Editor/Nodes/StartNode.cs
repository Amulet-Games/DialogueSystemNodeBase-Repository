using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public class StartNode : BaseNode
    {
        [Header("Ports")]
        public Port outputPort;

        public StartNode()
        {
            // GOAL: To be able to find in the node search bar.
        }

        public StartNode(Vector2 position, DialogueEditorWindow dsWindow, DSGraphView graphView)
        {
            SetupRefs();

            SetupNodeDetails();

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
                title = "Start";
                SetPosition(new Rect(position, defaultNodeSize));
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.startNodeStyle);
            }

            void AddPorts()
            {
                outputPort = AddOutputPort("Output", Port.Capacity.Single, N_NodeType.Start);
            }
        }
    }
}