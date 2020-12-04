﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour {
    // Объем повреждений, наносимых объекту.
    public int damage = 1;
    // Объем повреждений, наносимых себе при попадании
    // в какой-то другой объект.
    public int damageToSelf = 5;
    void HitObject(GameObject theObject) {
        // Нанести повреждение объекту, в который попал данный объект,
        // если возможно.
        var theirDamage = theObject.GetComponentInParent<DamageTaking>();
        if (theirDamage) {
            theirDamage.TakeDamage(damage, transform);
        }
        // Нанести повреждение себе, если возможно
        var ourDamage = this.GetComponentInParent<DamageTaking>();
        if (ourDamage) {
            ourDamage.TakeDamage(damageToSelf, transform);
        }
    }
    // Объект вошел в область действия данного триггера?
    void OnTriggerEnter(Collider collider) {
        HitObject(collider.gameObject);
    }
    // Другой объект столкнулся с текущим объектом?
    void OnCollisionEnter(Collision collision) {
        HitObject(collision.gameObject);
    }
}