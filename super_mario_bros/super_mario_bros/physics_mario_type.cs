/*********************************************************************
*
*   Class:
*       physics_mario_type
*
*   Description:
*       Contains the values for Mario's physics
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

/*--------------------------------------------------------------------
                           NAMESPACE
--------------------------------------------------------------------*/

namespace super_mario_bros {

/*--------------------------------------------------------------------
                           DELEGATES
--------------------------------------------------------------------*/

/*--------------------------------------------------------------------
                             CLASS
--------------------------------------------------------------------*/

public static class MarioPhysics {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public const float v_walk_min           = 0.07421875F;
public const float v_walk_max           = 1.5625F;
public const float v_walk_water_max     = 1.0625F;
public const float v_walk_no_ctrl_max   = 0.8125F;
public const float v_run_max            = 2.5625F;
public const float v_skid_thresh        = 0.5625F;

public const float a_walk               = 0.037109375F;
public const float a_run                = 0.0556640625F;
public const float a_release            = 0.05078125F;
public const float a_skid               = 0.1015625F;


public const float ax_jf_walk           = 0.037109375F;
public const float ax_jf_run            = 0.0556640625F;
public const float ax_jb_run            = -0.0556640625F;
public const float ax_jb_run_walk       = -0.05078125F;
public const float ax_jb_walk           = -0.037109375F;
public const float vx_j_thresh          = 1.875F;

public const float vy_j_thresh1         = 1.0F;
public const float vy_j_thresh2         = 2.3125F;

public static readonly float[] vy_j_init = { 4.0F, 4.0F, 5.0F };
public static readonly float[] ay_j_a    = { 0.09375F, 0.09375F, 0.1328125F };
public static readonly float[] ay_j_f    = { 0.265625F, 0.2421875F, 0.36328125F };

public const float vy_j_max             = 4.8F;


/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


}
}
