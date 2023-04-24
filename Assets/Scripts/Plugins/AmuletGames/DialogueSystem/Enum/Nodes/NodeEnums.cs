namespace AG.DS
{
    public class NodeEnums { }

    // ----------------------------- Node Enums Base -----------------------------
    public enum N_NodeType
    {
        Boolean,
        Dialogue,
        End,
        Event,
        OptionBranch,
        OptionRoot,
        Preview,
        Start,
        Story
    }


    public enum N_ContainerType
    {
        Extension,
        Top,
        TitleButton,
        Title,
        Content
    }
}