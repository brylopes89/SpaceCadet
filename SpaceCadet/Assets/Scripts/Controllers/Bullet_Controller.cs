using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float _bulletSpeed;
    public float _rotateSpeed;
    private GameObject _target;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");              

        //Destroy(gameObject, 3f);
    }

    private void Update()
    {
        var lookPos = _target.transform.position - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPos), _rotateSpeed * Time.deltaTime);
        transform.position += transform.forward * _bulletSpeed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Forcefield")
        {
            Destroy(gameObject);
        }
    }
}
