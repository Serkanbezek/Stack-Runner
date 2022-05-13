using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float swipeSpeed;
    private Vector3 firstPos, endPos;
    private float offset = 100;
    private float leftBound = -6.1f;
    private float rightBound = 2.81f;
  
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        HandleInput();
        ConstrainPlayer();
    }

    private void HandleInput()
    {
        GameObject firstCollectable = AtmRush.Instance.Collectables[0];
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;

            float differenceX = (endPos.x - firstPos.x);
            firstCollectable.transform.Translate(differenceX * Time.deltaTime * swipeSpeed / offset, 0, 0);
        }
        if (Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
        }
    }
    private void ConstrainPlayer()
    {
        GameObject firstCollectable = AtmRush.Instance.Collectables[0];
        var tempPos = firstCollectable.transform.localPosition;
        tempPos.x = Mathf.Clamp(tempPos.x, leftBound, rightBound);
        firstCollectable.transform.localPosition = tempPos;
    }

}
