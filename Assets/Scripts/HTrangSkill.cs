using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HTrangSkill : MonoBehaviour
{
    static public HTrangSkill Instance;
    public List<GameObject> btnSkill = new List<GameObject>();
    private void Awake() {
        Instance = this;
        
        for (int i = 0; i < btnSkill.Count; i++)
        {
            btnSkill[i].GetComponent<IndexBtnSkill>().indexSkill = i+1;
            if(i == 0){
                btnSkill[i].GetComponent<IndexBtnSkill>().isUnlock = PlayerData.Instance.kill1;
            }
            if(i == 1){
                btnSkill[i].GetComponent<IndexBtnSkill>().isUnlock = PlayerData.Instance.kill2;
            }
            if(i == 2){
                btnSkill[i].GetComponent<IndexBtnSkill>().isUnlock = PlayerData.Instance.kill3;
            }
            if(i == 3){
                btnSkill[i].GetComponent<IndexBtnSkill>().isUnlock = PlayerData.Instance.kill4;
            }
            if(i == 4){
                btnSkill[i].GetComponent<IndexBtnSkill>().isUnlock = PlayerData.Instance.kill5;
            }
            if(i == 5){
                btnSkill[i].GetComponent<IndexBtnSkill>().isUnlock = PlayerData.Instance.kill6;
            }
        }
        
    }
    public void SetUseSkillBtn(int indexSkill){
        for (int i = 0; i < btnSkill.Count; i++)
        {
            if(indexSkill != (i+1) && btnSkill[i].GetComponent<IndexBtnSkill>().isUnlock){
                btnSkill[i].GetComponentInChildren<Text>().color = Color.white;
                btnSkill[i].GetComponentInChildren<Text>().text = "Use";
                var colors = btnSkill[i].GetComponent<Button>().colors;
                colors.normalColor = Color.black;
                btnSkill[i].GetComponent<Button>().colors = colors;
            }
            else if(indexSkill == (i+1) && btnSkill[i].GetComponent<IndexBtnSkill>().isUnlock){
                btnSkill[i].GetComponentInChildren<Text>().text = "Used";
                var colors = btnSkill[i].GetComponent<Button>().colors;
                colors.normalColor = Color.red;
                btnSkill[i].GetComponent<Button>().colors = colors;
                var colorsSl = btnSkill[i].GetComponent<Button>().colors;
                colorsSl.selectedColor = Color.red;
                btnSkill[i].GetComponent<Button>().colors = colorsSl;
            }
        }
        PlayerData.Instance.SaveDataGame();
    }
}
