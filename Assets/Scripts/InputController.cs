using System.Collections.Generic;
using Player;
using UnityEngine;
using Zenject;

public class InputController : MonoBehaviour, IInitializable
{
    private List<Transform> _targets;
    private Turret _turret;
    
    private Quaternion _newRotation;
    private Vector3 _direction;
    private int _halfScreenCoordinate;
    private int _currentIndex;

    private float _timer, _delay;
    private void Start()
    {
        Initialize();
    }
    
    public void Initialize()
    {
        _halfScreenCoordinate = Screen.width / 2;
        _newRotation = Quaternion.identity;
        _currentIndex = 0;
        _timer = 0f;

        _turret = gameObject.GetComponent<Turret>();
    }

    public void SetTargets(Transform targets)
    {
        _targets = new List<Transform>();
        foreach (Transform singleTarget in targets)
        {
            _targets.Add(singleTarget);
        }
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && _timer > _delay)
        {
            UpdateTarget();
            _timer = 0f;
        }
        _turret.transform.rotation = Quaternion.Lerp(_turret.transform.rotation, _newRotation, 
            _turret.RotationSpeed * Time.deltaTime);
    }

    private void UpdateTarget()
    {
        _currentIndex -= (Input.mousePosition.x > _halfScreenCoordinate) ? 1 : -1;

        if (_currentIndex > _targets.Count - 1) _currentIndex = 0;
        if (_currentIndex < 0) _currentIndex = _targets.Count - 1;

        _direction = _targets[_currentIndex].transform.position - _turret.transform.position;
        _direction.y = 0;
        _newRotation = Quaternion.LookRotation(_direction);
    }
}
