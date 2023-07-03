using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public player p;
    public Text coinText;
    public Text equationText;
    public Text number;
    public int[] tempNumber = new int[5];
    public string[] equation = new string[100];
    public string[] result = new string[100];
    public string answer;
    private int i = 0;
    private int rnd;

    public GameObject FireworkPrefab;
    public int fireworkAmount;
    private int tempFireworkAmount;

    public GameObject EquationPanel;

    public Sprite[] sprite;

    public static GameManager Instance;

    public int AltinMiktari;

    public bool SoruSor;



    void Awake(){
        Instance = this;
    }

    void Start()
    {
        p = GameObject.FindWithTag("player").GetComponent<player>();
        number.text = "";
        //result = "32";
        equation[0] = "3 + 5";
        result[0] = "8";
        Equation();
        AltinMiktari = GameObject.FindGameObjectsWithTag("coin").Length;
        SoruSor = true;
    }


    void Update()
    {
        Debug.Log(AltinMiktari);
        //number = tempNumber;
        coinText.text = "x" + p.paraMiktari.ToString();

        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("MainMenu");
        }


        if(Input.GetKeyDown(KeyCode.Alpha0)){
            if(i > 4) return;
            tempNumber[i] = 0;
            number.text += tempNumber[i].ToString();
            i++;
            answer += "0";
        }

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            if(i > 4) return;
            tempNumber[i] = 1;
            number.text += tempNumber[i].ToString();
            i++;
            answer += "1";
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            if(i > 4) return;
            tempNumber[i] = 2;
            number.text += tempNumber[i].ToString();
            i++;
            answer += "2";
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)){
            if(i > 4) return;
            tempNumber[i] = 3;
            number.text += tempNumber[i].ToString();
            i++;
            answer += "3";
        }

        if(Input.GetKeyDown(KeyCode.Alpha4)){
            if(i > 4) return;
            tempNumber[i] = 4;
            number.text += tempNumber[i].ToString();
            i++;
            answer += "4";
        }

        if(Input.GetKeyDown(KeyCode.Alpha5)){
            if(i > 4) return;
            tempNumber[i] = 5;
            number.text += tempNumber[i].ToString();
            i++;
            answer += "5";
        }

        if(Input.GetKeyDown(KeyCode.Alpha6)){
            if(i > 4) return;
            tempNumber[i] = 6;
            number.text += tempNumber[i].ToString();
            i++;
            answer += "6";
        }

        if(Input.GetKeyDown(KeyCode.Alpha7)){
            if(i > 4) return;
            tempNumber[i] = 7;
            number.text += tempNumber[i].ToString();
            i++;
            answer += "7";
        }

        if(Input.GetKeyDown(KeyCode.Alpha8)){
            if(i > 4) return;
            tempNumber[i] = 8;
            number.text += tempNumber[i].ToString();
            i++;
            answer += "8";
        }

        if(Input.GetKeyDown(KeyCode.Alpha9)){
            if(i > 4) return;
            tempNumber[i] = 9;
            number.text += tempNumber[i].ToString();
            i++;
            answer += "9";
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            EquationPanel.SetActive(false);
            if(result[rnd] == answer){
            StartCoroutine("Firework");
            Invoke(nameof(NextLevel) , 2f);
            Debug.Log("true");
            }
            else{
                Invoke(nameof(Restart) , 0.5f);
            }
        }
    }

    public void Equation(){
        rnd = Random.Range(0 , equation.Length);
        equationText.text = equation[rnd];
    }

    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    IEnumerator Firework(){
        while(tempFireworkAmount != fireworkAmount){
        float a = Random.Range(-25f , 25f);
        float b = Random.Range(-10f , 10f);
        Vector3 targetPos = new Vector3(a , b , 0f);
        Instantiate(FireworkPrefab , targetPos , Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        tempFireworkAmount++;
        }
    }
}
