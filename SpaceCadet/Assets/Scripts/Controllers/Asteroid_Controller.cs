using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Controller : MonoBehaviour
{
    private Quaternion _randomRotation;
    [SerializeField]
    private int _seed;

    private Asteroid_Field _field;


    void Start()
    {
        _field = FindObjectOfType<Asteroid_Field>();

        Random.InitState(_seed);
        _randomRotation = Random.rotation;

    }

    void Update()
    {
        transform.Rotate(_randomRotation.eulerAngles * 0.1f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            _field.ReturnAsteroid(this.gameObject);
            _field._objects.Remove(this.gameObject);

        }

    }
}
