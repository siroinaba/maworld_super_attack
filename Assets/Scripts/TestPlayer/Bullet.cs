using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private static readonly float BASE_SPEED = 20;

    private Vector3 _speed;

    public Vector3 Speed {
        get => this._speed;
        set => this._speed = value;
    }

    private Rigidbody rigidbody = null;

    void Awake () {
        rigidbody = GetComponent<Rigidbody> ();
    }

    void Start () {

    }

    void Update () {
        rigidbody.velocity = Speed * Bullet.BASE_SPEED;
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag.Equals ("StageWall")) {
            Destroy (this.gameObject);
        }
    }
}