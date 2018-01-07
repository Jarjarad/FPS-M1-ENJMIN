using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int StartAmmo = 10;
    public int StartLife = 100;
    public int MaxAmmo = 50;
    public int MaxLife = 100;

    private int ammo;
    private int life;

    void Start()
    {
        ammo = StartAmmo;
        life = StartLife;
    }

    public int GetAmmo()
    {
        return ammo;
    }

    public int GetLife()
    {
        return life;
    }

    public void AddAmmo(int numberToAdd)
    {
        ammo = Math.Min(ammo + numberToAdd, MaxAmmo);
    }

    public void UseAmmo(int numberToDel)
    {
        ammo = Math.Max(ammo - numberToDel, 0);
    }

    public void AddLife(int numberToAdd)
    {
        life = Math.Min(life + numberToAdd, MaxLife);
    }

    public void LooseLife(int numberToDel)
    {
        life = -numberToDel;
    }
}
