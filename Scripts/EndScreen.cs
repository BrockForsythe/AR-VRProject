using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [TextArea(2, 6)]
    [SerializeField] string result = "Testing";
    public string GetResult()
    {
        return result;
    }

    //questionText.text = "Correct!";

    // Update is called once per frame
    void Update()
    {
        
    }
}
