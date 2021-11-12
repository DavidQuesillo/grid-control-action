using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private Attributes Hp = new Attributes(5);
    private Attributes earnedCapMeter = new Attributes(10);
    [SerializeField] private float HpAmount = 5f;
    [SerializeField] private float capEarnAmount = 5f;
    public Vector2 whereToAdvance;

    // Start is called before the first frame update
    void Start()
    {
        Hp.SetNewValue(HpAmount);
        earnedCapMeter.SetNewValue(capEarnAmount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageEnemy(float ouchNum)
    {
        Hp.SubstractToAttrtibute(ouchNum);
        if (Hp.CurrentValue <= 0)
        {
            GameManager.instance.addCapturePoints(capEarnAmount);
            Destroy(gameObject);
        }
    }


    public Vector2 getDirection()
    {
        return whereToAdvance;
    }
    public void RevertDirection()
    {
        whereToAdvance *= -1;
    }
}
