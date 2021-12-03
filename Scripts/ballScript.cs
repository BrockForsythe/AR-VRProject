using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    private GameObject ball; //assigns object to script
    private Rigidbody rb; //gets the rigidbody of the object

    //for despawning stationary ball
    private bool ticking;
    private Coroutine run;
    public float despawn_timer = 5f; //how fast it despawns (in seconds)

    public static bool isColliding = false;
    public bool ballExists;

    //Ball Features
    //Made public so on deletion and recreation, ball stays the same color
    public bool red = false;
    public bool yellow = false;
    public bool green = true;
    public bool blue = false;

    public static bool armBack = false;
    public static bool pointing = false;
    public static bool stepping = false;
    public static bool torsoturn = false;
    public static bool targetHit = false;

    // Start is called before the first frame update
    void Start()
    {
        //ChooseBallColor();
        ball = this.gameObject;
        ChooseBallColor();
        rb = GetComponent<Rigidbody>();
    }

    //update runs every frame
    void Update()
    {
        InactivityCheck();
        CheckThrowing();
    }

    //checks if the ball hasnt been moving
    private void InactivityCheck()
    {
        if (rb.IsSleeping()) //checks if object is stationary
        {
            if (!ticking) //if clock isnt running starts it
            {
                run = StartCoroutine(InactiveTimer(despawn_timer));
                Debug.Log("Timer Started");
            }
        }
        else //object is moving
        {
            if (ticking) //if clock is running, stops it
            {
                StopCoroutine(run);
                ticking = false;
                Debug.Log("Timer Stopped");
            }
        }
    }

    //clocks for calculating inactivity
    IEnumerator InactiveTimer(float time)
    {
        ticking = true;
        var instruction = new WaitForEndOfFrame();

        while (time > 0)
        {
            time -= Time.deltaTime;
            Debug.Log("Time = " + time);
            yield return instruction;
        }
        ticking = false;
        Despawn();
    }

    public void CheckThrowing()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.rb.useGravity = true;
        }
    }

    //simple "despawn" setting activity to false
    public void Despawn()
    {
        //ball.SetActive(false);
        Destroy(ball);
        Spawn.ballExists = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ArmBack" || col.gameObject.tag == "Pointing" || col.gameObject.tag == "Stepping" || col.gameObject.tag == "Throwing")
        {
            isColliding = true;
        }
    }

    public void ChooseBallColor()
    {
        //Default is red
        if (red)
        {
            var cubeRenderer = ball.GetComponent<Renderer>();       //Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", Color.red);
        }
        if (yellow)
        {
            var cubeRenderer = ball.GetComponent<Renderer>();       //Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", Color.yellow);
        }
        if (green)
        {
            var cubeRenderer = ball.GetComponent<Renderer>();       //Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", Color.green);
        }
        if (blue)
        {
            var cubeRenderer = ball.GetComponent<Renderer>();       //Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.SetColor("_Color", Color.blue);
        }
    }

    public static void CheckSteps()
    {
        if (armBack && pointing && stepping && torsoturn) // 0 0 0 0
            Debug.Log("You got them all right!");
        if (armBack && pointing && stepping && !torsoturn) // 0 0 0 1
            Debug.Log("Turn your torso next time");
        if (armBack && pointing && !stepping && torsoturn) // 0 0 1 0
            Debug.Log("Step next time");
        if (armBack && pointing && !stepping && !torsoturn) // 0 0 1 1
        {
            Debug.Log("Turn your torso Next time");
            Debug.Log("Step next time");
        }
        if (armBack && !pointing && stepping && torsoturn) // 0 1 0 0
            Debug.Log("Point next time");
        if (armBack && !pointing && stepping && !torsoturn) // 0 1 0 1
        {
            Debug.Log("Point next time");
            Debug.Log("Turn your torso next time");
        }
        if (armBack && !pointing && !stepping && torsoturn) // 0 1 1 0
        {
            Debug.Log("Point next time");
            Debug.Log("Step next time");
        }
        if (armBack && !pointing && !stepping && !torsoturn) // 0 1 1 1
        {
            Debug.Log("Point next time");
            Debug.Log("Step next time");
            Debug.Log("Turn your torso next time!");
        }
        if (!armBack && pointing && stepping && torsoturn) // 1 0 0 0
        {
            Debug.Log("Bring your arm back nex time");
        }
        if (!armBack && pointing && stepping && !torsoturn) // 1 0 0 1
        {
            Debug.Log("Bring your arm back nex time");
            Debug.Log("Turn your torso next time!");
        }
        if (!armBack && pointing && !stepping && torsoturn) // 1 0 1 0
        {
            Debug.Log("Bring your arm back nex time");
            Debug.Log("Step next time!");
        }
        if (!armBack && pointing && !stepping && !torsoturn) // 1 0 1 1
        {
            Debug.Log("Bring your arm back nex time");
            Debug.Log("Step next time!");
            Debug.Log("Turn your torso next time!");
        }
        if (!armBack && !pointing && stepping && torsoturn) // 1 1 0 0
        {
            Debug.Log("Bring your arm back nex time");
            Debug.Log("Point next time");
        }
        if (!armBack && !pointing && stepping && !torsoturn) // 1 1 0 1
        {
            Debug.Log("Bring your arm back nex time");
            Debug.Log("Point next time");
            Debug.Log("Turn your torso next time!");
        }
        if (!armBack && !pointing && !stepping && torsoturn) // 1 1 1 0
        {
            Debug.Log("Bring your arm back nex time");
            Debug.Log("Point next time");
            Debug.Log("Step next time!");
        }
        if (!armBack && !pointing && !stepping && torsoturn) // 1 1 1 1
        {
            Debug.Log("Bring your arm back nex time");
            Debug.Log("Point next time");
            Debug.Log("Step next time!");
            Debug.Log("Turn your torso next time!");
        }
    }

}