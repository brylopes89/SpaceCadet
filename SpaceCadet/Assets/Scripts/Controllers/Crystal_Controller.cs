using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crystal_Controller : MonoBehaviour
{
    public Sprite[] _collectedCrystals;
    public GameObject[] _crystals;
    public GameObject[] _emptyCanisters;

    public int[] _randomCollected;
    public int _seed;

    private void Start()
    {
        Random.InitState(_seed);
    }

    public void InitializeCrystals()
    {
        var _randomCrystals = new GameObject[_crystals.Length];

        for (int i = 0; i < _crystals.Length; i++)
        {
            int _take = Random.Range(i, _crystals.Length);
            _randomCrystals[i] = _crystals[_take];            

            _crystals[_take] = _crystals[i];
            _crystals[i] = _randomCrystals[i];
            _crystals[i].SetActive(true);
        }

        for (int i = 0; i < Quiz_Manager._instance._divoperand2; i++)
        {           
            if (i >= _emptyCanisters.Length)
                break;

            _emptyCanisters[i].SetActive(true);
        }
    }

    public void CollectCrystals()
    {
        _randomCollected = new int[_emptyCanisters.Length];

        for (int i = 0; i < _emptyCanisters.Length; i++)
        {
            var _sprite = _emptyCanisters[i].GetComponent<Image>().sprite;
            _randomCollected[i] = Random.Range(0, _collectedCrystals.Length);
            _emptyCanisters[i].GetComponent<Image>().sprite = _collectedCrystals[_randomCollected[i]];
            //_sprite = _collectedCrystals[_randomCollected[i]];
            //_collectedCrystals[i].SetActive(_emptyCanisters[i].activeInHierarchy);
        }
            

        //for (int i = 0; i < _emptyCanisters.Length; i++)        
            //_collectedCrystals[i].SetActive(_emptyCanisters[i].activeInHierarchy);

        for (int i = 0; i < _crystals.Length; i++)
            _crystals[i].SetActive(false);
    }

    
}
