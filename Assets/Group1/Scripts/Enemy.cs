using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _target;
    private float _speed = 2f;
    private float _maxTravetDistanse=4f;

    private void Start()
    {
        SetTarget();
    }

    private void Update()
    {
        MoveToTarget();
        if (IsInTarget())
            SetTarget();
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    private bool IsInTarget()
    {
        return transform.position == _target;
    }

    private void SetTarget()
    {
        _target = Random.insideUnitCircle * _maxTravetDistanse;
    }
}
