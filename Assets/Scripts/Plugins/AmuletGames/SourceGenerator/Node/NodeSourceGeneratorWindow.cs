using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace AG
{
    /// <summary>
    /// Node sources generator window module class.
    /// </summary>
    public class NodeSourceGeneratorWindow : EditorWindow
    {
        // Window skins.
        GUISkin skin = null;
        string skinPath = "Assets/Scripts/Plugins/AmuletGames/SourceGenerator/Node/NodeSourceGeneratorWindowSkin.guiskin";
        string skinStyle = "SourceGenerator";

        readonly Vector2 defaultMinSize = new(640, 600);
        Vector2 scrollPosition;

        // Fill in variables.
        string namespaceName = "";
        string baseName = "";
        readonly static string[] defaultNamespaceNames = new[]
        {
            "DS"
        };

        // System related variables.
        int systemIndex;
        readonly static string[] systemNames = new[]
        {
            "Dialogue System"
        };
        readonly static string[] systemFolderNames = new[]
        {
            "DialogueSystem"
        };

        // Destination Paths.
        string destinationPath = "";
        // Parent Folder Paths.
        string dataDestinationPath = "";
        string ussDestinationPath = "";
        // Source Files Paths.
        static(string Node, string Model, string Presenter, string Callback, string Serializer, string Data, string USS) sourceFilesPaths;


        [MenuItem("### AG ###/Node Source Generator", isValidateFunction: false, priority: 20101)]
        static void Open()
        {
            GetWindow<NodeSourceGeneratorWindow>("Node Source Generator").Show();
            
        }

        void OnEnable()
        {
            skin = AssetDatabase.LoadAssetAtPath<GUISkin>(skinPath);
            minSize = defaultMinSize;

            OnChangeTypeIndex();
        }

        void OnGUI()
        {
            GUI.skin = skin;

            scrollPosition = GUILayout.BeginScrollView(scrollPosition);

            var selectionGridTexts = systemNames;
            var gridIndex = GUILayout.SelectionGrid
            (
                selected: systemIndex,
                texts: selectionGridTexts,
                xCount: selectionGridTexts.Length,
                style: skinStyle
            );
            if (systemIndex != gridIndex)
            {
                systemIndex = gridIndex;
                OnChangeTypeIndex();
            }

            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                GUILayout.Label("Namespace");
                namespaceName = GUILayout.TextField(namespaceName);
            }

            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                GUILayout.Label("Base name");
                baseName = GUILayout.TextField(baseName);
            }

            bool error = false;

            if (baseName.Length == 0)
            {
                // No base name error
                GUILayout.Label("Please enter the base name.");
                error = true;
            }

            destinationPath = Selection.GetFiltered<DefaultAsset>(SelectionMode.Assets)
                .Select(x => AssetDatabase.GetAssetPath(x))
                .FirstOrDefault();
            if (destinationPath == null)
            {
                // No destination error
                GUILayout.Label("Please pick the directory folder in the project window that's going to hold the created source files.");
                error = true;
            }

            if (destinationPath != null)
            {
                var file = $"{destinationPath}/{baseName}Node.cs";
                if (File.Exists(file))
                {
                    // Node already exists error.
                    GUILayout.Label($"{Path.GetFileName(file)} is already exists.");
                    error = true;
                }

                file = $"{destinationPath}/{baseName}NodeModel.cs";
                if (File.Exists(file))
                {
                    // Model already exists error.
                    GUILayout.Label($"{Path.GetFileName(file)} is already exists.");
                    error = true;
                }

                file = $"{destinationPath}/{baseName}NodePresenter.cs";
                if (File.Exists(file))
                {
                    // Presenter already exists error.
                    GUILayout.Label($"{Path.GetFileName(file)} is already exists.");
                    error = true;
                }

                file = $"{destinationPath}/{baseName}NodeCallback.cs";
                if (File.Exists(file))
                {
                    // Callback already exists error.
                    GUILayout.Label($"{Path.GetFileName(file)} is already exists.");
                    error = true;
                }

                file = $"{destinationPath}/{baseName}NodeSerializer.cs";
                if (File.Exists(file))
                {
                    // Serializer already exists error.
                    GUILayout.Label($"{Path.GetFileName(file)} is already exists.");
                    error = true;
                }

                file = $"{dataDestinationPath}/{baseName}NodeData.cs";
                if (File.Exists(file))
                {
                    // Data already exists error.
                    GUILayout.Label($"{Path.GetFileName(file)} is already exists.");
                    error = true;
                }

                file = $"{ussDestinationPath}/DS{baseName}NodeStyle.uss";
                if (File.Exists(file))
                {
                    // USS already exists error.
                    GUILayout.Label($"{Path.GetFileName(file)} is already exists.");
                    error = true;
                }
            }

            if (!error)
            {
                using (new GUILayout.VerticalScope(GUI.skin.box))
                {
                    GUILayout.Label("Creating Folder");
                    var text = $"{destinationPath}/{baseName}";
                    var builder = new StringBuilder();

                    // Node
                    builder.AppendLine($"{text}Node.cs");
                    // Model
                    builder.AppendLine($"{text}NodeModel.cs");
                    // Presenter
                    builder.AppendLine($"{text}NodePresenter.cs");
                    // Callback
                    builder.AppendLine($"{text}NodeCallback.cs");
                    // Serializer
                    builder.AppendLine($"{text}NodeSerializer.cs");
                    // Data
                    text = $"{dataDestinationPath}/{baseName}";
                    builder.AppendLine($"{text}NodeData.cs");
                    // USS
                    text = $"{ussDestinationPath}/DS{baseName}";
                    builder.AppendLine($"{text}NodeStyle.uss");

                    GUILayout.TextArea(builder.ToString().TrimEnd());
                }

                if (GUILayout.Button("Create"))
                {
                    Create();
                    Close();
                }
            }

            GUILayout.EndScrollView();
        }

        void Create()
        {
            if (destinationPath == null) return;

            // Node
            {
                var sourceContent = File.ReadAllText(sourceFilesPaths.Node, Encoding.UTF8);
                var destinationContent = sourceContent
                    .Replace("#Namespace#", namespaceName)
                    .Replace("#Name#", baseName)
                    .Replace("#name#", baseName.ToLower());

                var destinationFile = $"{destinationPath}/{baseName}Node.cs";
                File.WriteAllText(destinationFile, destinationContent, Encoding.UTF8);
            }

            // Model
            {
                var sourceContent = File.ReadAllText(sourceFilesPaths.Model, Encoding.UTF8);
                var destinationContent = sourceContent
                    .Replace("#Namespace#", namespaceName)
                    .Replace("#Name#", baseName)
                    .Replace("#name#", baseName.ToLower());

                var destinationFile = $"{destinationPath}/{baseName}NodeModel.cs";
                File.WriteAllText(destinationFile, destinationContent, Encoding.UTF8);
            }

            // Presenter
            {
                var sourceContent = File.ReadAllText(sourceFilesPaths.Presenter, Encoding.UTF8);
                var destinationContent = sourceContent
                    .Replace("#Namespace#", namespaceName)
                    .Replace("#Name#", baseName)
                    .Replace("#name#", baseName.ToLower());

                var destinationFile = $"{destinationPath}/{baseName}NodePresenter.cs";
                File.WriteAllText(destinationFile, destinationContent, Encoding.UTF8);
            }

            // Callback
            {
                var sourceContent = File.ReadAllText(sourceFilesPaths.Callback, Encoding.UTF8);
                var destinationContent = sourceContent
                    .Replace("#Namespace#", namespaceName)
                    .Replace("#Name#", baseName)
                    .Replace("#name#", baseName.ToLower());

                var destinationFile = $"{destinationPath}/{baseName}NodeCallback.cs";
                File.WriteAllText(destinationFile, destinationContent, Encoding.UTF8);
            }

            // Serializer
            {
                var sourceContent = File.ReadAllText(sourceFilesPaths.Serializer, Encoding.UTF8);
                var destinationContent = sourceContent
                    .Replace("#Namespace#", namespaceName)
                    .Replace("#Name#", baseName)
                    .Replace("#name#", baseName.ToLower());

                var destinationFile = $"{destinationPath}/{baseName}NodeSerializer.cs";
                File.WriteAllText(destinationFile, destinationContent, Encoding.UTF8);
            }

            // Data
            {
                var sourceContent = File.ReadAllText(sourceFilesPaths.Data, Encoding.UTF8);
                var destinationContent = sourceContent
                    .Replace("#Namespace#", namespaceName)
                    .Replace("#Name#", baseName)
                    .Replace("#name#", baseName.ToLower());

                var destinationFile = $"{dataDestinationPath}/{baseName}NodeData.cs";
                File.WriteAllText(destinationFile, destinationContent, Encoding.UTF8);
            }

            // USS
            {
                var destinationContent = File.ReadAllText(sourceFilesPaths.USS, Encoding.UTF8);
                var destinationFile = $"{ussDestinationPath}/DS{baseName}NodeStyle.uss";
                File.WriteAllText(destinationFile, destinationContent, Encoding.UTF8);
            }

            AssetDatabase.Refresh();
        }

        void OnChangeTypeIndex()
        {
            // Namespace
            namespaceName = defaultNamespaceNames[systemIndex];

            // Source files
            sourceFilesPaths = new
            (
                $"Assets/Scripts/Plugins/AmuletGames/SourceGenerator/Node/Editor-Folder/Node-Sources-Node.txt",
                $"Assets/Scripts/Plugins/AmuletGames/SourceGenerator/Node/Editor-Folder/Node-Sources-Model.txt",
                $"Assets/Scripts/Plugins/AmuletGames/SourceGenerator/Node/Editor-Folder/Node-Sources-Presenter.txt",
                $"Assets/Scripts/Plugins/AmuletGames/SourceGenerator/Node/Editor-Folder/Node-Sources-Callback.txt",
                $"Assets/Scripts/Plugins/AmuletGames/SourceGenerator/Node/Editor-Folder/Node-Sources-Serializer.txt",
                $"Assets/Scripts/Plugins/AmuletGames/SourceGenerator/Node/Data-Folder/Node-Sources-Data.txt",
                $"Assets/Scripts/Plugins/AmuletGames/SourceGenerator/Node/USS-Folder/Node-Sources-USS.txt"
            );

            // Data destination path
            dataDestinationPath = $"Assets/Scripts/Plugins/AmuletGames/{systemFolderNames[systemIndex]}/Engine/Data/Nodes/Variants";

            // USS destination path
            ussDestinationPath = $"Assets/Editor Default Resources/{systemFolderNames[systemIndex]}/Nodes/Variants";
        }
    }
}