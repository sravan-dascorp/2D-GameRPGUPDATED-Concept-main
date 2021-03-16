using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class castleEndScripr : MonoBehaviour
{//this is a dumb lazy hack


    public GameObject fadingCanvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        // collision.transform.GetComponent<Animator>().SetBool("move", false);
        //var player = collision.transform.Find("Character");
        // player.transform.SetParent(null);

        //player.transform.Translate(this.gameObject.transform.parent.transform.position + transform.up * 2f, Space.World); ;
        if (collision.gameObject.tag == "Player")
        {
            fadingCanvas.SetActive(true);
            Invoke("next_level", 1f);
        }
        
    }

    void next_level()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
