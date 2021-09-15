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
    private Enemy_Ships _enemyShips;
    private UnderAttack_Controller _underAttackController;
    private List<GameObject> _bullets = new List<GameObject>();

    // Start is called before the first frame update
    void OnEnable()
    {
        _underAttackController = FindObjectOfType<UnderAttack_Controller>();
        _enemyShips = FindObjectOfType<Enemy_Ships>();
        _playerShip = GameObject.FindWithTag("Player");
        _target = _playerShip.transform.position;

        _numBullets = Quiz_Manager._instance._multoperand2;
        _maxDist = 20;//Random.Range(28f, 30f);     

        _changeTarget = false;
    }

    private void OnDisable()
    {
        StopCoroutine(ChangeTarget());
    }

    private void Update()
    {          
        if (_changeTarget)        
            _target = new Vector3(38,28,-40);        
        
        MoveTowards();

        if (IsPlayerWithinApproachRange())
        {
            if (_changeTarget)
                _enemyShips.ReturnShip(this.gameObject);
            else
                _moveSpeed = 0f;//StartCoroutine(ApproachSpeed());
        }                    

        HandleAttack();
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

    private void HandleAttack()
    {
        Collider[] _enemyShipColliders = transform.GetComponentsInChildren<Collider>();

        if (_bullets.Count >= 2)
        {
            StartCoroutine(ChangeTarget());
            //_changeTarget = true;
            _underAttackController._startAttack = false;
            _bullets.Clear();
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
        yield return new WaitForSeconds(1f);
        _changeTarget = true;        
        _moveSpeed = 20f;

        yield break;
    }
}
