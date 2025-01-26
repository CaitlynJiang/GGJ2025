using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bubbleAteImage;
    public GameObject bubbleLeftImage;
    public BubbleMaster bubbleMaster;
    public GameObject flipObject;

    // Start is called before the first frame update

    private void OnEnable()
    {
        BubbleMaster.bubbleFinished += win;
        LiquidMaster.liquidLeftEvent += lose;
    }

    private void OnDisable()
    {
        BubbleMaster.bubbleFinished -= win;
        LiquidMaster.liquidLeftEvent -= lose;
    }
    void Start()
    {
        bubbleAteImage.SetActive(false);
        bubbleLeftImage.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void win()
    {
        bubbleAteImage.SetActive(true);
        bubbleLeftImage.SetActive(false);
        LiquidMaster.liquidLeftEvent -= lose;
        StartCoroutine(endScene());
    }

    public void lose()
    {
        bubbleLeftImage.SetActive(true);
        bubbleAteImage.SetActive(false);
        TextMeshProUGUI text = bubbleLeftImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        text.text = bubbleMaster.bobbaLeft.ToString();
        StartCoroutine(endScene());
    }

    IEnumerator endScene()
    {
        yield return new WaitForSecondsRealtime(3);
        flipObject.GetComponent<Flip>().FlipRightPage();
    }
}
