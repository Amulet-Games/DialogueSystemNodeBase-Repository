using System;

namespace AG.DS
{
    public class StyleConfig
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static StyleConfig Instance { get; private set; } = null;

        #region Global USS Classes.
        public string Global_Display_None = "global_Display_None";
        public string Global_Visible_Hidden = "global_Visible_Hidden";
        public string Global_Interactable_Disable = "global_Picking_Ignore";
        #endregion

        #region Global Toolbar Menu USS Classes.
        public string Global_ToolbarMenu = "global_toolbarMenu";
        public string Global_ToolbarMenu_TextLabel = "global_ToolbarMenu_TextLabel";
        public string Global_ToolbarMenu_ArrowImage = "global_ToolbarMenu_ArrowImage";
        #endregion

        #region Headbar USS Classes.
        public string Headbar_Main = "headbar_Main";
        public string Headbar_ButtonContainer = "headbar_ButtonContainer";
        public string Headbar_SaveButton = "headbar_SaveButton";
        public string Headbar_LoadButton = "headbar_LoadButton";
        public string Headbar_GraphTitleTextField = "headbar_GraphTitleTextField";
        #endregion

        #region Input Hint USS Classes.
        public string InputHint_Main = "inputHint_Main";
        public string InputHint_IconImage = "inputHint_IconImage";
        public string InputHint_TextLabel = "inputHint_TextLabel";
        #endregion

        #region Modifier Event USS Classes.
        public readonly string EventModifier_HelperButton_Container = "eventModifier_HelperButton_Container";
        public readonly string EventModifier_MoveUp_Button = "eventModifier_MoveUp_Button";
        public readonly string EventModifier_MoveDown_Button = "eventModifier_MoveDown_Button";
        public readonly string EventModifier_Rename_Button = "eventModifier_Rename_Button";
        public readonly string EventModifier_Remove_Button = "eventModifier_Remove_Button";
        public readonly string EventModifier_DialogueEvent_Container = "eventModifier_DialogueEvent_Container";
        public readonly string EventModifier_DialogueEvent_Label = "eventModifier_DialogueEvent_Label";
        public readonly string EventModifier_DialogueEvent_ObjectField = "eventModifier_DialogueEvent_ObjectField";
        public readonly string EventModifier_StartDelay_Container = "eventModifier_StartDelay_Container";
        public readonly string EventModifier_StartDelay_Label = "eventModifier_StartDelay_Label";
        public readonly string EventModifier_DelaySeconds_Container = "eventModifier_DelaySeconds_Container";
        public readonly string EventModifier_DelaySeconds_IntegerField = "eventModifier_DelaySeconds_IntegerField";
        public readonly string EventModifier_DelaySeconds_Label = "eventModifier_DelaySeconds_Label";

        /*< -------------------- Group -------------------- >*/
        public readonly string EventModifierGroup_MainContainer = "eventModifierGroup_MainContainer";
        #endregion

        #region Modifier Condition USS Classes.
        public string Modifier_Condition_Main_Box = "modifier_Condition_Main_Box";
        public string Modifier_Condition_FirstTerm_ObjectField = "modifier_Condition_FirstTerm_ObjectField";

        public string Modifier_Condition_Operator_EnumField = "modifier_Condition_Operator_EnumField";
        public string Modifier_Condition_Operator_Icon = "modifier_Condition_Operator_Icon";

        public string Modifier_Condition_SecondTerm_TextField = "modifier_Condition_SecondTerm_TextField";
        public string Modifier_Condition_SecondTerm_FloatField = "modifier_Condition_SecondTerm_FloatField";
        public string Modifier_Condition_SecondTerm_ObjectField = "modifier_Condition_SecondTerm_ObjectField";

        public string Modifier_Condition_Button_Box = "modifier_Condition_Button_Box";
        public string Modifier_Condition_ChangeFieldType_Button = "modifier_Condition_ChangeFieldType_Button";
        public string Modifier_Condition_Remove_Button = "modifier_Condition_Remove_Button";

