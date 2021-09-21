using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnderAttack_Controller : MonoBehaviour
{
    [Header("Class References")]
    [SerializeField]
    private Ship_Controller _shipController;
    [SerializeField]
    private Enemy_Ships _enemyShip;
    [SerializeField]
    private TimerDisplay _timer;

    [Header("Animators")]
    [SerializeField]
    private Animator _topPanelAnimator;
    [SerializeField]
    private Animator _timerAnimator;

    [Header("UI")]
    [SerializeField]
    private Sprite[] _colorIndicators;
    [SerializeField]
    private InputField _inputField;
    [SerializeField]
    private Text _equationText;
    [SerializeField]
    private Text _problemText;
    [SerializeField]
    private Text _statusText;
    [SerializeField]
    private Text _timerDisplayText;
    [SerializeField]
    private Button _answerButton;

    [Header("Game Values")]
    [SerializeField]
    private int _amountNeeded;
    public int _numberCorrect;

    [HideInInspector]
    public bool _initiateNextSequence;
    [HideInInspector]
    public bool _success;
    [HideInInspector]
    public int _incorrectHigh;
    [HideInInspector]
    public int _incorrectLow;
    [HideInInspector]
    public bool _startAttack;

    private string _guess;
    public bool _firstActivated;
    private bool _inFlight;
    private bool _shieldActivated;
    private bool _submitted;

    private Image _colorPanel;


    void Start()
    {        
        _firstActivated = PlayerPrefs.GetInt("FirstActivated") == 1 ? true : false;

        if (_firstActivated)
        {
            _firstActivated = false;
            _numberCorrect = PlayerPrefs.GetInt("NumberCorrect");
            PlayerPrefs.SetInt("FirstActivated", _firstActivated ? 1 : 0);
        }
        else
        {
            PlayerPrefs.DeleteAll();            
        }        

        _initiateNextSequence = true;
        _colorPanel = _timerDisplayText.gameObject.GetComponentInParent<Image>();
        _colorPanel.sprite = _colorIndicators[1];

        StartCoroutine(StartFlightCourse());
    }

    void Update()
    {
        if (_inFlight)
            return;

        if (!_timer._startTimer)
            _inputField.DeactivateInputField();

        if (Input.GetButtonDown("Jump") && _initiateNextSequence)
            StartAttackScene();
        else if (Input.GetButtonDown("Submit"))
            Submit();
    }

    private void ResetValues()
    {
        if (_incorrectHigh >= 3 || _incorrectLow >= 3)
        {
            _problemText.text = "WE'RE GOING DOWN!";
        }

        else
        {
            _problemText.text = string.Empty;
        }

        _success = false;
        _submitted = false;
        _inputField.text = string.Empty;
        _equationText.text = string.Empty;
        _timerDisplayText.text = string.Empty;
        _guess = string.Empty;

        _colorPanel.sprite = _colorIndicators[1];
    }

    private void StartAttackScene()
    {
        _timerAnimator.SetTrigger("Deactivate");

        if (_numberCorrect == _amountNeeded)
        {
            BeginWinSequence();
            return;
        }

        if (_incorrectHigh >= 3 || _incorrectLow >= 3)
        {
            BeginCrashSequence();
            return;
        }
        _initiateNextSequence = false;
        StartCoroutine(StartTimer());
        Quiz_Manager._instance.GetMultiplyQuestion();
        ResetValues();
        _answerButton.gameObject.SetActive(true);

        if (!_shieldActivated)
        {
            _topPanelAnimator.SetBool("OpenPanel", true);
            _shipController._activateForceField = true;
            _shieldActivated = true;
            _enemyShip.GenerateEnemyShips();
        }
        else
        {
            _enemyShip.GetShip();
        }

    }

    private void Submit()
    {
        if (!_timer._startTimer)
        {
            _timerDisplayText.text = "Please Stand By";
            return;
        }

        int _currentGuess;

        bool _result = int.TryParse(_guess, out _currentGuess);
        if (!_result)
            return;

        if (_currentGuess > Quiz_Manager._instance._correctAnswer)
            GuessTooHigh();

        if (_currentGuess < Quiz_Manager._instance._correctAnswer)
            GuessTooLow();

        if (_currentGuess == Quiz_Manager._instance._correctAnswer)
            Success();

        _submitted = true;
        _inputField.text = Quiz_Manager._instance._correctAnswer.ToString();
        _inputField.DeactivateInputField();

        StartCoroutine(InitiateAttack());
        _answerButton.gameObject.SetActive(false);

    }

    private IEnumerator StartTimer()
    {
        _statusText.text = "Looks like we got company!";
        yield return new WaitForSeconds(5f);

        _colorPanel.sprite = _colorIndicators[0];
        _timer.DisplayTime(_timer._time);
        _inputField.ActivateInputField();
        _inputField.Select();
        _timer._startTimer = true;

        DisplayProblem();
    }

    private IEnumerator StartFlightCourse()
    {
        _inFlight = true;
        _answerButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        _inFlight = false;
        _timerAnimator.SetTrigger("Activate");
    }

    private void DisplayProblem()
    {
        _problemText.text = "There are " + Quiz_Manager._instance._multoperand1 + " PIRATES each firing " + Quiz_Manager._instance._multoperand2 + " missiles! How much energy should we put into our shields?";
        _equationText.text = Quiz_Manager._instance._multoperand1 + "x" + Quiz_Manager._instance._multoperand2 + " = ";
    }

    public IEnumerator InitiateAttack()
    {
        if (_guess == "" || !_submitted)
        {
            _timerDisplayText.text = "TIMES UP!";
            _shipController._switchHealth = true;
            _incorrectLow++;
            yield return new WaitForSeconds(2f);
        }

        _timer._startTimer = false;
        _startAttack = true;

        _colorPanel.sprite = _colorIndicators[3];
        _timerDisplayText.text = "CAUTION";
        _inputField.text = Quiz_Manager._instance._correctAnswer.ToString();

        while (_startAttack)
            yield return null;

        yield return new WaitForSeconds(5);

        _initiateNextSequence = true;
        ResetValues();
        _timerAnimator.SetTrigger("Activate");
    }

    private void Success()
    {
        _numberCorrect++;
        _statusText.text = "CORRECT!";
        _problemText.text = "Great job Cadets.";
        _success = true;

        PlayerPrefs.SetInt("NumberCorrect", _numberCorrect);
    }

    private void GuessTooHigh()
    {
        _incorrectHigh++;
        _statusText.text = "INCORRECT!";
        _problemText.text = "We've overloaded our shields!";
        _shipController._switchHealth = false;
    }

    private void GuessTooLow()
    {
        _incorrectLow++;
        _statusText.text = "INCORRECT!";
        _problemText.text = "We're taking damage to our engines!";
        _shipController._switchHealth = true;
    }

    private void BeginWinSequence()
    {
        _topPanelAnimator.SetBool("OpenPanel", false);
        _statusText.text = "We're all clear cadets. Looks like smooth sailing from here on out.";
        _timerDisplayText.text = string.Empty;

        _colorPanel.sprite = _colorIndicators[1];
        _answerButton.gameObject.SetActive(false);
        //GameManager._instance.ResetData();
        StartCoroutine(FadeOutLoader._instance.FadeOut("UnderAttackSuccess"));
    }

    private void BeginCrashSequence()
    {
        StartCoroutine(FadeOutLoader._instance.FadeOut("CrashLandingArrival"));
    }

    public void AnswerInput(string _answer)
    {
        _guess = _answer;
    }
}
