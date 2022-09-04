using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSChannelEdgeEventRegister
    {
        /// <summary>
        /// Register different mouse related events to the edge in order to change its connecting
        /// <br>option entry's and track port's style accordingly.</br>
        /// </summary>
        /// <param name="optionChannelEdge">The edge of which this event is register to.</param>
        public static void RegisterMouseEvents(Edge optionChannelEdge)
        {
            /// Placeholder references.
            DSOptionPort tmpEntryPort;
            DSOptionPort tmpTrackPort;

            /// Bools for temporary saving each side's disconnected status.
            bool isEntryPortDisconnected;
            bool isTrackPortDisconnected;

            Setup();

            RegisterMouseMoveEvent();

            RegisterMouseUpEvent();

            void Setup()
            {
                /// Setups before registering any mouse events to the edge.

                UpdateTemporaryEntryRef();
                UpdateTemporaryTrackRef();

                isEntryPortDisconnected = false;
                isTrackPortDisconnected = false;
            }

            void RegisterMouseMoveEvent()
            {
                /// Each time the edge is moved by mouse,
                /// check its connecting status to the entry port and track port
                /// and hide the connected style if it's detached from either's port.

                optionChannelEdge.RegisterCallback<MouseMoveEvent>(_ =>
                {
                    // If edge is removed from the entry port but the connected style is yet showing.
                    if (optionChannelEdge.output == null && !isEntryPortDisconnected)
                    {
                        HideEntryConnectedStyle();
                    }
                    // else if edge is removed from the track port but the connected style is yet showing.
                    else if (optionChannelEdge.input == null && !isTrackPortDisconnected)
                    {
                        HideTrackConnectedStyle();
                    }
                });
            }

            void RegisterMouseUpEvent()
            {
                /// Each time the user release the mouse button while dragging the edge,
                /// check its connecting status to the entry port and track port
                /// and hide or show the connected style accordingly.
                
                optionChannelEdge.RegisterCallback<MouseUpEvent>(_ =>
                {
                    // If entry port's connected style is hidden already and the user release the mouse button.
                    if (optionChannelEdge.output == null && isEntryPortDisconnected)
                    {
                        HideTrackConnectedStyle();
                    }
                    // else if the edge is connected to an entry port but its connected style is yet hidden.
                    else if (optionChannelEdge.output != null && isEntryPortDisconnected)
                    {
                        UpdateTemporaryEntryRef();

                        ShowEntryConnectedStyle();

                        HideEntryPreviousOpponentConnectedStyle();

                        UpdatePreviousOpponentsRef();
                    }
                    // else if track port's connected style is hidden already and the user release the mouse button.
                    else if (optionChannelEdge.input == null && isTrackPortDisconnected)
                    {
                        HideEntryConnectedStyle();
                    }
                    // else if the edge is connected to a track port but its connected style is yet hidden.
                    else if (optionChannelEdge.input != null && isTrackPortDisconnected)
                    {
                        UpdateTemporaryTrackRef();

                        ShowTrackConnectedStyle();

                        HideTrackPreviousOpponentConnectedStyle();

                        UpdatePreviousOpponentsRef();
                    }
                });
            }


            // ----------------------------- Wrapper Methods -----------------------------
            void ShowEntryConnectedStyle()
            {
                isEntryPortDisconnected = false;

                int SiblingIndex = tmpEntryPort.GetSiblingIndex();
                DSOptionChannelUtility.ShowEntryConnectedStyle(tmpEntryPort, SiblingIndex);
                DSOptionChannelUtility.UpdateTrackPortLabel(tmpTrackPort, SiblingIndex);
            }

            void ShowTrackConnectedStyle()
            {
                isTrackPortDisconnected = false;
                DSOptionChannelUtility.ShowTrackConnectedStyle(tmpTrackPort, tmpEntryPort.GetSiblingIndex());
            }

            void HideEntryConnectedStyle()
            {
                isEntryPortDisconnected = true;
                DSOptionChannelUtility.HideEntryConnectedStyle(tmpEntryPort);
            }

            void HideTrackConnectedStyle()
            {
                isTrackPortDisconnected = true;
                DSOptionChannelUtility.HideTrackConnectedStyle(tmpTrackPort);
            }

            void HideEntryPreviousOpponentConnectedStyle()
            {
                // if the entry port's previous opponent port is disconnected afterward, hide it connected style.
                tmpEntryPort.CheckOpponentConnectedStyle(false);
            }

            void HideTrackPreviousOpponentConnectedStyle()
            {
                // if the track port's previous opponent port is disconnected afterward, hide it connected style.
                tmpTrackPort.CheckOpponentConnectedStyle(true);
            }

            void UpdateTemporaryEntryRef()
            {
                tmpEntryPort = (DSOptionPort)optionChannelEdge.output;
            }

            void UpdateTemporaryTrackRef()
            {
                tmpTrackPort = (DSOptionPort)optionChannelEdge.input;
            }

            void UpdatePreviousOpponentsRef()
            {
                tmpEntryPort.PreviousOpponentPort = tmpTrackPort;
                tmpTrackPort.PreviousOpponentPort = tmpEntryPort;
            }
        }
    }
}