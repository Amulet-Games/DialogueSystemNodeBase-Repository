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
        public const string SearchTreeGroupEntry_NodeCreationRequest_CreationRequest_LabelText = "Creation Request";
        public const string SearchTreeGroupEntry_EdgeConnector_EdgeConnector_LabelText = "Edge Connector";
        public const string SearchTreeGroupEntry_NodeCreationRequest_NewNode_LabelText = "New Node";
        public const string SearchTreeEntry_Common_BooleanNode_LabelText = "Boolean Node";
        public const string SearchTreeEntry_Common_DialogueNode_LabelText = "Dialogue Node";
        public const string SearchTreeEntry_Common_EndNode_LabelText = "End Node";
        public const string SearchTreeEntry_Common_EventNode_LabelText = "Event Node";
        public const string SearchTreeEntry_Common_OptionBranchNode_LabelText = "Option Branch Node";
        public const string SearchTreeEntry_Common_OptionRootNode_LabelText = "Option Root Node";
        public const string SearchTreeEntry_Common_PreviewNode_LabelText = "Preview Node";
        public const string SearchTreeEntry_Common_StartNode_LabelText = "Start Node";
        public const string SearchTreeEntry_Common_StoryNode_LabelText = "Story Node";
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
        public const string EventModifier_DialogueEventField_PlaceholderText = "None (dialogue event)";
        public const string EventModifier_StartDelay_LabelText = "Start Delay";
        public const string EventModifier_DelaySeconds_LabelText = "seconds";
        #endregion

        #region Message Modifier Texts.
        public const string MessageModifier_FolderTitleField_DefaultText = "Message ";
        public const string MessageModifier_MessageTextLabel_LabelText = "String";
        public const string MessageModifier_MessageTextField_PlaceholderText = "“Hey what's up?”";
        public const string MessageModifier_MessageAudioLabel_LabelText = "Audio";
        public const string MessageModifier_MessageAudioField_PlaceholderText = "None (Audio Clip)";
        public const string MessageModifier_ContinueBy_LabelText = "Continue By";
        public const string MessageModifier_ContinueByInput_LabelText = "Input";
        public const string MessageModifier_ContinueByAuto_LabelText = "Auto";
        public const string MessageModifier_StartDelay_LabelText = "Start Delay";
        public const string MessageModifier_DelaySeconds_LabelText = "seconds";
        #endregion

        #region Condition Modifier Texts.
        
        #endregion

        public static class ConditionModifierView
        {
            public const string FolderTitleField_DefaultText = "Condition ";
            public const string SwitchButton_ToSceneObject_LabelText = "Switch To Scene Object";
            public const string SwitchButton_ToManualInput_LabelText = "Switch To Manual Input";
            public const string FirstVariable_LabelText = "Compare";
            public const string FirstTextField_PlaceholderText = "First String";
            public const string FirstFloatField_HintLabelText = "1st Number";
            public const string SecondVariable_LabelText = "With";
            public const string SecondTextField_PlaceholderText = "Second String";
            public const string SecondFloatField_HintLabelText = "2nd Number";
            public const string VariableSearchWindowSelector_PlaceholderText = "Empty Scene Object";
            public const string FieldInfoSearchWindowSelector_PlaceholderText = "Empty Field Info";
            public const string FieldInfo_LabelText = "Field Info";
            public const string Operation_LabelText = "Operation ";
            public const string ChainWith_LabelText = "Chain With ";
            public const string Operators_LabelText = "Operators";
            public const string Match_LabelText = "Match";
            public const string Equal_LabelText = "Equal";
            public const string EqualOrBigger_LabelText = "Equal Or Bigger";
            public const string EqualOrSmaller_LabelText = "Equal Or Smaller";
            public const string Bigger_LabelText = "Bigger";
            public const string Smaller_LabelText = "Smaller";
            public const string CustomLogic_LabelText = "Custom Logic";
            public const string Group_LabelText = "Group";
            public const string None_LabelText = "All";
            public const string Group1_LabelText = "Group 1";
            public const string Group2_LabelText = "Group 2";
            public const string Group3_LabelText = "Group 3";

            public const string SearchTreeEntry_NullValue_LabelText = "None";
            public const string SearchTreeEntry_SceneObject_LabelText = "Scene Objects";
            public const string SearchTreeEntry_ClassMember_LabelText = "Class Members";
            public const string SearchTreeEntry_ClassMember_Fields_LabelText = "Fields";
            public const string SearchTreeEntry_ClassMember_Properties_LabelText = "Properties";

            public const string BindingFlags_FlagElement_All_LabelText = "All";
            public const string BindingFlags_FlagElement_Instance_LabelText = "Instance";
            public const string BindingFlags_FlagElement_Static_LabelText = "Static";
            public const string BindingFlags_FlagElement_Public_LabelText = "Public";
            public const string BindingFlags_FlagElement_Private_LabelText = "Private";
        }

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
        public const string DialogueNode_DialogueSpeakerField_PlaceholderText = "None (Dialogue Character)";
        #endregion
    }
}