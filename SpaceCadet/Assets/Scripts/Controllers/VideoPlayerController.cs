using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer _alienPlayer; 
    public VideoPlayer _crashArrivalPlayer;
    public VideoPlayer _crashDepartPlayer;
    public VideoPlayer _underAttackSuccessPlayer;   

    public VideoClip[] _generatorClips;    

    public GameObject _generatorDisplay;
    public GameObject _lidDisplay;    

    public float _speed;

    [HideInInspector]
    public bool _playing = false;
    
    private CrashLanding_Controller _cl;
    public bool _rewind;

    private List<VideoPlayer> _videoPlayers = new List<VideoPlayer>();

    // Start is called before the first frame update
    void Awake()
    {
        if (_alienPlayer != null)
            _videoPlayers.Add(_alienPlayer);
        if (_crashArrivalPlayer != null)
            _videoPlayers.Add(_crashArrivalPlayer);
        if (_crashDepartPlayer != null)
            _videoPlayers.Add(_crashDepartPlayer);
        if (_underAttackSuccessPlayer != null)
            _videoPlayers.Add(_underAttackSuccessPlayer);
    }

    private void Start()
    {
        _cl = FindObjectOfType<CrashLanding_Controller>();

        foreach (VideoPlayer _player in _videoPlayers)
        {
            _player.frame = 0;
            _player.targetTexture.Release();
            _player.loopPointReached += EndReached;
        }
    }

    void EndReached(VideoPlayer vp)
    {               
        if(vp == _crashDepartPlayer || vp == _underAttackSuccessPlayer)                  
            StartCoroutine(FadeOutLoader._instance.FadeOut("UnderAttack"));        
        else        
            StartCoroutine(FadeOutLoader._instance.FadeOut("Field"));        
    }
}
