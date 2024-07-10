namespace AG.DS
{
    public class HeadbarCallback
    {
        /// <summary>
        /// The callback to invoke when the headbar is created on the dialogue system window.
        /// </summary>
        /// <param name="headbar">The header element to set for.</param>
        public static void OnCreate(Headbar headbar)
        {
            GraphTitleTextFieldCallback.OnCreate(headbar.GraphTitleTextFieldView);
        }
    }
}