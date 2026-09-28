using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    public Vector3 destination;

    public Vector3 place;

    // Start is called before the first frame update
    void Start()
    {

        place = transform.position;

        int direction = UnityEngine.Random.Range(0, 4);//get fed a max distance, that is a random direction away

        if (direction == 0) //left
        {
            destination = place + new Vector3(-maxFloatDistance, 0, 0);
        }
        if (direction == 1) //right
        {
            destination = place + new Vector3(maxFloatDistance, 0, 0);
        }
        if (direction == 2) //up
        {
            destination = place + new Vector3(0, maxFloatDistance, 0);
        }
        if (direction == 3) //down
        {
            destination = place + new Vector3(0, -maxFloatDistance, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        place = transform.position;

        Vector3 moveDirection = (destination - transform.position).normalized * moveSpeed * Time.deltaTime;// move to that distance at a max speed

        transform.position += moveDirection;

        if(Vector3.Distance(transform.position,destination) <= arrivalDistance)

        {
            int direction = UnityEngine.Random.Range(0, 4);//get fed a max distance, that is a random direction away

            if (direction == 0) //left
            {
                destination = place + new Vector3(-maxFloatDistance, 0, 0);
            }
            if (direction == 1) //right
            {
                destination = place + new Vector3(maxFloatDistance, 0, 0);
            }
            if (direction == 2) //up
            {
                destination = place + new Vector3(0, maxFloatDistance, 0);
            }
            if (direction == 3) //down
            {
                destination = place + new Vector3(0, -maxFloatDistance, 0);
            }
        }


    }

    public void Roam ()
    {
      
        
        // once within the range of arrival distance regenerate
       

    }

}
