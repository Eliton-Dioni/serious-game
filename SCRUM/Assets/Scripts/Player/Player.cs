using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float velocity = 5f;
    //public Text texto;

    //efeito texto
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";
    public GameObject dialogText;
    public Image dialogBox;

    
    // Start is called before the first frame update
    void Start()
    {
        //texto.enabled = false;        
        dialogBox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal * velocity * Time.deltaTime, vertical * velocity * Time.deltaTime, 0));

    }

    //efeito texto
    public IEnumerator ShowText() {
        for(int i = 0; i < fullText.Length; i++) {
            currentText = fullText.Substring(0, i+1);
            dialogText.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

    }

    void OnTriggerStay2D(Collider2D other) {
        interactions(other);
    }

    void interactions(Collider2D other) {
        // if(other.gameObject.CompareTag("PC") && Input.GetKey(KeyCode.Space)) {
        //     texto.enabled = true;
        // }

        if(other.gameObject.CompareTag("ScrumMaster") && Input.GetKey(KeyCode.Space)) {
            dialogBox.enabled = true;
            StartCoroutine(ShowText());           
        }

    }
}
