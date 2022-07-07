using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasThongBao : MonoBehaviour
{
    static public CanvasThongBao Instance;
    public Text txtThongBao;
    bool isShow = false;
    private void Start()
    {
        Instance = this;
    }
    public void SetThongBao(string txt)
    {
        txtThongBao.text = txt;
        ShowThongBao();
    }
    public void ShowThongBao()
    {
        
        StartCoroutine(Show());
    }
    IEnumerator Show()
    {
        if (!isShow)
        {
            txtThongBao.gameObject.SetActive(true);
            isShow = true;
            yield return new WaitForSeconds(1f);
            txtThongBao.gameObject.SetActive(false);
            isShow = false;
        }
        

    }
}
