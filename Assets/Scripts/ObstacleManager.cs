using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) DestroyItem(other.gameObject);
    }


    private void DestroyItem(GameObject collisionItem)
    {
        int collisionIndex = AtmRush.Instance.Collectables.IndexOf(collisionItem);

        if (collisionIndex == AtmRush.Instance.Collectables.Count - 1)
        {
            AtmRush.Instance.Collectables.RemoveAt(AtmRush.Instance.Collectables.Count - 1);
            Destroy(collisionItem);
        }
        else
        {
            for (int i = collisionIndex; i < AtmRush.Instance.Collectables.Count; i++)
            {
                AtmRush.Instance.Collectables[i].transform.localPosition = new Vector3(Random.Range(1.20f, -4.50f), AtmRush.Instance.Collectables[i].transform.localPosition.y, AtmRush.Instance.Collectables[i].transform.localPosition.z + Random.Range(6, 8));
                AtmRush.Instance.Collectables[i].transform.parent = null;
                AtmRush.Instance.Collectables[i].GetComponent<BoxCollider>().isTrigger = true;
                Destroy(AtmRush.Instance.Collectables[i].GetComponent<Rigidbody>());
                AtmRush.Instance.Collectables[i].GetComponent<Collision>().enabled = false;
            }
            AtmRush.Instance.Collectables.RemoveRange(collisionIndex, AtmRush.Instance.Collectables.Count - collisionIndex);
        }
    }
}
