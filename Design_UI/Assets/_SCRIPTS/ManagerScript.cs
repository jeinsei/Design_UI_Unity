using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ManagerScript : MonoBehaviour
{
    public AudioSource sonar;
    public Image background;
    public Image fadePnael;
    public Slider sliderFade;
    public Slider sliderSize;
    public Image changeFadeColor;
    public Image clockCount;
    public GameObject clockTimer;
    public GameObject barIcone;
    public Sprite wall1;
    public Sprite wall2;
    public Sprite wall3;
    public Sprite wall4;
    public Sprite wall5;
    public Material mat;
    public float matFloat;
    public float elapsed;
    public bool start;
    public Text DateTime;
    public Text hourTime;
    public Text hourTimeIn;
    public GameObject animPanel;
    public GameObject timePanel;
    public GameObject circlePanel;
    public GameObject blurPanel;
    public GameObject backPanel;
    public GameObject barPanel;
   
    // Start is called before the first frame update
    void Start()
    {

        start = false;
        matFloat = 0;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        clockTimer.GetComponent<Transform>().localScale  = new Vector3(sliderSize.value,sliderSize.value,sliderSize.value);
        barIcone.GetComponent<Transform>().localScale = new Vector3(sliderSize.value, sliderSize.value, sliderSize.value);
        fadePnael.GetComponent<CanvasGroup>().alpha = sliderFade.value;
        DateTime.text = System.DateTime.Now.ToString("dd-MM-yyyy");
        hourTime.text = System.DateTime.Now.ToString("HH-mm:ss tt");
        hourTimeIn.text = System.DateTime.Now.ToString("HH-mm:ss");

        if (Input.GetKeyDown(KeyCode.Return))
        {
            blurPanel.GetComponent<Animator>().Play("OPENBLUR");
            backPanel.GetComponent<Animator>().Play("WALL");
            barPanel.GetComponent<Animator>().Play("BARICONE");
            sonar.Play(0);

        }
      

        if (start == true)
        {
            elapsed += Time.deltaTime;

            if (elapsed >= 0.1f && matFloat < 5)
            {
                elapsed = elapsed % 1f;
                matFloat += 1;

            }
        }
      

        mat.SetFloat("_Size", matFloat);
    }

    public void StartOS()
    {
        start = true;
        animPanel.GetComponent<Animator>().Play("INFOS");
        timePanel.GetComponent<Animator>().Play("TIME");
        circlePanel.GetComponent<Animator>().Play("CIRCLE");
        backPanel.GetComponent<Animator>().Play("LIGHT");
    }

    public void Wall1()
    {
        background.GetComponent<Image>().sprite = wall1;
    }

    public void Wall2()
    {
        background.GetComponent<Image>().sprite = wall2;
    }

    public void Wall3()
    {
        background.GetComponent<Image>().sprite = wall3;
    }
    public void Wall4()
    {
        background.GetComponent<Image>().sprite = wall4;
    }
    public void Wall5()
    {
        background.GetComponent<Image>().sprite = wall5;
    }

    public void Color1()
    {
        clockCount.GetComponent<Image>().color = new Color32(236, 100, 80, 180);
        changeFadeColor.GetComponent<Image>().color = new Color32(236, 100, 80, 200);
    }
    public void Color2()
    {
        clockCount.GetComponent<Image>().color = new Color32(255, 200, 0, 180);
        changeFadeColor.GetComponent<Image>().color = new Color32(255, 200, 0, 200);
    }
    public void Color3()
    {
        clockCount.GetComponent<Image>().color = new Color32(70, 255, 180, 180);
        changeFadeColor.GetComponent<Image>().color = new Color32(70, 255, 180, 200);
    }
    public void Color4()
    {
        clockCount.GetComponent<Image>().color = new Color32(225, 100, 255, 180);
        changeFadeColor.GetComponent<Image>().color = new Color32(225, 100, 255, 200);
    }
}
