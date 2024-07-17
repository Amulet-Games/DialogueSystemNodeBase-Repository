namespace AG.DS
{
    public class BlackboardFactory
    {
        public static Blackboard Generate(GraphViewer graphViewer)
        {
            var blackboard = BlackboardPresenter.CreateElement(graphViewer);

            new BlackboardObserver(blackboard).RegisterEvents();

            return blackboard;
        }
    }
}