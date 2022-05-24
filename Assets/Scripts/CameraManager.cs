using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Transform playerPos;
    private Transform AllCharactersPos;
    private float offSetX = 1.65f;
    private float offSetZ = 7.9f;

    private void Awake()
    {
        playerPos = Movement.Instance.firstCollectable.transform;
        AllCharactersPos = Movement.Instance.transform;
    }

    void LateUpdate() => transform.position = new Vector3(playerPos.localPosition.x + offSetX, transform.position.y, AllCharactersPos.position.z - offSetZ);
}
