using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float animSpeed;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>(); 
    }

    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animSpeed * Time.deltaTime, 0);
    }
}