        /*< -------------------- Root -------------------- >*/
        public string Modifier_Condition_Rooted_Main_Box = "modifier_Condition_Rooted_Main_Box";
        public string Modifier_Condition_Rooted_FirstTerm_ObjectField = "modifier_Condition_Rooted_FirstTerm_ObjectField";

        public string Modifier_Condition_Rooted_Operator_EnumField = "modifier_Condition_Rooted_Operator_EnumField";
        public string Modifier_Condition_Rooted_Operator_Icon = "modifier_Condition_Rooted_Operator_Icon";

        public string Modifier_Condition_Rooted_SecondTerm_TextField = "modifier_Condition_Rooted_SecondTerm_TextField";
        public string Modifier_Condition_Rooted_SecondTerm_FloatField = "modifier_Condition_Rooted_SecondTerm_FloatField";
        public string Modifier_Condition_Rooted_SecondTerm_ObjectField = "modifier_Condition_Rooted_SecondTerm_ObjectField";

        public string Modifier_Condition_Rooted_Button_Box = "modifier_Condition_Rooted_Button_Box";
        public string Modifier_Condition_Rooted_ChangeFieldType_Button = "modifier_Condition_Rooted_ChangeFieldType_Button";
        #endregion

        #region Modifier Message USS Classes.
        public string Modifier_Message_Button_Container = "modifier_Message_Button_Container";
        public string Modifier_Message_MoveUp_Button = "modifier_Message_MoveUp_Button";
        public string Modifier_Message_MoveDown_Button = "modifier_Message_MoveDown_Button";
        public string Modifier_Message_Rename_Button = "modifier_Message_Rename_Button";
        public string Modifier_Message_Remove_Button = "modifier_Message_Remove_Button";
        public string Modifier_Message_Text_TextField = "modifier_Message_Text_TextField";
        public string Modifier_Message_Audio_ObjectField = "modifier_Message_Audio_ObjectField";
        public string Modifier_Message_ProgressType_Box = "modifier_Message_ProgressType_Box";
        public string Modifier_Message_ProgressType_Label = "modifier_Message_ProgressType_Label";
        public string Modifier_Message_ProgressType_EnumField = "modifier_Message_ProgressType_EnumField";
        #endregion

        #region Segment Common USS Classes.
        public string Segment_Common_Main_Box = "segment_Common_Main_Box";
        public string Segment_Common_Title_Box = "segment_Common_Title_Box";
        public string Segment_Common_Title_Label = "segment_Common_Title_Label";
        public string Segment_Common_Title_Button_Box = "segment_Common_Title_Button_Box";
        public string Segment_Common_ExpandSegment_Button = "segment_Common_ExpandSegment_Button";
        #endregion

        #region Segment Dialogue USS Classes.
        public string Segment_Dialogue_Title_Box = "segment_Dialogue_Title_Box";
        public string Segment_Dialogue_Content_Box = "segment_Dialogue_Content_Box";
        public string Segment_Dialogue_Character_ObjectField = "segment_Dialogue_Character_ObjectField";
        public string Segment_Dialogue_First_Textline_TextField = "segment_Dialogue_First_Textline_TextField";
        public string Segment_Dialogue_AudioClip_ObjectField = "segment_Dialogue_AudioClip_ObjectField";

        public string Segment_Dialogue_SecondContent_Box = "segment_Dialogue_SecondContent_Box";

        public string Segment_Dialogue_SecondLineTriggerType_Box = "segment_Dialogue_SecondLineTriggerType_Box";
        public string Segment_Dialogue_SecondLineTriggerType_Label = "segment_Dialogue_SecondLineTriggerType_Label";
        public string Segment_Dialogue_SecondLineTriggerType_EnumField = "segment_Dialogue_SecondLineTriggerType_EnumField";

        public string Segment_Dialogue_Duration_Box = "segment_Dialogue_Duration_Box";
        public string Segment_Dialogue_Duration_Label = "segment_Dialogue_Duration_Label";
        public string Segment_Dialogue_Duration_FloatField = "segment_Dialogue_Duration_FloatField";

