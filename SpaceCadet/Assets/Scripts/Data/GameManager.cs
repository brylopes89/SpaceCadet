using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, ISaveable
{
    public static GameManager _instance;

    public CrashLanding_Controller _clController;   
    public Quiz_Manager _quizManager;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        SaveSystem.RemoveFile();

    }

    public void ResetData()
    {
        //PlayerPrefs.DeleteAll();
        SaveSystem.RemoveFile();
        
    }

    public void SaveGame()
    {
        SaveSystem.SaveData(this);
    }

    public void LoadGame()
    {        
        SaveSystem.LoadJsonData(this);
    }

    public void PopulateSaveData(ProgressData progressData)
    {
        if (_clController != null)
            _clController.PopulateSaveData(progressData);

        if (_quizManager != null)
            _quizManager.PopulateSaveData(progressData);
    }

    public void LoadFromSaveData(ProgressData progressData)
    {
        if (_clController != null)
            _clController.LoadFromSaveData(progressData);

        if (_quizManager != null)
            _quizManager.LoadFromSaveData(progressData);
    }   
}
