using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour
{
    private int opt;
    public Animator zoomInTitle,zoomInDist;
    public GameObject dist,distImg,coins,coinsImg,airTime,cont;
    private float time = 0.9f;
    private bool detect;
    public void Start()
    {
        detect = false;
        distImg.SetActive(false);
        coinsImg.SetActive(false);
        airTime.SetActive(false);
        cont.SetActive(false);
        dist.SetActive(false);
        coins.SetActive(false);
        zoomInTitle.SetTrigger("Title");
        StartCoroutine(AfterDelay(time));
    }
    // Start is called before the first frame update
    /* public void AfterReason()
     {
         opt = 0;
         StartCoroutine(AfterDelay(time));
         Debug.Log("after reason");

     }
     public void AfterDistance()
     {
         opt = 1;
         StartCoroutine(AfterDelay(time));
         Debug.Log("after dist");

     }
     public void AfterCoins()
     {
         opt = 2;
         StartCoroutine(AfterDelay(time));
         Debug.Log("after coins");
     }
     public void AfterTime()
     {
         opt = 3;
         StartCoroutine(AfterDelay(time));
         Debug.Log("after time");
     }*/
    public void Update()
    {
        if(detect)
        {
            if(Input.touchCount>0 || Input.GetMouseButtonDown(0))
            {
                Debug.Log("touched");
                this.gameObject.SetActive(false);
                SceneManager.LoadScene("Game");
                //CoinCollector.tempCoin = 0;
            }
        }

    }
    IEnumerator AfterDelay(float time)
     {
        yield return new WaitForSeconds(time);
        dist.SetActive(true);
        distImg.SetActive(true);
        //dist.GetComponent<Animator>().SetTrigger("Dist");
        yield return new WaitForSeconds(time);
        coins.SetActive(true);
        coinsImg.SetActive(true);
        //coins.GetComponent<Animator>().SetTrigger("Coin");
        yield return new WaitForSeconds(time);
        airTime.SetActive(true);
        yield return new WaitForSeconds(time);
        cont.SetActive(true);
        detect = true;
        /* zoomIn.SetTrigger("Cont");
         if (opt == 0)
          {

          }
          else if(opt == 1)
          {

          }
          else if(opt == 2)
          {
              zoomIn.SetTrigger("AirTime");
          }
          else if(opt == 3)
          {
              zoomIn.SetTrigger("Cont");
          }*/
    }
}
