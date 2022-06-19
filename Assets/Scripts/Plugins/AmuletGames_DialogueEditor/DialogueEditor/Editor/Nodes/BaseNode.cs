using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class BaseNode : Node
    {
        public string nodeGuid;

        protected static Vector2 defaultNodeSize = new Vector2(200, 250);

        [Header("Refs.")]
        protected DSGraphView graphView;
        protected DialogueEditorWindow dsWindow;

        #region Setup.
        public BaseNode()
        {
            // Set node GUID
            SetupCommonDetails();

            // USS
            AddCommonStyleSheet();

            // Disable Collapse Button
            HideCollapseNodeButton();

            void SetupCommonDetails()
            {
                nodeGuid = Guid.NewGuid().ToString();
            }

            void AddCommonStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.dsGlobalStyle);
                styleSheets.Add(DSStylesConfig._nodesShareStyle);
            }

            void HideCollapseNodeButton()
            {
                DSFieldUtilityEditor.HideElement(m_CollapseButton);
            }
        }
        #endregion

        #region Virtual.
        public virtual void ReloadLanguage()
        {
            // GOAL: Reload all the language specific fields to match the current selected language in editor.
        }
        #endregion

        #region Utility.
        public static Color GetPortColorByNodeType(N_NodeType portColor)
        {
            switch (portColor)
            {
                case N_NodeType.Start:
                    return new Color(0.29f, 1, 0.34f);
                case N_NodeType.End:
                    return new Color(0.294f, 0.67f, 0.575f);
                case N_NodeType.Dialogue:
                    return new Color(1, 0.36f, 0.36f);
                case N_NodeType.Choice:
                    return new Color(0, 0.718f, 1);
                case N_NodeType.Branch:
                    return new Color(1, 0.616f, 0f);
                case N_NodeType.Event:
                    return new Color(1f, 0, 0.62f);
                default:
                    return new Color(0f, 0, 0f);
            }
        }

        public void DeleteVisualElement(VisualElement visualElement, N_NodeContainerType nodeContainerType)
        {
            switch (nodeContainerType)
            {
                case N_NodeContainerType.Extension:
                    extensionContainer.Remove(visualElement);
                    break;
                case N_NodeContainerType.Top:
                    topContainer.Remove(visualElement);
                    break;
                case N_NodeContainerType.TitleButton:
                    titleButtonContainer.Remove(visualElement);
                    break;
                case N_NodeContainerType.Title:
                    titleContainer.Remove(visualElement);
                    break;
                case N_NodeContainerType.Main:
                    mainContainer.Remove(visualElement);
                    break;
            }

            // Update changes for them to become visible.
            NodeRefreshStateOnly();
        }

        public void DeletePortElement(Port port, N_PortContainerType portContainerType)
        {
            switch (portContainerType)
            {
                case N_PortContainerType.Output:
                    outputContainer.Remove(port);
                    break;
                case N_PortContainerType.Input:
                    inputContainer.Remove(port);
                    break;
            }

            // Update changes for them to become visible.
            NodeRefreshAll();
        }

        public void NodeRefreshStateOnly() => RefreshExpandedState();

        public void NodeRefreshPortOnly() => RefreshPorts();

        public void NodeRefreshAll()
        {
            RefreshPorts();
            RefreshExpandedState();
        }
        #endregion

        #region Add Ports.
        protected Port AddOutputPort(string name, Port.Capacity capacity, N_NodeType nodeType)
        {
            Port outputPort;

            CreatePortInstance();

            SetupPortDetail();

            AddPortToContainer();

            return outputPort;

            void CreatePortInstance()
            {
                outputPort = GetPortInstance(Direction.Output, capacity);
            }

            void SetupPortDetail()
            {
                outputPort.name = Guid.NewGuid().ToString();
                outputPort.portName = name;
                outputPort.portColor = GetPortColorByNodeType(nodeType);
            }

            void AddPortToContainer()
            {
                outputContainer.Add(outputPort);
            }
        }

        protected Port AddInputPort(string name, Port.Capacity capacity, N_NodeType nodeType)
        {
            Port inputPort;

            CreatePortInstance();

            SetupPortDetail();

            AddPortToContainer();

            return inputPort;

            void CreatePortInstance()
            {
                inputPort = GetPortInstance(Direction.Input, capacity);
            }

            void SetupPortDetail()
            {
                inputPort.name = Guid.NewGuid().ToString();
                inputPort.portName = name;
                inputPort.portColor = GetPortColorByNodeType(nodeType);
            }

            void AddPortToContainer()
            {
                inputContainer.Add(inputPort);
            }
        }

        protected Port AddEntryPort(string name, Port.Capacity capacity, N_NodeType nodeType)
        {
            Port outputPort;

            CreatePortInstance();

            SetupPortDetail();

            AddPortToContainer();

            return outputPort;

            void CreatePortInstance()
            {
                outputPort = GetPortInstance(Direction.Output, capacity);
            }

            void SetupPortDetail()
            {
                outputPort.name = name;
                outputPort.portName = "";
                outputPort.portColor = GetPortColorByNodeType(nodeType);
            }

            void AddPortToContainer()
            {
                outputContainer.Add(outputPort);
            }
        }

        protected Port GetPortInstance(Direction nodeDirection, Port.Capacity capacity)
        {
            return InstantiatePort(Orientation.Horizontal, nodeDirection, capacity, typeof(float));
        }
        #endregion
    }
}