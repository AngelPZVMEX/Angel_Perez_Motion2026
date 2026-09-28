using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

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

    

    void Start()
    {
        diff = new Vector3(0, -1, 0);
        trailspacing = new Vector2(0, 2);

        currentAcceleration = maxspeed / accelerationTime;

        deceleration = maxspeed / decelerationTime;

    }




    void Update()
    {
        myposition = transform.position;

        PlayerMovement();

       

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

        public void PlayerMovement()
    {
        Vector3 aDirection = Vector3.zero;

        if (Keyboard.current.upArrowKey.isPressed)
        {
            aDirection += Vector3.up;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            aDirection += Vector3.down;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            aDirection += Vector3.left;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            aDirection += Vector3.right;
        }

        currentVelocity += aDirection.normalized * currentAcceleration * Time.deltaTime;

       if (aDirection.normalized == Vector3.zero)
        {
            currentDeceleration += aDirection.normalized * deceleration * Time.deltaTime;
        }
        

        //need to implement deceleration

        if(currentVelocity.magnitude > maxspeed)
        {
            currentVelocity = currentVelocity.normalized * maxspeed;
        }

        transform.position = transform.position + currentVelocity + currentDeceleration * Time.deltaTime;

        Debug.Log(aDirection.normalized);

    }




    
}



