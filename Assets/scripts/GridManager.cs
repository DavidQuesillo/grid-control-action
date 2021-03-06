using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [SerializeField]
    private Tile playerColor;
    [SerializeField]
    private Tile enemyColor;

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
        playerMap.SetTile(squareCoordinates, null);
        enemyMap.SetTile(squareCoordinates, enemyColor);
        Debug.Log(squareCoordinates.ToString());
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
