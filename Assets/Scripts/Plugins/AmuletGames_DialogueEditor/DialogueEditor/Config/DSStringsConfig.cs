namespace AG
{
    public static class DSStringsConfig
    {
        // ----------------------------- Window Labels -----------------------------
        public const string DialogueEditorWindowLabelText = "Dialogue Editor";
        public const string WindowAlreadyOpenedWarningText = "Action is ignored since a dialogue editor window is already opened.";
        public const string WindowAlreadySavedWarningText = "Action is ignored since there's no unsaved changes.";
        public const string WindowAlreadyLoadedWarningText = "Action is ignored since there's nothing changed from the last time it loaded.";

        // ----------------------------- HeadBar Labels -----------------------------
        public const string DefaultGraphTitleFieldText = "New Dialogue Container SO";
        public const string HeadBarSaveButtonLabelText = "Save";
        public const string HeadBarLoadButtonLabelText = "Load";

        // ----------------------------- Input Hint Texts -----------------------------
        public const string LanguageFieldInputHintText = "This field is language dependent.";

        // ----------------------------- Search Entry Labels -----------------------------
        public const string AncestorEntryLabelText = "Dialogue Editor";
        public const string NodesFamilyEntryLabelText = "Nodes";
        public const string BooleanNodeChildEntryLabelText = "Boolean Node";
        public const string PathNodeChildEntryLabelText = "Path Node";
        public const string EndNodeChildEntryLabelText = "End Node";
        public const string EventNodeChildEntryLabelText = "Event Node";
        public const string OptionNodeChildEntryLabelText = "Option Node";
        public const string StartNodeChildEntryLabelText = "Start Node";
        public const string StoryNodeChildEntryLabelText = "Story Node";

        // ----------------------------- Node Labels -----------------------------
        public const string BooleanNodeDefaultLabelText = "Boolean";
        public const string PathNodeDefaultLabelText = "Path";
        public const string EndNodeDefaultLabelText = "End";
        public const string EventNodeDefaultLabelText = "Event";
        public const string OptionNodeDefaultLabelText = "Option";
        public const string StartNodeDefaultLabelText = "Start";
        public const string StoryNodeDefaultLabelText = "Story";

        // ----------------------------- Port Labels -----------------------------
        public const string NodeInputLabelText = "Input";
        public const string NodeOutputLabelText = "Output";
        public const string BooleanNodeTrueOutputLabelText = "True";
        public const string BooleanNodeFalseOutputLabelText = "False";
        public const string OptionChannelTrackLabelText = "Track ";
        public const string OptionChannelEntryLabelText = "Option ";
        public const string OptionChannelEmptyTrackLabelText = "Input";
        public const string OptionChannelEmptyEntryLabelText = "Output";
        public const string PathNodeContinueOuputLabelText = "Continue";


        // ----------------------------- Content Button Labels -----------------------------
        public const string AddConditionLabelText = "Add Condition";
        public const string AddEventLabelText = "Add Event";
        public const string AddEntryLabelText = "Add Entry";


        // ----------------------------- Contextual Menu Item Labels -----------------------------
        public const string DisconnectInputPortLabelText = "Disconnect Input Port";
        public const string DisconnectOutputPortLabelText = "Disconnect Output Port";
        public const string DisconnectTrueOutputPortLabelText = "Disconnect True Port";
        public const string DisconnectFalseOutputPortLabelText = "Disconnect False Port";
        public const string DisconnectContinueOutputPortLabelText = "Disconnect Continue Port";
        public const string DisconnectTrackPortLabelText = "Disconnect ";
        public const string DisconnectEntryPortLabelText = "Disconnect ";
        public const string DisconnectAllPortLabelText = "Disconnect All";


        // ----------------------------- TextField Placeholder Texts -----------------------------
        public const string OptionNodeHeadlinePlaceHolderText = "Headline";
        public const string DialogueSegmentCharacterPlaceHolderText = "Character";
        public const string DialogueSegmentTextlinePlaceHolderText = "Textline";
        public const string ConditionModifierConditionNamePlaceHolderText = "Condition Name";


        // ----------------------------- Segment Title Labels -----------------------------
        public const string DialogueSegmentTitleLabelText = "Dialogue";
        public const string DualPortraitsSegmentTitleLabelText = "Image";
        public const string EventSegmentTitleLabelText = "Scriptable Events";
        public const string ConditionSegmentTitleLabelText = "Conditions";


        // ----------------------------- Label Element Texts -----------------------------
        public const string SecondLineTriggerTypeLabelText = "Trigger Type";
        public const string DurationLabelText = "Duration";
    }
}