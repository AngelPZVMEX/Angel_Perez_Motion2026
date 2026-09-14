using UnityEngine;

public class SrawVectors : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dVector = new Vector2(0, 1);
        Vector2 eVector = new Vector2(3, -2);
        Vector2 origin = new Vector2(0, 0);

        Debug.DrawLine(origin, dVector, Color.yellow, 30);
        Debug.DrawLine(origin, eVector, Color.gray, 30);
    }
}
