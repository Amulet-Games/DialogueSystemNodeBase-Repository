using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class ChoiceNode : BaseNode, IConditionModifierUtility
    {
        [Header("Data")]
        public ChoiceNodeData nodeData = new ChoiceNodeData();

        [Header("Ports")]
        public Port inputPort;
        public Port outputPort;

        [Header("Visual Element Refs")]
        private Box unmetConditionDisplayOption;

        public ChoiceNode()
        {
            // GOAL: To be able to find in the node search bar.
        }

        public ChoiceNode(Vector2 position, DialogueEditorWindow dsWindow, DSGraphView graphView)
        {
            SetupRefs();

            SetupNodeDetails();

            SetupToolbarMenu_AddConditionModifier();

            SetupLanguageGroup_Textline();

            SetupOptionField_UnmetConditionDisplayOption();

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
                title = "Choice";
                SetPosition(new Rect(position, defaultNodeSize));
            }

            void SetupToolbarMenu_AddConditionModifier()
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
                    dropdownMenu.menu.AppendAction("Condition", DSToolbarMenuUtilityEditor.DSDropdownMenuAction(AddConditionModifier));
                }

                void AddMenuToContainer()
                {
                    titleContainer.Add(dropdownMenu);
                }
            }

            void SetupLanguageGroup_Textline()
            {
                Box languageTextlineBox = DSLanguageGroupsMaker.GetNewLanguageGroup_Textline(nodeData.LG_Texts_Container, nodeData.LG_AudioClips_Container);
                mainContainer.Add(languageTextlineBox);
            }

            void SetupOptionField_UnmetConditionDisplayOption()
            {
                EnumField unmetConditionDisplayOptionEnumField;
                Label unmetConditionDisplayOptionLabel;

                SetupBoxContainer();

                SetupEnumField();

                SetupLabelField();

                AddToMainContainer();

                void SetupBoxContainer()
                {
                    unmetConditionDisplayOption = new Box();
                    unmetConditionDisplayOption.AddToClassList(DSStylesConfig.unmetConditionDisplayOption_MainBox);
                }

                void SetupEnumField()
                {
                    unmetConditionDisplayOptionEnumField = DSBuiltInFieldsMaker.GetNewEnumField(nodeData.unmetConditionDisplayType_EnumContainer, DSStylesConfig.unmetConditionDisplayOption_EnumField);   
                }

                void SetupLabelField()
                {
                    unmetConditionDisplayOptionLabel = DSBuiltInFieldsMaker.GetNewLabel("Å¶ If conditions not match", DSStylesConfig.unmetConditionDisplayOption_Label);
                }

                void AddToMainContainer()
                {
                    unmetConditionDisplayOption.Add(unmetConditionDisplayOptionEnumField);
                    unmetConditionDisplayOption.Add(unmetConditionDisplayOptionLabel);

                    mainContainer.Add(unmetConditionDisplayOption);
                }
            }

            void AddStyleSheet()
            {
                styleSheets.Add(DSStylesConfig.choiceNodeStyle);
                styleSheets.Add(DSStylesConfig.dsModifiersStyle);
            }

            void AddPorts()
            {
                inputPort = AddInputPort("Input", Port.Capacity.Multi, N_NodeType.Choice);
                outputPort = AddOutputPort("Output", Port.Capacity.Single, N_NodeType.Choice);
            }
        }

        #region Overrides.
        public override void ReloadLanguage()
        {
            // INHERIT: Base Node Class
            // GOAL: Overrides to implement this class's own reload language behaviour.

            nodeData.LG_Texts_Container.ReloadLanguage();
            nodeData.LG_AudioClips_Container.ReloadLanguage();
        }
        #endregion

        #region Dropdown Menu Action.
        void AddConditionModifier()
        {
            DSModifiersMaker.GetNewModifier_Condition(this, null);
            DSFieldUtilityEditor.ShowElement(unmetConditionDisplayOption);
        }
        #endregion

        #region IConditionModifierUtility.
        public void ToggleUnmetConditionDisplayOptionVisible()
        {
            DSFieldUtilityEditor.ToggleElementDisplay(nodeData.conditionModifiers.Count < 1, unmetConditionDisplayOption);
        }

        public void AddModifierToData(ConditionModifier conditionModifier)
        {
            nodeData.conditionModifiers.Add(conditionModifier);
            nodeData.all.Add(conditionModifier);
        }

        public void RemoveModifierFromData(ConditionModifier conditionModifier)
        {
            nodeData.conditionModifiers.Remove(conditionModifier);
            nodeData.all.Remove(conditionModifier);
        }
        #endregion
    }
}