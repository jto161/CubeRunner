using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public Rigidbody rb;

    public float obstacleSpeed;

    private bool move = true;
    private bool fling = false;

    private void Start()
    {
        obstacleSpeed = GameObject.Find("Spawner").GetComponent<Spawner>().obstacleSpeed;
    }

    private void Update()
    {
        if (transform.position.y < -5 || transform.position.z < -5)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (move)
        {
            rb.AddForce(0, 0, -obstacleSpeed * Time.fixedDeltaTime, ForceMode.Force);
        }

        else if(fling)
        {
            rb.AddForce(0, Random.Range(.2f, .5f), Random.Range(.4f, 1f), ForceMode.Impulse);
            rb.AddTorque(Random.Range(.2f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f), ForceMode.Impulse);
            fling = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            move = false;
            fling = true;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
