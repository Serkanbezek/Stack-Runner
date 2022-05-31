using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public Button NextLevelButton;
    private IEnumerator OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            DropCollectables(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            GameManager.Instance.IsLevelFinished = true;
            other.transform.DOMove(new Vector3(0.048f, other.transform.position.y, other.transform.position.z + 5), 1).SetLink(other.gameObject).OnComplete(() =>
            other.GetComponent<Animator>().SetBool("isRunning", false));
            yield return new WaitForSeconds(1.5f);
            NextLevelButton.gameObject.SetActive(true);
        }
    }

    private void DropCollectables(GameObject collectable)
    {
        collectable.transform.parent = null;
        collectable.GetComponent<Collision>().enabled = false;
        Destroy(collectable.GetComponent<Rigidbody>());
        AtmRush.Instance.Collectables.Remove(collectable);
        collectable.AddComponent<MoveToAtm>();
    }

}
