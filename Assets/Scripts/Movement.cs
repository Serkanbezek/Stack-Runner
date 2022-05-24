using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Singleton<Movement>
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float swipeSpeed;
    //private Vector3 firstPos, endPos;
    private float leftBound = -4.50f;
    private float rightBound = 1.20f;
    private float differenceX;
    private float lastFrameFingerPosX;
    public GameObject firstCollectable;

    private void Awake() => firstCollectable = AtmRush.Instance.Collectables[0];
    
    void Update()
    {
        if (AnimationManager.Instance.isGameActive == true)
        {
            ForwardMovement();
            HandleInput();
            ConstrainPlayer();
        }
    }

    private void HandleInput()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            differenceX = Input.mousePosition.x - lastFrameFingerPosX;
            lastFrameFingerPosX = Input.mousePosition.x;
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            differenceX = 0f;
        }
        firstCollectable.transform.Translate(differenceX * Time.deltaTime * swipeSpeed, 0, 0);
    }

    private void ForwardMovement() => transform.position += moveSpeed * Time.deltaTime * Vector3.forward;

    private void ConstrainPlayer()
    {
        GameObject firstCollectable = AtmRush.Instance.Collectables[0];
        var tempPos = firstCollectable.transform.localPosition;
        tempPos.x = Mathf.Clamp(tempPos.x, leftBound, rightBound);
        firstCollectable.transform.localPosition = tempPos;
    }

}
