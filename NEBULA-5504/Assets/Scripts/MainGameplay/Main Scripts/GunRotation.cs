using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer gunSprite;

    private GameObject player;

    Vector3 mousePos;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
    }

    private void Update()
    {
        transform.position = player.transform.position;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        if (player.GetComponent<PlayerMovement>().MovementAvailable)
        {
            Vector3 lookDir = mousePos - player.transform.position;
            float targetAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);

            if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            {
                gunSprite.flipY = true;
            }
            else
            {
                gunSprite.flipY = false;
            }
        }
    }
}
