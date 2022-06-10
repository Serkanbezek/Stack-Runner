using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float SmoothTime = 0.3f;
    private Transform playerPos;
    private Transform AllCharactersPos;
    private float offSetX = 1.65f;
    private float offSetZ = 7.9f;
    private Vector3 camVelocity = Vector3.zero;
    

    private void Start()
    {
        playerPos = Movement.Instance.firstCollectable.transform;
        AllCharactersPos = Movement.Instance.transform;
    }

    void LateUpdate() => transform.position = Vector3.SmoothDamp(transform.position, new Vector3(playerPos.localPosition.x + offSetX, transform.position.y, AllCharactersPos.position.z - offSetZ), ref camVelocity, SmoothTime);
}
