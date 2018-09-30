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

public const int vx_walk_min          = 0x0130;
public const int vx_walk_max          = 0x1900;
public const int vx_walk_water_max    = 0x1100;
public const int vx_walk_no_ctrl_max  = 0x0D00;
public const int vx_run_max           = 0x2900;
public const int vx_skid_thresh       = 0x0900;

public const int ax_walk              = 0x0098;
public const int ax_run               = 0x00E4;
public const int ax_release           = 0x00D0;
public const int ax_skid              = 0x01A0;


public const int ax_jf_walk           = 0x0098;
public const int ax_jf_run            = 0x00E4;
public const int ax_jb_run            = -0x00E4;
public const int ax_jb_run_walk       = -0x00A0;
public const int ax_jb_walk           = -0x0068;
public const int vx_j_thresh          = 0x1D00;

public const int vy_j_thresh1         = 0x1000;
public const int vy_j_thresh2         = 0x2500;

public static readonly int[] vy_j_init = { -0x4000, -0x4000, -0x5000 };
public static readonly int[] ay_j_a    = {  0x0180,  0x0180,  0x0220 };
public static readonly int[] ay_j_f    = {  0x0440,  0x03E0,  0x05D0 };

public const int vy_j_max             = 0x4800;
public const int vy_hard_block        = 0x1000;


/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


}
}
