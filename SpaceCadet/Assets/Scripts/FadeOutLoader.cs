using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutLoader : MonoBehaviour
{
    public static FadeOutLoader _instance;
    private Animator _animator;

    private void Awake()
    {       
        _instance = this;      
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        //SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public void FadeOutScene(string _sceneName)
    {
        StartCoroutine(FadeOut(_sceneName));
    }

    public IEnumerator FadeOut(string _sceneName)
    {
        _animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(_sceneName);
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("Scene loaded: " + scene.name);

        var path = "Shaders/Levels/" + scene.name;
        var collection = Resources.Load<ShaderVariantCollection>(path);

        if (collection != null)
        {
            //Debug.Log("Shaders/variants: " + collection.shaderCount + "/" + collection.variantCount);

            collection.WarmUp();

            Resources.UnloadAsset(collection);
        }
    }
}
