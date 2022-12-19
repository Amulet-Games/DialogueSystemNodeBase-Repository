using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ChannelEdgeCallbacks
    {
        /// <summary>
        /// Register different mouse related events to the edge in order to change the
        /// <br>option input's and output port's connecting style accordingly.</br>
        /// </summary>
        /// <param name="channelEdge">The channel edge of which this event is register to.</param>
        public static void Register(Edge channelEdge)
        {
            /// Placeholder references.
            OptionPort tmpOutputPort;
            OptionPort tmpInputPort;

            /// Bools for temporary saving each side's disconnected status.
            bool isOutputPortDisconnected;
            bool isInputPortDisconnected;

            Setup();

            RegisterMouseEvents();

            RegisterFocusBlurEvents();


            // ----------------------------- Setups -----------------------------
            void Setup()
            {
                /// Setups before registering any mouse events to the edge.

                UpdateTemporaryOutputRef();
                UpdateTemporaryInputRef();

                isOutputPortDisconnected = false;
                isInputPortDisconnected = false;
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
                    channelEdge.AddToClassList(StylesConfig.Channel_Option_Edge);
                }

                void RegisterFocusEvent()
                {
                    channelEdge.RegisterCallback<FocusEvent>(callback =>
                    {
                        // Add to selected style class.
                        channelEdge.AddToClassList(StylesConfig.Channel_Option_Edge_Selected);
                    });
                }

                void RegisterBlurEvent()
                {
                    channelEdge.RegisterCallback<BlurEvent>(callback =>
                    {
                        // Remove from selected style class.
                        channelEdge.RemoveFromClassList(StylesConfig.Channel_Option_Edge_Selected);
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
                    /// check its connecting status to the output port and input port
                    /// and hide the connected style if it's detached from either's port.

                    channelEdge.RegisterCallback<MouseMoveEvent>(callback =>
                    {
                        // If the edge is removed from the output port but the connected style is yet showing.
                        if (channelEdge.output == null && !isOutputPortDisconnected)
                        {
                            HideOutputConnectedStyle();
                        }
                        // else if the edge is removed from the input port but the connected style is yet showing.
                        else if (channelEdge.input == null && !isInputPortDisconnected)
                        {
                            HideInputConnectedStyle();
                        }
                    });
                }

                void RegisterMouseUpEvent()
                {
                    /// Each time the user release the mouse button while dragging the edge,
                    /// check its connecting status to the output port and input port
                    /// and hide or show the connected style accordingly.

                    channelEdge.RegisterCallback<MouseUpEvent>(callback =>
                    {
                        // If output port's connected style is hidden already and the user release the mouse button.
                        if (channelEdge.output == null && isOutputPortDisconnected)
                        {
                            HideInputConnectedStyle();
                        }
                        // else if the edge is connected to an output port but its connected style is yet hidden.
                        else if (channelEdge.output != null && isOutputPortDisconnected)
                        {
                            UpdateTemporaryOutputRef();

                            ShowOutputConnectedStyle();

                            HideOutputPreviousOpponentConnectedStyle();

                            UpdatePreviousOpponentsRef();
                        }
                        // else if input port's connected style is hidden already and the user release the mouse button.
                        else if (channelEdge.input == null && isInputPortDisconnected)
                        {
                            HideOutputConnectedStyle();
                        }
                        // else if the edge is connected to a input port but its connected style is yet hidden.
                        else if (channelEdge.input != null && isInputPortDisconnected)
                        {
                            UpdateTemporaryInputRef();

                            ShowInputConnectedStyle();

                            HideInputPreviousOpponentConnectedStyle();

                            UpdatePreviousOpponentsRef();
                        }
                    });
                }
            }


            // ----------------------------- Wrapper Methods -----------------------------
            void ShowOutputConnectedStyle()
            {
                isOutputPortDisconnected = false;

                int SiblingIndex = tmpOutputPort.GetSiblingIndexAdd(addByNumber: 1);

                OptionChannelHelper.ShowConnectedStyleOutput
                (
                    outputPort: tmpOutputPort,
                    siblingIndex: SiblingIndex
                );

                OptionChannelHelper.UpdateLabelInput
                (
                    inputPort: tmpInputPort,
                    siblingIndex: SiblingIndex
                );
            }

            void ShowInputConnectedStyle()
            {
                isInputPortDisconnected = false;

                OptionChannelHelper.ShowConnectedStyleInput
                (
                    inputPort: tmpInputPort,
                    siblingIndex: tmpOutputPort.GetSiblingIndexAdd(addByNumber: 1)
                );
            }

            void HideOutputConnectedStyle()
            {
                isOutputPortDisconnected = true;
                OptionChannelHelper.HideConnectedStyleOutput(outputPort: tmpOutputPort);
            }

            void HideInputConnectedStyle()
            {
                isInputPortDisconnected = true;
                OptionChannelHelper.HideConnectedStyleInput(inputPort: tmpInputPort);
            }

            void HideOutputPreviousOpponentConnectedStyle()
            {
                // if the output port's previous opponent port is disconnected afterward, hide it connected style.
                tmpOutputPort.HideConnectedStyleOpponent(isOutput: false);
            }

            void HideInputPreviousOpponentConnectedStyle()
            {
                // if the input port's previous opponent port is disconnected afterward, hide it connected style.
                tmpInputPort.HideConnectedStyleOpponent(isOutput: true);
            }

            void UpdateTemporaryOutputRef()
            {
                tmpOutputPort = (OptionPort)channelEdge.output;
            }

            void UpdateTemporaryInputRef()
            {
                tmpInputPort = (OptionPort)channelEdge.input;
            }

            void UpdatePreviousOpponentsRef()
            {
                tmpOutputPort.OpponentPort = tmpInputPort;
                tmpInputPort.OpponentPort = tmpOutputPort;
            }
        }
    }
}