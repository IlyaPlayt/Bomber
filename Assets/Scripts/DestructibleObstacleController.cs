using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObstacleController : MonoBehaviour
{
    private Transform[] children;

    void Start()
    {
        children = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
        }
    }

    public void RestartGame()
    {
        foreach (var child in children)
        {
            child.gameObject.SetActive(true);
        }
    }
}