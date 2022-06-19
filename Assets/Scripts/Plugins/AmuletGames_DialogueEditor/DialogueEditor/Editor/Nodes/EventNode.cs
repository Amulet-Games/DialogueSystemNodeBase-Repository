using System;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class EventNode : BaseNode, IBasicEventModifierUtility, IScriptableEventModifierUtility
    {
        [Header("Data")]
        public EventNodeData nodeData = new EventNodeData();

        [Header("Ports")]
        public Port inputPort;
        public Port outputPort;

        public EventNode()
        {
            // GOAL: To be able to find in the node search bar.
        }

        public EventNode(Vector2 position, DialogueEditorWindow dsWindow, DSGraphView graphView)
        {
            SetupRefs();

            SetupNodeDetails();

            SetupToolbarMenu();

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
                title = "Event";
                SetPosition(new Rect(position, defaultNodeSize));
            }

            void SetupToolbarMenu()
            {
                ToolbarMenu dropdownMenu;

                SetupMenu();

                RegisterMenuDropdownAction();

                AddMenuToContainer();

                void SetupMenu()
                {
                    dropdownMenu = DSBuiltInFieldsMaker.GetNewToolbarMenu("Add Event");
                }

                void RegisterMenuDropdownAction()
                {
                    dropdownMenu.menu.AppendAction("Basic Event", DSToolbarMenuUtilityEditor.DSDropdownMenuAction(AddBasicEvent));
                    dropdownMenu.menu.AppendAction("Scriptable Event", DSToolbarMenuUtilityEditor.DSDropdownMenuAction(AddScriptableEvent));
                }

                void AddMenuToContainer()
                {
                    titleContainer.Add(dropdownMenu);
                }
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.eventNodeStyle);
                styleSheets.Add(DSStylesConfig.dsModifiersStyle);
            }

            void AddPorts()
            {
                inputPort = AddInputPort("Input", Port.Capacity.Multi, N_NodeType.Event);
                outputPort = AddOutputPort("Output", Port.Capacity.Single, N_NodeType.Event);
            }
        }

        #region Dropdow Menu Action.
        void AddBasicEvent()
        {
            DSModifiersMaker.GetNewModifier_BasicEvent(this, null);
        }

        void AddScriptableEvent()
        {
            DSModifiersMaker.GetNewModifier_ScriptableEvent(this, null);
        }
        #endregion

        #region IBasicEventModifierUtility
        public void AddModifierToData(BasicEventModifier basicEventModifier)
        {
            nodeData.basicEventModifiers.Add(basicEventModifier);
            nodeData.all.Add(basicEventModifier);
        }

        public void RemoveModifierFromData(BasicEventModifier basicEventModifier)
        {
            nodeData.basicEventModifiers.Remove(basicEventModifier);
            nodeData.all.Remove(basicEventModifier);
        }
        #endregion

        #region IScriptableEventModifierUtility
        public void AddModifierToData(ScriptableEventModifier scriptableEventModifier)
        {
            nodeData.scriptableEventModifiers.Add(scriptableEventModifier);
            nodeData.all.Add(scriptableEventModifier);
        }

        public void RemoveModifierFromData(ScriptableEventModifier scriptableEventModifier)
        {
            nodeData.scriptableEventModifiers.Remove(scriptableEventModifier);
            nodeData.all.Remove(scriptableEventModifier);
        }
        #endregion
    }
}