using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMovement : MonoBehaviour
{
    [SerializeField] private float _TrackingSpeed = 10.0f;
    [SerializeField] private bool _UseTrackingMovement = true;
    [SerializeField] private Transform _TrackingTarget;

    [SerializeField] private bool _UseTrackingTargetParent = false;
    [SerializeField] private bool _IsRootObject = false;
    RaycastHit hit;
    private Camera camera;
    Ray ray;


    public Transform trackingTarget
    { get; set; }
    public float trackingSpeed
    { get; set; }

    public bool useTrackingMovement
    { get; set; }

    void Start()
    {
       
        camera = gameObject.transform.GetComponent<Camera>();
         ray = camera.ScreenPointToRay(Input.mousePosition);
    

    }

    protected virtual private void Awake()
    {
        if (_UseTrackingTargetParent)
            trackingTarget = transform.parent;

        if (_IsRootObject)
            transform.SetParent(null);
    }


    void Update()
    {

        TrackingTarget();

        ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        if(Physics.Raycast(ray, out hit, 500.0f))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);
           // Debug.Log(transform.name);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction*100, Color.red);
        }





    }

    private void TrackingTarget()
    {

        if (trackingTarget == null)
            return;

        // transform.position = Vector3.Lerp(
        //transform.position,(new Vector3(_TrackingTarget.position.x, _TrackingTarget.position.y + 15, _TrackingTarget.position.z)), _TrackingSpeed * Time.deltaTime);

        transform.position = new Vector3(_TrackingTarget.position.x, _TrackingTarget.position.y + 25,-160);

    }


    public bool CheckTrackingFinished()
    {


        // 추적 목표가 존재하지 않는다면 false 를 리턴합니다.
        if (_TrackingTarget == null) return false;

        // 목표와의 거리가 1.0 미만이라면 true 를 리턴합니다.
        return Vector3.Distance(
            _TrackingTarget.position, transform.position) < 1.0f;
    }
}



