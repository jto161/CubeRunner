using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public Vector3 spin;
    public float speed;

    private void Update()
    {
        transform.Rotate(spin, speed * Time.deltaTime);
    }
}
