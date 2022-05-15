using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            if (!AtmRush.Instance.Collectables.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.AddComponent<Collision>();
                other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
                other.gameObject.AddComponent<MPBController>();
                AtmRush.Instance.StackCollectable(other.gameObject, AtmRush.Instance.Collectables.Count - 1);
            }
        }
    }
}
