using UnityEngine;

class HLedge : Ledge{

    void Start() {
        outVal = transform.position.x + direction*GetComponent<BoxCollider2D>().size.x / 4;
        foreach(BoxCollider2D bc in GetComponents<BoxCollider2D>()) {
            if (bc.isTrigger) {
                bc.offset = new Vector2(bc.offset.x*-1*direction, bc.offset.y); //asumes pos by default;
            }
        }
    }

    protected override Vector2 jump(Vector2 from) {
        return new Vector2(outVal, from.y);
    }

}
