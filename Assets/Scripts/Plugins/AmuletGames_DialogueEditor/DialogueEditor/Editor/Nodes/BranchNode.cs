using System;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class BranchNode : BaseNode
    {
        [Header("Data")]
        public BranchNodeData nodeData = new BranchNodeData();

        [Header("Ports")]
        public Port inputPort;
        public Port trueOutputPort;
        public Port falseOutputPort;

        public BranchNode()
        {
            // GOAL: To be able to find in the node search bar.
        }

        public BranchNode(Vector2 position, DialogueEditorWindow dsWindow, DSGraphView graphView)
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
                title = "Branch";
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
                    dropdownMenu = DSBuiltInFieldsMaker.GetNewToolbarMenu("Add Condition");
                }

                void RegisterMenuDropdownAction()
                {
                    dropdownMenu.menu.AppendAction("Condition", DSToolbarMenuUtilityEditor.DSDropdownMenuAction(AddConditionModifierAction));
                }

                void AddMenuToContainer()
                {
                    titleContainer.Add(dropdownMenu);
                }
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.branchNodeStyle);
                styleSheets.Add(DSStylesConfig.dsModifiersStyle);
            }

            void AddPorts()
            {
                inputPort = AddInputPort("Input", Port.Capacity.Multi, N_NodeType.Branch);
                trueOutputPort = AddOutputPort("True", Port.Capacity.Single, N_NodeType.Branch);
                falseOutputPort = AddOutputPort("False", Port.Capacity.Single, N_NodeType.Branch);
            }
        }

        #region Dropdown Menu Action.
        void AddConditionModifierAction()
        {
            DSModifiersMaker.GetNewModifier_Condition(this, nodeData.conditionModifiers, null);
        }
        #endregion
    }
}