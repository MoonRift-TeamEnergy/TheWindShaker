using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region objects in relation

    [SerializeField] Image powerScale = default;
    [SerializeField] Transform target = default;
    [SerializeField] Animator targetAnimator = default;

    #endregion

    #region SerializeFields

    [SerializeField] float SpeedOfPower = 10;
    [SerializeField] float maxPower = 100;

    #endregion

    #region my variables

    Rigidbody myrb = default;
    Vector3 beginingOfTheLevel = default;
    Vector3 savePosition = default;
    bool up = true;
    float power = 1.0f;
    int buttonPress = 0;
    bool isgounded = false;

    #endregion

    [SerializeField] Vector3 test;

    // Start is called before the first frame update
    void Start()
    {
        powerScale.enabled = false;
        myrb = GetComponent<Rigidbody>();
        
        beginingOfTheLevel = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Jump();
        myrb.AddForce(PushVector, ForceMode.Force); 

    }


    // this controls the players jump
    void Jump()
    {
        if(isgounded)
        switch (buttonPress)
        {
            case 0:
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        savePosition = target.localPosition;
                        targetAnimator.SetBool("Pause", true);
                        buttonPress++;
                        target.gameObject.SetActive(false);

                        powerScale.enabled = true;
                    }
                    break;
                }

            case 1:
                {
                    updatePower();
                    powerScale.fillAmount = power / maxPower;
                    if (Input.GetButtonUp("Jump"))
                    {

                        targetAnimator.SetBool("Pause", false);
                        powerScale.enabled = false;
                        buttonPress = 0;
                        Debug.Log("power = " + power);

                        myrb.AddForce(savePosition * power, ForceMode.VelocityChange);

                        Debug.Log("velocity = " + myrb.velocity);
                        power = 0;
                        isgounded = false;
                    }
                    break;
                }
        }

    }

    // this controls the power of the jump
    void updatePower()
    {
        Debug.Log("power = " + power);
        if (up)
        {
            power += SpeedOfPower * Time.deltaTime;

        }
        else
        if (!up)
        {
            power -= SpeedOfPower * Time.deltaTime;

        }

        if (power >= maxPower)
        {
            up = false;
        }
        else if (power <= 1)
        {
            up = true;
        }
    }

    void Death()
    {
        Debug.Log("im dead XP");
        myrb.velocity = Vector3.zero;
        transform.position = beginingOfTheLevel;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Danger")
        {
            Death();
        }
        else if(collision.collider.tag == "Ground" && !isgounded)
        {
            isgounded = true;
            target.gameObject.SetActive(true);
        }
    }


    public void SetVilocity(Vector3 _vilocity)
    {
        myrb.velocity = _vilocity;
    }

    public Vector3 GetVilocity()
    {
        return myrb.velocity;
    }

    public void SetGrounded(bool _isgrounded)
    {
        isgounded = _isgrounded;
        if(isgounded)
        {
            targetAnimator.SetBool("Pause", false);
            target.gameObject.SetActive(true);
        }
    }

    public bool GetGrounded()
    {
        return isgounded;
    }



    public Vector3 PushVector { get; set; }
}
