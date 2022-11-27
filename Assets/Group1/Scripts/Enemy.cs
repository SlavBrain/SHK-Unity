using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _target;
    private float _speed = 2f;
    private float _maxTravetDistanse = 4f;

    public event System.Action<Enemy> Die;

    private void Start()
    {
        SetTarget();
    }

    private void Update()
    {
        MoveToTarget();
        if (IsInTarget())
        {
            SetTarget();
        }
    }

    public void TakeDamage()
#pragma warning restore SA1202 // Elements should be ordered by access
    {
            Die?.Invoke(this);
            Destroy(gameObject);
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
