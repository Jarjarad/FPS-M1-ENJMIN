using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {

    public float DeltaUpdateSec = 0.5f;
    public Text ammoText;
    public Text lifeText;
    public Transform DataSource;

    private PlayerData datas;
    private float delta = 0.0f;


    // Use this for initialization
    void Start () {
        datas = DataSource.GetComponent<PlayerData>();

    }
	
	// Update is called once per frame
	void Update () {
        delta += Time.deltaTime;
        if (delta > DeltaUpdateSec)
        {
            Debug.Log(ammoText);
            Debug.Log(datas);

            ammoText.text = datas.GetAmmo().ToString();
            lifeText.text = datas.GetLife().ToString();

            delta -= DeltaUpdateSec;
        }

    }
}
