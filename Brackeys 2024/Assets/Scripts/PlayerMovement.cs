using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction playerControls;
    public InputAction jump;
    private Rigidbody2D rb;
    private GameObject playerChild;
    private GameObject playerShadow;

    public float moveSpeed;
    private Vector2 direction;

    private bool canJump;
    public float jumpDuration;
    public float jumpHeight;
    public AnimationCurve playerJumpCurve;
    public AnimationCurve playerScaleCurveX;
    public AnimationCurve shadowCurve;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerChild = transform.GetChild(0).gameObject;
        playerShadow = transform.GetChild(1).gameObject;
        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        direction = playerControls.ReadValue<Vector2>();
        rb.velocity = direction.normalized * moveSpeed;
    }

    void OnJumpPerformed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if(!canJump ) { return; }
        canJump = false;
        StartCoroutine(PerformJump());
    }

    IEnumerator PerformJump()
    {
        float time = 0;
        float jumpMaxHeight = playerChild.transform.localPosition.y + jumpHeight;
        float originialHeight = playerChild.transform.localPosition.y;
        Vector3 originalShadowScale = new Vector3(playerShadow.transform.localScale.x, playerShadow.transform.localScale.y, playerShadow.transform.localScale.z);
        Vector3 originalPlayerScale = new Vector3(playerChild.transform.localScale.x, playerChild.transform.localScale.y, playerChild.transform.localScale.z);
        float playerScaleModifierX;
        float shadowScaleModifier = 0;
        while (time < jumpDuration)
        {
            float t = time / jumpDuration;
            shadowScaleModifier = shadowCurve.Evaluate(t);
            playerScaleModifierX = playerScaleCurveX.Evaluate(t);

            playerChild.transform.localPosition = new Vector2(0, Mathf.Lerp(originialHeight, jumpMaxHeight, playerJumpCurve.Evaluate(t)));
            playerChild.transform.localScale = Vector3.Scale(originalPlayerScale, new Vector3(playerScaleModifierX, 1, 1));
            playerShadow.transform.localScale = originalShadowScale * shadowScaleModifier;
            time += Time.deltaTime;
            yield return null;
        }
        canJump = true;
        playerShadow.transform.localScale = originalShadowScale;
        playerChild.transform.localScale = originalPlayerScale;
        playerChild.transform.localPosition = new Vector2(0, originialHeight);
    }

    private void OnEnable()
    {
        jump.Enable();
        jump.started += OnJumpPerformed;
        playerControls.Enable();
    }

    private void OnDisable()
    {
        jump.started -= OnJumpPerformed;
        jump.Disable();
        playerControls.Disable();
    }
}
