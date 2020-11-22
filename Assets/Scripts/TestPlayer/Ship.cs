using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO:ステータス、体力のクラス(敵、プレイヤー共有)
namespace TestPlayer {
    public class Ship : MonoBehaviour {
        private Rigidbody rigidbody = null;

        [SerializeField]
        public GameObject BulletPrefab = null;

        [SerializeField]
        public Transform Root = null;

        private static readonly float REGAIN_SPEED = 0.01f;

        private static readonly float INCLINE_SPEED = 2;

        private float angleLimit = 60;

        protected void Awake () {
            rigidbody = Root.GetComponent<Rigidbody> ();
        }

        protected void Debug_MoveTurn () {
            Root.transform.eulerAngles += Vector3.down * 180;
        }

        protected void ShotBullet () {
            GameObject obj = Instantiate (BulletPrefab, Root.transform.position, Quaternion.identity);
            obj.GetComponent<Bullet> ().Speed = rigidbody.velocity;
        }

        protected void MoveLeft () {
            Root.transform.eulerAngles += Vector3.down * Ship.INCLINE_SPEED;
            InclineShipRight ();
        }

        protected void MoveRight () {
            Root.transform.eulerAngles += Vector3.up * Ship.INCLINE_SPEED;
            InclineShipLeft ();
        }

        protected void MoveUp () {
            //print (FixAngle (Ship.transform.eulerAngles.x) + "::" + Ship.transform.eulerAngles.x);
            if (-this.angleLimit < FixAngle (Root.transform.eulerAngles.x)) {
                Root.transform.eulerAngles += Vector3.left * INCLINE_SPEED;
            }
        }

        protected void MoveDown () {
            //print (FixAngle (Ship.transform.eulerAngles.x) + "::" + Ship.transform.eulerAngles.x);
            if (FixAngle (Root.transform.eulerAngles.x) < this.angleLimit) {
                Root.transform.eulerAngles += Vector3.right * INCLINE_SPEED;
            }
        }

        protected void ApplyVelocity () {
            rigidbody.velocity = new Vector3 (
                Mathf.Sin (Mathf.Deg2Rad * Root.transform.eulerAngles.y),
                (-1) * Mathf.Sin (Mathf.Deg2Rad * Root.transform.eulerAngles.x),
                Mathf.Cos (Mathf.Deg2Rad * Root.transform.eulerAngles.y)
            );
        }

        protected void RegainShip () {
            if (0 < FixAngle (Root.transform.eulerAngles.z)) {
                Root.transform.eulerAngles += Vector3.back * INCLINE_SPEED;
            } else if (0 > FixAngle (Root.transform.eulerAngles.z)) {
                Root.transform.eulerAngles += Vector3.forward * INCLINE_SPEED;
            }
        }

        private void InclineShipLeft () {
            if (-this.angleLimit < FixAngle (Root.transform.eulerAngles.z)) {
                Root.transform.eulerAngles += Vector3.back * INCLINE_SPEED;
            }
        }

        private void InclineShipRight () {
            if (FixAngle (Root.transform.eulerAngles.z) < this.angleLimit) {
                Root.transform.eulerAngles += Vector3.forward * INCLINE_SPEED;
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