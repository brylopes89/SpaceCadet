using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ships : MonoBehaviour
{
    public GameObject[] ships;
    
    public int[] _randomShip;

    public Vector3 _spawnRange;
    public int _seed;

    private GameObject[] _shipClones;
    private int _numberOfShips;
    private List<GameObject> _clones = new List<GameObject>();


    public void GenerateEnemyShips()
    {
        _numberOfShips = Quiz_Manager._instance._multoperand1;

        _randomShip = new int[_numberOfShips];        
        _shipClones = new GameObject[_numberOfShips];

        Random.InitState(_seed);

        for (int i = 0; i < _numberOfShips; i++)
        {
            _randomShip[i] = Random.Range(0, ships.Length);           
            _shipClones[i] = Instantiate(ships[_randomShip[i]], new Vector3(transform.position.x + Random.Range(-_spawnRange.x, _spawnRange.x), transform.position.y + Random.Range(-_spawnRange.y, _spawnRange.y),
                                                                    transform.position.z + Random.Range(-_spawnRange.z, _spawnRange.z)), Quaternion.identity);
            _shipClones[i].transform.parent = this.transform;

            _clones.Add(_shipClones[i]);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _spawnRange * 2);
    }
}
