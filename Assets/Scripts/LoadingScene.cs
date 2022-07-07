using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    static public LoadingScene Instance;
    private void Awake() {
        Instance = this;
    }
    public Slider slideLoading;
    void Start()
    {
        slideLoading.gameObject.SetActive(false);
        // LoadSc(1);
    }
    public void LoadScLevel(string nameSc){
        PlayerUI.Instance.CanVasBtn.SetActive(false);
        PlayerUI.Instance.CanVasInfoPlayer.SetActive(false);
        slideLoading.gameObject.SetActive(true);
        slideLoading.maxValue = 100;
        slideLoading.value = 0;
        StartCoroutine(LoadingScenePr(nameSc));
    }

    IEnumerator LoadingScenePr(string nameSc){
        while(true){
            slideLoading.value += 1;
            yield return new WaitForSeconds(0.05f);
            if(slideLoading.value >= 100){
                PlayerMeoController.Instance.SetPosPlayer();
                PlayerUI.Instance.CanVasBtn.SetActive(true);
                PlayerUI.Instance.CanVasInfoPlayer.SetActive(true);
                SceneManager.LoadScene(nameSc);
            }
        }
    }
    public void LoadScThuong(string nameSc){
        slideLoading.gameObject.SetActive(true);
        slideLoading.maxValue = 100;
        slideLoading.value = 0;
        StartCoroutine(LoadingSceneThuong(nameSc));
    }

    IEnumerator LoadingSceneThuong(string nameSc){
        while(true){
            slideLoading.value += 1;
            yield return new WaitForSeconds(0.05f);
            if(slideLoading.value >= 100){
                // PlayerMeoControll.Instance.SetPosPlayer();
                //PlayerMeoController.Instance.DestroyObj();
                SceneManager.LoadScene(nameSc);
            }
        }
    }
}
