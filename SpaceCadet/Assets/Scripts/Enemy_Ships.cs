using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ships : MonoBehaviour
{
    public GameObject _shipPrefab;

    //public int[] _randomShip;

    public Vector3 _spawnRange;
    public LayerMask _layerMask;
    public int _seed;

    private GameObject[] _shipClones;
    private GameObject[] _selectedClones;

    private int _maxships = 12;
    private int _numberOfShips;
    private List<GameObject> _clones = new List<GameObject>();
    private Queue<GameObject> _shipPool = new Queue<GameObject>();


    public void GenerateEnemyShips()
    {

        _numberOfShips = Quiz_Manager._instance._multoperand1;

        //_randomShip = new int[_numberOfShips];        
        _shipClones = new GameObject[_maxships];

        Random.InitState(_seed);

        for (int i = 0; i < _maxships; i++)
        {
            //_randomShip[i] = Random.Range(0, ships.Length);
            //

            _shipClones[i] = Instantiate(_shipPrefab);
            Vector3 _randomSpawnPos = GetValidSpawnLocation(_shipClones[i]);
            _shipClones[i].transform.position = _randomSpawnPos;
            _shipClones[i].transform.rotation = Quaternion.identity;
            _shipClones[i].transform.parent = this.transform;
            _shipPool.Enqueue(_shipClones[i]);
            _clones.Add(_shipClones[i]);
        }

        for (int i = 0; i < _maxships - _numberOfShips; i++)
        {
            _clones[i].SetActive(false);
        }
    }

    private Vector3 GetValidSpawnLocation(GameObject go)
    {
        Collider _collider = go.GetComponentInChildren<Collider>();
        Vector3 _newPos = Vector3.zero;
        bool _validPos = false;

        int _failureLimit = _maxships;
        int _fails = 0;

        do
        {
            _newPos = new Vector3(transform.position.x + Random.Range(-_spawnRange.x, _spawnRange.x), transform.position.y + Random.Range(-_spawnRange.y, _spawnRange.y),
                                                                    transform.position.z + Random.Range(-_spawnRange.z, _spawnRange.z));

            Vector3 min = _newPos - _collider.bounds.extents;
            Vector3 max = _newPos + _collider.bounds.extents;

            Collider[] _overlapObjects = new Collider[1];

            int _numCollidersFound = Physics.OverlapBoxNonAlloc(go.transform.position, go.transform.localScale / 2, _overlapObjects, Quaternion.identity, _layerMask);

            if (_numCollidersFound == 0)
            {
                //Debug.Log("Good");
                _validPos = true;
                _fails = 0;
            }
            else
            {
                //Debug.Log("Overlapping has occured");
                _validPos = false;
                _fails++;
            }
        }

        while (!_validPos && _fails < _failureLimit);

        return _newPos;

    }

    public void GetShip()
    {
        _numberOfShips = Quiz_Manager._instance._multoperand1;
        _selectedClones = new GameObject[_numberOfShips];


        if (_shipPool.Count > 0)
        {
            for (int i = 0; i < _numberOfShips; i++)
            {
                _selectedClones[i] = _shipPool.Dequeue();
                _selectedClones[i].SetActive(true);
                _selectedClones[i].transform.position = new Vector3(transform.position.x + Random.Range(-_spawnRange.x, _spawnRange.x),
                                                                    transform.position.y + Random.Range(-_spawnRange.y, _spawnRange.y),
                                                                    transform.position.z + Random.Range(-_spawnRange.z, _spawnRange.z));
                _selectedClones[i].transform.rotation = Quaternion.identity;

            }
            //return _selectedClones[_numberOfShips];

        }
        else
        {
            GameObject _shipClone = Instantiate(_shipPrefab, new Vector3(transform.position.x + Random.Range(-_spawnRange.x, _spawnRange.x),
                                                                    transform.position.y + Random.Range(-_spawnRange.y, _spawnRange.y),
                                                                    transform.position.z + Random.Range(-_spawnRange.z, _spawnRange.z)), Quaternion.identity);

            _shipClone.transform.parent = this.transform;
            _clones.Add(_shipClone);

            //return _shipClone;
        }
    }
    public void ReturnShip(GameObject _ship)
    {
        _shipPool.Enqueue(_ship);
        _ship.SetActive(false);
        _clones.Clear();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _spawnRange * 2);
    }
}
