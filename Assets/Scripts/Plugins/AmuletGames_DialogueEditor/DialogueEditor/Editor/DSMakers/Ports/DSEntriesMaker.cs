using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSEntriesMaker
    {
        /// <summary>
        /// Create all the UIElements that are needed in this choice entry.
        /// </summary>
        /// <param name="node">Node of which this entry is created for.</param>
        /// <param name="source">The another choice entry that has the values to this new entry to load from if it's provided.</param>
        /// <param name="choiceEntryRemovedAction">Action that will invoked when this entry is deleted from the node.</param>
        /// <param name="choiceEntryList">The list that this entry'll be added to once it's created.</param>
        public static void GetNewChoiceEntry
            (DSNodeBase node, ChoiceEntry source, Action<Port> choiceEntryRemovedAction, List<ChoiceEntry> choiceEntryList)
        {
            ChoiceEntry newChoiceEntry;

            Port newEntryPort;

            Button entryRemoveButton;

            CreateChoiceEntry();

            GetNewChoiceEntryPort();

            SetupEntryRemoveButton();

            CheckSourceValues();

            AddElementsToEntry();

            AddEntryToModelList();

            void CreateChoiceEntry()
            {
                newChoiceEntry = new ChoiceEntry(Guid.NewGuid().ToString(), node.NodeGuid);
            }

            void GetNewChoiceEntryPort()
            {
                newEntryPort = 
                    AddEntryPort
                    (
                        node,
                        source != null ? source.PortGuid : newChoiceEntry.PortGuid,
                        Port.Capacity.Single,
                        N_NodeType.Choice
                    );
            }

            void SetupEntryRemoveButton()
            {
                entryRemoveButton = AddEntryRemoveButton(ChoiceEntryRemovedAction);
            }

            void CheckSourceValues()
            {
                if (source != null)
                {
                    newChoiceEntry.LoadEntryValue(source);
                }
            }

            void AddElementsToEntry()
            {
                newEntryPort.contentContainer.Add(entryRemoveButton);
            }

            void AddEntryToModelList()
            {
                choiceEntryList.Add(newChoiceEntry);
            }

            void ChoiceEntryRemovedAction()
            {
                choiceEntryRemovedAction.Invoke(newEntryPort);
            }
        }


        /// <summary>
        /// Create a new entry's output port.
        /// </summary>
        /// <param name="node">Node of which this port is created for.</param>
        /// <param name="portName">The name of this port, it comes in handy when save and load the entry later.</param>
        /// <param name="capacity">The type determines how many edges a port can have for connection.</param>
        /// <param name="nodeType">The type of the node in which the connecting entry is created for.</param>
        /// <returns>A entry port for connecting the node within to the other certain kind of node or nodes if capacity is set to multiple.</returns>
        static Port AddEntryPort(DSNodeBase node, string portName, Port.Capacity capacity, N_NodeType nodeType)
        {
            Port newEntryPort;

            CreatePortInstance();

            SetupPortDetail();

            AddPortToContainer();

            return newEntryPort;

            void CreatePortInstance()
            {
                newEntryPort = node.InstantiatePort(Orientation.Horizontal, Direction.Output, capacity, typeof(float));
            }

            void SetupPortDetail()
            {
                newEntryPort.name = portName;
                newEntryPort.portName = "";
                newEntryPort.portColor = DSPortsUtility.GetPortColorByNodeType(nodeType);
            }

            void AddPortToContainer()
            {
                node.outputContainer.Add(newEntryPort);
            }
        }


        /// <summary>
        /// Create a new entry's remove button within entry.
        /// </summary>
        /// <param name="EntryRemovedAction">The action to invoke when remove button is pressed.</param>
        /// <returns>Button that is use to remove the entry that it's connecting to.</returns>
        static Button AddEntryRemoveButton(Action EntryRemovedAction)
        {
            return DSButtonsMaker.GetNewButton(DSAssetsConfig.removeModifierButtonIconImage, EntryRemovedAction, DSStylesConfig.entry_RemoveModifier_Button);
        }
    }
}