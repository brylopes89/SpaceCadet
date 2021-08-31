using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal_Controller : MonoBehaviour
{
    public GameObject[] _collectedCrystals;
    public GameObject[] _crystals;
    public GameObject[] _emptyCanisters;
    //public GameObject[] _randomCrystals;
    private int _index = 0;

    public void InitializeCrystals()
    {
        var _randomCrystals = new GameObject[_crystals.Length];
        
        for(int i = 0; i < _crystals.Length; i++)
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

        for (int i = 0; i < _emptyCanisters.Length; i++)        
            _collectedCrystals[i].SetActive(_emptyCanisters[i].activeInHierarchy);

        for (int i = 0; i < _crystals.Length; i++)
            _crystals[i].SetActive(false);
    }

    
}
