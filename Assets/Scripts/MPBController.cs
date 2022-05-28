using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPBController : MonoBehaviour
{
    [SerializeField] private Color GoldColor = Color.yellow;
    [SerializeField] private Color DiamondColor = Color.magenta;
    private Renderer _renderer = null;
    private MaterialPropertyBlock _materialPropertyBlock = null;
    public bool isGreen, isGold;

    private void Start()
    { 
        isGreen = true;
        isGold = false;
        _renderer = GetComponent<Renderer>();
        _materialPropertyBlock = new MaterialPropertyBlock();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate") && isGreen)
        {
            _materialPropertyBlock.SetColor("_Color", GoldColor);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
            isGold = true;
            isGreen = false;
        }
        else if (other.CompareTag("Gate") && isGold)
        {
            _materialPropertyBlock.SetColor("_Color", DiamondColor);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
            isGold = false;
        }
    }
}
