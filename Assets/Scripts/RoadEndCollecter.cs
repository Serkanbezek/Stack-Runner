using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadEndCollecter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable") Destroy(other.gameObject);
    }
}
