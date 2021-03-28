using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagnetMovement : MonoBehaviour
{
    public GameObject topMag;
    public GameObject bottomMag;

    Vector2 topMove = Vector2.zero;
    Vector2 bottomMove = Vector2.zero;

    public float speed = 1.0f;

    bool swap = false;

    private void FixedUpdate()
    {
        if (swap)
        {
            topMag.GetComponent<Magnet>().SwapPolarity();
            bottomMag.GetComponent<Magnet>().SwapPolarity();
            swap = false;
        }

        topMag.transform.position = (topMag.transform.position + new Vector3(topMove.x, 0.0f, topMove.y) * speed * Time.fixedDeltaTime);
        bottomMag.transform.position = (bottomMag.transform.position + new Vector3(bottomMove.x, 0.0f, bottomMove.y) * speed * Time.fixedDeltaTime);
    }

    public void OnTopMagnet(InputAction.CallbackContext ctx)
    {
        topMove = ctx.ReadValue<Vector2>();
        topMove.y = 0.0f;
    }
    public void OnBottomMagnet(InputAction.CallbackContext ctx)
    {
        bottomMove = ctx.ReadValue<Vector2>();
        bottomMove.y = 0.0f;
    }

    public void OnSwapPolarity(InputAction.CallbackContext ctx)
    {
        float button = ctx.ReadValue<float>();

        swap = button > 0.5f ? swap = true : swap = false;


    }
}
