using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAlert : MonoBehaviour
{
    public GameObject block;
    public GameObject ball;
    public float xPos;
    public float yPos;
    public float zPos;
    public Transform Ball;
    public bool IsColliding = false;

    void Update()
    {
        if (IsColliding)
            DespawnBall();
    }

    void OnCollisionEnter(Collision coll)
    {
        Debug.Log(block.transform.position);
        if (Ball.transform.position.x == block.transform.position.x && Ball.transform.position.y == block.transform.position.y && Ball.transform.position.z == block.transform.position.z)
        {
            Debug.Log("You reached the center!");
        }

        if (coll.gameObject.tag == "Object")
        {
            Debug.Log("Target Hit");
            xPos = Ball.transform.position.x;
            yPos = Ball.transform.position.y;
            zPos = Ball.transform.position.z;
        }

        if (coll.gameObject.tag == "ground")
        {
            IsColliding = true;
        }
    }

    //TODO Check when ball collides with mesh, then wait 3 seconds and destroy
    public void DespawnBall()
    {
        Destroy(GameObject.FindWithTag("ball"), 3);
    }
}
