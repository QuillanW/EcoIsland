using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointer : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(run());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator run() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }

}
