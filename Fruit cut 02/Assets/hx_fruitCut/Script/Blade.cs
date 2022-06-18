using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
   public GameObject bladeTrailPrefab;
    public float minCuttingVelocity = .001f;
    Vector2 previousPosition;
    bool isCutting = false;
    GameObject currentBladeTrail;
    Rigidbody2D rb;
    CircleCollider2D circleCollider;
    Camera cam;

    void Start(){
        circleCollider = GetComponent<CircleCollider2D>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut(){
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude / Time.deltaTime;
        if( velocity > minCuttingVelocity ){
            circleCollider.enabled = true;
        }else{
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;
    }

    void StartCutting(){
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        circleCollider.enabled = false;
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void StopCutting(){
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }
}
