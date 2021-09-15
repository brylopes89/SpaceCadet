using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAlien : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _aliens;

    public int _index;

    void Start()
    {
        _index = PlayerPrefs.GetInt("AlienIndex");

        if (_index >= 3)
            _index = 0;

        _aliens[_index].SetActive(true);

        _index++;
        PlayerPrefs.SetInt("AlienIndex", _index);
    }
}
