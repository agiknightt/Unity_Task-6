using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform _pointsSpawn;
    [SerializeField] private GameObject _enemy;

    private List<Transform> _points = new List<Transform>();
    private float _spawnTime = 2;
    private float _elapsedTime = 0;

    private void Start()
    {
        for (int i = 0; i < _pointsSpawn.childCount; i++)
        {
            _points.Add(_pointsSpawn.GetChild(i).transform);
        }       
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnTime)
        {
            _elapsedTime = 0;

            RespawnEnemy();
        }        
    }
    private void RespawnEnemy()
    {
        if(_points.Count >= 1)
        {
            Instantiate(_enemy, _points[0].transform);
            _points.RemoveAt(0);
        }        
    }
}
