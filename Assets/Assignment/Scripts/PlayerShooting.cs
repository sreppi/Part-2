using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject retical;
    public Vector3 worldPosition;
    public GameObject arrowPrefab;
    public Vector2 newPosition;
    public Transform startPosition;
    public Transform endPosition;
    public float coolDownTimer;
    public bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        coolDownTimer += Time.deltaTime;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; // This is to fix the z axis issue
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        retical.transform.position = worldPosition;

        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            PlayerShoot();
            canShoot = false;
        }

        while (canShoot == false) 
        {
            coolDownTimer += Time.deltaTime;
            if (coolDownTimer >= 2) 
            {
                canShoot = true;
                coolDownTimer = 0;
            }
            return;
        }
    }

    public void PlayerShoot()
    {
        //Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(arrowPrefab, worldPosition, Quaternion.identity);
    }
}
