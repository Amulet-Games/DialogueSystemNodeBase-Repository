using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using SystemBindingFlags = System.Reflection.BindingFlags;

namespace AG.DS
{
    public class ConditionModifierViewSearchTreeEntryProvider
    {
        /// <summary>
        /// Reference of the search tree entry icon.
        /// </summary>
        public Texture2D SearchTreeEntryIcon;


        /// <summary>
        /// The title search tree entry index.
        /// </summary>
        readonly int titleEntryLevelIndex = 0;


        /// <summary>
        /// The null value search tree entry index.
        /// </summary>
        readonly int nullValueEntryLevelIndex = 1;


        /// <summary>
        /// Reference of the null value variable search tree entry.
        /// </summary>
        public SearchTreeEntry NullValueVariableSearchTreeEntry;


        /// <summary>
        /// Reference of the null value property search tree entry.
        /// </summary>
        public SearchTreeEntry NullValuePropertySearchTreeEntry;


        /// <summary>
        /// Reference of the condition modifier view.
        /// </summary>
        readonly ConditionModifierView view;


        /// <summary>
        /// Constructor of the condition modifier view search tree entry provider.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        public ConditionModifierViewSearchTreeEntryProvider(ConditionModifierView view)
        {
            this.view = view;

            CreateSearchTreeEntryIcon();

            CreateNullValueSearchTreeEntries();
        }


        /// <summary>
        /// Create the search tree entry icon.
        /// </summary>
        void CreateSearchTreeEntryIcon()
        {
            SearchTreeEntryIcon = new Texture2D(1, 1);
            SearchTreeEntryIcon.SetPixel(0, 0, new Color(0, 0, 0, 0));
            SearchTreeEntryIcon.Apply();
        }


        /// <summary>
        /// Create the null value search tree entries.
        /// </summary>
        void CreateNullValueSearchTreeEntries()
        {
            NullValueVariableSearchTreeEntry = SearchTreeEntryPresenter.CreateEntry
            (
                text: StringConfig.ConditionModifierView.SearchTreeEntry_NullValue_LabelText,
                icon: SearchTreeEntryIcon,
                level: nullValueEntryLevelIndex,
                userData: null
            );

            NullValuePropertySearchTreeEntry = SearchTreeEntryPresenter.CreateEntry
            (
                text: StringConfig.ConditionModifierView.SearchTreeEntry_NullValue_LabelText,
                icon: SearchTreeEntryIcon,
                level: nullValueEntryLevelIndex,
                userData: null
            );
        }


        /// <summary>
        /// Create the search tree entries for the variable search window selector element.
        /// </summary>
        /// <returns>The search tree entries for the variable search window selector element.</returns>
        public List<SearchTreeEntry> CreateVariableSelectorSearchTreeEntries()
        {
            var variableSelectorSearchTreeEntries = new List<SearchTreeEntry>();
            SearchTreeGroupEntry titleGroupEntry;

            // Title Group Entry
            {
                titleGroupEntry = SearchTreeGroupEntryPresenter.CreateEntry
                (
                    text: StringConfig.ConditionModifierView.SearchTreeEntry_SceneObject_LabelText,
                    level: titleEntryLevelIndex
                )
                .AddTo(entries: variableSelectorSearchTreeEntries);
            }

            // Null Value Entry
            {
                NullValueVariableSearchTreeEntry.AddTo(entries: variableSelectorSearchTreeEntries);
            }

            // Scene Object Entries
            {
                var sceneObjects = SceneManager.GetActiveScene().GetRootGameObjects();
                for (int i = 0; i < sceneObjects.Length; i++)
                {
                    variableSelectorSearchTreeEntries.Add(SearchTreeEntryPresenter.CreateEntry
                    (
                        text: sceneObjects[i].name,
                        icon: SearchTreeEntryProvider.EmptySearchTreeEntryIcon,
                        level: titleGroupEntry.NextLevel(),
                        userData: sceneObjects[i]
                    ));
                }
            }

            return variableSelectorSearchTreeEntries;
        }


