using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject ball;
    public float xpos = 0;
    public float ypos = 0;
    public float zpos = 0;
    private bool ballExist = false;
    void Update()
    {
        if(ballExist == false)
        {
            if (Input.GetKey(KeyCode.W)) //Change to on push method for AR
            {
                SpawnBall();
                ballExist = true;
            }
        }

        if(ballExist == true)
        {
            if(Input.GetKey(KeyCode.M))
            {
                DespawnBall();
                ballExist = false;
            }
        }
        
    }

    void SpawnBall()
    {
        Instantiate(ball, new Vector3(xpos, ypos, zpos), Quaternion.identity);
    }
    void DespawnBall()
    {
        Destroy(GameObject.FindWithTag("ball"));
    }
}
