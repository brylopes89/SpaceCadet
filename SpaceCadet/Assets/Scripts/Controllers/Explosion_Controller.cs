using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Controller : MonoBehaviour
{
    private ParticleSystem _ps;

    void Start()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!_ps.IsAlive())
            Destroy(gameObject);
    }
}
