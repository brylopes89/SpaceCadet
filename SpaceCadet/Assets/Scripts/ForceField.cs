using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public Ship_Controller _shipController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (_shipController._stats._currentHealth <= 0)
        //{            
        //    Destroy(this);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Asteroid")
        //{
        //    Debug.Log("Hit");
        //    _shipController._stats._currentHealth -= collision.transform.GetComponent<Asteroid_Controller>()._stats._damage;
        //    Destroy(collision.gameObject);
        //}
    }
}
