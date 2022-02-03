using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour, IExplosive
{
    [SerializeField] private LayerMask raycastMask;
    [SerializeField] private DestructibleObstacleController destructObstController;
    [SerializeField] private GameObject bombPrefab;
    private Vector3 defaultPosition = new Vector3(-8, 0, 0);
    private bool isMovement;
    
    void Update()
    {
        if (isMovement)
        {
            return;
        }

        if (Input.GetKey((KeyCode.LeftArrow)))
        {
            MovePlayerTo(Vector2.left);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovePlayerTo(Vector2.right);
        }

        if (Input.GetKey((KeyCode.UpArrow)))
        {
            MovePlayerTo(Vector2.up);
        }

        if (Input.GetKey((KeyCode.DownArrow)))
        {
            MovePlayerTo(Vector2.down);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bomb = Instantiate(bombPrefab, transform.position, quaternion.identity);
            StartCoroutine(bomb.GetComponent<Bomb>().Badabum());
        }
    }

    private void MovePlayerTo(Vector2 dir)
    {
        if (Raycast(dir))
        {
            return;
        }

        isMovement = true;
        var pos = (Vector2) transform.position + dir;
        transform.DOMove(pos, 0.5f).OnComplete(() => { isMovement = false; });
    }

    private bool Raycast(Vector2 dir)
    {
        var hit = Physics2D.Raycast(transform.position, dir, 1f, raycastMask);
        return hit.collider != null;
    }


    public void Explode()
    {
        gameObject.SetActive(false);
       //  Debug.Log("Before");
       // // yield return new WaitForSeconds(0.4f);
       // yield return null;
       //  Debug.Log("After");
        RestartGame();
    }

    private void RestartGame()
    {
        destructObstController.RestartGame();
        transform.position = defaultPosition;
        gameObject.SetActive(true);
    }
}