        public string Segment_Dialogue_Second_Textline_TextField = "segment_Dialogue_Second_Textline_TextField";
        #endregion

        #region Segment Condition USS Classes.
        public string Segment_Condition_Title_Box = "segment_Condition_Title_Box";
        public string Segment_Condition_UnmetOptionDisplayType_EnumField = "segment_Condition_UnmetOptionDisplayType_EnumField";
        public string Segment_Condition_Content_Box = "segment_Condition_Content_Box";
        #endregion

        #region Segment Event USS Classes.
        public string Segment_Event_Title_Box = "segment_Event_Title_Box";
        public string Segment_Event_Content_Box = "segment_Event_Content_Box";
        #endregion

        #region Folder Common USS Classes.
        public readonly string Folder_MainContainer = "folder_MainContainer";
        public readonly string Folder_Title_Container = "folder_Title_Container";
        public readonly string Folder_ExpandFolder_Button = "folder_ExpandFolder_Button";
        public readonly string Folder_Title_TextField = "folder_Title_TextField";
        public readonly string Folder_ContentContainer = "folder_ContentContainer";
        public readonly string Folder_Expanded = "folder_Expanded";
        #endregion

        #region Content Button USS Classes.
        public readonly string ContentButton_Main = "contentButton_Main";
        public readonly string ContentButton_Title_Label = "contentButton_Title_Label";
        public readonly string ContentButton_Icon_Image = "contentButton_Icon_Image";
        #endregion

        #region Field Common USS Classes.
        public string TextField_Empty = "textField_Empty";
        public string ObjectField_Empty = "objectField_Empty";
        public string FloatField_Empty = "floatField_Empty";
        #endregion

        #region Field Icon USS Classes.
        public string ObjectField_Icon = "objectField_Icon";
        public string TextField_Icon = "textField_Icon";
        public string FloatField_Icon = "floatField_Icon";
        #endregion

        #region Node Common USS Classes.
        /*< -------------------- Border -------------------- >*/
        public readonly string Node_Border = "node_Border";
        public readonly string Node_Border_Hover = "node_Border_Hover";

        /*< -------------------- Node Title -------------------- >*/
        public readonly string Node_Title_Container = "node_Title_Container";
        public readonly string Node_Title_TextField = "node_Title_TextField";
        public readonly string Node_EditTitle_Button = "node_EditTitle_Button";

        /*< -------------------- Input / Ouput Container -------------------- >*/
        public readonly string Node_Input_Container = "node_Input_Container";
        public readonly string Node_Output_Container = "node_Output_Container";

        /*< -------------------- Content Container -------------------- >*/
        public readonly string Node_Content_Container = "node_Content_Container";
        #endregion

        #region Node Dialogue USS Classes.
        public string DialogueNode_Character_ObjectField = "dialogueNode_Character_ObjectField";
        public string MessageModifierGroup_Content_Container = "dialogueNode_Stitcher_Modifiers_Box";
        #endregion

        #region Node Option Branch USS Classes.
        public readonly string OptionBranchGroup_MainContainer = "optionBranchGroup_MainContainer";
        public readonly string OptionBranchGroup_OuterContainer = "optionBranchGroup_OuterContainer";
        public readonly string OptionBranchGroup_Icon_Image = "optionBranchGroup_Icon_Image";
        public readonly string OptionBranchGroup_InnerContainer = "optionBranchGroup_InnerContainer";
        public readonly string OptionBranchGroup_Title_Label = "optionBranchGroup_Title_Label";
        public readonly string OptionBranchGroup_Title_TextField = "optionBranchGroup_Title_TextField";
        #endregion

