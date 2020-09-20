using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPlayer {
    [RequireComponent (typeof (Rigidbody))]
    public class Player : MonoBehaviour {
        [SerializeField]
        public Rigidbody Rigidbody = null;

        [SerializeField]
        public GameObject Ship = null;

        private static readonly float SHIP_REGAIN_SPEED = 0.01f;

        private static readonly float SHIP_INCLINE_SPEED = 2;

        private float angleLimit = 60;

        void Awake () {

        }

        void Start () {

        }

        void Update () {
            //速度計算
            Rigidbody.velocity = new Vector3 (
                Mathf.Sin (Mathf.Deg2Rad * transform.eulerAngles.y),
                (-1) * Mathf.Sin (Mathf.Deg2Rad * transform.eulerAngles.x),
                Mathf.Cos (Mathf.Deg2Rad * transform.eulerAngles.y)
            );

            //左右
            if (Input.GetKey (KeyCode.LeftArrow)) {
                transform.eulerAngles += Vector3.down * Player.SHIP_INCLINE_SPEED;
                InclineShipRight ();
            } else if (Input.GetKey (KeyCode.RightArrow)) {
                transform.eulerAngles += Vector3.up * Player.SHIP_INCLINE_SPEED;
                InclineShipLeft ();
            } else {
                RegainShip ();
            }

            //上下
            if (Input.GetKey (KeyCode.DownArrow)) {
                //print (FixAngle (Ship.transform.eulerAngles.x) + "::" + Ship.transform.eulerAngles.x);
                if (FixAngle (Ship.transform.eulerAngles.x) < this.angleLimit) {
                    transform.eulerAngles += Vector3.right * Player.SHIP_INCLINE_SPEED;
                }
            } else if (Input.GetKey (KeyCode.UpArrow)) {
                //print (FixAngle (Ship.transform.eulerAngles.x) + "::" + Ship.transform.eulerAngles.x);
                if (-this.angleLimit < FixAngle (Ship.transform.eulerAngles.x)) {
                    transform.eulerAngles += Vector3.left * Player.SHIP_INCLINE_SPEED;
                }
            }
        }

        private void InclineShipLeft () {
            if (-this.angleLimit < FixAngle (Ship.transform.eulerAngles.z)) {
                Ship.transform.eulerAngles += Vector3.back * Player.SHIP_INCLINE_SPEED;
            }
        }

        private void InclineShipRight () {
            if (FixAngle (Ship.transform.eulerAngles.z) < this.angleLimit) {
                Ship.transform.eulerAngles += Vector3.forward * Player.SHIP_INCLINE_SPEED;
            }
        }

        private void RegainShip () {
            if (0 < FixAngle (Ship.transform.eulerAngles.z)) {
                Ship.transform.eulerAngles += Vector3.back * Player.SHIP_INCLINE_SPEED;
            } else if (0 > FixAngle (Ship.transform.eulerAngles.z)) {
                Ship.transform.eulerAngles += Vector3.forward * Player.SHIP_INCLINE_SPEED;
            }
        }

        private float FixAngle (float angle) {
            float eularAnglesZ = angle;
            if (eularAnglesZ > 180) {
                return eularAnglesZ - 360;
            }

            if (eularAnglesZ < -180) {
                return eularAnglesZ + 360;
            }

            return eularAnglesZ;
        }
    }
}