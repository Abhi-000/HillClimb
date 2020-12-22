using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerDeath : MonoBehaviour
{
    public HingeJoint2D head;
    public WheelJoint2D[] tires;
    public GameObject[] bodyParts = new GameObject[10];
    public GameObject parentObj;
    private bool isDead;
    public void Start()
    {
        print(parentObj.name + ":" + parentObj.transform.localEulerAngles.z);
        isDead = false;
        Time.timeScale = 1f;
        for (int i = 0;i<5;i++)
        {
            bodyParts[i] = parentObj.transform.Find("body" + i).gameObject;
        }
        tires = parentObj.GetComponents<WheelJoint2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            StartCoroutine(LevelRestart());
        }
    }
    public void Update()
    {
        //print(parentObj.name+":"+parentObj.transform.localEulerAngles.z);
       if(parentObj.transform.localEulerAngles.z == 360)
        {
            print("Back Flip");
        }
       else if(parentObj.transform.localEulerAngles.z == -360)
        {
            print("front Flip");
        }
    }

    IEnumerator LevelRestart()
    {
        isDead = true;
        yield return new WaitForSeconds(0.25f);
/*        for (int i = 0; i < 5; i++)
        {
            bodyParts[i].AddComponent<Rigidbody2D>();
        }
        for (int i = 0; i < 5; i++)
        {
            bodyParts[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }*/
        head.enabled = false;
        for (int i = 0; i < tires.Length; i++)
        {
            tires[i].enabled = false;
        }
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("SampleScene");

    }
}
