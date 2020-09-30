using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moviment : MonoBehaviour
{
    public float velocity = 5f;
    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
        texto.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal * velocity * Time.deltaTime, vertical * velocity * Time.deltaTime, 0));

    }

    void OnTriggerStay2D(Collider2D other) {
        interactions(other);
    }

    void interactions(Collider2D other) {
        if(other.gameObject.CompareTag("PC") && Input.GetKey(KeyCode.Space)) {
            texto.enabled = true;
        }
    }    
}
