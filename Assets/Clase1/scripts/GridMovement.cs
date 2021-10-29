using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public Vector2[,] spaces = new Vector2[3,3];
    public Vector2 currentLocation = new Vector2(2, 2);

    public List<Vector2> spots;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        spaces[0, 0] = spots.ToArray()[0];
        spaces[1, 0] = spots.ToArray()[1];
        spaces[2, 0] = spots.ToArray()[2];
        spaces[0, 1] = spots.ToArray()[3];
        spaces[1, 1] = spots.ToArray()[4];
        spaces[2, 1] = spots.ToArray()[5];
        spaces[0, 2] = spots.ToArray()[6];
        spaces[1, 2] = spots.ToArray()[7];
        spaces[2, 2] = spots.ToArray()[8];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentLocation.y > 0)
            {
                currentLocation.y -= 1;
                rb.MovePosition(spaces[(int)currentLocation.x, (int)currentLocation.y]);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentLocation.y < 2)
            {
                currentLocation.y += 1;
                rb.MovePosition(spaces[(int)currentLocation.x, (int)currentLocation.y]);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentLocation.x > 0)
            {
                currentLocation.x -= 1;
                rb.MovePosition(spaces[(int)currentLocation.x, (int)currentLocation.y]);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentLocation.x < 2)
            {
                currentLocation.x += 1;
                rb.MovePosition(spaces[(int)currentLocation.x, (int)currentLocation.y]);
            }
        }
    }
}
