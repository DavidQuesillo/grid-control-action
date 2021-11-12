using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralEnemy : MonoBehaviour
{
    [SerializeField]
    private Vector2 whereToShoot;
    [SerializeField]
    private float timeToKeepGoing = 1f;

    [SerializeField]
    private Rigidbody2D rb;
    //[SerializeField]
    //private LayerMask enemyGridLayer;
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private EnemyBase eb;
    [SerializeField]
    private EnemyShoot es;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AdvanceAndAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CheckPointAtDirection(Vector2 dir)
    {
        Vector2 checkpos = (Vector2)transform.position + whereToShoot * 2.5f + dir * 2.5f ;
        Collider2D col = Physics2D.OverlapPoint(checkpos, playerLayer);
        //Collider2D enemycol = Physics2D.OverlapPoint(checkpos, enemyObjLayer);
        if (col == null)
        {
            return false;
        }
        return col.CompareTag("PlayerGrid");
        Debug.Log("player grid encontrada");
    }

    private IEnumerator AdvanceAndAttack()
    {
        while (true)
        {
            if (CheckPointAtDirection(eb.getDirection()))
            {
                rb.MovePosition((Vector2)transform.position + eb.getDirection() * 2.5f);
            }
            else
            {
                eb.RevertDirection();
                rb.MovePosition((Vector2)transform.position + eb.getDirection() * 2.5f);
            }

            yield return new WaitForSeconds(timeToKeepGoing);
        }
    }
}
