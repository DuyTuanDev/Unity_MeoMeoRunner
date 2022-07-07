using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLevelControll : MonoBehaviour
{
    public int soMap;
    public List<GameObject> btnLv = new List<GameObject>();
    private void Start() {
        for (int i = 0; i < btnLv.Count; i++)
        {
            if (i > (soMap+1))
            {
                btnLv[i].GetComponent<Button>().interactable = false;
            }
            btnLv[i].GetComponent<IndexButtonMap>().nameMap = "Map" + (i + 1);
        }
    }
    public void ClickBtnLevel(){
        gameObject.SetActive(false);
    }
}
