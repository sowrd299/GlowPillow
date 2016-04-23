using UnityEngine;

public class Exp : MonoBehaviour {

    private int[] expPerLevel = null; // = new int[9] { 100, 200, 300, 400, 500, 600, 700, 800, 900 };
    public int[] ExpPerLevel {
        get { return expPerLevel; }
        set { if (expPerLevel == null) expPerLevel = value; }
    }

    protected int exp;
    public int Level {
        get {
            for(int i = expPerLevel.Length-1; i >= 0; --i) {
                if(exp >= expPerLevel[i]) {
                    return i + 1;
                }
            }
            return 0;
        }
    }
	
    public static Exp operator + (Exp to, int i) {
        //syntactic sugar
        to.Add(i);
        return to;
    }

    public void Add(int i) {
        /*
        score i exp
        */
        exp += i;
        Debug.Log("Level is: " + Level);
    }

}
