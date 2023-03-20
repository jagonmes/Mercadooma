using UnityEngine.Events;
using UnityEngine;

public class Arma : MonoBehaviour
{

    public UnityEvent OnGunShoot;
    public float FireCoolDown;

    public bool Auto;

    private float CoolDown;

    void Start()
    {
        CoolDown = FireCoolDown;
    }

    void Update()
    {
        if (Auto) 
        {
            if (Input.GetMouseButton(0))
            {
                if (CoolDown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CoolDown = FireCoolDown;
                }
            }
        }else 
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (CoolDown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CoolDown = FireCoolDown;
                }
            }
        }
        CoolDown -= Time.deltaTime;
    }
}
