using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public bool outOfFuel = false;
    public static float VehicleStartPos;
    public static GameObject vehicle;
    public static int coin;
    public TMP_Text fuelTxt;
    public static double fuelValue = 100;
    public TMP_Text Cointext;
    public TMP_Text TotalCoin, TotalAirTime,deadReason,distanceTxt;
    public Slider slider;
    public float decreaseRate = 0.1f;
    public GameObject lowFuel, AfterDeath;
    public static GameManager instance;
    public static bool driverDown;
    public void Start()
    {
        instance = this;
        InitData();
    }
    public void InitData()
    {
        coin = PlayerPrefs.GetInt("coins", 0);
        vehicle = GameObject.Find("VehicleBody");
        VehicleStartPos = vehicle.transform.position.x;        
    }
    void Update()
    {
        fuelValue -= decreaseRate /5;
        slider.value -= decreaseRate/500;
        if(slider.value <= 0.2)
        {
            lowFuel.SetActive(true);
        }
        if(Refuel.refuel)
        {
            slider.value = 1;
        }
        if(fuelValue == 0)
        {
            outOfFuel = true;
        }
        string tempTextFloat;
        tempTextFloat = float.Parse(fuelValue.ToString()).ToString();
        string[] newStr = tempTextFloat.Split(char.Parse("."));
        //Debug.Log("Parf2:"+newStr[1]);
        //tempTextInt = int.Parse(fuelValue.ToString());
        //Debug.Log("TempTextInt:" + tempTextInt);
        //fuelTxt.text = newStr[0].ToString();
        //Debug.Log("TempInt:" + int.Parse(tempText).ToString());
        /*Debug.Log("In Float:" + int.TryParse(fuelValue.ToString(),out tempVal));
        Debug.Log("Int:" + tempVal);
        *///Debug.Log("In Int:" + int.Parse(float.Parse(fuelTxt.ToString()).ToString()));
        //slider.value -= int.Parse(float.Parse(fuelTxt.ToString()).ToString());
        Cointext.text = coin.ToString();
    }
    public void AfterGame()
    {
        if(outOfFuel)
        {
            deadReason.text = "OUT OF FUEL";
        }
        else if(driverDown)
        {
            deadReason.text = "DRIVER DOWN";
        }
        distanceTxt.text = "Distance:"+CarController.distTraveled.ToString() + "m";
        TotalCoin.text = "+"+CoinCollector.tempCoin.ToString() + "Coins";
        TotalAirTime.text = CarController.airTimeCount.ToString()+"xAirTime";
        AfterDeath.SetActive(true);
    }
}
