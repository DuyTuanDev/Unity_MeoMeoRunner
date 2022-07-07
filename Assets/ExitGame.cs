using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            PlayerMeoController.Instance.DestroyObj();
            SceneManager.LoadScene("Loading");
        } 
        
    }
}
