using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private Animator substanceBall = null;

    // Start is called before the first frame update
    void Start()
    {
        substanceBall = this.GetComponent<Animator>();
        Debug.Log("Helloo???");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAnimation(GameObject parent)
    {
        substanceBall.transform.SetParent(parent.transform, false);

        Debug.Log("Play Animation");
        substanceBall.Play("MoveBall", 0, 0.0f);


        //if (substanceBall.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        //{
        //    Debug.Log("SubstanceBall destroyed");
        //    Destroy(this);
        //}

    }
}
