namespace AG.DS
{
    public class DialogueSystemWindowFactory
    {
        /// <summary>
        /// Generate a new dialogue system window.
        /// </summary>
        /// <param name="asset">The dialogue system window asset to set for.</param>
        /// <returns>A new dialogue system window.</returns>
        public static DialogueSystemWindow Generate(DialogueSystemWindowAsset asset)
        {
            var window = DialogueSystemWindowPresenter.CreateWindow();
            window.Init(asset);
            window.Setup();

            new DialogueSystemWindowObserver(dialogueSystemWindow: window).RegisterEvents();

            DialogueSystemWindowCallback.OnCreate(window);

            return window;
        }
    }
}