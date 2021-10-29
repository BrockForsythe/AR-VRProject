using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject ball;
    public GameObject Spawner;
    public bool ballExists = false;

    public void Start()
    {
        Instantiate(ball, new Vector3(Spawner.transform.position.x, Spawner.transform.position.y, Spawner.transform.position.z), Quaternion.identity);
        ballExists = true;
    }

    public void Update()
    {
        if(!ballExists)
            SpawnBall();
        DespawnBall();
    }

    public void SpawnBall()
    {
        Instantiate(ball, new Vector3(Spawner.transform.position.x, Spawner.transform.position.y, Spawner.transform.position.z), Quaternion.identity);
    }

    //TODO Check when ball collides with mesh, then wait 3 seconds and destroy
    public void DespawnBall()
    { 
        Destroy(GameObject.FindWithTag("ball"), 5);
        
    }
}
