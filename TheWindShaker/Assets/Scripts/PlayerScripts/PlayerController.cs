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
    Vector3 savePosition = default;
    bool up = true;
    float power = 0;
    int buttonPress = 0;

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        powerScale.enabled = false;
        myrb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Jump();


    }


    // this controls the players jump
    void Jump()
    {

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
                    if (Input.GetButtonDown("Jump"))
                    {

                        targetAnimator.SetBool("Pause", false);
                        powerScale.enabled = false;
                        buttonPress = 0;
                        Debug.Log("power = " + power);

                        myrb.velocity = savePosition * power;

                        Debug.Log("velocity = " + myrb.velocity);
                        power = 0;
                        target.gameObject.SetActive(true);
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
        else if (power <= 0)
        {
            up = true;
        }
    }
}
