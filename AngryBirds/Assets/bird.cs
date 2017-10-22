using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class bird : MonoBehaviour {

    private bool isPressed = false;
    public Rigidbody2D rb;
    public float releaseTime = .15f;
    public float maxDragDistance = 2f;
    public Rigidbody2D hook;
    public GameObject nextBird;

    // Update is called once per frame
    void Update () {
        if (isPressed) {
            Vector2 mousePos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
           {
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            }
           else {
                rb.position = mousePos;
           }
        }
         
	}

     void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

     void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release() {
       yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);

        if (nextBird != null)
        {
            nextBird.SetActive(true);
        }
        else {
            enemy.enemyAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
