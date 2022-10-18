using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSChannelEdgeCallbacks
    {
        /// <summary>
        /// Register different mouse related events to the edge in order to change the
        /// <br>option entry's and track port's connecting style accordingly.</br>
        /// </summary>
        /// <param name="channelEdge">The channel edge of which this event is register to.</param>
        public static void Register(Edge channelEdge)
        {
            /// Placeholder references.
            DSOptionPort tmpEntryPort;
            DSOptionPort tmpTrackPort;

            /// Bools for temporary saving each side's disconnected status.
            bool isEntryPortDisconnected;
            bool isTrackPortDisconnected;

            Setup();

            RegisterMouseEvents();

            RegisterFocusBlurEvents();


            // ----------------------------- Setups -----------------------------
            void Setup()
            {
                /// Setups before registering any mouse events to the edge.

                UpdateTemporaryEntryRef();
                UpdateTemporaryTrackRef();

                isEntryPortDisconnected = false;
                isTrackPortDisconnected = false;
            }


            // ----------------------------- Focus / Blur Events -----------------------------
            void RegisterFocusBlurEvents()
            {
                SetAllowsFocus();

                AddDefaultEdgeStyle();

                RegisterFocusEvent();

                RegisterBlurEvent();

                void SetAllowsFocus()
                {
                    // Set its focusable property to true so that it can register to FocusEvent.
                    channelEdge.focusable = true;
                }

                void AddDefaultEdgeStyle()
                {
                    // Add to the channel edge style class.
                    channelEdge.AddToClassList(DSStylesConfig.Channel_Option_Edge);
                }

                void RegisterFocusEvent()
                {
                    channelEdge.RegisterCallback<FocusEvent>(_ =>
                    {
                        // Add to selected style class.
                        channelEdge.AddToClassList(DSStylesConfig.Channel_Option_Edge_Selected);
                    });
                }

                void RegisterBlurEvent()
                {
                    channelEdge.RegisterCallback<BlurEvent>(_ =>
                    {
                        // Remove from selected style class.
                        channelEdge.RemoveFromClassList(DSStylesConfig.Channel_Option_Edge_Selected);
                    });
                }
            }


            // ----------------------------- Mouse Events -----------------------------
            void RegisterMouseEvents()
            {
                RegisterMouseMoveEvent();

                RegisterMouseUpEvent();

                void RegisterMouseMoveEvent()
                {
                    /// Each time the edge is moved by mouse,
                    /// check its connecting status to the entry port and track port
                    /// and hide the connected style if it's detached from either's port.

                    channelEdge.RegisterCallback<MouseMoveEvent>(_ =>
                    {
                        // If edge is removed from the entry port but the connected style is yet showing.
                        if (channelEdge.output == null && !isEntryPortDisconnected)
                        {
                            HideEntryConnectedStyle();
                        }
                        // else if edge is removed from the track port but the connected style is yet showing.
                        else if (channelEdge.input == null && !isTrackPortDisconnected)
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

                    channelEdge.RegisterCallback<MouseUpEvent>(_ =>
                    {
                        // If entry port's connected style is hidden already and the user release the mouse button.
                        if (channelEdge.output == null && isEntryPortDisconnected)
                        {
                            HideTrackConnectedStyle();
                        }
                        // else if the edge is connected to an entry port but its connected style is yet hidden.
                        else if (channelEdge.output != null && isEntryPortDisconnected)
                        {
                            UpdateTemporaryEntryRef();

                            ShowEntryConnectedStyle();

                            HideEntryPreviousOpponentConnectedStyle();

                            UpdatePreviousOpponentsRef();
                        }
                        // else if track port's connected style is hidden already and the user release the mouse button.
                        else if (channelEdge.input == null && isTrackPortDisconnected)
                        {
                            HideEntryConnectedStyle();
                        }
                        // else if the edge is connected to a track port but its connected style is yet hidden.
                        else if (channelEdge.input != null && isTrackPortDisconnected)
                        {
                            UpdateTemporaryTrackRef();

                            ShowTrackConnectedStyle();

                            HideTrackPreviousOpponentConnectedStyle();

                            UpdatePreviousOpponentsRef();
                        }
                    });
                }
            }


            // ----------------------------- Wrapper Methods -----------------------------
            void ShowEntryConnectedStyle()
            {
                isEntryPortDisconnected = false;

                int SiblingIndex = tmpEntryPort.GetSiblingIndexAdd(1);
                DSOptionChannelUtility.ShowEntryConnectedStyle(tmpEntryPort, SiblingIndex);
                DSOptionChannelUtility.UpdateTrackPortLabel(tmpTrackPort, SiblingIndex);
            }

            void ShowTrackConnectedStyle()
            {
                isTrackPortDisconnected = false;
                DSOptionChannelUtility.ShowTrackConnectedStyle(tmpTrackPort, tmpEntryPort.GetSiblingIndexAdd(1));
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
                tmpEntryPort.HideOpponentConnectedStyle(false);
            }

            void HideTrackPreviousOpponentConnectedStyle()
            {
                // if the track port's previous opponent port is disconnected afterward, hide it connected style.
                tmpTrackPort.HideOpponentConnectedStyle(true);
            }

            void UpdateTemporaryEntryRef()
            {
                tmpEntryPort = (DSOptionPort)channelEdge.output;
            }

            void UpdateTemporaryTrackRef()
            {
                tmpTrackPort = (DSOptionPort)channelEdge.input;
            }

            void UpdatePreviousOpponentsRef()
            {
                tmpEntryPort.PreviousOpponentPort = tmpTrackPort;
                tmpTrackPort.PreviousOpponentPort = tmpEntryPort;
            }
        }
    }
}