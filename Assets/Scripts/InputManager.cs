using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.ShipWeapons;
using UnityEngine;

public class InputManager : Singleton<InputManager> {
    // Джойстик, используемый для управления кораблем.
    public VirtualJoystick steering;

    private ShipArsenal _arsenal;

    // Текущий сценарий ShipWeapons управления стрельбой.
    private ShipWeapons currentWeapons;
        
    // Содержит true, если в данный момент ведется огонь.
    private bool isFiring = false;

    public void nextWeapon()
    {
        _arsenal.nextWeapon();
    }

    public void setArsenal(ShipArsenal arsenal)
    {
        this._arsenal = arsenal;
    }
    
    // Вызывается сценарием ShipWeapons для обновления
    // переменной currentWeapons.
    public void SetWeapons(ShipWeapons weapons) {
       this.currentWeapons = weapons;
    }
         
    // Аналогично; вызывается для сброса
    // переменной currentWeapons.
    public void RemoveWeapons(ShipWeapons weapons) {
        
        // Если currentWeapons ссылается на данный объект 'weapons', присвоить ей null.
        if (this.currentWeapons == weapons) {
            this.currentWeapons = null;
        }
    }
    
    public void RemoveArsenal(ShipArsenal arsenal) {
        
        if (_arsenal == arsenal) {
            _arsenal = null;
        }
    }
    
    // Вызывается, когда пользователь касается кнопки Fire.
    public void StartFiring() {
        if (isFiring)
        {
            return;
        }
        // Запустить сопрограмму ведения огня
        StartCoroutine(FireWeapons());
    }
     
    IEnumerator FireWeapons() {
        // Установить признак ведения огня
        isFiring = true;
             
        // Продолжать итерации, пока isFiring равна true
        while (isFiring) {
             
            // Если сценарий управления оружием зарегистрирован,
            // сообщить ему о необходимости произвести выстрел!
            if (this.currentWeapons != null) {
                currentWeapons.Fire();
            }
             
            // Ждать fireRate секунд перед
            // следующим выстрелом
            yield return new WaitForSeconds(currentWeapons.getFireRate());
                 
        }
    }
     
    // Вызывается, когда пользователь убирает палец с кнопки Fire
    public void StopFiring() {
        // Присвоить false, чтобы завершить цикл в
        // FireWeapons
        isFiring = false;
    }
}