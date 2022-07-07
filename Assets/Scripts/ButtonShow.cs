using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShow : MonoBehaviour
{
    public GameObject show;
    public GameObject btn;
    private void Start() {
        show.SetActive(false);
        btn.SetActive(false);
        cvDh = GameObject.Find("CanvasNutDieuHuong");
    }
    GameObject cvDh;
    
    public void ShowGameObject(){
        PlayerMeoController.Instance.isWork = true;
        show.SetActive(true);
        btn.SetActive(false);
        
        cvDh.SetActive(false);
    }
    public void HideGameObject(){
        show.SetActive(false);
        cvDh.SetActive(true);
        PlayerMeoController.Instance.isWork = false;
    }
}
