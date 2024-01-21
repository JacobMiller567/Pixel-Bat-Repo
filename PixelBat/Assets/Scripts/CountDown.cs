using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] private GameObject readyPopup;
    //[SerializeField] private GameObject goPopup;

    void Start()
    {
        GameObject floatingCountDown = Instantiate(readyPopup, transform.position, Quaternion.identity) as GameObject;
        floatingCountDown.transform.GetChild(0).GetComponent<TMP_Text>().text = "Ready";
        StartCoroutine(NextPopup());    
    }

    private IEnumerator NextPopup()
    {
        yield return new WaitForSeconds(1f);
        GameObject floatingCountDown = Instantiate(readyPopup, transform.position, Quaternion.identity) as GameObject;
        floatingCountDown.transform.GetChild(0).GetComponent<TMP_Text>().text = "Go!";
    }
}
