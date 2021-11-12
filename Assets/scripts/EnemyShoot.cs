using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private float shootSpeed = 1f;
    [SerializeField]
    private float damage = 1f;

    [SerializeField]
    private GameObject bullet;
    public Vector2 whereToShoot;
    /*[SerializeField]
    private EnemyBase eb;*/

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireAtPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShootPlayer()
    {
        GameObject shot = Instantiate(bullet, transform.position, transform.rotation, null);
        shot.GetComponent<PlayerShot>().setDamage(damage);
        shot.GetComponent<Rigidbody2D>().AddForce(whereToShoot * shootSpeed);
    }

    private IEnumerator FireAtPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            ShootPlayer();
        }
    }
}
