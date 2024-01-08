namespace AG.DS
{
    public static class StringConfig
    {
        #region Window Labels.
        public const string Editor_WindowDefaultTitleText = "Append Dialogue Editor Graph";
        public const string Editor_WindowAlreadyOpened_WarningText = "Action is ignored since the dialogue system window of this asset is already opened.";
        public const string Editor_WindowAlreadySaved_WarningText = "Action is ignored since there's no unsaved changes.";
        public const string Editor_WindowAlreadyLoaded_WarningText = "Action is ignored since there's nothing changed from the last time it loaded.";
        #endregion

        #region Headbar Labels.
        public const string Headbar_SaveButton_LabelText = "Save";
        public const string Headbar_LoadButton_LabelText = "Load";
        #endregion

        #region Input Hint Texts.
        public const string InputHint_HintTextLabel_LabelText = "This field is language dependent.";
        #endregion

        #region Search Entry Labels.
        public const string SearchEntry_AncestorEntry_LabelText = "Dialogue Editor";
        public const string SearchEntry_FamilyEntry_Nodes_LabelText = "Nodes";
        public const string SearchEntry_ChildEntry_BooleanNode_LabelText = "Boolean Node";
        public const string SearchEntry_ChildEntry_DialogueNode_LabelText = "Dialogue Node";
        public const string SearchEntry_ChildEntry_EndNode_LabelText = "End Node";
        public const string SearchEntry_ChildEntry_EventNode_LabelText = "Event Node";
        public const string SearchEntry_ChildEntry_OptionBranchNode_LabelText = "Option Branch Node";
        public const string SearchEntry_ChildEntry_OptionRootNode_LabelText = "Option Root Node";
        public const string SearchEntry_ChildEntry_PreviewNode_LabelText = "Preview Node";
        public const string SearchEntry_ChildEntry_StartNode_LabelText = "Start Node";
        public const string SearchEntry_ChildEntry_StoryNode_LabelText = "Story Node";
        #endregion

        #region Contextual Menu Item Labels.
        public const string ContextualMenuItem_DisconnectInputPort_LabelText = "Disconnect Input Port";
        public const string ContextualMenuItem_DisconnectOutputPort_LabelText = "Disconnect Output Port";
        public const string ContextualMenuItem_DisconnectTrueOutputPort_LabelText = "Disconnect True Output Port";
        public const string ContextualMenuItem_DisconnectFalseOutputPort_LabelText = "Disconnect False Output Port";
        public const string ContextualMenuItem_DisconnectContinueOutputPort_LabelText = "Disconnect Continue Output Port";
        public const string ContextualMenuItem_DisconnectOptionCellPort_Input_LabelText = "Disconnect ";
        public const string ContextualMenuItem_DisconnectOptionCellPort_Output_LabelText = "Disconnect ";
        public const string ContextualMenuItem_DisconnectAllPort_LabelText = "Disconnect All";
        #endregion

        #region Node Title Labels.
        public const string BooleanNode_NodeTitleField_DefaultText = "Boolean";
        public const string DialogueNode_NodeTitleField_DefaultText = "Dialogue";
        public const string EndNode_NodeTitleField_DefaultText = "End";
        public const string EventNode_NodeTitleField_DefaultText = "Event";
        public const string OptionBranchNode_NodeTitleField_DefaultText = "Option Branch";
        public const string OptionRootNode_NodeTitleField_DefaultText = "Option Root";
        public const string PreviewNode_NodeTitleField_DefaultText = "Preview";
        public const string StartNode_NodeTitleField_DefaultText = "Start";
        public const string StoryNode_NodeTitleField_DefaultText = "Story";
        #endregion

        #region Port Labels.
        public const string Port_Input_LabelText = "Input";
        public const string Port_Output_LabelText = "Output";
        public const string Port_True_LabelText = "True";
        public const string Port_False_LabelText = "False";
        #endregion

        #region Option Port Cell Labels.
        public const string OptionPortCell_Input_Connect_LabelText = "Option ";
        public const string OptionPortCell_Output_Connect_LabelText = "Option ";
        public const string OptionPortCell_Input_Disconnect_LabelText = "Track";
        public const string OptionPortCell_Output_Disconnect_LabelText = "Entry";
        #endregion

        #region Content Button Labels.
        public const string ContentButton_AddCondition_LabelText = "Add Condition";
        public const string ContentButton_AddEvent_LabelText = "Add Event";
        public const string ContentButton_AddEntry_LabelText = "Add Entry";
        public const string ContentButton_AddMessage_LabelText = "Add Message";
        #endregion

        #region TextField Placeholder Texts.
        public const string DialogueSegmentCharacterPlaceholderText = "Character";
        public const string DialogueSegmentTextlinePlaceholderText = "Textline";
        public const string ConditionModifierCompareToStringPlaceholderText = "String";
        #endregion

        #region Segment Title Labels.
        public const string EventSegmentTitleLabelText = "Scriptable Events";
        public const string ConditionSegmentTitleLabelText = "Conditions";
        #endregion

        #region Event Modifier Texts.
        public const string EventModifier_FolderTitleField_DefaultText = "Event ";
        public const string EventModifier_DialogueEventLabel_LabelText = "Dialogue Event";
        public const string EventModifier_DialogueEventField_PlaceholderText = "All (Dialogue Event)";
        public const string EventModifier_StartDelay_LabelText = "Start Delay";
        public const string EventModifier_DelaySeconds_LabelText = "seconds";
        #endregion

        #region Message Modifier Texts.
        public const string MessageModifier_FolderTitleField_DefaultText = "Message ";
        public const string MessageModifier_MessageTextLabel_LabelText = "String";
        public const string MessageModifier_MessageTextField_PlaceholderText = "“Hey what's up?”";
        public const string MessageModifier_MessageAudioLabel_LabelText = "Audio";
        public const string MessageModifier_MessageAudioField_PlaceholderText = "All (Audio Clip)";
        public const string MessageModifier_ContinueBy_LabelText = "Continue By";
        public const string MessageModifier_ContinueByInput_LabelText = "Input";
        public const string MessageModifier_ContinueByAuto_LabelText = "Auto";
        public const string MessageModifier_StartDelay_LabelText = "Start Delay";
        public const string MessageModifier_DelaySeconds_LabelText = "seconds";
        #endregion

        #region Condition Modifier Texts.
        public const string ConditionModifier_FolderTitleField_DefaultText = "Condition ";
        public const string ConditionModifier_SwitchFieldButton_LabelText = "Switch Field Type";
        public const string ConditionModifier_SecondVariable_LabelText = "With";
        public const string ConditionModifier_SecondReflectableObjectField_PlaceholderText = "All (Object)";
        public const string ConditionModifier_SecondTextField_PlaceholderText = "Second String";
        public const string ConditionModifier_SecondFloatHint_LabelText = "2nd Number";
        public const string ConditionModifier_SecondBindingFlags_LabelText = "Sort By";
        public const string ConditionModifier_BindingFlags_FlagElement_All_LabelText = "All";
        public const string ConditionModifier_BindingFlags_FlagElement_Instance_LabelText = "Instance";
        public const string ConditionModifier_BindingFlags_FlagElement_Static_LabelText = "Static";
        public const string ConditionModifier_BindingFlags_FlagElement_Public_LabelText = "Public";
        public const string ConditionModifier_BindingFlags_FlagElement_Private_LabelText = "Private";
        public const string ConditionModifier_Operation_LabelText = "Operation ";
        public const string ConditionModifier_ChainWith_LabelText = "Chain With ";
        public const string ConditionModifier_Operators_LabelText = "Operators";
        public const string ConditionModifier_Match_LabelText = "Match";
        public const string ConditionModifier_Equal_LabelText = "Equal";
        public const string ConditionModifier_EqualOrBigger_LabelText = "Equal Or Bigger";
        public const string ConditionModifier_EqualOrSmaller_LabelText = "Equal Or Smaller";
        public const string ConditionModifier_Bigger_LabelText = "Bigger";
        public const string ConditionModifier_Smaller_LabelText = "Smaller";
        public const string ConditionModifier_CustomLogic_LabelText = "Custom Logic";
        public const string ConditionModifier_Group_LabelText = "Group";
        public const string ConditionModifier_None_LabelText = "All";
        public const string ConditionModifier_Group1_LabelText = "Group 1";
        public const string ConditionModifier_Group2_LabelText = "Group 2";
        public const string ConditionModifier_Group3_LabelText = "Group 3";
        #endregion

        #region Option Root Node Texts.
        public const string OptionRootNode_RootTitleLabel_LabelText = "Root Title";
        public const string OptionRootNode_RootTitleField_PlaceholderText = "“Did you have lunch yet?”";
        #endregion

        #region Option Branch Node Texts.
        public const string OptionBranchNode_BranchTitleLabel_LabelText = "Branch Title";
        public const string OptionBranchNode_BranchTitleField_PlaceholderText = "“Yeah I had it in the Indian restaurant.”";
        #endregion

        #region Dialogue Node Texts.
        public const string DialogueNode_DialogueSpeakerLabel_LabelText = "Speaker";
        public const string DialogueNode_DialogueSpeakerField_PlaceholderText = "All (Dialogue Character)";
        #endregion
    }
}