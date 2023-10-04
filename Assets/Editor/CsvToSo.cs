///Phap Nguyen
///Description:
///Created date: 04/10/2023
///Last edit: 05/10/2023

using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using System.IO;

public class CsvToSo : EditorWindow
{
    //CSV location
    private static string characterCSV = "/Resources/Data/CSV/CharacterStats.csv";
    private static string enemyCSV = "/Resources/Data/CSV/EnemyStats.csv";
    private static string weaponCSV = "/Resources/Data/CSV/WeaponStats.csv";

    //Directory location
    private static string characterSOFolder = "Assets/Resources/Data/ScriptableObject/Character";
    private static string enemySOFolder = "Assets/Resources/Data/ScriptableObject/Enemy";
    private static string weaponSOFolder = "Assets/Resources/Data/ScriptableObject/Weapon";

    private static string cacheDir = "";

    //Dropdown menu
    public string[] options = new string[] { "Generate character", "Generate enemy", "Generate weapon" };
    public int index = 0;

    //Create context menu
    [MenuItem("Tools/Generate Data")]
    public static void GenerateData()
    {
        CsvToSo wnd = GetWindow<CsvToSo>();
        wnd.titleContent = new GUIContent("Conversion Setup");
    }

    //Init window
    void OnGUI()
    {
        VisualElement root = rootVisualElement;

        GUILayout.Label("Select a data type to convert from CSV file to ScriptableObject:");

        GUILayout.Space(5);

        if (Selection.activeGameObject)
            Selection.activeGameObject.name =
                EditorGUILayout.TextField("Data Type: ", Selection.activeGameObject.name);

        index = EditorGUILayout.Popup(index, options);

        GUILayout.Space(15);

        //Update UI per case
        switch (index)
        {
            //On selecting character
            case 0:
                GUILayout.Label("Generate character data from: ..." + characterCSV);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Change Output directory"))
                    SelectFolder();
                if (GUILayout.Button("Set to default Output directory"))
                    DefaultLocation(characterSOFolder);
                GUILayout.EndHorizontal();
                GUILayout.Label("output folder: ..." + cacheDir);
                break;

            //On selecting enemy
            case 1:
                GUILayout.Label("Generate enemy data from: ..." + enemyCSV);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Change Output directory"))
                    SelectFolder();
                if (GUILayout.Button("Set to default Output directory"))
                    DefaultLocation(enemySOFolder);
                GUILayout.EndHorizontal();
                GUILayout.Label("output folder: ..." + cacheDir);
                break;

            //On selecting weapon
            case 2:
                GUILayout.Label("Generate weapon data from: ..." + weaponCSV);
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Change Output directory"))
                    SelectFolder();
                if (GUILayout.Button("Set to default Output directory"))
                    DefaultLocation(weaponSOFolder);
                GUILayout.EndHorizontal();
                GUILayout.Label("output folder: ..." + cacheDir);
                break;
        }

        GUILayout.Space(15);

        Debug.Log(cacheDir);

        if (GUILayout.Button("Generate data :)"))
            InitiateDataConversion();
    }

    #region SET DIRECTORY
    //Open folder browser
    void SelectFolder()
    {
        string folderDir = EditorUtility.OpenFolderPanel("Select Directory", "", "");
        cacheDir = Application.dataPath + folderDir;
    }

    //Reset to default folder directory
    void DefaultLocation(string folderDir)
    {
        cacheDir = Application.dataPath + folderDir;
    }
    #endregion SET DIRECTORY

    //Init data conversion process by case
    void InitiateDataConversion()
    {
        if(cacheDir == null)
        {
            Debug.LogError("PLEASE SET OUTPUT DIRECTORY FIRST!!");
            return;
        }

        switch (index)
        {
            case 0:
                GenerateCharacter();
                break;
            case 1:

                break;
            case 2:

                break;
        }
    }

    #region GENERATE FUNCTION
    void GenerateCharacter()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + characterCSV);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');

            CharacterSO character = ScriptableObject.CreateInstance<CharacterSO>();
            character.charName =        splitData[0];
            character.health =          int.Parse(splitData[1]);
            character.armor =           int.Parse(splitData[2]);
            character.baseSpeed =       float.Parse(splitData[3]);
            character.maxSpeed =        float.Parse(splitData[4]);
            character.acceleration =    float.Parse(splitData[5]);

            AssetDatabase.CreateAsset(character, $"{characterSOFolder}/{character.charName}.asset");
        }

        AssetDatabase.SaveAssets();
    }

    void GenerateEnemy()
    {

    }

    void GenerateWeapon()
    {

    }
    #endregion GENERATE FUNCTION
}
