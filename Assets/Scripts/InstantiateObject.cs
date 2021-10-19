using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    public GameObject ball;
    public GameObject ArmBackBlock;
    public GameObject PointingBlock;
    /*Need to check if player is lefty or righty to determine where block spawns*/
    public GameObject SteppingBlock;
    public GameObject ThrowingBlock;

    public bool ballExists = false;
    private float xpos = 1f;
    private float ypos = 2.65f;
    private float zpos = 1.65f;
    private int gamePhase = 1;

    public float speed = 7.0f;

    void Start()
    {
        Instantiate(ball, new Vector3(xpos, ypos, zpos), Quaternion.identity);
        Instantiate(ArmBackBlock, new Vector3(1.37f, 2.06f, -0.260f), Quaternion.identity);
        ballExists = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamePhase == 1)
        {
            Debug.Log(gamePhase);
            ball.transform.position += Vector3.back * speed * Time.deltaTime;
            if (ball.transform.position.x == ArmBackBlock.transform.position.x && ball.transform.position.y == ArmBackBlock.transform.position.y && ball.transform.position.z == ArmBackBlock.transform.position.z)
            {
                Destroy(GameObject.FindWithTag("ball"));
                Destroy(GameObject.FindWithTag("ArmBack"));
                ballExists = false;
                gamePhase += 1;
            }
        }

        if (gamePhase == 2)
        {
            Debug.Log(gamePhase);
            if (ballExists == false)
            {
                Instantiate(ball, new Vector3(xpos, ypos, zpos), Quaternion.identity);
                Instantiate(PointingBlock, new Vector3(0.3194f, 4.47f, 4.8990f), Quaternion.identity);
                ballExists = true;
            }

            if (Input.GetKey(KeyCode.F))
            {
                Destroy(GameObject.FindWithTag("ball"));
                Destroy(GameObject.FindWithTag("Pointing"));
                ballExists = false;
                gamePhase += 1;
            }
        }

        if (gamePhase == 3)
        {
            Debug.Log(gamePhase);
            if (ballExists == false)
            {
                Instantiate(ball, new Vector3(xpos, ypos - 1.6f, zpos), Quaternion.identity);
                Instantiate(SteppingBlock, new Vector3(0.52f, 0.373f, 5.52f), Quaternion.identity);
                ballExists = true;
            }
            
            if (Input.GetKey(KeyCode.G))
            {
                Destroy(GameObject.FindWithTag("ball"));
                Destroy(GameObject.FindWithTag("Stepping"));
                ballExists = false;
                gamePhase += 1;
            }
        }

        if (gamePhase == 4)
        {
            Debug.Log(gamePhase);
            if (ballExists == false)
            {
                Instantiate(ball, new Vector3(xpos, ypos, zpos), Quaternion.identity);
                Instantiate(ThrowingBlock, new Vector3(-0.23f, 5.16f, 9.74f), Quaternion.identity);
                ballExists = true;
            }

            if (Input.GetKey(KeyCode.H))
            {
                Destroy(GameObject.FindWithTag("ball"));
                Destroy(GameObject.FindWithTag("Throwing"));
                ballExists = false;
            }
        }
    }
}
