using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager
{
    private const string saveFileName = "calculator_save.json";
    public void Save(SaveData _data)
    {
        Debug.Log("Saving...");
        string json = JsonUtility.ToJson(_data);
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);
        File.WriteAllText(filePath, json);
    }
    public SaveData Load()
    {
        Debug.Log("Save file is located at: " + Application.persistentDataPath);
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<SaveData>(json);
        }

        return new SaveData
        {
            currentExpression = string.Empty,
            history = new List<string>()
        };
    }
}

[System.Serializable]
public class SaveData
{
    public string currentExpression;
    public List<string> history;
}