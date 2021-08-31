using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Field : MonoBehaviour
{
    [SerializeField]
    private Queue<GameObject> _asteroidPool = new Queue<GameObject>();
    [SerializeField]
    private GameObject[] _asteroids;
    [SerializeField]
    private int _asteroidPoolSize;
    [SerializeField]
    private int[] _randomAsteroid;
    public Vector3 _spawnRange;
    [SerializeField]
    private float[] _speedRange;
    [SerializeField]
    private int _seed;

    //private GameObject[] _asteroidClones;
    public List<GameObject> _objects = new List<GameObject>();

    [SerializeField]
    private float _timeToSpawn = 30f;
    
    public float _timeSinceSpawn;

    void Start()
    {
        _randomAsteroid = new int[_asteroidPoolSize];
        _speedRange = new float[_asteroidPoolSize];
        //_asteroidClones = new GameObject[_asteroidPoolSize];

        Random.InitState(_seed);

        InstantiateAsteroids();
    }

    private void InstantiateAsteroids()
    {
        for (int i = 0; i < _asteroidPoolSize; i++)
        {
            _randomAsteroid[i] = Random.Range(0, _asteroids.Length);
            _speedRange[i] = Random.Range(12, 25);
            GameObject _asteroidClone = Instantiate(_asteroids[_randomAsteroid[i]], new Vector3(transform.position.x + Random.Range(-_spawnRange.x, _spawnRange.x),
                                                                    transform.position.y + Random.Range(-_spawnRange.y, _spawnRange.y),
                                                                    transform.position.z + Random.Range(-_spawnRange.z, _spawnRange.z)), Quaternion.identity);
            _asteroidClone.GetComponent<Rigidbody>().velocity = transform.forward * _speedRange[i];
            _asteroidClone.transform.parent = this.transform;

            _asteroidPool.Enqueue(_asteroidClone);
            _objects.Add(_asteroidClone);
        }
    }

    private void Update()
    {
        if(_objects.Count < _asteroidPoolSize)
        {
            NewAsteroidClones();
        }
    }

    public void NewAsteroidClones()
    {
        GameObject _asteroidClone = GetAsteroid();
        _asteroidClone.transform.position = new Vector3(transform.position.x + Random.Range(-_spawnRange.x, _spawnRange.x),
                                                            transform.position.y + Random.Range(-_spawnRange.y, _spawnRange.y),
                                                            transform.position.z + Random.Range(-_spawnRange.z, _spawnRange.z));
        _asteroidClone.transform.parent = this.transform;
        _asteroidClone.GetComponent<Rigidbody>().velocity = transform.forward * _speedRange[Random.Range(8, 15)];
        _objects.Add(_asteroidClone);
    }

    public GameObject GetAsteroid()
    {   
        if (_asteroidPool.Count > 0)
        {
            GameObject _asteroid = _asteroidPool.Dequeue();
            _asteroid.SetActive(true);
            return _asteroid;
        }
        else
        {
            GameObject _asteroidClone = Instantiate(_asteroids[_randomAsteroid[Random.Range(0, _randomAsteroid.Length)]], new Vector3(transform.position.x + Random.Range(-_spawnRange.x, _spawnRange.x),
                                                                    transform.position.y + Random.Range(-_spawnRange.y, _spawnRange.y),
                                                                    transform.position.z + Random.Range(-_spawnRange.z, _spawnRange.z)), Quaternion.identity);
            _asteroidClone.GetComponent<Rigidbody>().velocity = transform.forward * _speedRange[Random.Range(8, 15)];
            _asteroidClone.transform.parent = this.transform;
            _objects.Add(_asteroidClone);

            return _asteroidClone;
        }
    }
    public void ReturnAsteroid(GameObject _asteroid)
    {
        _asteroidPool.Enqueue(_asteroid);
        _asteroid.SetActive(false);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _spawnRange * 2);
    }
}
