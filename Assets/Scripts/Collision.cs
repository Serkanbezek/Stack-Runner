using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void Awake()
    {
        if (gameObject.tag == "Collectable")
        {
            enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            if (!AtmRush.Instance.Collectables.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.GetComponent<Collision>().enabled = true;
                other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
                AtmRush.Instance.StackCollectable(other.gameObject, AtmRush.Instance.Collectables.Count - 1);
            }
        }
    }
}
