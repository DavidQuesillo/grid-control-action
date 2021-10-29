using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TakeColumn : MonoBehaviour
{
    public Tilemap map;
    public Tile playerColor;
    public int owned = 3;
    public GridMovement moveS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (owned == 3)
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
            }
        }
    }
}