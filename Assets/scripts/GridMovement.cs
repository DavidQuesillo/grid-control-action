using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    //public Vector2[,] spaces = new Vector2[3,3];
    //public Vector2 currentLocation = new Vector2(2, 2);

    //public List<Vector2> spots;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Attributes playerHp = new Attributes(10);
    [SerializeField]
    private float hpAmount = 3f;
    [SerializeField]
    private LayerMask gridLayer;

    // Start is called before the first frame update
    void Start()
    {
        playerHp.SetNewValue(hpAmount);

        /*spaces[0, 0] = spots.ToArray()[0];
        spaces[1, 0] = spots.ToArray()[1];
        spaces[2, 0] = spots.ToArray()[2];
        spaces[0, 1] = spots.ToArray()[3];
        spaces[1, 1] = spots.ToArray()[4];
        spaces[2, 1] = spots.ToArray()[5];
        spaces[0, 2] = spots.ToArray()[6];
        spaces[1, 2] = spots.ToArray()[7];
        spaces[2, 2] = spots.ToArray()[8];*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (CheckPointAtDirection(Vector2.up))
            {
                rb.MovePosition((Vector2)transform.position + Vector2.up * 2.5f);
            }

            /*if (currentLocation.y > 0)
            {
                currentLocation.y -= 1;
                rb.MovePosition(spaces[(int)currentLocation.x, (int)currentLocation.y]);
            }*/
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (CheckPointAtDirection(Vector2.down))
            {
                rb.MovePosition((Vector2)transform.position + Vector2.down * 2.5f);
            }

            /*if (currentLocation.y < 2)
            {
                currentLocation.y += 1;
                rb.MovePosition(spaces[(int)currentLocation.x, (int)currentLocation.y]);
            }*/
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (CheckPointAtDirection(Vector2.left))
            {
                rb.MovePosition((Vector2)transform.position + Vector2.left * 2.5f);
            }

            /*if (currentLocation.x > 0)
            {
                currentLocation.x -= 1;
                rb.MovePosition(spaces[(int)currentLocation.x, (int)currentLocation.y]);
            }*/
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            /*if (Physics2D.OverlapPoint(CheckPointAtDirection(Vector2.right), gridLayer).CompareTag("PlayerGrid"))
            {
                rb.MovePosition((Vector2)transform.position + Vector2.right * 2.5f);
            }*/

            if (CheckPointAtDirection(Vector2.right))
            {
                rb.MovePosition((Vector2)transform.position + Vector2.right * 2.5f);
            }

            /*if (currentLocation.x < 2)
            {
                currentLocation.x += 1;
                rb.MovePosition(spaces[(int)currentLocation.x, (int)currentLocation.y]);
            }*/
        }
    }

    /*private Vector2 CheckPointAtDirection(Vector2 dir)
    {
        return (Vector2)transform.position + dir * 2.5f;
    }*/

    private bool CheckPointAtDirection(Vector2 dir)
    {
        Vector2 checkpos = (Vector2)transform.position + dir * 2.5f;
        Collider2D col = Physics2D.OverlapPoint(checkpos, gridLayer);
        if (col == null)
        {
            return false;
        }
        return col.CompareTag("PlayerGrid");
    }

    public void DamagePlayer(float ouchNum)
    {
        playerHp.SubstractToAttrtibute(ouchNum);
        if (playerHp.CurrentValue <= 0)
        {
            Destroy(gameObject);
        }
    }

    public LayerMask getLayer()
    {
        return gridLayer;
    }
}
