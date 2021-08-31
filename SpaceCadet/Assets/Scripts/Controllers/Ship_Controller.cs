using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ship_Stats
{
    public float _maxShieldHealth;
    public float _maxEngineHealth;    
    public float _currentShieldHealth;
    public float _currentEngineHealth;
}

public class Ship_Controller : MonoBehaviour
{
    public GameObject _bullet;
    public Ship_Stats _stats;
    public GameObject _largeExplosionPrefab;
    public GameObject _smallExplosionPrefab;
    public GameObject _smallLightningPrefab;

    public AudioSource _shieldPowerUpSFX;
    public AudioSource _shieldPowerDownSFX;
    public AudioSource _impactSFX;
    public AudioSource _smallExplosionSFX;
    public AudioSource _engineFailure1;
    public AudioSource _engineFailure2;
    public AudioSource _shieldDamageSFX;

    public GameObject _largePlasmaPrefab;
    public GameObject _smallPlasmaPrefab;
    public GameObject _forceField;
    public UnderAttack_Controller _underAttackController;    

    [HideInInspector]
    public bool _switchHealth = false;

    public bool _activateForceField;
    public Material _forceFieldMat;

    private float _speed = 1.8f;
    private float _time = 0f;
    private float _fill;

    private bool _explosionActive = false;
    private bool _lightningActive = false;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed", 1);
        _forceFieldMat.SetFloat("_Fill", -2f);        
    
        _forceField.SetActive(false);

        _stats._currentEngineHealth = _stats._maxEngineHealth;
        _stats._currentShieldHealth = _stats._maxShieldHealth;       
    }

    private void Update()
    {        
        if (_stats._currentEngineHealth <= 0.1f)
        {            
            if (_time >= 2)
                _time = 0f;

            if (_time == 0f)
            {
                var _explosion = Instantiate(_largeExplosionPrefab, transform.position, Quaternion.identity);
                var _ps = _explosion.GetComponent<ParticleSystem>();
                var _main = _ps.main;
                _main.startDelayMultiplier = Random.Range(0.2f, 2f);
                _ps.Play();
                _smallExplosionSFX.PlayOneShot(_smallExplosionSFX.clip);
      
                _engineFailure2.Play();
                _animator.SetTrigger("Crash");                
            }

            _time += Time.deltaTime;
        }          

        if(_stats._currentShieldHealth <= 0.1f)
        {
            
        }

        if (_activateForceField)
        {
            StartCoroutine(ActivateForceField(true));
            //_shieldPowerUpSFX.PlayOneShot(_shieldPowerUpSFX.clip);
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;         

            Instantiate(_smallPlasmaPrefab, position, rotation);
            _impactSFX.PlayOneShot(_impactSFX.clip);

            if (_underAttackController._success)                     
                return;

            if (_switchHealth)
            {
                switch (_underAttackController._incorrectLow)
                {
                    case 1:
                        StartCoroutine(ReduceHealth(67f));                       
                        _animator.SetFloat("Speed", 2);       
                        break;
                    case 2:
                        StartCoroutine(ReduceHealth(34f));
                        _animator.SetFloat("Speed", 4);
                        _engineFailure1.Play();
                        if (!_explosionActive)
                        {
                            Instantiate(_smallExplosionPrefab, transform.position, Quaternion.identity);
                            _explosionActive = true;
                        }                        
                        break;
                    case 3:
                        StartCoroutine(ReduceHealth(0.09f));
                        if (_engineFailure1.isPlaying)
                            _engineFailure1.Stop();
                        _engineFailure2.Play();
                        break;
                }
            }
            else
            {
                switch (_underAttackController._incorrectHigh)
                {
                    case 1:
                        StartCoroutine(ReduceHealth(67f));
                        break;
                    case 2:
                        StartCoroutine(ReduceHealth(34f));
                        _shieldDamageSFX.Play();
                        if (!_lightningActive)
                        {
                            _smallLightningPrefab.SetActive(true);
                            _lightningActive = true;
                        }                        

                        break;
                    case 3:
                        StartCoroutine(ReduceHealth(0.09f));
                        Instantiate(_largePlasmaPrefab, position, rotation);
                        if (_shieldDamageSFX.isPlaying)
                            _shieldDamageSFX.Stop();

                        
                        _shieldPowerDownSFX.PlayOneShot(_shieldPowerDownSFX.clip);

                        _smallLightningPrefab.SetActive(false);
                        StartCoroutine(ActivateForceField(false));
                        
                        
                        //Destroy(_forceField);
                        break;
                }
            }             

            Destroy(collision.gameObject);
        }
    }

    private IEnumerator ActivateForceField(bool _activate)
    {
        if(_forceField.gameObject != null)
            _forceField.SetActive(true);      

        float currentFill = -2f;
        float newFill = 0.01f;
        float i = 0.0f;
        float time = 2.3f;
        float rate = (1.0f / time) * _speed;        

        while (i < 1)
        {
            i += Time.deltaTime * rate;
            float ratio = i / time;

            if (ratio > 1.0f)
            {
                break;
            }

            if(_activate)
                _fill = Mathf.Lerp(currentFill, newFill, i);
            else
                _fill = Mathf.Lerp(newFill, currentFill, i);

            _forceFieldMat.SetFloat("_Fill", _fill);            

            yield return null;
        }

        yield return new WaitForEndOfFrame();
        _activateForceField = false;
    }
    private IEnumerator ReduceHealth(float _targetHealth)
    {
        float i = 0.0f;
        float time = 4f;
        float rate = (1.0f / time) * _speed;

        while (i < 1)
        {
            i += Time.deltaTime * rate;
            float ratio = i / time;

            if (ratio > 1.0f)
            {
                break;
            }

            if(_switchHealth)
                _stats._currentEngineHealth = Mathf.Lerp(_stats._currentEngineHealth, _targetHealth, ratio);         
            else
                _stats._currentShieldHealth = Mathf.Lerp(_stats._currentShieldHealth, _targetHealth, ratio);

            yield return null;
        }

        yield return null;
    }
}