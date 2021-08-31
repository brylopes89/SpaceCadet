using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressData 
{
    [System.Serializable]
    public struct UnderAttackData
    {
        public int m_numberCorrect;
    }

    [System.Serializable]
    public struct CrashLandingData
    {
        public float m_currentHealth;
        public int m_numberCorrect;
        public bool m_firstActivated;
        public bool m_sequenceFinished;
        public bool m_success;
        public bool m_initiateNextSequence;
    }   

    [System.Serializable]
    public struct CrystalData
    {
        public List<bool> m_stateOfCrystals;
        public List<bool> m_stateOfCollected;
        public int m_index;
    }

    [System.Serializable]
    public struct QuizData
    {
        public int m_index;
        public int m_multoperand1;
        public int m_multoperand2;
        public int m_divoperand1;
        public int m_divoperand2;
    }

    public CrashLandingData crashLandingData;    
    public UnderAttackData underAttackData;
    public int m_numCorrect;
    public CrystalData crystalData;
    public QuizData quizData;
 
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }
}

public interface ISaveable
{
    void PopulateSaveData(ProgressData progressData);
    void LoadFromSaveData(ProgressData progressData);
}
