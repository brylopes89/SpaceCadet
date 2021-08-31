using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFieldScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    private bool _changeScene = false;

    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(ActivateScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && _changeScene)
        {
            StartCoroutine(FadeOutLoader._instance.FadeOut(_sceneName));
        }
    }

    private IEnumerator ActivateScene()
    {
        yield return new WaitForSeconds(3f);
        _changeScene = true;
    }
}
