using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;
    public GameObject panelWinGame;
    public GameObject panelGameOver;
    public List<GameObject> listStar = new List<GameObject>();
    public bool isWinGame = false;
    public int soQuaiVat;
    public int countItem;
    public int countStar = 0;
    public int congVang = 100;
    public Text txtCongVang;
    private void Awake() {
        // if(Instance != null){
        //     Destroy(gameObject);
        // }
        Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void SetWinGame(){
        GameObject.Find("CanvasNutDieuHuong").SetActive(false);
        panelWinGame.SetActive(true);
        if(isWinGame) countStar+=1;
        if(soQuaiVat <= 0) countStar+=1;
        if(countItem <= 0) countStar+=1;
        StartCoroutine(SetStar());
    }
    public void SetGameOver(){
        panelGameOver.SetActive(true);
    }
    IEnumerator SetStar(){
        
        for (int i = 1; i <= countStar; i++)
        {
            int sumGold = congVang * i;
            listStar[i-1].SetActive(true);
            txtCongVang.text = "+" + sumGold;
            yield return new WaitForSeconds(1.5f);
            PlayerData.Instance.gold += sumGold;
            PlayerData.Instance.SaveDataGame();
        }
    }
    public void GoHanhTrang(){
        //LoadingScene.Instance.LoadScThuong("HanhTrang");
        PlayerMeoController.Instance.DestroyObj();
        SceneManager.LoadScene("Main");
    }
    
    public void RestartLever(){
        PlayerMeoController.Instance.SetNut();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
