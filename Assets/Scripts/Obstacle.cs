using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            AtmRush.Instance.Collectables.Remove(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
