using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [SerializeField]
    private int playerSquares = 1;
    [SerializeField]
    private int enemySquares = 1;
    [SerializeField]
    private Tile playerColor;
    [SerializeField]
    private Tile enemyColor;
    [SerializeField]
    private int playerWinAmount = 10;
    [SerializeField]
    private int playerLoseAmount = 2;

    [SerializeField]
    private Grid grid;
    [SerializeField]
    private Tilemap playerMap;
    [SerializeField]
    private Tilemap enemyMap;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeSquareForPlayer(Vector3Int squareCoordinates)
    {
        playerMap.SetTile(squareCoordinates, playerColor);
        //playerMap.InsertCells(squareCoordinates, 0, 1, 1);
        enemyMap.SetTile(squareCoordinates, null);
        Debug.Log(squareCoordinates.ToString());
    }
    public void TakeSquareForEnemy(Vector3Int squareCoordinates)
    {
        playerMap.SetTile(squareCoordinates, enemyColor);
    }

    public Tilemap getEnemyTilemap()
    {
        return enemyMap;
    }
    public Tilemap getPlayerTilemap()
    {
        return playerMap;
    }
}
