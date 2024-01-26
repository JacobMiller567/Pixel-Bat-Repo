using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyPopup : MonoBehaviour
{
    void Start()
    {
        transform.localPosition += new Vector3(0, 0.5f,0);
        Destroy(gameObject, 0.8f);
    }
}
