using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinCollector : MonoBehaviour
{
    public static int tempCoin;
    public int coin;
    public static bool flag = true;
    public void Start()
    {
        tempCoin = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flag = true;
            tempCoin += coin;
            GameManager.coin += coin;
            PlayerPrefs.SetInt("coins", GameManager.coin);
            gameObject.GetComponent<Animator>().SetBool("CoinCollect", true);
            //GameObject.Find("CoinTxt").GetComponent<Animator>().SetBool("Collect", true);
            GameObject.Find("CoinTxt").GetComponent<Animator>().SetTrigger("Collect");
            StartCoroutine(AfterDelay(0.3f));
            //StartCoroutine(AfterDelayStop(0.5f));
        }
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            flag = false;
        }

    }*/
    IEnumerator AfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        //GameObject.Find("CoinTxt").GetComponent<Animator>().SetBool("Collect", false);
        Destroy(this.gameObject);

    }
    IEnumerator AfterDelayStop(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("CoinTxt").GetComponent<Animator>().SetBool("Collect", false);
    }
}
