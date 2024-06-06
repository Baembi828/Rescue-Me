using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.35f, 5f),
        Mathf.Clamp(transform.position.y, -4.8f, 0.5f), transform.position.z);
    }
}
