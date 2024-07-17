using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.GenericMenu;

namespace AG.DS
{
    public class Blackboard : UnityEditor.Experimental.GraphView.Blackboard
    {
        /// <summary>
        /// Reference of the string variables blackboard category;
        /// </summary>
        public BlackboardCategory StringVariablesCategory;


        /// <summary>
        /// Reference of the float variables blackboard category;
        /// </summary>
        public BlackboardCategory FloatVariablesCategory;


        /// <summary>
        /// Reference of the bool variables blackboard category;
        /// </summary>
        public BlackboardCategory BooleanVariablesCategory;


        /// <summary>
        /// Reference of the blackboard's add button.
        /// </summary>
        public VisualElement AddButton { get; private set; }


        /// <summary>
        /// Reference of the add item generic menu.
        /// </summary>
        public GenericMenu AddItemGenericMenu;


        /// <summary>
        /// The function that will be called when the add item generic menu's string menu item is selected.
        /// </summary>
        public MenuFunction GenericMenuStringItemSelectedEvent;


        /// <summary>
        /// The function that will be called when the add item generic menu's float menu item is selected.
        /// </summary>
        public MenuFunction GenericMenuFloatItemSelectedEvent;


        /// <summary>
        /// The function that will be called when the add item generic menu's boolean menu item is selected.
        /// </summary>
        public MenuFunction GenericMenuBooleanItemSelectedEvent;


        /// <summary>
        /// Constructor of the blackboard element.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public Blackboard(GraphViewer graphViewer) : base(graphViewer)
        {
            SetupAddButton();
            SetupGenericMenu();
        }


        /// <summary>
        /// Setup the add button element.
        /// </summary>
        void SetupAddButton()
        {
            AddButton = this.GetAddButton();
        }


        /// <summary>
        /// Setup the generic menu.
        /// </summary>
        void SetupGenericMenu()
        {
            AddItemGenericMenu = new GenericMenu();
            AddItemGenericMenu.AddItem
            (
                content: new GUIContent(StringConfig.Blackboard.GenericMenu.StringLabelText),
                on: false,
                func: GenericMenuStringItemSelectedEvent
            );
            AddItemGenericMenu.AddItem
            (
                content: new GUIContent(StringConfig.Blackboard.GenericMenu.FloatLabelText),
                on: false,
                func: GenericMenuFloatItemSelectedEvent
            );
            AddItemGenericMenu.AddItem
            (
                content: new GUIContent(StringConfig.Blackboard.GenericMenu.BooleanLabelText),
                on: false,
                func: GenericMenuBooleanItemSelectedEvent
            );
        }
    }
}