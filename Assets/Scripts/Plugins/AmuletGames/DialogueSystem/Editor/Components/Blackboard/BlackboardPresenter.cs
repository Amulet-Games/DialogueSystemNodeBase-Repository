using UnityEngine;

namespace AG.DS
{
    public class BlackboardPresenter
    {
        public static Blackboard CreateElement(GraphViewer graphViewer)
        {
            Blackboard blackboard;
            BlackboardSection variablesSection;

            CreateBlackboard();

            SetupDetails();

            CreateCategories();

            CreateSection();

            AddElementsToBlackboard();

            return blackboard;

            void CreateBlackboard()
            {
                blackboard = new(graphViewer);
                blackboard.AddToClassList(StyleConfig.Blackboard);
            }

            void SetupDetails()
            {
                // Position
                {
                    blackboard.SetPosition(newPos: new Rect(x: 30f, y: 80f, width: 350f, height: 400f));
                }
            }

            void CreateSection()
            {
                variablesSection = BlackboardSectionPresenter.CreateElement(sectionTitle: StringConfig.Blackboard.VariablesSection.MainLabelText);
            }

            void CreateCategories()
            {
                blackboard.StringVariablesCategory = BlackboardCategoryPresenter.CreateElement(categoryTitle: StringConfig.Blackboard.VariablesSection.StringsLabelText);
                blackboard.FloatVariablesCategory = BlackboardCategoryPresenter.CreateElement(categoryTitle: StringConfig.Blackboard.VariablesSection.FloatsLabelText);
                blackboard.BooleanVariablesCategory = BlackboardCategoryPresenter.CreateElement(categoryTitle: StringConfig.Blackboard.VariablesSection.BooleansLabelText);
            }

            void AddElementsToBlackboard()
            {
                blackboard.Add(variablesSection);
                blackboard.Add(blackboard.StringVariablesCategory.Row);
                blackboard.Add(blackboard.FloatVariablesCategory.Row);
                blackboard.Add(blackboard.BooleanVariablesCategory.Row);
            }
        }
    }
}