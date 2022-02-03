using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public IEnumerator Badabum()
    {
        yield return new WaitForSeconds(3);

        var hit = Physics2D.Raycast(transform.position, Vector2.left, 2f);
        if (hit.collider != null && hit.collider.GetComponent<IExplosive>() != null)
        {
            //StartCoroutine(hit.collider.GetComponent<IExplosive>().Explode());
            hit.collider.GetComponent<IExplosive>().Explode();
        }

        hit = Physics2D.Raycast(transform.position, Vector2.right, 2f);
        if (hit.collider != null && hit.collider.GetComponent<IExplosive>() != null)
        {
          //  StartCoroutine(hit.collider.GetComponent<IExplosive>().Explode());
          hit.collider.GetComponent<IExplosive>().Explode();
        }

        hit = Physics2D.Raycast(transform.position, Vector2.up, 2f);
        if (hit.collider != null && hit.collider.GetComponent<IExplosive>() != null)
        {
            //StartCoroutine(hit.collider.GetComponent<IExplosive>().Explode());
            hit.collider.GetComponent<IExplosive>().Explode();
        }

        hit = Physics2D.Raycast(transform.position, Vector2.down, 2f);
        if (hit.collider != null && hit.collider.GetComponent<IExplosive>() != null)
        {
            //StartCoroutine(hit.collider.GetComponent<IExplosive>().Explode());
            hit.collider.GetComponent<IExplosive>().Explode();
        }

        Destroy(gameObject);
    }
}