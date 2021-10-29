using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalShot : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public float rate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject shot = Instantiate(bullet, transform);
            shot.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
        }
    }
}
