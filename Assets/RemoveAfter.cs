using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfter : MonoBehaviour
{
    [SerializeField]
    private float destroyAfter = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyAfter);
    }

}
