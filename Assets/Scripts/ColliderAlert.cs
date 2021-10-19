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

    void Start()
    {
        
    }

    void Update()
    {
     
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
    }
}
