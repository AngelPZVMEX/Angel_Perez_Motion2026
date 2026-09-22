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

    void Start()
    {
        diff = new Vector3(0, -1, 0);
        trailspacing = new Vector2 (0, 2);
    }




    void Update()
    {
        Vector3 myposition = transform.position;

        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            spawnBombAtOffset(myposition, diff);
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            {
                SpawnBombTrail(myposition,trailspacing, 4);
            }
        }
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            spawnBombOnRandomCorner(4);
        }

        void spawnBombAtOffset(Vector3 theposition, Vector3 theoffset)
        {
            Instantiate(bombPrefab, theposition + theoffset, Quaternion.identity);
        }

        void SpawnBombTrail(Vector3 theposition, Vector2 inBombSpacing, int inNumberOfBombs)
        {
            for (int i = 1; i < inNumberOfBombs; i++)
            {



                Instantiate(bombPrefab, theposition - (Vector3) (inBombSpacing * i),quaternion.identity);

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


        public void WarpPlayer (Transform target, float ratio)
        {



        }


    }
}



