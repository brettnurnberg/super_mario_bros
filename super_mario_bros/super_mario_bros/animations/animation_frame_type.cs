/*********************************************************************
*
*   Class:
*       animation_frame_type
*
*   Description:
*       Contains data for an animation frame
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

public class animation_frame_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  int     sprite_id;
public  int     cnt;
public  int     rolling_cnt;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       animation_frame_type
*
*   Description:
*       Constructor. Accepts the enum value for the texture
*       and the number of frames the texture is active.
*
***********************************************************/

public animation_frame_type( int id, int frame_cnt )
{
sprite_id = id;
cnt = frame_cnt;
rolling_cnt = 0;
} /* animation_frame_type() */


}
}
