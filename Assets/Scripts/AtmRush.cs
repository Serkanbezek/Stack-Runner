using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AtmRush : MonoBehaviour
{
    public static AtmRush Instance;
    public float MovementDelay = 0.25f;
    public List<GameObject> Collectables = new List<GameObject>();
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        LerpListElements();
    }
    
    public void StackCollectable(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = Collectables[index].transform.localPosition;
        newPos.z += 1.1f;
        other.transform.localPosition = newPos;
        Collectables.Add(other);
        StartCoroutine(MakeObjectsBigger());
    }

    private IEnumerator MakeObjectsBigger()
    {
        for (int i = Collectables.Count - 1; i > 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;
            Collectables[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
            Collectables[index].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            yield return new WaitForSeconds(0.05f);

        }
    }

    private void LerpListElements()
    {
        float lerpValue = 20;
        for (int i = 1; i < Collectables.Count; i++)
        {
            Vector3 pos = Collectables[i].transform.localPosition;
            Vector3 finalPos = Collectables[i - 1].transform.localPosition;
            Collectables[i].transform.localPosition = new Vector3(Mathf.Lerp(pos.x, finalPos.x, Time.deltaTime * lerpValue), pos.y, pos.z);
        }
    }
}
