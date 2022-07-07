using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtnMain : MonoBehaviour
{
    public void LoadSceneHanhTrang(){
        SceneManager.LoadScene("Main");
        //LoadingScene.Instance.LoadScThuong("HanhTrang");
    }
    public void AboutGame(){

    }
    public void RestartLevel(){
        SceneManager.LoadScene(1);
    }
    public void QuidGame(){
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            Destroy(other.gameObject);
            SceneManager.LoadScene(0);
        }
    }
    public GameObject panelAbout;
    public void OpenAbout()
    {
        panelAbout.SetActive(true);
    }
    public void CloseAbout()
    {
        panelAbout.SetActive(false);
    }
    public void OpenUrlFb()
    {
        Application.OpenURL("https://www.facebook.com/phamduy.tuan.04092001");
    }
}
