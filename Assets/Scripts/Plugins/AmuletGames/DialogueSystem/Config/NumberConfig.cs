namespace AG.DS
{
    public static class NumberConfig
    {
        // ----------------------------- Field -----------------------------
        /// <summary>
        /// The maximum number of delay second that can be set in the delay second field.
        /// </summary>
        public const int MAX_DELAY_SECOND = 99999;


        /// <summary>
        /// The minimum number of delay second that can be set in the delay second field.
        /// </summary>
        public const int MIN_DELAY_SECOND = 0;


        /// <summary>
        /// The maximum number of characters that a multiline text field can have.
        /// </summary>
        public const int MAX_CHAR_LENGTH_MULTI_LINE_TEXT_FIELD = 400;


        /// <summary>
        /// The maximum number of characters that a single line text field can have.
        /// </summary>
        public const int MAX_CHAR_LENGTH_SINGLE_LINE_TEXT_FIELD = 40;


        // ----------------------------- Node -----------------------------
        /// <summary>
        /// The min width value of the boolean node.
        /// </summary>
        public const int BOOLEAN_NODE_MIN_WIDTH = 531;


        /// <summary>
        /// The min width value of the dialogue node.
        /// </summary>
        public const int DIALOGUE_NODE_MIN_WIDTH = 491;


        /// <summary>
        /// The min width value of the end node.
        /// </summary>
        public const int END_NODE_MIN_WIDTH = 142;


        /// <summary>
        /// The min width value of the event node.
        /// </summary>
        public const int EVENT_NODE_MIN_WIDTH = 491;


        /// <summary>
        /// The min width value of the option branch node.
        /// </summary>
        public const int OPTION_BRANCH_NODE_MIN_WIDTH = 491;


        /// <summary>
        /// The min width value of the option root node.
        /// </summary>
        public const int OPTION_ROOT_NODE_MIN_WIDTH = 491;


        /// <summary>
        /// The min width value of the preview node.
        /// </summary>
        public const int PREVIEW_NODE_MIN_WIDTH = 456;


        /// <summary>
        /// The min width value of the start node.
        /// </summary>
        public const int START_NODE_MIN_WIDTH = 142;


        /// <summary>
        /// The min width value of the story node.
        /// </summary>
        public const int STORY_NODE_MIN_WIDTH = 424;


        /// <summary>
        /// The value to use when calculating the final position of the node in relation to the Y axis of the graph.
        /// </summary>
        public const float MANUAL_CREATE_Y_OFFSET = 25.5f;


        /// <summary>
        /// The maximum length of characters that a node title text field can have.
        /// </summary>
        public const int MAX_CHAR_LENGTH_NODE_TITLE_TEXT = 40;


        // ----------------------------- Folder -----------------------------
        /// <summary>
        /// The maximum number of characters that a folder element can have.
        /// </summary>
        public const int MAX_CHAR_LENGTH_FOLDER_TITLE_TEXT = 40;
    }
}