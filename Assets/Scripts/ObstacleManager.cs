using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") AtmRush.Instance.DestroyItem(other.gameObject);
    }
}
