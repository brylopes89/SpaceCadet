using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrashLanding_Controller : MonoBehaviour, ISaveable
{
    [Header("Class References")]
    [SerializeField]
    private TimerDisplay _timer;
    [SerializeField]
    private Crystal_Controller _crystalController;

    [Header("Animators")]
    [SerializeField]
    private Animator _panelAnimator;
    [SerializeField]
    private Animator _generatorAnim;
    [SerializeField]
    private Animator _generatorLidAnim;
    [SerializeField]
    private Animator _timerAnimator;

    [Header("UI")]
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
    [SerializeField]
    private Sprite[] _colorIndicators;

    [Header("Game Values")]
    [SerializeField]
    private int _amountNeeded = 10;
    [SerializeField]
    private int _numberCorrect;      
   
    [HideInInspector]
    public float _currentHealth;
    
    public bool _initiateNextSequence;

    private string _guess;
    private bool _firstActivated;
    private bool _success;   
    private int _currentGuess;
    private int _numberAttackCorrect;
    private Image _colorPanel;

    void Awake()
    {
        _firstActivated = PlayerPrefs.GetInt("FirstActivated") == 1 ? true : false;

        if (!_firstActivated)
        {
            _currentHealth = 0;
            _firstActivated = true;
 
            PlayerPrefs.SetInt("FirstActivated", _firstActivated ? 1 : 0);
        }
        else
        {
            GameManager._instance.LoadGame();
        }
        
    }

    private void Start()
    {
        _colorPanel = _timerDisplayText.gameObject.GetComponentInParent<Image>();
        _colorPanel.sprite = _colorIndicators[2];

        _initiateNextSequence = true;
        _timerAnimator.SetTrigger("Activate");

        _crystalController.InitializeCrystals();
    }

    void Update()
    {
        if (!_timer._startTimer)
            _inputField.DeactivateInputField();
       
        if (Input.GetButtonDown("Jump") && _initiateNextSequence)
            StartCrashScene();
        else if (Input.GetButtonDown("Submit"))
            Submit();
    }

    private void ResetValues()
    {
        _initiateNextSequence = false;
        _statusText.text = "LOCATION UNKNOWN";
        _success = false;
        _inputField.text = string.Empty;
        _problemText.text = string.Empty;
        _equationText.text = string.Empty;
        _guess = string.Empty;
    }

    public void StartCrashScene()
    {       
        _timerAnimator.SetTrigger("Deactivate");        

        StartCoroutine(StartTimer());

        _panelAnimator.SetBool("OpenPanel", true);    
        ResetValues();
             
        _answerButton.gameObject.SetActive(true);
    }

    public void Submit()
    {
        if (!_timer._startTimer && !_initiateNextSequence)
        {
            _timerDisplayText.text = "Please Stand By";
            return;
        }  

        bool _result = int.TryParse(_guess, out _currentGuess);
        if (!_result)
            return;

        if (_timer._startTimer)
            _timer._startTimer = false;        

        _inputField.text = Quiz_Manager._instance._correctAnswer.ToString();
        _inputField.DeactivateInputField();
        _answerButton.gameObject.SetActive(false);

        CheckGuess();       
    }

    public void CheckGuess()
    {
        if (_numberCorrect == _amountNeeded)
        {            
            return;
        }            

        if (_currentGuess != Quiz_Manager._instance._correctAnswer)
        {
            _success = false;
            _inputField.text = Quiz_Manager._instance._correctAnswer.ToString();

            StartCoroutine(InitiateChase());            
        }
        else
        {            
            _success = true;            
            
            _numberCorrect++;
            StartCoroutine(RefillHealth());
        }

        _crystalController.CollectCrystals();
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(2f);
        
        _timer.DisplayTime(_timer._time);
        _colorPanel.sprite = _colorIndicators[0];
        
        _problemText.text = Quiz_Manager._instance._divoperand1 + " CRYSTALS DETECTED\n\nDISTRIBUTE BETWEEN " + Quiz_Manager._instance._divoperand2 + " CANISTERS";
        _equationText.text = Quiz_Manager._instance._divoperand1 + "\u00F7" + Quiz_Manager._instance._divoperand2 + " =";

        _inputField.ActivateInputField();
        _inputField.Select();
        _timer._startTimer = true;
    }

    private IEnumerator ActivateGenerator()
    {
        _generatorLidAnim.SetTrigger("Close");

        yield return new WaitForSeconds(_generatorLidAnim.GetCurrentAnimatorStateInfo(0).length);

        //_generatorAnim.SetTrigger("Activate");        

        if (_success)
        {
            _generatorAnim.SetTrigger("Success");
            yield return new WaitForSeconds(.5f);
            _statusText.text = "CORRECT!";
        }

        else
        {
            _generatorAnim.SetTrigger("Fail");
            yield return new WaitForSeconds(.5f);
            _statusText.text = "INCORRECT!";
        }

        yield return new WaitForSeconds(_generatorAnim.GetCurrentAnimatorStateInfo(0).length);

        ResetValues();
    }   

    public IEnumerator InitiateChase() 
    {        
        _inputField.text = Quiz_Manager._instance._correctAnswer.ToString();

        if (_guess == "")
        {
            _timerDisplayText.text = "TIMES UP!";
            yield return new WaitForSeconds(3f);
        }
        _timerDisplayText.text = "CAUTION";        
        _colorPanel.sprite = _colorIndicators[3];

        yield return ActivateGenerator();

        GameManager._instance.SaveGame();
        StartCoroutine(FadeOutLoader._instance.FadeOut("AlienChase"));
    }

    private IEnumerator RefillHealth()
    {
        float i = 0.0f;
        float time = 4f;
        float rate = (1.0f / time) * 2f;
        float targetHealth = _currentHealth + 20;

        while(i < 1)
        {
            i += Time.deltaTime * rate;
            float ratio = i / time;

            if (ratio > 1.0f)
                break;

            _currentHealth = Mathf.Lerp(_currentHealth, targetHealth, ratio);

            yield return null;
        }

        yield return ActivateGenerator();
        
        if (_numberCorrect == _amountNeeded)
        {
            GameManager._instance.ResetData();
            StartCoroutine(FadeOutLoader._instance.FadeOut("CrashLandingDepart"));
        }            
        else
        {
            GameManager._instance.SaveGame();
            StartCoroutine(FadeOutLoader._instance.FadeOut("Field"));
        }   
            
    }

    public void AnswerInput(string _answer)
    {
        _guess = _answer;
    }

    public void PopulateSaveData(ProgressData progressData)
    {
        progressData.crashLandingData.m_currentHealth = _currentHealth;
        progressData.crashLandingData.m_numberCorrect = _numberCorrect;
        progressData.crashLandingData.m_success = _success;
        progressData.m_numCorrect = _numberAttackCorrect;

        //Debug.Log(progressData.m_numCorrect);
    }

    public void LoadFromSaveData(ProgressData progressData)
    {
        _numberAttackCorrect = progressData.m_numCorrect;
        _currentHealth = progressData.crashLandingData.m_currentHealth;
        _numberCorrect = progressData.crashLandingData.m_numberCorrect;
        _success = progressData.crashLandingData.m_success;

        //Debug.Log(progressData.m_numCorrect);
    }
}
