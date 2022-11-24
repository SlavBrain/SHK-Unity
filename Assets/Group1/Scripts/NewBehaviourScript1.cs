using UnityEngine;
using System.Collections;

public class NewBehaviourScript1 : MonoBehaviour
{
    public float _speed;
    public bool timer;
    public float time;
    // Use this for initialization


    void Start()
    {
    }
    // Update is called once per frame
    void Update(){
        if (timer)
        {
            time -= Time.deltaTime;
            if(time < 0)
   {
                timer = false;
                _speed /= 2;
            }
        }

        GameObject[] result = GameObject.FindGameObjectsWithTag("Enemy");

        if(result.Length == 0)
        {
            GameController.controller.End();
            enabled = false;
        }

        if (Input.GetKey(KeyCode.W))
            transform.Translate(0, _speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(0, -_speed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-_speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    public void SendMEssage(GameObject b)
    {


        if(b.name == "enemy")
        {
            Destroy(b);
        }if(b.name == "speed")
        {
            _speed *= 2;
            timer = true;
            time = 2;



        }
    }
}
