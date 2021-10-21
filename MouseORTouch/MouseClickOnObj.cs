using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class MouseClickOnObj : MonoBehaviour
{

    private bool _drag;             // indica que pode mover o obj
    private Vector2 _mouse;         // atributos do mouse
    private RaycastHit2D hit;       // recebe ray que vai atingir gameObject
    private Vector2 _offset;        // Offset entre player e mouse

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){   

        _mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);   // pega posição do mouse no espaço da tela
        hit = Physics2D.Raycast(_mouse, Vector2.zero);
        
        follow();
    }

    void follow(){

        if(Input.GetMouseButton(0) && !_drag){
            if (hit && hit.collider.gameObject.GetHashCode() == this.gameObject.GetHashCode()){
                
                float _x = transform.position.x - _mouse.x;
                float _y = transform.position.y - _mouse.y;

                _offset = new Vector2(_x,_y);

                hit.transform.GetComponent<MouseClickOnObj>()._drag = true;
            }
        }

        if(_drag){
            this.transform.position = _mouse + _offset;
            //Debug.Log(hit.collider.name);
        }

        if(Input.GetMouseButtonUp(0) && _drag){
            _drag = false;
            _offset = new Vector2(0f,0f);
        }
    }

}
