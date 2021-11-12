using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancingEnemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private EnemyBase eb;
    [SerializeField]
    private LayerMask enemyGridLayer;
    [SerializeField]
    private LayerMask enemyObjLayer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveTowardsCenter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator MoveTowardsCenter()
    {
        while (true)
        {
            if (Random.Range(1, 5) <= 3)
            {
                if (CheckPointAtDirection(eb.getDirection()))
                {
                    rb.MovePosition((Vector2)transform.position + eb.getDirection() * 2.5f);
                }
                else
                {
                    Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + eb.getDirection() * 2.5f);
                    GridManager.instance.TakeSquareForEnemy(squareToTake);
                }
            }
            else
            {
                if (Random.Range(1, 3) < 2)
                {
                    if (CheckPointAtDirection(new Vector2(eb.getDirection().y, eb.getDirection().x)))
                    {
                        rb.MovePosition((Vector2)transform.position + new Vector2(eb.getDirection().y, eb.getDirection().x) * 2.5f);
                    }
                }
                else
                {
                    if (CheckPointAtDirection(new Vector2(eb.getDirection().y, -eb.getDirection().x)))
                    {
                        rb.MovePosition((Vector2)transform.position + new Vector2(eb.getDirection().y, -eb.getDirection().x) * 2.5f);
                    }
                    else
                    {
                        Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + eb.getDirection() * 2.5f);
                        GridManager.instance.TakeSquareForEnemy(squareToTake);
                    }
                }
            }
            yield return new WaitForSeconds(Random.Range(1, 2.5f));
        }
    }

    private bool CheckPointAtDirection(Vector2 dir)
    {
        Vector2 checkpos = (Vector2)transform.position + dir * 2.5f;
        Collider2D col = Physics2D.OverlapPoint(checkpos, enemyGridLayer);
        Collider2D enemycol = Physics2D.OverlapPoint(checkpos, enemyObjLayer);
        if (col == null || enemycol != null)
        {
            return false;
        }
        return col.CompareTag("EnemyGrid");
    }
}
