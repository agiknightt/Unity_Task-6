using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform _pointSpawn;

    private Color _targetColor = new Color(1,1,1,1);

    private void Update()
    {
        RespawnEnemy();        
    }

    private void RespawnEnemy()
    {
        for (int i = 0; i < _pointSpawn.childCount; i++)
        {
            if (i == 0)
            {
                ChangeColor(i);
            }
            else if (_pointSpawn.GetChild(i).GetComponent<SpriteRenderer>().color.a <= _targetColor.a && _pointSpawn.GetChild(i - 1).GetComponent<SpriteRenderer>().color.a >= _targetColor.a)
            {
                ChangeColor(i);
            }
        }
    }

    private void ChangeColor(int i)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_pointSpawn.GetChild(i).GetComponent<SpriteRenderer>().DOFade(1, 2)).SetRelative();
    }

    
}
