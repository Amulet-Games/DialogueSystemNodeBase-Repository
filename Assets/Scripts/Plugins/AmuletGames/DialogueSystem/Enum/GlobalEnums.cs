namespace AG.DS
{
    public class GlobalEnums { }

    // ----------------------------- Global Enums -----------------------------
    public enum LanguageType
    {
        English = 0,
        German = 1,
        Danish = 2,
        Spanish = 3,
        Japanese = 4,
        Latin = 5
    }


    // ----------------------------- Variable Enums -----------------------------
    public enum VariableType
    {
        Boolean,
        Float,
        String
    }


    // ----------------------------- Reflection Field Enums -----------------------------
    public enum ReflectionFieldType
    {
        Public,
        Private,
        Instance,
        Static,
        
        Public_Private,
        Public_Instance,
        Public_Static,

        Public_Private_Instance,
        Public_Private_Static,
        Public_Private_Instance_Static,

        Public_Instance_Static,
        
        Private_Instance,
        Private_Static,

        Private_Instance_Static,

        Instance_Static,
    }

    // ----------------------------- Reflection Data Enums -----------------------------
    public enum ReflectionDataType
    {
        None,
        Float,
        Double,
        Integer,
        String
    }
}