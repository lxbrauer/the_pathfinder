namespace Mapbox.Unity.Map
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Mapbox.Unity.Map;
    using Mapbox.Unity.Utilities;
    using Mapbox.Utils;

    public class Positioning : MonoBehaviour
    {
        public Transform end;

        [SerializeField]
        Vector2d[] _locations;

        [SerializeField]
        AbstractMap _map;

        
        Vector2d latLong = new Vector2d(52.513504, 13.323175);

        void Start()
        {
            Invoke("Then", 1);
        }

        void Then()
        {            
            foreach (var location in _locations)
            {                
                Vector3 pos = Conversions.GeoToWorldPosition(location, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
                Instantiate(end, pos, Quaternion.identity);
                end.transform.localPosition = pos;
                
            }
        }
                
    }
}
