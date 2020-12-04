using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public SphereCollider collider;
    // Целевой объект для следования
    public Transform target;
    
    public float speed = 100f;

    // Время в секундах, через которое следует уничтожить снаряд
    public float life = 20.0f;

    [SerializeField] private float collideAfter = 1f;
    private Rigidbody rb;
    
    // Вызывается для каждого кадра
    void LateUpdate()
    {
        // Выйти, если цель не определена
        if (!target)
            return;

        transform.LookAt(target);
        rb.velocity = speed * Time.deltaTime * transform.forward;
    }
    
    void Start()
    {
        collider = GetComponent<SphereCollider>();
        collider.enabled = false;
        Asteroid targetAsteroid = FindObjectOfType<Asteroid>();
        if (targetAsteroid)
        {
            target = targetAsteroid.transform;
            transform.LookAt(target);
        }

        rb = GetComponent<Rigidbody>();
        // Уничтожить через 'life' секунд
        Destroy(gameObject, life);
    }

    IEnumerator startCollide()
    {
        yield return new WaitForSeconds(collideAfter);
        collider.enabled = true;
    }

}
