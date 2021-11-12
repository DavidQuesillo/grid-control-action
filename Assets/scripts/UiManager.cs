using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField]
    private GameObject ableTxt;
    [SerializeField]
    private GameObject unableTxt;
    [SerializeField]
    private Text remainingCapsCounter;
    [SerializeField]
    public Image captureMeter;

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
}
