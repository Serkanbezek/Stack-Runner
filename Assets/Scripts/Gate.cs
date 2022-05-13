using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            other.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            other.tag = "Gold";
        }
        else if (other.CompareTag("Gold"))
        {
            other.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
        }

    }
}
 
