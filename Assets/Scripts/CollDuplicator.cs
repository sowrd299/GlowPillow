using UnityEngine;

public class CollDuplicator : MonoBehaviour {

    /* a script that allows the object to have two indentical colliders
     * on different layers with differen attribute
     */

    public int Layer; //the tag to give the new collider
    public bool Trigger; //weather or not the new collider should be a trigger

	void Awake() {
        GameObject obj = new GameObject();
        Collider2D coll = gameObject.GetComponent<Collider2D>();
        coll = CopyComponent(coll, obj);
        obj.layer = Layer;
        coll.isTrigger = Trigger;
        obj.transform.parent = transform;
        obj.transform.localPosition = Vector2.zero;
    }

    protected T CopyComponent<T>(T original, GameObject destination) where T : Component {
        //method from http://answers.unity3d.com/questions/458207/copy-a-component-at-runtime.html
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields) {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy as T;
    }

}
