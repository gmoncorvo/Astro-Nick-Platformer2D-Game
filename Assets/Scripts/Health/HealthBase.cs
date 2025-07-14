using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [Header("Stats")]
    public int startLife = 10;
    public bool destroyOnKill = false;

    public float delayToKill = 0f;

    private int _currentlife;
    private bool _isDead = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _currentlife = startLife;
        _isDead = false;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;
        _currentlife -= damage;

        if (_currentlife <= 0 )
        {
            kill();
        }
    }

    private void kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
    }
}
