using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.ShipWeapons;
using UnityEditor;
using UnityEngine;

public class ShipArsenal : MonoBehaviour
{
    [SerializeField]
    public List<ShipWeapons> allWeapons;

    public List<GameObject> objWithWeapon;

    private int currentWeaponId = 0;

    private ShipWeapons _currentWeapon;
    [SerializeField] private ShipTarget shipReticle;
    
    public void Awake() {
        allWeapons = new List<ShipWeapons>();
        foreach (var obj in objWithWeapon)
        {
            allWeapons.Add(obj.GetComponent<ShipWeapons>());
        }
        if (allWeapons.Count > 0)
        {
            _currentWeapon = allWeapons.ElementAt(currentWeaponId);
        }
        InputManager.instance.setArsenal(this);
        InputManager.instance.SetWeapons(_currentWeapon);
    }

    public void Start()
    {
        _currentWeapon.Select();
    }

    public void nextWeapon()
    {
        currentWeaponId++;
        if (currentWeaponId >= allWeapons.Count)
        {
            currentWeaponId = 0;
        }
        _currentWeapon.Unselect();
        _currentWeapon = allWeapons[currentWeaponId];
        _currentWeapon.Select();
        InputManager.instance.SetWeapons(_currentWeapon);
    }

    // Вызывается при удалении объекта
    public void OnDestroy() {
        // Ничего не делать, если вызывается не в режиме игры
        if (Application.isPlaying == true) {
            InputManager.instance.RemoveWeapons(_currentWeapon);
        }
    }
    
}
