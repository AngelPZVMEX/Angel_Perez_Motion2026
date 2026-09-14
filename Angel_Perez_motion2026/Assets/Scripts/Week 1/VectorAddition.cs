using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class VectorAddition : MonoBehaviour
{
    public Transform rTransform;
    public Transform bTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
      Vector2  rPlusb = rTransform.position + bTransform.position;

        if (Keyboard.current.rKey.isPressed)
        {

            Debug.DrawLine(Vector2.zero, rTransform.position, Color.red);
        }

        if (Keyboard.current.bKey.isPressed)
        {

            Debug.DrawLine(Vector2.zero, bTransform.position, Color.blue);
        }
        

        if (Keyboard.current.rKey.isPressed && Keyboard.current.bKey.isPressed)
        {

            Debug.DrawLine(Vector2.zero, rPlusb , Color.purple);
     
        }

        float sizeOfrPLusb = Mathf.Sqrt(rPlusb.x * rPlusb.x + rPlusb.y * rPlusb.y);

        Debug.Log(sizeOfrPLusb);



        Vector2 fromrToB = bTransform.position - rTransform.position;
    }
}
