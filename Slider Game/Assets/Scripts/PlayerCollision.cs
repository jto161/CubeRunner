using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public TimeManager timeManager;
    public Rigidbody rb;
    private bool ended = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle" && !ended)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(0, 10f, 0, ForceMode.Impulse);
            rb.AddTorque(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f), ForceMode.Impulse);

            FindObjectOfType<GameManager>().EndGame();

            Debug.Log("End Game");
            ended = true;
        }
    }
}
