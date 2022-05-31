using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AtmManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            CollectItem(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    
    private void CollectItem(GameObject collisionItem)
    {
        int collisionIndex = AtmRush.Instance.Collectables.IndexOf(collisionItem);

        if (collisionIndex == AtmRush.Instance.Collectables.Count - 1 && collisionIndex != 0)
        {
            AtmRush.Instance.Collectables.RemoveAt(AtmRush.Instance.Collectables.Count - 1);
            Destroy(collisionItem);
            GameManager.Instance.UpdateScore(collisionItem.GetComponent<MPBController>().ValueOfCollectable);
        }
        else
        {
            for (int i = collisionIndex; i < AtmRush.Instance.Collectables.Count; i++)
            {
                //AtmRush.Instance.Collectables[i].transform.localPosition = new Vector3(Random.Range(1.20f, -4.50f), AtmRush.Instance.Collectables[i].transform.localPosition.y, AtmRush.Instance.Collectables[i].transform.localPosition.z + Random.Range(6, 8));
                AtmRush.Instance.Collectables[i].transform.DOJump(new Vector3(Random.Range(-2.7f, 2.7f), AtmRush.Instance.Collectables[i].transform.position.y, AtmRush.Instance.Collectables[i].transform.position.z + Random.Range(10, 12)), 2, 3, 0.8f);
                AtmRush.Instance.Collectables[i].transform.parent = null;
                AtmRush.Instance.Collectables[i].GetComponent<BoxCollider>().isTrigger = true;
                Destroy(AtmRush.Instance.Collectables[i].GetComponent<Rigidbody>());
                AtmRush.Instance.Collectables[i].GetComponent<Collision>().enabled = false;
            }
            AtmRush.Instance.Collectables.RemoveRange(collisionIndex, AtmRush.Instance.Collectables.Count - collisionIndex);
        }
    }
}