        /// <summary>
        /// Create the search tree entries for the field info search window selector element.
        /// </summary>
        /// <param name="fieldInfoObject">The field info object to set for.</param>
        /// <returns>The search tree entries for the field info search window selector element</returns>
        public List<SearchTreeEntry> CreateFieldInfoSelectorSearchTreeEntries(GameObject fieldInfoObject)
        {
            var fieldInfoSelectorSearchTreeEntries = new List<SearchTreeEntry>();
            SearchTreeGroupEntry titleGroupEntry;

            // Title Group Entry
            {
                titleGroupEntry = SearchTreeGroupEntryPresenter.CreateEntry
                (
                    text: StringConfig.ConditionModifierView.SearchTreeEntry_ClassMember_LabelText,
                    level: titleEntryLevelIndex
                )
                .AddTo(entries: fieldInfoSelectorSearchTreeEntries);
            }

            // Null Value Entry
            {
                NullValuePropertySearchTreeEntry.AddTo(entries: fieldInfoSelectorSearchTreeEntries);
            }

            var sceneObjectComponents = fieldInfoObject.GetComponents(typeof(Component));

            for (int i = 0; i < sceneObjectComponents.Length; i++)
            {
                SearchTreeGroupEntry componentGroupEntry;
                Type componentType = sceneObjectComponents[i].GetType();

                // Component Group Entry
                {
                    componentGroupEntry = SearchTreeGroupEntryPresenter.CreateEntry
                    (
                        text: componentType.Name,
                        level: titleGroupEntry.NextLevel()
                    )
                    .AddTo(entries: fieldInfoSelectorSearchTreeEntries);
                }

                // Field Info Entries
                {
                    SearchTreeGroupEntry fieldsGroupEntry;

                    // Fields Group Entry
                    {
                        fieldsGroupEntry = SearchTreeGroupEntryPresenter.CreateEntry
                        (
                            text: StringConfig.ConditionModifierView.SearchTreeEntry_ClassMember_Fields_LabelText,
                            level: componentGroupEntry.NextLevel()
                        )
                        .AddTo(entries: fieldInfoSelectorSearchTreeEntries);
                    }

                    // Fields Child Entries
                    {
                        var fieldInfo = componentType.GetFieldInfo(SystemBindingFlags.Instance | SystemBindingFlags.Static | SystemBindingFlags.Public);

                        var fieldInfoList = (view.m_OperationType == ConditionModifierView.OperationType.String
                                          ? fieldInfo.FilterWithStringType()
                                          : fieldInfo.FilterWithNumberType()).ToList();

                        var fieldInfoCount = fieldInfoList.Count;
                        for (int j = 0; j < fieldInfoCount; j++)
                        {
                            fieldInfoSelectorSearchTreeEntries.Add(SearchTreeEntryPresenter.CreateEntry
                            (
                                text: fieldInfoList[j].Name,
                                icon: SearchTreeEntryProvider.EmptySearchTreeEntryIcon,
                                level: fieldsGroupEntry.NextLevel(),
                                userData: fieldInfoList[j]
                            ));
                        }
                    }
                }

                // Property Info Entries
                {
                    SearchTreeGroupEntry propertiesGroupEntry;

                    // Properties Group Entry
                    {
                        propertiesGroupEntry = SearchTreeGroupEntryPresenter.CreateEntry
                        (
                            text: StringConfig.ConditionModifierView.SearchTreeEntry_ClassMember_Properties_LabelText,
                            level: componentGroupEntry.NextLevel()
                        )
                        .AddTo(entries: fieldInfoSelectorSearchTreeEntries);
                    }

                    // Properties Child Entry
                    {
                        var propertyInfo = componentType
                            .GetPropertyInfo(SystemBindingFlags.Instance | SystemBindingFlags.Static | SystemBindingFlags.Public)
                            .FilterWithReadable();

                        var propertyInfoList = (view.m_OperationType == ConditionModifierView.OperationType.String
                                             ? propertyInfo.FilterWithStringType()
                                             : propertyInfo.FilterWithNumberType()).ToList();

                        var propertyInfoCount = propertyInfoList.Count;
                        for (int j = 0; j < propertyInfoCount; j++)
                        {
                            fieldInfoSelectorSearchTreeEntries.Add(SearchTreeEntryPresenter.CreateEntry
                            (
                                text: propertyInfoList[j].Name,
                                icon: SearchTreeEntryProvider.EmptySearchTreeEntryIcon,
                                level: propertiesGroupEntry.NextLevel(),
                                userData: propertyInfoList[j]
                            ));
                        }
                    }
                }
            }

            return fieldInfoSelectorSearchTreeEntries;
        }
    }
}