using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Singleton<Movement>
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float swipeSpeed;
    [SerializeField] private float SmoothTime = 0.3f;
    private float leftBound = -4.50f;
    private float rightBound = 1.20f;
    private float differenceX;
    private float lastFrameFingerPosX;
    public GameObject firstCollectable;
    private Vector3 playerVelocity = Vector3.zero;
    

    private void Start()
    {
        firstCollectable = AtmRush.Instance.Collectables[0];
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameActive && !GameManager.Instance.IsLevelFinished)
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
        firstCollectable.transform.localPosition = Vector3.SmoothDamp(firstCollectable.transform.localPosition, new Vector3(firstCollectable.transform.localPosition.x + (differenceX * swipeSpeed), firstCollectable.transform.localPosition.y, firstCollectable.transform.localPosition.z), ref playerVelocity, SmoothTime);
    }
    public void ForwardMovement() => transform.position += moveSpeed * Time.deltaTime * Vector3.forward;

    private void ConstrainPlayer()
    {
        var tempPos = firstCollectable.transform.localPosition;
        tempPos.x = Mathf.Clamp(tempPos.x, leftBound, rightBound);
        firstCollectable.transform.localPosition = tempPos;
    }

}
