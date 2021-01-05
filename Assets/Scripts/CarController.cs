using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CarController : MonoBehaviour
{
    public static float distTraveled;
    public float starPosX;
    public static int airTimeCount;
    public GameObject airTime;
    public TMP_Text airTimePoints,distanceTxt;
    [SerializeField] private Transform m_GroundCheck;
    [SerializeField] private LayerMask m_WhatIsGround;
    float k_GroundedRadius = 1f;
    private bool m_Grounded = false;
    public Rigidbody2D frontWheel;
    public Rigidbody2D backWheel;
    public Rigidbody2D Car;
    public float carSpeed =50f;
    private float timer = 0.0f;
    public float carTorque= -100f;
    float input;
    bool flag = false;
    public int points;
    public void Awake()
    {
       m_GroundCheck = GameObject.Find("GroundCheck").transform;
    }
    private void Start()
    {
        starPosX = transform.position.x;
    }
    void FixedUpdate()
    {
        CheckPosition();
        frontWheel.AddTorque(input * carSpeed * Time.fixedDeltaTime);
        backWheel.AddTorque(input * carSpeed * Time.fixedDeltaTime);
        Car.AddTorque(input * carTorque * Time.fixedDeltaTime);
        bool wasGrounded = m_Grounded;
        //Debug.Log(wasGrounded);
        m_Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                {
                    //OnLandEvent.Invoke();
                    if (flag) 
                    CalAirPoints();
                    flag = true;
                    timer = 0.0f;                    
                }
            }
        }
        if(!m_Grounded)
        {
            if (flag)
            {
                m_Grounded = false;
                timer += Time.deltaTime;
            }
        }
    }
    public void CheckPosition()
    {
        distTraveled = ((int)transform.position.x - starPosX);
        if (distTraveled < 0)
        {
            distanceTxt.text = "0m";
        }
        else
        {
            distanceTxt.text = distTraveled.ToString() + "m";
        }
    }
    public void CalAirPoints()
    {
        int timerCount = (int)(timer / 0.5f);
        points = timerCount * 50;
        if (points != 0)
        {
            if (!TriggerDeath.isDead)
            {
                airTime.SetActive(true);
                airTimeCount++;
                airTimePoints.text = "+"+points.ToString();
                GameManager.coin += points;
                StartCoroutine(AfterDelay(1f));
            }
        }
        /*points = timer * 10;
        Debug.Log("POints:" + points);
        if(points>=5 && points<=10)
        {
            Debug.Log("Point:25");
        }
        else if(points>=11 && points<=15)
        {
            Debug.Log("Points: 50");
        }*/
    }

    // Update is called once per frame
    IEnumerator AfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        airTime.SetActive(false);
    }
    void Update()
    {
        input = -SimpleInput.GetAxis("Horizontal");
        //GameManager.fuelValue += (input/100);
    }
}
