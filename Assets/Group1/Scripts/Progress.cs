using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public static Progress Instance;

    [SerializeField] private GameObject _gameOverImage;
    [SerializeField] private Player _player;
    [SerializeField] private List<GameObject> _enviroment;

    public event Action EndGame;

    public IReadOnlyList<GameObject> Enviroments => _enviroment;

    private void Start()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;

        foreach (GameObject item in _enviroment)
        {
            if (item.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Die += OnEnemyDie;
            }
        }
    }

    private void OnEnable()
    {
        EndGame += _player.OnEndGame;
    }

    private void OnEnemyDie(Enemy enemy)
    {
        enemy.Die -= OnEnemyDie;
        _enviroment.Remove(enemy.gameObject);

        if (!HasEnemy())
        {
            EndGame?.Invoke();
            End();
        }
    }

    private bool HasEnemy()
    {
        return _enviroment.Where(item => item.TryGetComponent<Enemy>(out Enemy enemy)).ToList().Count > 0;
    }

    private void End()
    {
        _gameOverImage.SetActive(true);
    }
}
