using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Drag : MonoBehaviour
{
    public int value = 1;
    public int newValue;
    Vector3 screenPoint;
    Vector3 offset;
    public TMP_Text showValue;
    public GameObject number;

    private void Update()
    {
        showValue.text = "" + value;
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Number")
        {
            newValue = value + collision.gameObject.GetComponent<Drag>().value;//value of new num
            Vector2 midPoint = (transform.position + collision.transform.position) / 2;//position of new num

            value = newValue;
            Instantiate(number, midPoint, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

