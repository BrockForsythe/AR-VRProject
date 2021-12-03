using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    public GameObject ball;
    public GameObject Spawner;
    static public bool ballExists = false;

    public void Start()
    {
        SpawnBall();
    }

    public void Update()
    {
        if (!ballExists)
            SpawnBall();
    }

    //Calls ChooseBallColor() to retain previously selected ball color.
    public void SpawnBall()
    {
        if (InstantiateObject.leftHanded)
        {
            Instantiate(ball, new Vector3(Spawner.transform.position.x - 4.0f, Spawner.transform.position.y, Spawner.transform.position.z), Quaternion.identity);
        }
        else
        { 
            Instantiate(ball, new Vector3(Spawner.transform.position.x, Spawner.transform.position.y, Spawner.transform.position.z), Quaternion.identity);
        }
        ballExists = true;
    }
}