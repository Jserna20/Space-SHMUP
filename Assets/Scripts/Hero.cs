using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S;

    [Header("Set in Inspector")]

    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    public float gameResartDelay = 2f;

    [Header("Set Dynamically")]
    [SerializeField]
    private float _shieldLevel = 1;

    //This variable holds a reference to the last triggering GameObject
    private GameObject lastTriggeredGo = null;

    private void Awake()
    {
        if (S == null)
            S = this;
        else
            Debug.LogError("Hero.Awake() - Attempted tp assign second Hero.S!");
    }

	
	// Update is called once per frame
	void Update ()
    {
        //Pull in information from the Input class
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        //Change transform.position based on the axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        //Rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);
	}

	private void OnTriggerEnter(Collider other)
	{
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;

        if(go == lastTriggeredGo)
        {
            return;
        }
        lastTriggeredGo = go;

        if(go.tag == "Enemy")
        {
            shieldLevel--;
            Destroy(go);
        }
        else
        {
            print("Triggered by non-Enemy" + go.name);
        }
	}

    public float shieldLevel{
        get{
            return (_shieldLevel);
        }
        set{
            _shieldLevel = Mathf.Min(value, 4);
            //If the shield is going to be set to less than zero
            if(value < 0)
            {
                Destroy(this.gameObject);
                Main.S.DelayedRestart(gameResartDelay);
            }
        }
    }
}
