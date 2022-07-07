// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CamFollow : MonoBehaviour
// {
//     static public CamFollow Instance;
//     public GameObject Player;
//     public Transform posPlayer;
//     public float minX, maxX;
//     public float minY, maxY;
//     float speedCam = 3f;
//     private void Start() {
//         Instance = this;
//         // Player = GameObject.Find("Player");
//         posPlayer = Player.transform;
//         transform.position = new Vector3(posPlayer.position.x, posPlayer.position.y, -10f);
//     }
//     private void Update() {
//         transform.position = new Vector3(posPlayer.position.x, posPlayer.position.y, -10f);
//     }
//     // void LateUpdate()
//     // {
//     //     if(posPlayer != null){
//     //         Vector3 temp = transform.position;
//     //         temp = posPlayer.position;
//     //         temp.z = -10f;
//     //         if(temp.x < minX){
//     //             temp.x = minX;
//     //         }
//     //         if(temp.x > maxX){
//     //             temp.x = maxX;
//     //         }
//     //         if(temp.y < minY){
//     //             temp.y = minY;
//     //         }
//     //         if(temp.y > maxY){
//     //             temp.y = maxY;
//     //         }
//     //         transform.position = Vector3.MoveTowards(transform.position, temp, speedCam * Time.deltaTime);
//     //     }
//     //     // if(posPlayer != null){
//     //     //     Vector3 tempy = transform.position;
//     //     //     tempy.y = posPlayer.position.y;
//     //     //     if(tempy.y < minY){
//     //     //         tempy.y = minY;
//     //     //     }
//     //     //     if(tempy.y > maxY){
//     //     //         tempy.y = maxY;
//     //     //     }
//     //     //     transform.position = Vector3.MoveTowards(transform.position, tempy, speedCam * Time.deltaTime);
//     //     // }
//     // }
// }
