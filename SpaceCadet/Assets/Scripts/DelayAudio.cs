using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAudio : MonoBehaviour
{
    public float _delayTime;
    private AudioSource _source;
    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.PlayDelayed(_delayTime);
    }
}
