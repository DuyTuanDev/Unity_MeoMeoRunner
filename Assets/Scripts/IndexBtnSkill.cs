using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndexBtnSkill : MonoBehaviour
{
    public int indexSkill = -1;
    public bool isUnlock = false;
    public void SetSkillPlayer(){
        PlayerMeoController.Instance.indexSkill = indexSkill;
        HTrangSkill.Instance.SetUseSkillBtn(indexSkill);
        PlayerData.Instance.indexSkill = indexSkill;
        PlayerData.Instance.SaveDataGame();
    }
    public Button btn;
    void Start()
    {
        btn = GetComponent<Button>();
        HTrangSkill.Instance.SetUseSkillBtn(PlayerMeoController.Instance.indexSkill);
        if(isUnlock){
            
            btn.onClick.AddListener(SetSkillPlayer);
        }
        else{
            // btn.GetComponentInChildren<Text>().text = "Buy";
            btn.onClick.AddListener(BuySkill);
        }
    }
    int gold;
    public void BuySkill(){
        
        if (indexSkill == 1 && !PlayerData.Instance.kill1)
        {
            gold = 100;
            if (PlayerData.Instance.gold < gold)
            {
                CanvasThongBao.Instance.SetThongBao("Không đủ tiền");
            }
            else
            {
                PlayerData.Instance.kill1 = true;
            }
        }
        if (indexSkill == 2 && !PlayerData.Instance.kill2)
        {
            gold = 500;
            if (PlayerData.Instance.gold < gold)
            {
                CanvasThongBao.Instance.SetThongBao("Không đủ tiền");
            }
            else
            {
                PlayerData.Instance.kill2 = true;
            }
        }
        if (indexSkill == 3 && !PlayerData.Instance.kill3)
        {
            gold = 1000;
            if (PlayerData.Instance.gold < gold)
            {
                CanvasThongBao.Instance.SetThongBao("Không đủ tiền");
            }
            else
            {
                PlayerData.Instance.kill3 = true;
            }
        }
        if(indexSkill == 4 && !PlayerData.Instance.kill4)
        {
            
            gold = 1500;
            if (PlayerData.Instance.gold < gold)
            {
                CanvasThongBao.Instance.SetThongBao("Không đủ tiền");
            }
            else
            {
                PlayerData.Instance.kill4 = true;
            }
        }
        if(indexSkill == 5 && !PlayerData.Instance.kill5)
        {
            
            gold = 2500;
            if (PlayerData.Instance.gold < gold)
            {
                CanvasThongBao.Instance.SetThongBao("Không đủ tiền");
            }
            else
            {
                PlayerData.Instance.kill5 = true;
            }
        }
        if(indexSkill == 6 && !PlayerData.Instance.kill6)
        {
            
            gold = 4000;
            if (PlayerData.Instance.gold < gold)
            {
                CanvasThongBao.Instance.SetThongBao("Không đủ tiền");
            }
            else
            {
                PlayerData.Instance.kill6 = true;
            }
        }
        if(PlayerData.Instance.gold < gold && !isUnlock)
        {
            CanvasThongBao.Instance.SetThongBao("Không đủ tiền");
        }
        else if(PlayerData.Instance.gold >= gold && !isUnlock)
        {
            isUnlock = true;
            PlayerData.Instance.gold-= gold;
            PlayerMeoController.Instance.indexSkill = indexSkill;
            PlayerData.Instance.indexSkill = indexSkill;
            btn.onClick.AddListener(SetSkillPlayer);
            HTrangSkill.Instance.SetUseSkillBtn(indexSkill);
            PlayerData.Instance.SaveDataGame();
        }
        
    }
}
