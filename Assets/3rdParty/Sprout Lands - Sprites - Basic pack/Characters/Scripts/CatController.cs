using UnityEngine;

namespace _3rdParty.Sprout_Lands___Sprites___Basic_pack.Characters.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CatController : MonoBehaviour
    {
        private Rigidbody2D _rb2d;
        private float _xInput;
        private float _yInput;
        private Vector2 _move;
        [SerializeField] private float _speed = 3.0f;
        private Animator _anim;
        private Vector2 _lastMove;

        // Start is called before the first frame update
        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            MovementsV1();
        }

        private void MovementsV2()
        {
            _xInput = Input.GetAxis("Horizontal");
            _yInput = Input.GetAxis("Vertical");
            
            _move = new Vector2(_xInput, _yInput);

            // For stop moving and set Blend tree values for Idle
            if (_move.magnitude == 0)
            {
                _anim.SetBool("IsMoving", false);
                _anim.SetFloat("DirectionX", _lastMove.x);
                _anim.SetFloat("DirectionY", _lastMove.y);
                _rb2d.velocity = Vector2.zero;
                return;
            }

            // Add new variable for store last move
            _lastMove = _move;
            _rb2d.velocity = _speed * _move;

            _anim.SetFloat("DirectionX", _xInput);
            _anim.SetFloat("DirectionY", _yInput);
            _anim.SetBool("IsMoving", true);
            
        }
        
        private void MovementsV1()
        {
            _xInput = Input.GetAxis("Horizontal");
            _yInput = Input.GetAxis("Vertical");
            _move = new Vector2(_xInput, _yInput);

            if (_move.magnitude == 0)
            {
                _anim.SetBool("IsMoving", false);
                _anim.SetFloat("DirectionX", _lastMove.x);
                _anim.SetFloat("DirectionY", _lastMove.y);
                _rb2d.velocity = Vector2.zero;
                return;
            }

            _lastMove = _move;

            _rb2d.velocity = _speed * _move;
            
            _anim.SetFloat("DirectionX", _xInput);
            _anim.SetFloat("DirectionY", _yInput);
            _anim.SetBool("IsMoving", true);
        }
    }
}
