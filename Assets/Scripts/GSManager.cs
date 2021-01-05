using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GSManager : MonoBehaviour
{
    public Animator[] selection;
    public Animator vehicle;
    public GameObject right, left,unlock,insufficientInfo,vehicleInfo,GetCoins;
    public TMP_Text coinTxt,vehicleName,unlockCost,Needed;
    public static int coins,vehiclePrice;
    public int extraPrice,carNum;
    private string[] vehicles = { "CAR", "MOTOR BIKE" };
    private int[] vehiclePrices = { 10000, 1000000 };
    int tempNum = -1;
    public void Start()
    {
        left.SetActive(false);
        coins = PlayerPrefs.GetInt("coins", 0);
        coinTxt.text = coins.ToString(); ;
    }
    public void OnClickBtn(int num)
    {
        Debug.Log("Number:" + num);
        for(int i=0;i<selection.Length;i++)
        {
            if (tempNum != -1 && tempNum!=num)
                selection[tempNum].SetTrigger(tempNum.ToString() + "down");
            tempNum = num;
            if (num == i)
            {
                selection[i].SetTrigger(i.ToString());
            }
        }
    }
    public void OnClickArrow(int dir)
    {
        if (dir == 0)
        {
            vehicle.SetTrigger("slideRight");
            right.SetActive(false);
            left.SetActive(true);
        }
        else if(dir==1)
        {
            right.SetActive(true);
            left.SetActive(false);
            Debug.Log("left");
            vehicle.SetTrigger("slideLeft");
        }
    }
    public void ClickVehicle(int carNo)
    {
        if (!unlock.activeSelf)
        {
            unlock.SetActive(true);
            carNum = carNo;
            Debug.Log(vehicles.Length);
            vehicleName.text = vehicles[carNum];
        }
        else
        {
            unlock.SetActive(false);
        }
    }
    public void BuyVehicle()
    {
        if(carNum == 1)
        {
            vehiclePrice = vehiclePrices[carNum];
            if (coins< vehiclePrice)
            {
                vehicleInfo.SetActive(false);
                insufficientInfo.SetActive(true);
                GetCoins.SetActive(true);
                extraPrice = vehiclePrice - coins;
                unlockCost.text = "Unlock cost: "+vehiclePrices[carNum].ToString() + "coins";
                Needed.text = "You need: "+extraPrice.ToString() +"coins";
            }
        }
    }
}