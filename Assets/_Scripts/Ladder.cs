using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ladder : MonoBehaviour
{
    public Transform playerController;
    bool insideLadder;
    public float ladderHeight = 2.5f;
    public FirstPersonController playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<FirstPersonController>();
        insideLadder = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            playerInput.enabled = false;
            insideLadder = !insideLadder;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            playerInput.enabled = true;
            insideLadder = !insideLadder;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (insideLadder && Input.GetKey("w"))
        {
            playerController.transform.position += Vector3.up / ladderHeight;
        }
    }
}
