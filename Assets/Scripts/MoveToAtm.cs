using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAtm : MonoBehaviour
{
    private float speed = 8;
    private void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.left;
    }

}
