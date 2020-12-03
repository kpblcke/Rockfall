using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.ShipWeapons;
using UnityEngine;

public class BulletWeapon : MonoBehaviour, ShipWeapons {
    // Шаблон для создания лазеров
    public GameObject shotPrefab;
    // Список пушек для стрельбы лазером
    public Transform[] firePoints;
    // Задержка между выстрелами в секундах.
    public float fireRate = 0.2f;
    // Индекс в firePoints, указывающий на следующую пушку
    private int firePointIndex;
    
    [SerializeField]
    private ShipTarget reticle;
    public void Select()
    {
        reticle.setActive(true);
    }

    public void Unselect()
    {
        reticle.setActive(false);
    }
    
    public float getFireRate()
    {
        return fireRate;
    }

    // Вызывается диспетчером ввода InputManager.
    public void Fire() {
        // Если пушки отсутствуют, выйти
        if (firePoints.Length == 0)
            return;
        // Определить следующую пушку для выстрела
        var firePointToUse = firePoints[firePointIndex];
        // Создать новый снаряд с ориентацией,
        // соответствующей пушке
        Instantiate(shotPrefab, firePointToUse.position, firePointToUse.rotation);
        
        // Если пушка имеет компонент источника звука,
        // воспроизвести звуковой эффект
        var audio = firePointToUse.GetComponent<AudioSource>();
        if (audio) {
            audio.Play();
        }
        // Перейти к следующей пушке
        firePointIndex++;
        // Если произошел выход за границы массива,
        // вернуться к его началу
        if (firePointIndex >= firePoints.Length)
            firePointIndex = 0;
    }
}