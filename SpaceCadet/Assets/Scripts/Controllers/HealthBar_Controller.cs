using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Controller : MonoBehaviour
{
    public Ship_Controller _shipController;
    public CrashLanding_Controller _clController;

    public Slider _shieldHealthBar;
    public Slider _engineHealthBar;
 
    public Image _shieldFill;
    public Image _engineFill;
    public Material _forceFieldMat;
    public ParticleSystem _thrusters;

    public Color[] _fillColor = new Color[3];

    [ColorUsage(true, true)]
    public Color[] _emissionColor = new Color[3];

    public bool _isCrashLanding;
    private void Start()
    {
        _fillColor[0] = new Color(0, 255, 0);
        _fillColor[1] = new Color(255, 194, 0);
        _fillColor[2] = new Color(255, 0, 0);

        if (!_isCrashLanding)
        {
            _shieldHealthBar.wholeNumbers = true;
            _shieldHealthBar.minValue = 0;            
        }

        _engineHealthBar.wholeNumbers = true;
        _engineHealthBar.minValue = 0;
    }

    private void Update()
    {
        if (!_isCrashLanding)
            ShipHealthValues();
        else
            CrashHealthValues();        
    }

    private void ShipHealthValues()
    {
        _shieldHealthBar.maxValue = _shipController._stats._maxShieldHealth;
        _shieldHealthBar.value = _shipController._stats._currentShieldHealth;
        _engineHealthBar.maxValue = _shipController._stats._maxEngineHealth;
        _engineHealthBar.value = _shipController._stats._currentEngineHealth;

        _shieldFill.color = _fillColor[0];
        _engineFill.color = _fillColor[0];

        _forceFieldMat.SetVector("Color_Emission", _emissionColor[0]);
        var _emission = _thrusters.emission;
        var _velocityOL = _thrusters.velocityOverLifetime;
        _emission.rateOverTime = 100;
        _velocityOL.speedModifier = 12.5f;

        if (_shieldHealthBar.value <= 67f)
        {
            _shieldFill.color = _fillColor[1];
            _forceFieldMat.SetVector("Color_Emission", _emissionColor[1]);

        }

        if (_shieldHealthBar.value <= 34f)
        {
            _shieldFill.color = _fillColor[2];
            _forceFieldMat.SetVector("Color_Emission", _emissionColor[2]);

        }

        if (_engineHealthBar.value <= 67)
        {
            _engineFill.color = _fillColor[1];
            _emission.rateOverTime = 75;
            _velocityOL.speedModifier = 7f;
        }

        if (_engineHealthBar.value <= 34f)
        {
            _engineFill.color = _fillColor[2];
            _emission.rateOverTime = 25;
            _velocityOL.speedModifier = 1.2f;
        }

        if(_engineHealthBar.value <= 0)
        {
            _emission.rateOverTime = 0;
            _velocityOL.speedModifier = 0f;
        }
    }

    private void CrashHealthValues()
    {
        _engineHealthBar.maxValue = 100;
        _engineHealthBar.value = _clController._currentHealth;
        _engineFill.color = _fillColor[0];
        if (_engineHealthBar.value <= 67)
        {
            _engineFill.color = _fillColor[1];
        }
        if (_engineHealthBar.value <= 34f)
        {
            _engineFill.color = _fillColor[2];
        }
    }
}
