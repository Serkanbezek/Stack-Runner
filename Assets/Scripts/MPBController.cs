using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPBController : MonoBehaviour
{
    [SerializeField] private Color GoldColor = Color.yellow;
    [SerializeField] private Color DiamondColor = Color.magenta;
    private Renderer _renderer = null;
    private MaterialPropertyBlock _materialPropertyBlock = null;
    public bool IsGreen, IsGold, IsDiamond;
    public int ValueOfCollectable;

    private void Start()
    { 
        IsGreen = true;
        IsGold = false;
        IsDiamond = false;
        ValueOfCollectable = 1;
        _renderer = GetComponent<Renderer>();
        _materialPropertyBlock = new MaterialPropertyBlock();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gate") && IsGreen)
        {
            _materialPropertyBlock.SetColor("_Color", GoldColor);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
            IsGold = true;
            ValueOfCollectable++;
            IsGreen = false;
        }
        else if (other.CompareTag("Gate") && IsGold)
        {
            _materialPropertyBlock.SetColor("_Color", DiamondColor);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
            IsDiamond = true;
            ValueOfCollectable++;
            IsGold = false;
            
        }
    }
}
