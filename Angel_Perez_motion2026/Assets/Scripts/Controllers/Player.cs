using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public GameObject grapple;

    public Vector2 trailspacing;

    public Vector3 diff;

    public float speed = 0.01f;

    public Vector3 myposition;
    public float maxspeed;

    public float currentAcceleration;

    public float accelerationTime;

    public float decelerationTime;

    public float deceleration;

    public Vector3 currentVelocity = Vector3.right;

    public Vector3 currentDeceleration = Vector3.left;

    public float range;

    public Vector3 mousepos;




    void Start()
    {
        diff = new Vector3(0, -1, 0);
        trailspacing = new Vector2(0, 2);

        currentAcceleration = maxspeed / accelerationTime;

        deceleration = maxspeed / decelerationTime;

        Instantiate(grapple,new Vector3(100,100,100),quaternion.identity);
        

    }




    void Update()
    {
        grapple.transform.position = transform.position;

        myposition = transform.position;

        PlayerMovement();

        Vector2 mousenow = Mouse.current.position.ReadValue(); //gets mosuepos

        mousepos = Camera.main.ScreenToWorldPoint(mousenow); //converts it to world point

        GrappleHook(range,mousepos);

        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            spawnBombAtOffset(myposition, diff);
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            {
                SpawnBombTrail(myposition, trailspacing, 4);
            }
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            spawnBombOnRandomCorner(4);

        }


        }

        void spawnBombAtOffset(Vector3 theposition, Vector3 theoffset)
        {
            Instantiate(bombPrefab, theposition + theoffset, Quaternion.identity);
        }

        void SpawnBombTrail(Vector3 theposition, Vector2 inBombSpacing, int inNumberOfBombs)
        {
            for (int i = 1; i < inNumberOfBombs; i++)
            {



                Instantiate(bombPrefab, theposition - (Vector3)(inBombSpacing * i), quaternion.identity);

            }
        }

        void spawnBombOnRandomCorner(float inDistance)
        {
            int cornerN = UnityEngine.Random.Range(0, 4); // generate random number to correspond with a corner


            if (cornerN == 0) //bleft
            {
                Instantiate(bombPrefab, myposition + new Vector3(-inDistance, -inDistance, 0), Quaternion.identity);
            }

            if (cornerN == 1) //bright
            {
                Instantiate(bombPrefab, myposition + new Vector3(inDistance, -inDistance, 0), Quaternion.identity);
            }
            if (cornerN == 2) //tleft
            {
                Instantiate(bombPrefab, myposition + new Vector3(-inDistance, inDistance, 0), Quaternion.identity);
            }
            if (cornerN == 3) //tright
            {
                Instantiate(bombPrefab, myposition + new Vector3(inDistance, inDistance, 0), Quaternion.identity);
            }
            Debug.Log(cornerN);
        }

    void PlayerMovement()
    {
        Vector3 accelerationDirection = Vector3.zero;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            accelerationDirection += Vector3.left;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            accelerationDirection += Vector3.right;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            accelerationDirection += Vector3.up;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            accelerationDirection += Vector3.down;
        }
      
        currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime;

        transform.position += currentVelocity * Time.deltaTime;
    }

    public void GrappleHook (float range, Vector3 mousepos)
    {
       Vector3 direction = mousepos - transform.position;
        direction.z = 0f;
        direction.Normalize();

        Vector3 grappleEnd = transform.position + direction * range;

       

        Debug.Log("Grapple endpoint: " + grappleEnd);


        if (Keyboard.current.qKey.wasPressedThisFrame && Vector3.Distance(transform.position,enemyTransform.position) <= range)
        {
             Debug.DrawLine(transform.position, grappleEnd, Color.red, 2f);


        }
    }




    
}



