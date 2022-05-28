using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AtmRush : Singleton<AtmRush>
{
    public List<GameObject> Collectables = new List<GameObject>();
    private float lerpValue = 30;

    private void Update()
    {
        LerpListElements();
    }
    
    public void StackCollectable(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = new Vector3(Collectables[index].transform.localPosition.x, other.transform.localPosition.y, Collectables[index].transform.localPosition.z);
        newPos.z += 0.5f;
        other.transform.localPosition = newPos;
        Collectables.Add(other);
        StartCoroutine(MakeObjectsBigger());
    }

    private IEnumerator MakeObjectsBigger()
    {
        for (int i = Collectables.Count - 1; i > 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(1, 0.4f, 0.4f);
            scale *= 1.5f;
            Collectables[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
            Collectables[index].transform.DOScale(new Vector3(1, 0.4f, 0.4f), 0.1f));
            yield return new WaitForSeconds(0.05f);

        }
    }
    private void LerpListElements()
    {
        
        for (int i = 1; i < Collectables.Count; i++)
        {
            Vector3 pos = Collectables[i].transform.localPosition;
            Vector3 finalPos = Collectables[i - 1].transform.localPosition;
            Collectables[i].transform.localPosition = new Vector3(Mathf.Lerp(pos.x, finalPos.x, Time.deltaTime * lerpValue), pos.y, pos.z);
        }
    }

    public void DestroyItem(GameObject collisionItem)
    {
        int collisionIndex = Collectables.IndexOf(collisionItem);

        if (collisionIndex == Collectables.Count - 1)
        {
            Collectables.RemoveAt(Collectables.Count - 1);
            collisionItem.SetActive(false);
        }
        else
        {
            for (int i = collisionIndex; i < Collectables.Count; i++)
            {
                Collectables[i].transform.localPosition = new Vector3(Random.Range(1.20f, -4.50f), Collectables[i].transform.localPosition.y, Collectables[i].transform.localPosition.z + Random.Range(6, 8));
                Collectables[i].transform.parent = null;
                Collectables[i].GetComponent<BoxCollider>().isTrigger = true;
                Destroy(Collectables[i].GetComponent<Rigidbody>());
                Collectables[i].GetComponent<Collision>().enabled = false;
            }
            Collectables.RemoveRange(collisionIndex, Collectables.Count - collisionIndex);
        }
    }
        
}
