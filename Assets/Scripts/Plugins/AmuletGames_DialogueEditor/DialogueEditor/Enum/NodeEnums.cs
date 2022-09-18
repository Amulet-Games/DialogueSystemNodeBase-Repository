namespace AG
{
    public class NodeEnums { }

    // ----------------------------- Common Types -----------------------------
    public enum N_NodeType
    {
        Start,
        Dialogue,
        Option,
        Event,
        Branch,
        End
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


    public enum N_NodeCreationConnectorType
    {
        Default,
        OptionChannel
    }


    // ----------------------------- End Nodes -----------------------------
    public enum N_End_DialogueOverHandleType
    {
        End = 1,
        Repeat = 2,
        ReturnToStart = 3
    }


    // ----------------------------- Modifiers -----------------------------
    public enum N_Modifier_ConditionDisplayType
    {
        Hide = 1,
        GrayOut = 2
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
}