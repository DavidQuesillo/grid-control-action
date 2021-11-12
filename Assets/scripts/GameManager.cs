using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private int spacesToWin = 10;
    [SerializeField]
    private Attributes capturePoints = new Attributes(100f);
    [SerializeField]
    private int playerWinAmount = 10;
    [SerializeField]
    private int playerLoseAmount = 2;
    [SerializeField]
    private int playerSquares = 1;
    [SerializeField]
    private int enemySquares = 1;

    private void Awake()
    {
        instance = this;
        capturePoints.SubstractToAttrtibute(100f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (capturePoints.CurrentValue == 100f)
        {
            Win();
        }
    }

    public void Win()
    {
        Debug.Log("WIN");
    }

    public int getSpacesToWin()
    {
        return spacesToWin;
    }

    public float getCapturePoints()
    {
        return capturePoints.CurrentValue;
    }
    public void addCapturePoints(float addAmount)
    {
        capturePoints.AddToAttribute(addAmount);
        SyncCaptureMeter();
    }

    public void setCapturePoints(float amount)
    {
        capturePoints.SetNewValue(amount);
        SyncCaptureMeter();
    }

    public void SyncCaptureMeter()
    {
        UiManager.instance.captureMeter.fillAmount = capturePoints.Percent;
    }
}
