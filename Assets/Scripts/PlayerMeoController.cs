using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeoController : CharacterMeoController
{
    static public PlayerMeoController Instance;
    private void Awake() {
        if(Instance != null){
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        isGround = true;
        indexSkill = PlayerData.Instance.indexSkill;
        for (int i = 1; i < skills.Count; i++)
        {
            skills[i].SetActive(false);
        }
    }
    void Update()
    {
        if (PlayerMeoController.Instance.isGameOver) return;
        if (isWork || isGameOver) {
            mBody.velocity = new Vector2(0f, mBody.velocity.y);
            return;
        }

        AttackJoy();
        MoveAndroid();
        //#if UNITY_ANDROID
        //if (Application.platform == RuntimePlatform.Android)
        //        {
        //            AttackJoy();
        //            MoveAndroid();
        //        }
        //#endif
    }
    public GameObject CanvasNutDieuHuong;
    public void SetNut()
    {
        CanvasNutDieuHuong.SetActive(true);
    }
    public void SetMove(bool bl){
        this.isMoveLeft = bl;
        this.isMoveRight = !bl;
    }
    public void SetFalseMove(){
        this.isMoveLeft = false;
        this.isMoveRight = false;
    }
    
    private void MoveAndroid()
    {
        if(!isRuning){
            if(isMoveRight){
                spJoy = 1;
            }
            if(isMoveLeft){
                spJoy = -1;
            }
            if(!PlayerMeoController.Instance.isAttack){
                mBody.velocity = new Vector3(spJoy * speed, mBody.velocity.y);
                mAni.SetFloat("speed", Mathf.Abs(spJoy));
            }
            
            if(spJoy < 0f){
                transform.eulerAngles = new Vector3(0,0,0);
                FlipTrue();
            }
            else if(spJoy > 0f){
                transform.eulerAngles = new Vector3(0,180,0);
                FlipFalse();
            }
        }
        else{
            mAni.SetFloat("speed", 1);
        }
        if(isJump && isGround){
            mBody.AddForce(new Vector2(0, 300f));
            mAni.SetTrigger("Jump");
            isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            isGround = true;
            isJump = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            mAni.SetTrigger("Died");
            PlayerUI.Instance.CanVasBtn.SetActive(false);
            GameManager.Instance.SetGameOver();
            isGameOver = true;
        }
    }
    public void SetPosPlayer(){
        isRuning = true;
        isWork = false;
        mAni.SetFloat("speed", 1f);
        transform.eulerAngles = new Vector3(0,180,0);
        transform.position = new Vector3(-6.5f, -1.5f, 0);
    }
    public void DestroyObj(){
        Destroy(gameObject);
    }
    public GameObject panelSetting;
    public void ShowPanelSetting()
    {
        panelSetting.SetActive(true);
        PlayerMeoController.Instance.isWork = true;
    }
    public void HidePanelSetting()
    {
        panelSetting.SetActive(false);
        PlayerMeoController.Instance.isWork = false;
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
