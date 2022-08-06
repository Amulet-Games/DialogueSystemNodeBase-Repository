using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    public class NodeEnum { }

    #region Commons.
    public enum N_NodeType
    {
        Start,                          // Green            Color(0.141f, 0.541f, 0.271f)
        Dialogue,                       // Orange           Color(1f, 0.388f, 0.204f)
        Choice,                         // Blue             Color(0.235f, 0.69f, 0.973f)
        Event,                          // Purple           Color(0.635f, 0.0784f, 0.424f)
        Branch,                         // Yellow           Color(1f, 0.651f, 0f)
        End                             // River Green      Color(0.286f, 0.380f, 0.357f)
    }

    public enum N_NodeContainerType
    {
        Extension,
        Top,
        TitleButton,
        Title,
        Main
    }

    public enum N_PortContainerType
    {
        Output,
        Input
    }
    #endregion

    #region End Node.
    public enum N_End_DialogueOverHandleType
    {
        End = 1,
        Repeat = 2,
        ReturnToStart = 3
    }
    #endregion

    #region Modifiers.
    public enum N_Modifier_ConditionDisplayType
    {
        ShowAll = 1,
        ShowMatched = 2,
        GrayOutUnmatched = 3
    }

    public enum N_Modifier_ConditionComparisonType
    {
        True = 1,
        False = 2,
        Equals = 3,
        EqualsOrBigger = 4,
        EqualsOrSmaller = 5,
        Bigger = 6,
        Smaller = 7
    }

    public enum N_Modifier_BasicEventType
    {
        Add = 1,
        Subtract = 2,
        SetTrue = 3,
        SetFalse = 4
    }
    #endregion
}