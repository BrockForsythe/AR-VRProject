using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerMovement : MonoBehaviour
{
    public float speed = 2.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
		    transform.position += Vector3.right * speed * Time.deltaTime;
	    }
        if (Input.GetKey(KeyCode.A))
        {
		    transform.position += Vector3.left * speed * Time.deltaTime;
	    }
        if (Input.GetKey(KeyCode.W))
        {
		    transform.position += Vector3.forward * speed * Time.deltaTime;
	    }
        if (Input.GetKey(KeyCode.S))
        {
		    transform.position += Vector3.back * speed * Time.deltaTime;
	    }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("{0} trigger enter: {1}", this, other);
    }
}
