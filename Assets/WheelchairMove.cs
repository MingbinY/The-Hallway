using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelchairMove : MonoBehaviour
{
    public ToyCar tc;
    public MeshRenderer mr;
    public Material monitorMat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerManager>() != null)
        {
            tc.TriggerMove();
            mr.material = monitorMat;
            Destroy(gameObject);
        }
    }
}
