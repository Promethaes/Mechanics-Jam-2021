using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public Material defaultMaterial;
    public Material otherMaterial;
    public bool startNegative = false;
    public bool otherPolarity;


    public void SwapPolarity()
    {
        Debug.Log("E");
        otherPolarity = !otherPolarity;
        if (otherPolarity)
            gameObject.GetComponent<MeshRenderer>().material = otherMaterial;
        else
            gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "MiddleMagnet")
        {

            var rigid = other.gameObject.GetComponent<Rigidbody>();
            //if (rigid.velocity.magnitude >= 20.0f)
            //    rigid.velocity = Vector3.zero;

            Vector3 dir = new Vector3();

            if (startNegative)
                dir = gameObject.transform.position - other.gameObject.transform.position;
            else
                dir = other.gameObject.transform.position - gameObject.transform.position;

            dir = dir.normalized;
            if (otherPolarity){
                dir = -dir;
                dir.x = 0.0f;
            }

            rigid.AddForce(dir, ForceMode.Impulse);
        }
    }

}
