using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float rotationSpeed;
    private Quaternion _newRotation;
    private Vector3 _direction;
    private int _halfScreenCoordinate;
    private int _currentIndex;

    private float _timer, _delay;
    private void Start()
    {
        _halfScreenCoordinate = Screen.width / 2;
        _newRotation = Quaternion.identity;
        _currentIndex = 0;
        _timer = 0f;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && _timer > _delay)
        {
            UpdateTarget();
            _timer = 0f;
        }
        player.transform.rotation = Quaternion.Lerp(transform.rotation, _newRotation, rotationSpeed * Time.deltaTime);
    }

    private void UpdateTarget()
    {
        _currentIndex -= (Input.mousePosition.x > _halfScreenCoordinate) ? 1 : -1;

        if (_currentIndex > targets.Count - 1) _currentIndex = 0;
        if (_currentIndex < 0) _currentIndex = targets.Count - 1;

        _direction = targets[_currentIndex].transform.position - player.transform.position;
        _direction.y = 0;
        _newRotation = Quaternion.LookRotation(_direction);
    }
}
