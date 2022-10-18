using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public static class DSOptionChannelUtility
    {
        // ----------------------------- Set Connected Style Services -----------------------------
        /// <summary>
        /// Add the connected style to both entry and track port. And update their port label.
        /// </summary>
        /// <param name="optionChannelEdge">The edge that was created during the OnDrop Listener.</param>
        public static void ShowBothConnectedStyle(Edge optionChannelEdge)
        {
            Port entryPort = optionChannelEdge.output;
            Port trackPort = optionChannelEdge.input;
            string siblingIndexText = entryPort.GetSiblingIndexAdd(1).ToString();

            // Entry
            entryPort.portName = DSStringUtility.New(DSStringsConfig.OptionChannelEntryLabelText, siblingIndexText).ToString();
            entryPort.AddToClassList(DSStylesConfig.Channel_Option_Entry_Port_Connected);

            // Track
            trackPort.portName = DSStringUtility.New(DSStringsConfig.OptionChannelTrackLabelText, siblingIndexText).ToString();
            trackPort.AddToClassList(DSStylesConfig.Channel_Option_Track_Port_Connected);
        }


        /// <summary>
        /// Add the connected style to option's track port. And update its port label.
        /// </summary>
        /// <param name="trackPort">The target track port to add the connected style to.</param>
        /// <param name="siblingIndex">The index to set for the track port's label to show which entry is it connected from.</param>
        public static void ShowTrackConnectedStyle(Port trackPort, int siblingIndex)
        {
            trackPort.portName = DSStringUtility.New(DSStringsConfig.OptionChannelTrackLabelText, siblingIndex.ToString()).ToString();
            trackPort.AddToClassList(DSStylesConfig.Channel_Option_Track_Port_Connected);
        }


        /// <summary>
        /// Add the connected style to option's entry port. And update its port label.
        /// </summary>
        /// <param name="entryPort">The target entry port to add the connected style to.</param>
        /// <param name="siblingIndex">The index to set for the entry port's label to show which entry is it connected from.</param>
        public static void ShowEntryConnectedStyle(Port entryPort, int siblingIndex)
        {
            entryPort.portName = DSStringUtility.New(DSStringsConfig.OptionChannelEntryLabelText, siblingIndex.ToString()).ToString();
            entryPort.AddToClassList(DSStylesConfig.Channel_Option_Entry_Port_Connected);
        }


        /// <summary>
        /// Add the connected style to option's track port
        /// </summary>
        /// <param name="trackPort">The target track port to add the connected style to.</param>
        public static void AddToTrackConnectedClass(Port trackPort)
        {
            trackPort.AddToClassList(DSStylesConfig.Channel_Option_Track_Port_Connected);
        }


        /// <summary>
        /// Add the connected style to option's entry port.
        /// </summary>
        /// <param name="entryPort">The target entry port to add the connected style to.</param>
        public static void AddToEntryConnectedClass(Port entryPort)
        {
            entryPort.AddToClassList(DSStylesConfig.Channel_Option_Entry_Port_Connected);
        }


        /// <summary>
        /// Update the option track port's label to follow the new specificed sibling index.
        /// </summary>
        /// <param name="trackPort">The track port of which the label to change is belong to.</param>
        /// <param name="siblingIndex">The index to set for the track port's label to show which entry is it connected from.</param>
        public static void UpdateTrackPortLabel(Port trackPort, int siblingIndex)
        {
            trackPort.portName = DSStringUtility.New(DSStringsConfig.OptionChannelTrackLabelText, siblingIndex.ToString()).ToString();
        }


        /// <summary>
        /// Update the option entry port's label to follow it's new sibling index.
        /// </summary>
        /// <param name="entryPort">The entry port of which the label to change is belong to.</param>
        /// <param name="siblingIndex">The index to set for the entry port's label to show which entry is it connected from.</param>
        public static void UpdateEntryPortLabel(Port entryPort, int siblingIndex)
        {
            entryPort.portName = DSStringUtility.New(DSStringsConfig.OptionChannelEntryLabelText, siblingIndex.ToString()).ToString();
        }


        /// <summary>
        /// Remove the connected style to both entry and track port. And reset their port labels.
        /// </summary>
        /// <param name="trackPort">The track port to remove the connected style from.</param>
        /// <param name="entryPort">The entry port to remove the connected style from.</param>
        public static void HideBothConnectedStyle(Port trackPort, Port entryPort)
        {
            trackPort.portName = DSStringsConfig.OptionChannelEmptyTrackLabelText;
            trackPort.RemoveFromClassList(DSStylesConfig.Channel_Option_Track_Port_Connected);

            entryPort.portName = DSStringsConfig.OptionChannelEmptyEntryLabelText;
            entryPort.RemoveFromClassList(DSStylesConfig.Channel_Option_Entry_Port_Connected);
        }


        /// <summary>
        /// Remove the connected style from option's track port. And reset its port label to input.
        /// </summary>
        /// <param name="trackPort">The track port to remove the connected style from.</param>
        public static void HideTrackConnectedStyle(Port trackPort)
        {
            trackPort.portName = DSStringsConfig.OptionChannelEmptyTrackLabelText;
            trackPort.RemoveFromClassList(DSStylesConfig.Channel_Option_Track_Port_Connected);
        }


        /// <summary>
        /// Remove the connected style from option's entry port. And reset its port label to empty.
        /// </summary>
        /// <param name="entryPort">The entry port to remove the connected style from.</param>
        public static void HideEntryConnectedStyle(Port entryPort)
        {
            entryPort.portName = DSStringsConfig.OptionChannelEmptyEntryLabelText;
            entryPort.RemoveFromClassList(DSStylesConfig.Channel_Option_Entry_Port_Connected);
        }
    }
}