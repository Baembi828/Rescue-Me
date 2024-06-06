using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.35f, 5f),
        Mathf.Clamp(transform.position.y, -4.5f, 4f), transform.position.z);
    }
}
