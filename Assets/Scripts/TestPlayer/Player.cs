using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPlayer {
    public class Player : Ship {
        void Awake () {
            base.Awake();
        }

        void Start () {

        }

        void Update () {
            ApplyVelocity ();

            if (Input.GetKeyDown (KeyCode.Space)) {
                ShotBullet ();
            }

            if (Input.GetKey (KeyCode.A)) {
                Debug_MoveTurn ();
            }

            if (Input.GetKey (KeyCode.LeftArrow)) {
                MoveLeft ();
            } else if (Input.GetKey (KeyCode.RightArrow)) {
                MoveRight ();
            } else {
                RegainShip ();
            }

            if (Input.GetKey (KeyCode.DownArrow)) {
                MoveDown ();
            } else if (Input.GetKey (KeyCode.UpArrow)) {
                MoveUp ();
            }
        }
    }
}