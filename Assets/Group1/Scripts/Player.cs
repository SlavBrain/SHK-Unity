using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnDisable()
    {
        Progress.Instance.EndGame -= OnEndGame;
    }

    private void Update()
    {
        if (TryFindGameObjectsNearby(out List<GameObject> items))
        {
            foreach (GameObject item in items)
            {
                if (item != null)
                {
                    OnCollision(item);
                }
            }
        }

        Move();
    }

    public void OnEndGame()
    {
        enabled = false;
    }

    private void OnCollision(GameObject collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Hit(enemy);
        }
    }

    private void Hit(Enemy enemy)
    {
        enemy.TakeDamage();
    }

    private bool TryFindGameObjectsNearby(out List<GameObject> nearbyItems)
    {
        nearbyItems = new List<GameObject>();

        if (Progress.Instance.Enviroments.Count != 0)
        {
            foreach (GameObject item in Progress.Instance.Enviroments)
            {
                if (item == null)
                    continue;

                if (Vector3.Distance(transform.position, item.transform.position) < 0.2f)
                {
                    nearbyItems.Add(item);
                }
            }
        }

        return nearbyItems.Count != 0;
    }

    private void Move()
    {
        Vector3 direction = SetMoveDirection();

        if (direction != Vector3.zero)
        {
            transform.Translate(direction * _speed * Time.deltaTime);
        }
    }

    private Vector3 SetMoveDirection()
    {
        Vector3 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
            direction += Vector3.up;

        if (Input.GetKey(KeyCode.S))
            direction += Vector3.down;

        if (Input.GetKey(KeyCode.A))
            direction += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            direction += Vector3.right;

        return direction;
    }
}
