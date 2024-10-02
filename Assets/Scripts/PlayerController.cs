using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText, winText;
    private int count;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        count =0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalMovement,0,verticalMovement);
        rb.AddForce(movement * speed);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Coin")){
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count - " + count.ToString();
            if(count >=8)
                winText.text = "Game Completed";
        }
    }
}
