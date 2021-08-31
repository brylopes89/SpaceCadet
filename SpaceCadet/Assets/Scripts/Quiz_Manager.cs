using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Quiz_Manager : MonoBehaviour, ISaveable
{
    public static Quiz_Manager _instance;

    public int _correctAnswer;
    public int _multoperand1;
    public int _multoperand2;
    public int _divoperand1;   
    public int _divoperand2;
    public int _seed;

    private void Awake()
    {
        _instance = this;
        UnityEngine.Random.InitState(_seed);     
        
    }

    private void Start()
    {
        GetDivisionQuestion();
    }

    public void GetMultiplyQuestion()
    {
        KeyValuePair<int, int> val = GenerateIntDivisibleNoPair(2, 12);
        _multoperand1 = val.Value;
        _multoperand2 = val.Key;

        _correctAnswer = _multoperand1 * _multoperand2;
    }

    public void GetDivisionQuestion()
    {
        KeyValuePair<int, int> val = GenerateIntDivisibleNoPair(2, 12);
        _divoperand1 = val.Value * val.Key;
        _divoperand2 = val.Key;       

        _correctAnswer = _divoperand1 / _divoperand2;
    }


    public KeyValuePair<int, int> GenerateIntDivisibleNoPair(int p, int q)
    {
        if (p <= 0 || q <= 0 || q <= p)
            throw new Exception(); //for simplification of idea

        System.Random rand = new System.Random();
        int a = rand.Next(p, q + 1); //cannot be zero! note: maxValue put as q + 1 to include q
        int n = rand.Next(p, q + 1); //cannot be zero! note: maxValue put as q + 1 to include q

        return new KeyValuePair<int, int>(a, n);
    }


    public void PopulateSaveData(ProgressData progressData)
    {
        progressData.quizData.m_multoperand1 = _multoperand1;
        progressData.quizData.m_multoperand2 = _multoperand2;

        progressData.quizData.m_divoperand1 = _divoperand1;
        progressData.quizData.m_divoperand2 = _divoperand2;       
    }

    public void LoadFromSaveData(ProgressData progressData)
    {
        _multoperand1 = progressData.quizData.m_multoperand1;
        _multoperand2 = progressData.quizData.m_multoperand2;

        _divoperand1 = progressData.quizData.m_divoperand1;
        _divoperand2 = progressData.quizData.m_divoperand2;
    }
}
