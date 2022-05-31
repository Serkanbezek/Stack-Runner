using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadEndCollecter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            GameManager.Instance.UpdateScore(other.GetComponent<MPBController>().ValueOfCollectable);
            Destroy(other.gameObject);
        }
        
    }
}
