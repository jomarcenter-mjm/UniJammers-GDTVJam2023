using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    for (float i = 0; i < 360; i++)
    {
      Debug.DrawRay(this.gameObject.transform.position, Quaternion.Euler(0, i, 0) * this.gameObject.transform.forward * 2, Color.red, 1.0f);
    }
  }
}
