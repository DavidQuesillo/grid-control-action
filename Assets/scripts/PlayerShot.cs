using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField]
    private bool isPlayerShot = true;
    private GameObject player;
    [SerializeField]
    private float damage = 1f;

    [SerializeField]
    private LayerMask enemyBulletLayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDamage(float newDamage)
    {
        damage = newDamage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPlayerShot)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyBase>().DamageEnemy(damage);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("bad"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                Debug.Log("it runs");
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<GridMovement>().DamagePlayer(damage);
                Destroy(gameObject);
            }
        }
    }
}
