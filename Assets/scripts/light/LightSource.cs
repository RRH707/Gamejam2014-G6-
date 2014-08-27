using UnityEngine;
using System.Collections;

public class LightSource : MonoBehaviour {

    public bool draw;
    private float angleMultiplayer;
    public int castRes = 200;
    private Vector2[] hitPoints;
    public float maxDist = 4;
    private LayerMask layer;

    void Start()
    {
        hitPoints = new Vector2[castRes];
    }
	void Update () {
        CheckHitShadow();

	}

    private void CheckHitShadow()
    {
        if (Game.shadowActive)
        {
            layer = LayerMask.NameToLayer("Shadow");
        }
        else
        {
            layer = LayerMask.NameToLayer("Player");
        }
        int i;
        angleMultiplayer = castRes / 360.0f;
        Vector3 center = transform.position;
        center.z = 0;
        Vector2 center2D = new Vector2(center.x, center.y);
        hitPoints[0] = transform.position;
        for (i = 0; i < castRes; i++)
        {
            float angle = (float)i / angleMultiplayer;
            Vector2 direct = Math.AngleToDirection(angle);
            direct = new Vector2(direct.x * maxDist, direct.y * maxDist);
            Vector2 colPoint = (center2D + direct);
            RaycastHit2D ray = Physics2D.Linecast(center, colPoint, layer);
            if (ray.collider != null)
            {
                if (draw)
                {
                    Debug.DrawLine(center, ray.point, Color.red);
                }
                if (Game.shadowActive)
                {
                    hitPoints[i] = ray.point;
                    LightReceiver lightHit = ray.collider.gameObject.GetComponent<LightReceiver>();
                    float distPowerReceiver = (maxDist - Vector3.Distance(lightHit.transform.position, gameObject.transform.position));
                    if (distPowerReceiver < 0)
                    {
                        distPowerReceiver = 0;
                    }
                    lightHit.LightHit(distPowerReceiver);
                }
                else
                {
                    Game.PlayerInLightAndShadowNotActive = true;
                }
                break;
            }
            else
            {
                Vector2 point = new Vector2(direct.x + center.x, direct.y + center.y);
                if (draw)
                {
                    Debug.DrawLine(center, point, Color.green);
                }
                hitPoints[i] = point;
            }
        }
    }
}
