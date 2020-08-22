using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	public Text cartSpeed, txtMaxSpeed;
	public Canvas menu, about;
	public Image T_IMG;
	public GameObject Lift;
	public Text liftSpeed;

	// 0 -> T=0
	// 1 -> T=2pisqrt(l/g)
	// 2 -> T=2pisqrt(l/sqrt(sqr(g)+-sqr(a)))
	// 3 -> T=2pisqrt(l/sqrt(g+-a))
	public Sprite spriteTeq_0, spriteTeq_1, spriteTeq_2, spriteTeq_3;
	
	void Start() {
		Time.timeScale = 1;
		cartSpeed.text = "Скорость тележки: 0 км/ч";

		menu.gameObject.SetActive(false);
		about.gameObject.SetActive(false);
	}

	void Update() {
		cartSpeed.text = "Скорость тележки: " 
			+ GameObject.Find("Real Cart").GetComponent<CartController>().getKmph() 
			+ " км/ч";
	}

	public void OnValueChanged(Slider slider) {
		txtMaxSpeed.text = slider.value + " км/ч";
		GameObject.Find("Real Cart").GetComponent<CartController>().maxSpeed = slider.value;
	}

	public void OnValueChangedVer(Slider slider) {
		txtMaxSpeed.text = slider.value + " км/ч";
		GameObject.Find("Lift").GetComponent<LiftScript>().liftSpeed = slider.value;
	}
	
	public void Exit() {
		Time.timeScale = 1;
		Application.Quit();
	}

	public void Restart() {
		Time.timeScale = 1;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void open_m() {
		menu.gameObject.SetActive(true);
		about.gameObject.SetActive(false);
		Time.timeScale = 0;
	}

	public void open_a() {
		menu.gameObject.SetActive(false);
		about.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void close_a() {
		menu.gameObject.SetActive(false);
		about.gameObject.SetActive(false);
		Time.timeScale = 1;
	}

	// 0 -> T=0
	// 1 -> T=2pisqrt(l/g)
	// 2 -> T=2pisqrt(l/sqrt(sqr(g)+-sqr(a)))
	// 3 -> T=2pisqrt(l/sqrt(g+-a))
	public void setTeq(int num) {
		switch (num) {
		case 0: 
			T_IMG.sprite = spriteTeq_0;
			break;
		case 1:
			T_IMG.sprite = spriteTeq_1;
			break;
		case 2: 
			T_IMG.sprite = spriteTeq_2;
			break;
		case 3: 
			T_IMG.sprite = spriteTeq_3;
			break;
		}
	}

	public void toggle_void(Toggle toggle) {
		Lift.GetComponent<LiftScript>().activated = !Lift.GetComponent<LiftScript>().activated;
	}

	public void onLiftSpeedChange(Slider slider) {
		float tmp = Lift.GetComponent<LiftScript>().liftSpeed;
		if(tmp < 0) {
			Lift.GetComponent<LiftScript>().liftSpeed = slider.value * -1;
			liftSpeed.text = "" + slider.value;
		} else {
			Lift.GetComponent<LiftScript>().liftSpeed = slider.value;
			liftSpeed.text = "" + slider.value;
		}
	}

	public void setLiftDirection(int k) {
		Lift.GetComponent<LiftScript>().liftSpeed *= k;
	}

	public void loadLvl(int which) {
		Application.LoadLevel(which);
	}
	
}
