using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{

    public float mouseX;
    public float mouseY;
    public float yPosition;
    public float xPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");


        if (Input.GetMouseButtonDown(0))
        {
            xPosition = mouseX; 
            yPosition = mouseY;
        }

        transform.position = new Vector2(xPosition, yPosition);
        
    }
}
