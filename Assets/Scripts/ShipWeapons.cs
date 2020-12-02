using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour {
    // Шаблон для создания снарядов
    public GameObject shotPrefab;
    // Список пушек для стрельбы
    public Transform[] firePoints;
    // Индекс в firePoints, указывающий на следующую
    // пушку
    private int firePointIndex;
    
    public void Awake() {
         // Когда данный объект запускается, сообщить
         // диспетчеру ввода, чтобы использовать его
         // как текущий сценарий управления оружием
    InputManager.instance.SetWeapons(this);
    }
    
    // Вызывается при удалении объекта
    public void OnDestroy() {
        // Ничего не делать, если вызывается не в режиме игры
        if (Application.isPlaying == true) {
            InputManager.instance.RemoveWeapons(this);
        }
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