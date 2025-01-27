using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextControl : MonoBehaviour
{
    private TextMeshProUGUI mlText;
    private TextMeshProUGUI bobaText;
    private TextMeshProUGUI cupText;
    public LiquidMaster liquidMaster;
    public BubbleMaster bubbleMaster;

    // Start is called before the first frame update
    void Start()
    {
        mlText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        bobaText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        cupText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        print(liquidMaster.liquidLeft);
        mlText.text = liquidMaster.liquidLeft.ToString();
        bobaText.text = bubbleMaster.bobbaLeft.ToString();
        cupText.text = SceneManager.GetActiveScene().buildIndex.ToString();
    }

    private void OnEnable()
    {
        BubbleLiquidDespawn.bubbleSucked += updateboba;
        BubbleLiquidDespawn.liquidSucked += updateml;
    }

    private void OnDisable()
    {
        BubbleLiquidDespawn.bubbleSucked -= updateboba;
        BubbleLiquidDespawn.liquidSucked -= updateml;
    }

    private void updateml()
    {
        mlText.text = liquidMaster.liquidLeft.ToString();
    }

    private void updateboba() 
    {
        bobaText.text = bubbleMaster.bobbaLeft.ToString();
    }
}
