using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class IndexButtonMap : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public string nameMap;
    public Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadingLevel);
    }

    public void LoadingLevel(){
        // Debug.Log(indexMap);
        //LoadingScene.Instance.LoadScLevel(nameMap);
        PlayerMeoController.Instance.SetPosPlayer();
        PlayerUI.Instance.CanVasBtn.SetActive(true);
        PlayerUI.Instance.CanVasInfoPlayer.SetActive(true);
        SceneManager.LoadScene(nameMap);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    
}
