using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;

public static class SaveSystem
{
    public static void SaveData(GameManager _gameManager)
    {
        ProgressData data = new ProgressData();
        _gameManager.PopulateSaveData(data);

        if (WriteToFile("SaveData.dat", data.ToJson()))
            Debug.Log("Game saved!");
    }

    public static void LoadJsonData(GameManager _gameManager)
    {
        if (LoadFromFile("SaveData.dat", out var json))
        {
            ProgressData data = new ProgressData();
            data.LoadFromJson(json);

            _gameManager.LoadFromSaveData(data);
            Debug.Log("Load complete.");
        }
    }

    public static bool WriteToFile(string a_FileName, string a_FileContents)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, a_FileName);

        try
        {
            File.WriteAllText(fullPath, a_FileContents);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to write to { fullPath} with exception { e}");
        }
        return false;
    }

    public static bool LoadFromFile(string a_FileName, out string result)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, a_FileName);

        try
        {
            result = File.ReadAllText(fullPath);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to read from { fullPath} with exception { e}");
            result = "";
            return false;
        }
    }

    public static void RemoveFile()
    {
        string[] filePaths = Directory.GetFiles(Application.persistentDataPath);
        foreach (string filePath in filePaths)
            File.Delete(filePath);
        File.Delete("SaveData.dat");
        Debug.Log("File Deleted");
    }
}