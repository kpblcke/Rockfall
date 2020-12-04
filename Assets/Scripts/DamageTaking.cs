using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaking : MonoBehaviour {
    // Число очков прочности данного объекта
    public int hitPoints = 10;
    // При разрушении создать этот объект
    // в текущей позиции
    public GameObject destructionPrefab;

    public GameObject damagePrefab;
    // Завершить игру при разрушении данного объекта?
    public bool gameOverOnDestroyed = false;
    // Вызывается другими объектами (например, астероидами и шарами плазмы)
    // для нанесения повреждений
    public void TakeDamage(int amount, Transform atTransform) {
        // Вычесть amount из числа очков прочности
        hitPoints -= amount;
        // Очки исчерпаны?
        if (hitPoints <= 0) {
            // Удалить себя из игры
            Destroy(gameObject);
            // Задан шаблон для создания объекта в точке разрушения?
            if (destructionPrefab != null) {
                // Создать объект в текущей позиции
                // с текущей ориентацией.
                Instantiate(destructionPrefab, transform.position, transform.rotation);
            }
            // Если требуется завершить игру, вызвать
            // метод GameOver класса GameManager.
            if (gameOverOnDestroyed == true) {
                GameManager.instance.GameOver();
            }
        }
        else
        {
            if (damagePrefab != null)
            {
                Instantiate(damagePrefab, atTransform.position, atTransform.rotation, transform);
            }
        }
    }
}