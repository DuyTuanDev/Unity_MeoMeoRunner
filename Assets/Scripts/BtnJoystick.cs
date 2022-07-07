using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.name == "BtnJump"){
            PlayerMeoController.Instance.isJump = true;
        }
        if(gameObject.name == "BtnSkill"){
            PlayerMeoController.Instance.isAttackJoy = true;
        }
        if(gameObject.name == "BtnLeft"){
            PlayerMeoController.Instance.SetMove(true);
        }
        if(gameObject.name == "BtnRight"){
            PlayerMeoController.Instance.SetMove(false);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if(gameObject.name == "BtnLeft"){
            PlayerMeoController.Instance.isMoveLeft = false;
            PlayerMeoController.Instance.spJoy = 0;
        }
        if(gameObject.name == "BtnRight"){
            PlayerMeoController.Instance.isMoveRight = false;
            PlayerMeoController.Instance.spJoy = 0;
        }

        PlayerMeoController.Instance.isJump = false;
        PlayerMeoController.Instance.isAttackJoy = false;
    }
}
