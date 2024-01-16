using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Net;

public class Drag : MonoBehaviour
{
    public int value = 1;
    public int newValue;
    public int tenAmount = 0;
    public int oneAmount;
    public int tenValue;
    public int oneValue;
    Vector3 screenPoint;
    Vector3 offset;
    public TMP_Text showValue;
    public GameObject number;

    private void Update()
    {
        showValue.text = "" + value;//show the correct value

        if (Input.GetMouseButtonDown(1) && value >= 11)
        {
            HowMany();

            Vector2 tenSpot = new(transform.position.x - 1, transform.position.y);
            tenValue = tenAmount * 10;

            Vector2 oneSpot = new(transform.position.x + 1, transform.position.y);
            oneValue = oneAmount;

            value = tenValue;
            Instantiate(number, tenSpot, Quaternion.identity);

            value = oneValue;
            Instantiate(number, oneSpot, Quaternion.identity);

            Destroy(gameObject);
        }
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);//alllows you to drag number without snapping to the middle

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);//get rellative mouse position
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset; //mouse position + the offset
        transform.position = curPosition;//place it correctly
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Number"))
        {
            newValue = value + collision.gameObject.GetComponent<Drag>().value;//value of new num
            Vector2 midPoint = (transform.position + collision.transform.position) / 2;//position of new num

            value = newValue;//change value to outcome calculation
            Instantiate(number, midPoint, Quaternion.identity);//spawn new number

            Destroy(collision.gameObject);//destroy the old ones
            Destroy(gameObject);
        }
    }
    private void HowMany()
    {
        oneAmount = value;
        while (oneAmount > 10)
        {
            oneAmount -= 10;
            tenAmount++;
        }
    }
}

