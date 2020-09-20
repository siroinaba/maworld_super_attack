using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReverseCollider : MonoBehaviour {
    private void Start () {
        CreateInvertedMeshCollider ();
    }

    public void CreateInvertedMeshCollider () {
        InvertMesh ();
        gameObject.AddComponent<MeshCollider> ();
    }

    private void InvertMesh () {
        Mesh mesh = GetComponent<MeshFilter> ().mesh;
        mesh.triangles = mesh.triangles.Reverse ().ToArray ();
    }
}