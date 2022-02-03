using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObstacle : MonoBehaviour, IExplosive
{
    [SerializeField] private Sprite explosiveTexture;
    [SerializeField] private Sprite defaultTexture;


    public void Explode()
    {
        // gameObject.GetComponent<SpriteRenderer>().sprite = explosiveTexture;
        // Debug.Log("Before");
        // yield return new WaitForSeconds(0.2f);
        // Debug.Log("After");
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = defaultTexture;
    }
}