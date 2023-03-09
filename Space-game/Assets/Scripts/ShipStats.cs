using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour, IStats
{
    public float GetHealth()
    {
        return this.Health;
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    public float GetMoveSpeed()
    {
        return MoveSpeed;
    }

    public float GetTurnSpeed()
    {
        return TurnSpeed;
    }

    public float GetMoveAcceleration()
    {
        return MoveAcceleration;
    }

    public float GetFireRate()
    {
        return FireRate;
    }

    public void Initialize(IStats stats)
    {
        ShipStats shipStats = stats as ShipStats;
        this.Health = shipStats.Health;
        this.MaxHealth = shipStats.MaxHealth;
        this.MoveSpeed = shipStats.MoveSpeed;
        this.TurnSpeed = shipStats.TurnSpeed;
        this.FireRate = shipStats.FireRate;
        this.MoveAcceleration = shipStats.MoveAcceleration;
    }

    public void TakeDamage(float damage)
    {
        if ((this.Health -= damage) <= 0)
        {
            _onDestroy();
        }
    }

    public void SetOnDestroy(Action action)
    {
        this._onDestroy = action;
    }

    [SerializeField] private float Health;
    [SerializeField] private float MaxHealth;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float TurnSpeed;
    [SerializeField] private float FireRate;
    [SerializeField] private float MoveAcceleration;
    private Action _onDestroy;

    public ShipStats(float health, float maxHealth, float moveSpeed, float turnSpeed, float fireRate, float moveAcceleration)
    {
        Health = health;
        MaxHealth = maxHealth;
        MoveSpeed = moveSpeed;
        TurnSpeed = turnSpeed;
        FireRate = fireRate;
        MoveAcceleration = moveAcceleration;
    }
}
