using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private float _countDownTime;
    [SerializeField] private Text _countDownDisplay;
    [SerializeField] private CrashLanding_Controller _crashLanding;
    [SerializeField] private UnderAttack_Controller _underAttack;

    [HideInInspector]
    public float _time;
    [HideInInspector]
    public bool _startTimer = false;

    private void Start()
    {
        _time = _countDownTime;        
    }

    private void Update()
    {        
        if (_startTimer)
        {
            _time -= Time.deltaTime;
            DisplayTime(_time);
            if(_time <= 0.1)
            {                
                _time = _countDownTime;
                _startTimer = false;

                if(_underAttack != null)
                    StartCoroutine(_underAttack.InitiateAttack());

                if (_crashLanding != null)
                    _crashLanding.CheckGuess();
            }
        }
        else
        {
            _time = _countDownTime;
        }
    }

    public void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _countDownDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
