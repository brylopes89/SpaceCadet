using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAlien : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _aliens;

    public int _seed;

    private void Awake()
    {
        Random.InitState(_seed);
    }

    void Start()
    {
        _aliens[Random.Range(0, _aliens.Length)].SetActive(true);
    }
}
