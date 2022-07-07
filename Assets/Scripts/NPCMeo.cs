using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMeo : MonoBehaviour
{
    static public NPCMeo Instance;
    public GameObject btnShow, cvDh, cvInfo;
    public bool isNoWork;
    private void Awake()
    {
        Instance = this;
    }
    private void Start() {
        btnShow.SetActive(false);
        cvDh = GameObject.Find("CanvasNutDieuHuong");
        cvInfo = GameObject.Find("CanvasThongTinNV");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && !isNoWork){
            btnShow.SetActive(true);
            cvDh.SetActive(false);
            cvInfo.SetActive(false);
            PlayerMeoController.Instance.spJoy = 0f;
            PlayerMeoController.Instance.isWork = true;
            PlayerMeoController.Instance.isMoveLeft = false;
            PlayerMeoController.Instance.isMoveRight = false;
        }
        if(other.gameObject.tag == "Player" && isNoWork){
            btnShow.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player" && isNoWork){
            btnShow.SetActive(false);
        }
    }
    public void ClosePanelLevel(){
        btnShow.SetActive(false);
        cvDh.SetActive(true);
        cvInfo.SetActive(true);
        PlayerMeoController.Instance.isWork = false;
    }
}