        #region Node Option Root USS Classes.
        public readonly string OptionRootGroup_MainContainer = "optionRootGroup_MainContainer";
        public readonly string OptionRootGroup_OuterContainer = "optionRootGroup_OuterContainer";
        public readonly string OptionRootGroup_Icon_Image = "optionRootGroup_Icon_Image";
        public readonly string OptionRootGroup_InnerContainer = "optionRootGroup_InnerContainer";
        public readonly string OptionRootGroup_Title_Label = "optionRootGroup_Title_Label";
        public readonly string OptionRootGroup_Title_TextField = "optionRootGroup_Title_TextField";
        #endregion

        #region Node Preview USS Classes.
        public string PreviewNode_PreviewImage_Box = "previewNode_PreviewImage_Box";
        public string PreviewNode_PreviewImage_Image = "previewNode_PreviewImage_Image";
        public string PreviewNode_PreviewImage_Image_L = "previewNode_PreviewImage_Image_L";
        public string PreviewNode_PreviewImage_Image_R = "previewNode_PreviewImage_Image_R";

        public string PreviewNode_PreviewSprite_Box = "previewNode_PreviewSprite_Box";
        public string PreviewNode_PreviewSprite_ObjectField = "previewNode_PreviewSprite_ObjectField";
        public string PreviewNode_PreviewSprite_ObjectField_L = "previewNode_PreviewSprite_ObjectField_L";
        public string PreviewNode_PreviewSprite_ObjectField_R = "previewNode_PreviewSprite_ObjectField_R";
        public string PreviewNode_MiddleEmpty_Box = "previewNode_MiddleEmpty_Box";
        #endregion

        #region Node Story USS Classes.
        public string StoryNode_PreferenceImage_Image = "storyNode_PreferenceImage_Image";
        #endregion

        #region Port Default USS Classes.
        /*< -------------------- Common -------------------- >*/
        public string Port_Sibling = "port_Sibling";
        public string Port_Connect = "port_Connect";

        /*< -------------------- Port -------------------- >*/
        public string Default_Input_Port = "default_Input_Port";
        public string Default_Output_Port = "default_Output_Port";

        /*< -------------------- Connector -------------------- >*/
        public string Default_Input_Connector = "default_Input_Connector";
        public string Default_Output_Connector = "default_Output_Connector";

        /*< -------------------- Label -------------------- >*/
        public string Default_Input_Label = "default_Input_Label";
        public string Default_Output_Label = "default_Output_Label";

        /*< -------------------- Cap -------------------- >*/
        public string Default_Input_Cap = "default_Input_Cap";
        public string Default_Output_Cap = "default_Output_Cap";
        #endregion

        #region Port Option USS Classes.
        /*< -------------------- Port -------------------- >*/
        public string Option_Input_Port = "option_Input_Port";
        public string Option_Output_Port = "option_Output_Port";

        /*< -------------------- Connector -------------------- >*/
        public string Option_Input_Connector = "option_Input_Connector";
        public string Option_Output_Connector = "option_Output_Connector";

        /*< -------------------- Label -------------------- >*/
        public string Option_Input_Label = "option_Input_Label";
        public string Option_Output_Label = "option_Output_Label";

        /*< -------------------- Cap -------------------- >*/
        public string Option_Input_Cap = "option_Input_Cap";
        public string Option_Output_Cap = "option_Output_Cap";
        #endregion

        #region Option Port Group USS Classes.
        public string OptionPortGroup_RemoveButton = "optionPortGroup_RemoveButton";
        #endregion

        #region Edge Default USS Classes.
        /*< -------------------- Common -------------------- >*/
        public string Edge_Selected = "edge_Selected";

        /*< -------------------- Default -------------------- >*/
        public string Default_Edge = "default_Edge";
        #endregion

        #region Edge Option USS Classes.
        public string Option_Edge = "option_Edge";
        #endregion


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class, used to initialize internal fields.
        /// </summary>
        public static void Setup()
        {
            Instance ??= new();
        }


        // ----------------------------- Dispose -----------------------------
        /// <summary>
        /// Dispose for the class.
        /// </summary>
        public void Dispose()
        {
            Instance = null;
        }
    }
}