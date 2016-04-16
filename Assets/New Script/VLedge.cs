using UnityEngine;

class VLedge : Ledge{

    void Start() {
        outVal = transform.position.y + direction*GetComponent<BoxCollider2D>().size.y / 4;
        foreach(BoxCollider2D bc in GetComponents<BoxCollider2D>()) {
            if (bc.isTrigger) {
                bc.offset = new Vector2(bc.offset.x,bc.offset.y*-1*direction); //asumes pos by default;
            }
        }
    }

    protected override Vector2 jump(Vector2 from) {
        return new Vector2(from.x,outVal);
    }

}
