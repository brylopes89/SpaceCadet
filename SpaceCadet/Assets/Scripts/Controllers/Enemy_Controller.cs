using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public Transform _firePoint;
    public GameObject _playerShip;
    public GameObject _bulletPrefab;
    private Vector3 _target;
    [HideInInspector]
    public int _numBullets;

    private bool _withinDistance;  

    private float _rotationSpeed = 2;
    private float _moveSpeed = 20f;    
    private float _maxDist;
    private float _time = 0;

    private bool _changeTarget;
    private UnderAttack_Controller _underAttackController;
    private List<GameObject> _bullets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {        
        _underAttackController = FindObjectOfType<UnderAttack_Controller>();
        _playerShip = GameObject.FindWithTag("Player");
        _target = _playerShip.transform.position;

        _numBullets = Quiz_Manager._instance._multoperand2;
        _maxDist = 28;//Random.Range(28f, 30f);     

        _changeTarget = false;
    }

    private void Update()
    {          
        if (_changeTarget)
        {
            _target = new Vector3(38,28,-40);            
            _withinDistance = false;
        }

        if (!_withinDistance)
            MoveTowards();

        if (IsPlayerWithinApproachRange())
        {
            if (_changeTarget)
                Destroy(this.gameObject);
            else
                _moveSpeed = 0f;//StartCoroutine(ApproachSpeed());
        }                    

        HandleAttack();
    }

    private void HandleAttack()
    {
        Collider[] _enemyShipColliders = transform.GetComponentsInChildren<Collider>();

        if (_bullets.Count >= 2)
        {
            StartCoroutine(ChangeTarget());
            //_changeTarget = true;
            _underAttackController._startAttack = false;
            return;
        }

        if (!_underAttackController._startAttack)
            return;        

        _time += Time.deltaTime;
        if (_time >= .15f)
        {
            _time = 0;
        }

        if (_time == 0)
        {
            GameObject _bulletClone = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);            
            _bullets.Add(_bulletClone);

            for (int x = 0; x < _enemyShipColliders.Length; x++)
            {
                Physics.IgnoreCollision(_bulletClone.transform.GetComponent<Collider>(), _enemyShipColliders[x]);
            }     
        }
    }

    private IEnumerator ChangeTarget()
    {       
        yield return new WaitForSeconds(2f);
        _changeTarget = true;        
        _moveSpeed = 20f;
    }

    void MoveTowards()
    {
        var lookPos = _target - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookPos), _rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }

    bool IsPlayerWithinApproachRange()
    {
        var distance = (_target - transform.position).magnitude;
       // Debug.Log(distance);
        return distance < _maxDist;
    }

    IEnumerator ApproachSpeed()
    {               
        float newSpeed = 0.0f;
        float time = .5f;        
        float i = 0.0f;
        float rate = (1 / time);

        while (i < time)
        {
            i += Time.fixedDeltaTime * rate;
            float ratio = i / time;

            if (ratio > 1.0f)//reaches %100
            {
                _withinDistance = true;
                _moveSpeed = 20f;

                //yield return new WaitForSeconds(.5f);
                //HandleAttack();
                break;
            }

            _moveSpeed = Mathf.SmoothStep(_moveSpeed, newSpeed, ratio);
            yield return null;
        }
    }
}
