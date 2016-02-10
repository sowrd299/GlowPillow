using UnityEngine;
using UnityEngine.UI;

public class InfoUI_Controller : MonoBehaviour {

	//display colors
	static Color offColor = new Color(0.5f,0.5f,0.5f,0.6f);
	static Color dfltColor = new Color (0.8f, 0.8f, 0.1f, 0.75f);
	static Color onColor = new Color (1.0f,1.0f,0.4f,0.87f);


	//NOTE: CODE WORKS BEST IF ALL IMAGES IN GRAY-SCALE, TRANSPARENCY (PER PIXEL) EATHER FULL OR NONE
	//each coded sepporately to address unique behavior
	public Image blankyImage;
	public Image sprintImage;
	public Image meleeImage;
	public Image rangedImage;

	//all the shit that the infor comes from
	public GameObject blanky;
	public PlayerAbility pAbil;
	public KeyCode meleeKey;

	public Image reminderImage;

	void start(){
		if(reminderImage != null) colorImage (ref reminderImage, dfltColor);
	}

	void Update(){

		conditDispImage (ref blankyImage, getBlankyOn(),false);
		conditDispImage (ref sprintImage, getIsSprinting (), getBlankyOn() || getIsCooldown ());
		conditDispImage (ref meleeImage, Input.GetKey (meleeKey), getBlankyOn() || getProjectileThrown());
		conditDispImage (ref rangedImage, getProjectileThrown (), getBlankyOn());

	}

	private bool getBlankyOn(){
		//SHOULD RETURN TRUE IF THE PLAYER IS WEARING THE BLANKY
		return blanky.activeInHierarchy;
	}

	private bool getIsSprinting(){
		//SHOULD RETURN TRUE IF THE PLAYER IS SPRINTING
		return false;
	}

	private bool getIsCooldown(){
		//SHOULD RETURN TRUE IF SPRINT IS ON COOLDOWN
		return false;
	}

	private bool getProjectileThrown(){
		//SHOULD RETURN TRUE WHILE THE PROJECTILE IS OUT
		return pAbil.getProjectileThrown();
	}

	public void setReminderVisibility(bool arg){
		/*
		 * Sets the reminder image as active/inactive.
		 */
		reminderImage.gameObject.SetActive(arg);
	}
		
	private void conditDispImage(ref Image image, bool onCondit, bool offCondit){
		/*
		 * Displays the image with a color based on the given conditions.
		 * Gives priority to 'off' if both conditions are met.
		 */
		colorImage (ref image, (offCondit ? offColor : (onCondit ? onColor : dfltColor)));
	}

	private void colorImage(ref Image image, Color color){
		/*
		 * Colors the image.
		 */
		image.color = color;
	}

}