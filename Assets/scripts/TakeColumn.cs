using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TakeColumn : MonoBehaviour
{   
    [SerializeField]
    private int facingDir = 0;
    private bool canCapture = false;

    //public GameObject ableTxt;
    //public GameObject unableTxt;

    public Tile playerColor;
    public Tilemap map;

    public GridMovement moveS;
    [SerializeField]
    private LayerMask gridLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDirectionFacing();
        IsCapturePossible();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canCapture)
            {
                TakeSquareClockwise();
            }

            /*if (owned == 3)
            {
                map.SetTile(new Vector3Int(-2, -1, 0), playerColor);
                map.SetTile(new Vector3Int(-2, 0, 0), playerColor);
                map.SetTile(new Vector3Int(-2, 1, 0), playerColor);
                owned += 1;
                //moveS.spots.Add()
                return;
            }
            if (owned == 4)
            {
                map.SetTile(new Vector3Int(-3, -1, 0), playerColor);
                map.SetTile(new Vector3Int(-3, 0, 0), playerColor);
                map.SetTile(new Vector3Int(-3, 1, 0), playerColor);
                owned += 1;
                return;
            }
            if (owned == 5)
            {
                map.SetTile(new Vector3Int(-4, -1, 0), playerColor);
                map.SetTile(new Vector3Int(-4, 0, 0), playerColor);
                map.SetTile(new Vector3Int(-4, 1, 0), playerColor);
                GameManager.instance.Win();
                return;
            }*/

            //Physics2D.OverlapBoxAll()
        }
    }

    public void TakeSquareClockwise()
    {
        if (facingDir == 0)
        {
            if (CheckPointAtDirection(Vector2.up, "EnemyGrid"))
            {
                //Collider2D checkedSpace = Physics2D.OverlapPoint((Vector2)transform.position + Vector2.up * 2.5f, gridLayer);
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.up * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
                GameManager.instance.setCapturePoints(0f);

                //StartCoroutine(TakeWholeRow(false, Vector2.up));
                //Debug.Log("checked");
            }
            #region(the just in case)
            else if (CheckPointAtDirection(Vector2.right, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.right * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            else if (CheckPointAtDirection(Vector2.down, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.down * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            else if (CheckPointAtDirection(Vector2.left, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.left * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            #endregion
        }
        else if (facingDir == 1)
        {
            if (CheckPointAtDirection(Vector2.right, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.right * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
                GameManager.instance.setCapturePoints(0f);
            }
            #region(the just in case)
            else if (CheckPointAtDirection(Vector2.up, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.up * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            else if (CheckPointAtDirection(Vector2.down, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.down * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            else if (CheckPointAtDirection(Vector2.left, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.left * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            #endregion
        }

        else if (facingDir == 2)
        {
            if (CheckPointAtDirection(Vector2.down, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.down * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
                GameManager.instance.setCapturePoints(0f);
            }
            #region(the just in case)
            else if (CheckPointAtDirection(Vector2.left, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.left * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            else if (CheckPointAtDirection(Vector2.right, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.right * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            else if (CheckPointAtDirection(Vector2.up, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.up * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            #endregion
        }

        else if (facingDir == 3)
        {
            if (CheckPointAtDirection(Vector2.left, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.left * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
                GameManager.instance.setCapturePoints(0f);
            }
            #region(the just in case)
            else if (CheckPointAtDirection(Vector2.up, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.up * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            else if (CheckPointAtDirection(Vector2.down, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.down * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            else if (CheckPointAtDirection(Vector2.right, "EnemyGrid"))
            {
                Vector3Int squareToTake = GridManager.instance.getEnemyTilemap().WorldToCell((Vector2)transform.position + Vector2.left * 2.5f);
                Debug.Log(squareToTake.ToString());
                GridManager.instance.TakeSquareForPlayer(squareToTake);
            }
            #endregion
        }

        else
        {
            Debug.Log("none");
        }
    }

    public void CheckDirectionFacing()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            facingDir = 0;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            facingDir = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            facingDir = 2;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            facingDir = 3;
        }
    }

    private void IsCapturePossible()
    {
        if (GameManager.instance.getCapturePoints() < 100f)
        {
            canCapture = false;
        }
        else
        {
            canCapture = true;
        }
    }

    private bool CheckPointAtDirection(Vector2 dir, string targetTag = "PlayerGrid")
    {
        Vector2 checkpos = (Vector2)transform.position + dir * 2.5f;
        Collider2D col = Physics2D.OverlapPoint(checkpos, gridLayer);
        if (col == null)
        {
            //Debug.Log("encuentra null buscando para" + targetTag);
            return false;
        }
        //Debug.Log("comparetag retorna" + col.CompareTag(targetTag) + "para tag" + targetTag);
        return col.CompareTag(targetTag);
    }

        IEnumerator TakeWholeRow(bool isVertical, Vector2 direction)
        {
        int squareProgress = 1;
        bool moreAtLeft = true;
        bool moreAtRight = true;
        Vector2 spotToStart = new Vector2(0f, 0f);

        int squaresUntilFirst = 1;

        Tilemap enemyMap = GridManager.instance.getEnemyTilemap();

        if (!isVertical)
        {
            while(moreAtLeft == true)
            {
                if (Physics2D.OverlapPoint((Vector2)transform.position + direction * 2.5f + new Vector2(-2.5f * squaresUntilFirst, 0f)).CompareTag("EnemyTile"))
                {
                    squaresUntilFirst += 1;
                    spotToStart = new Vector2(transform.position.x + -2.5f * squaresUntilFirst, transform.position.y + 2.5f);
                    yield return null;
                }
                else
                {
                    moreAtLeft = false;
                }
            }
            while(moreAtRight == true)
            {
                if (Physics2D.OverlapPoint((Vector2)transform.position + direction * 2.5f + new Vector2(2.5f * squareProgress, 0f)).CompareTag("EnemyTile"))
                {
                    squareProgress += 1;
                }
                else
                {
                    moreAtRight = false;
                    Vector2[] tilesToChangeWorldPos = new Vector2[squareProgress];

                    for (int i = 0; i < squareProgress; i++)
                    {
                        tilesToChangeWorldPos[i] = spotToStart + new Vector2(2.5f * i, spotToStart.y);
                        GridManager.instance.TakeSquareForPlayer(enemyMap.WorldToCell(tilesToChangeWorldPos[i]));
                    }
                }
            }



            //GridManager.instance.TakeSquareForPlayer(GridManager.instance. (Vector2)transform.position + direction * 2.5f)
        }
    }
}