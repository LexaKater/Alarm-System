using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _stepDistance;
    [SerializeField] private AudioSource _stepsAudioSource;

    private float _coveredDistance = 0f;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(_rotationSpeed * rotation * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis("Vertical");

        if (direction == 0)
        {
            _coveredDistance = 0;
            return;
        }

        float distance = direction * _moveSpeed * Time.deltaTime;
        _coveredDistance += Mathf.Abs(distance);

        transform.Translate(direction * Vector3.forward);

        if (_coveredDistance > _stepDistance)
        {
            _coveredDistance -= _stepDistance;
            _stepsAudioSource.Play();
        }
    }
}
