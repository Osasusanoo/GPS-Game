using UnityEngine;

public class EntityMovement : MonoBehaviour
{

    public bool canMove = true;
    [SerializeField] protected float moveSpeed = 12f;
    [SerializeField] protected float moveSpeedMult = 1f;
    [SerializeField] protected float accel = 3f;
    [SerializeField] protected float deccel = 7f;
    [SerializeField] protected float velPower = 1f;

    public Rigidbody2D rb;

    public void SlowDown()
    {
        if (canMove)
        {
            Vector2 speedDiff = -rb.linearVelocity;
            Vector2 movement = Mathf.Pow(speedDiff.magnitude * deccel, velPower) * speedDiff.normalized;
            rb.AddForce(movement * Time.deltaTime);
        }
    }

    public void SetMoveSpeedMult(float mult)
    {
        moveSpeedMult = mult;
    }

    /// <summary>
    /// Only call from FixedUpdate
    /// </summary>
    /// <param name="movementDir"></param>
    public virtual void Move(Vector2 movementDir)
    {
        if (canMove)
        {
            // calculate dir want to move and desired velo
            Vector2 targetSpeed = movementDir.normalized * (moveSpeed * moveSpeedMult);
            // change accell depending on situation(if our target target speed wants to not be 0 use decell)
            // need to split up so don't accidentally use accel for the axis that is supposed to deccel
            Vector2 accelRate = new Vector2(Mathf.Abs(targetSpeed.x) > .01f ? accel : deccel, Mathf.Abs(targetSpeed.y) > .01f ? accel : deccel);
            // calc diff between current and target 
            Vector2 speedDif = targetSpeed - rb.linearVelocity;
            // applies accel to speed diff, raises to power so accel will increase with higher speeds then applies to desired dir
            Vector2 movement = new Vector2(Mathf.Sign(speedDif.x) * Mathf.Pow(Mathf.Abs(speedDif.x * accelRate.x), velPower), Mathf.Sign(speedDif.y) * Mathf.Pow(Mathf.Abs(speedDif.y * accelRate.y), velPower));
            // apply force
            // rb.AddForce(movement * Time.deltaTime);
            rb.AddForce(movement);
        }
    }

    public virtual void ApplyKnockback(Vector2 kb)
    {
        rb.AddForce(kb, ForceMode2D.Impulse);
    }
}
