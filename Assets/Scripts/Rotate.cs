using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float xSpeed = 0f;
    [SerializeField]
    private float ySpeed = 0f;
    [SerializeField]
    private float zSpeed = 0f;


    void Update()
    {
        transform.Rotate(
            Time.deltaTime * xSpeed,
            Time.deltaTime * ySpeed,
            Time.deltaTime * zSpeed,
            Space.Self);
    }
}
