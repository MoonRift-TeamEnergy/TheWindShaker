using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerWithAnimations : MonoBehaviour
{
    #region objects in relation

    [SerializeField] Image powerScale = default;
    [SerializeField] Transform target = default;
    [SerializeField] Animator targetAnimator = default;
    [SerializeField] Sprite[] temperarryanimator = default;

    #endregion

    #region SerializeFields

    [SerializeField] float SpeedOfPower = 10;
    [SerializeField] float maxPower = 100;

    #endregion

    #region my variables

    Rigidbody myrb = default;
    ParticleSystem airParticals = default;
    SpriteRenderer mysprite = default;
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
        airParticals = GetComponent<ParticleSystem>();
        beginingOfTheLevel = transform.position;
        mysprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Jump();
        ParticalsAndAnimationsUpdater();
        myrb.AddForce(PushVector, ForceMode.Force);

    }


    // this controls the players jump
    void Jump()
    {
        if (isgounded)
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
                            mysprite.sprite = temperarryanimator[1];
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
                            GetComponent<AudioSource>().Play();


                            targetAnimator.SetBool("Pause", false);
                            powerScale.enabled = false;
                            buttonPress = 0;
                            Debug.Log("power = " + power);

                            myrb.AddForce(savePosition * power, ForceMode.VelocityChange);
                            mysprite.sprite = temperarryanimator[2];
                            Debug.Log("velocity = " + myrb.velocity);
                            power = 0;
                            isgounded = false;
                            airParticals.Play(true);
                        }
                        break;
                    }
            }

    }

    void ParticalsAndAnimationsUpdater()
    {
        #region particals updater

        if (airParticals.isPlaying && myrb.velocity.y < 0)
        {
            airParticals.Stop();
        }

        #endregion

        #region animations
        if (myrb.velocity.y < 0 & !isgounded)
        {
            mysprite.sprite = temperarryanimator[3];
        }

        #endregion
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
        if (collision.collider.tag == "Danger")
        {
            Death();
        }
        else if (collision.collider.tag == "Ground" && !isgounded)
        {
            isgounded = true;
            target.gameObject.SetActive(true);
            mysprite.sprite = temperarryanimator[0];
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
        if (isgounded)
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
