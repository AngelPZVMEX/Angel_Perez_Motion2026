using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class angleTest : MonoBehaviour
{
    public List<float> angles = new List<float>();
    public float radius = 1;

    private int currentAnglesIndex = 0;

    public Vector3 circleOffset;
    public float shiftDuration;

    private float shiftProgress = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //float FortyFiveAngle = 45f;

        //float ffdInRad = FortyFiveAngle * Mathf.Deg2Rad;
        //float TwoPiRad = 2 * Mathf.PI;
        //float tprdeg = TwoPiRad * Mathf.Rad2Deg;
        //float currentAngle = 90f;
        //Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        //Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        

    }


    // Update is called once per frame
    void Update()
    {
        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
        //    currentAnglesIndex++;

        //    if(currentAnglesIndex >= angles.Count)
        //    {
        //        currentAnglesIndex = 0;
        //    }
        //}

        shiftProgress += Time.deltaTime;
        if (shiftProgress > shiftDuration)
        {
            currentAnglesIndex++;

            if (currentAnglesIndex >= angles.Count)
            {
                currentAnglesIndex = 0;
            }
            shiftProgress = 0f;
        }
        float currentAngle = angles[currentAnglesIndex];
        float angleinRad = currentAngle * Mathf.Deg2Rad;

        Vector3 startPoint = Vector3.zero+ circleOffset;
        Vector3 endPoint = new Vector3(Mathf.Cos(angleinRad),Mathf.Sin(angleinRad)*radius) + circleOffset;
        
        Debug.DrawLine(startPoint, endPoint, Color.wheat);
    }


}

