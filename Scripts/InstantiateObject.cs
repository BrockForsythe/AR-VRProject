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
    private int gamePhase = 1;

    public bool hitboxExists = false;

    //Player Features
    public static bool leftHanded = false;
    public static bool rightHanded = true;

    public static float speed = 7.0f;

    void Start()
    {
        if (leftHanded)
            Instantiate(ArmBackBlock, new Vector3(-2.37f, 2.06f, -0.260f), Quaternion.identity);
        else
            Instantiate(ArmBackBlock, new Vector3(1.37f, 2.06f, -0.260f), Quaternion.identity);
        hitboxExists = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGamePhase();
    }

    void CheckGamePhase()
    {
        if (gamePhase == 0)
        {
            //ballScript.CheckSteps();
            Application.LoadLevel(1);
        }

        if (gamePhase == 1)
        {
            GamePhaseOne();
        }

        if (gamePhase == 2)
        {
            GamePhaseTwo();
        }

        if (gamePhase == 3)
        {
            GamePhaseThree();
        }

        if (gamePhase == 4)
        {
            GamePhaseFour();
        }
    }

    void GamePhaseOne()
    {
        if (ballScript.isColliding == true)
        {
            Destroy(GameObject.FindWithTag("ArmBack"));
            ballScript.isColliding = false;
            hitboxExists = false;
            ballScript.armBack = true;
            gamePhase += 1;
        }
    }

    void GamePhaseTwo()
    {
        if (!hitboxExists)
        {
            if(leftHanded)
                Instantiate(PointingBlock, new Vector3(-2.3194f, 4.47f, 4.8990f), Quaternion.identity);
            else
                Instantiate(PointingBlock, new Vector3(0.3194f, 4.47f, 4.8990f), Quaternion.identity);
            hitboxExists = true;
        }
            
        if (ballScript.isColliding == true)
        {
            Destroy(GameObject.FindWithTag("Pointing"));
            ballScript.isColliding = false;
            hitboxExists = false;
            ballScript.pointing = true;
            gamePhase += 1;
        }
    }

    void GamePhaseThree()
    {
        if (!hitboxExists)
        {
            if(leftHanded)
                Instantiate(SteppingBlock, new Vector3(-2.52f, 1.373f, 7.52f), Quaternion.identity);
            else
                Instantiate(SteppingBlock, new Vector3(0.52f, 1.373f, 7.52f), Quaternion.identity);
            hitboxExists = true;
        }
        if (ballScript.isColliding == true)
        {
            Destroy(GameObject.FindWithTag("Stepping"));
            ballScript.isColliding = false;
            hitboxExists = false;
            ballScript.stepping = true;
            gamePhase += 1;
        }
    }

    void GamePhaseFour()
    {
        if (!hitboxExists)
        {
            if(leftHanded)
                Instantiate(ThrowingBlock, new Vector3(-2.23f, 5.16f, 15.74f), Quaternion.identity);
            else
                Instantiate(ThrowingBlock, new Vector3(-0.23f, 5.16f, 15.74f), Quaternion.identity);
            hitboxExists = true;
        }
        if (ballScript.isColliding == true)
        {
            Destroy(GameObject.FindWithTag("Throwing"));
            ballScript.isColliding = false;
            hitboxExists = false;
            ballScript.targetHit = true;
            gamePhase = 0;
        }
    }
}
