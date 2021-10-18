using UnityEngine;

namespace Constants.LayersLogic
{
    public static class LayerMasks
    {

        public static readonly LayerMask PLAYER_PROJECTILE  = LayerMask.GetMask(LayerMask.LayerToName(Layers.ENEMY));
        public static readonly LayerMask ENEMY_PROJECTILE   = LayerMask.GetMask(LayerMask.LayerToName(Layers.PLAYER));
        public static readonly LayerMask GROUND             = LayerMask.GetMask(LayerMask.LayerToName(Layers.GROUND));
        public static readonly LayerMask WALL               = LayerMask.GetMask(LayerMask.LayerToName(Layers.WALL));

    }

}
