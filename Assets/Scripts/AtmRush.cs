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
        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }
    }


    public void StackCollectable(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = Collectables[index].transform.localPosition;
        newPos.z += 1.2f;
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

    private void MoveListElements()
    {
        for (int i = 1; i < Collectables.Count; i++)
        {
            Vector3 pos = Collectables[i].transform.localPosition;
            pos.x = Collectables[i - 1].transform.localPosition.x;
            Collectables[i].transform.DOLocalMove(pos, MovementDelay);
        }
    }

    private void MoveOrigin()
    {
        for (int i = 1; i < Collectables.Count; i++)
        {
            Vector3 pos = Collectables[i].transform.localPosition;
            pos.x = Collectables[0].transform.localPosition.x;
            Collectables[i].transform.DOLocalMove(pos, 0.70f);
        }
    }

}
