using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 scaleRate = new Vector3(1.2f, 1.2f, 1.2f);
    [SerializeField] private float scaleDuration = 0.8f;

    private void Start()
    {
        transform.DOScale(scaleRate, scaleDuration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetLink(gameObject);
    }
        
    private void Update()
    {
        if (GameManager.Instance.IsGameActive)
        {
            Destroy(gameObject);
        }
    }
}
