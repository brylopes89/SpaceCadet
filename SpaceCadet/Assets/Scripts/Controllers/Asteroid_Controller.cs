using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Asteroid_Stats
{
    public float _maxHealth;
    public float _currentHealth;
    public float _damage;
}

public class Asteroid_Controller : MonoBehaviour
{
    public Asteroid_Stats _stats;
    public GameObject _explosionPrefab;
    private Quaternion _randomRotation;
    public Asteroid_Field _field;
    private bool _spawned = false;

    void Start()
    {
        _field = FindObjectOfType<Asteroid_Field>();
        _stats._currentHealth = _stats._maxHealth;
        _randomRotation = Random.rotation;       
    }

    void Update()
    {
        transform.Rotate(_randomRotation.eulerAngles * 0.1f * Time.deltaTime);

        if (_stats._currentHealth <= 0)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (this.transform.localPosition.z >= 700f && !_spawned)
        {           
            _field.ReturnAsteroid(this.gameObject);
            _field._objects.Remove(this.gameObject);
            _spawned = true;
        }
            
    }
}
