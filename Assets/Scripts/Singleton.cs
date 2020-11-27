using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    // Единственный экземпляр этого класса.
    private static T _instance;
    // Метод доступа. При первом вызове настраивает _instance.
    // Если требуемый объект не найден,
    // выводит сообщение об ошибке в журнал.
    public static T instance {
        get {
            // Если свойство _instance еще не настроено..
            if (_instance == null)
            {
                // ...попытаться найти объект.
                _instance = FindObjectOfType<T>();
                // Записать сообщение об ошибке в случае неудачи.
                if (_instance == null) {
                    Debug.LogError("Can't find "
                                   + typeof(T) + "!");
                }
            }
            // Вернуть экземпляр для использования!
            return _instance;
        }
    }
}