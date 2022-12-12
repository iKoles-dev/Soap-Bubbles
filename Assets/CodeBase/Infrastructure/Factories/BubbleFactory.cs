using CodeBase.Infrastructure.ObjectPools;
using CodeBase.Infrastructure.Services.OutScreenPositioner;
using CodeBase.Infrastructure.Services.SizeRandomizer;
using CodeBase.SoapBubble;

namespace CodeBase.Infrastructure.Factories
{
    public class BubbleFactory
    {
        private readonly BubblePool _bubblePool;
        private readonly OutScreenPositionerService _outScreenPositionerService;
        private readonly SizeAndSpeedRandomizerService _sizeAndSpeedRandomizerService;

        public BubbleFactory(BubblePool bubblePool, OutScreenPositionerService outScreenPositionerService, SizeAndSpeedRandomizerService sizeAndSpeedRandomizerService)
        {
            _bubblePool = bubblePool;
            _outScreenPositionerService = outScreenPositionerService;
            _sizeAndSpeedRandomizerService = sizeAndSpeedRandomizerService;
        }
        public ComponentsHolder CreateBubble()
        {
            ComponentsHolder bubble = _bubblePool.Get();
            _sizeAndSpeedRandomizerService.RandomizeSizeAndSpeed(bubble);
            _outScreenPositionerService.SetPosition(bubble);
            return bubble;
        }
    }
}