using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerShip;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _playerShip.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _playerShip.transform.position + _offset;
    }
}
