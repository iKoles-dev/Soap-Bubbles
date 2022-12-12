using CodeBase.SoapBubble;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.OutScreenPositioner
{
    public class OutScreenPositionerService
    {
        private readonly float _borderSize;
        private readonly float _downBorder;
        public OutScreenPositionerService()
        {
            float orthographicSize = Camera.main.orthographicSize;
            _borderSize = orthographicSize * Screen.width / Screen.height;
            _downBorder = - orthographicSize;
        }
        public void SetOnPosition(ComponentsHolder holder)
        {
            float halfSize = holder.Transform.localScale.x / 2;
            holder.Transform.position = new Vector3(Mathf.Lerp(-_borderSize + halfSize, _borderSize - halfSize, Random.value), _downBorder - halfSize, 0);
        }
    }
}