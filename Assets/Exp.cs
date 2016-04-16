using UnityEngine;

public class Exp : MonoBehaviour {

    readonly int[] expPerLevel = new int[9] { 100, 200, 300, 400, 500, 600, 700, 800, 900 };

    protected int exp;

    public int Level {
        get {
            for(int i = expPerLevel.Length; i >=0; --i) {
                if(exp > expPerLevel[i]) {
                    return i+1;
                }

            }
            return 0;
        }
    }
	
    public void Add(int i) {
        /*
        score i exp
        */
        exp += i;
    }

}
