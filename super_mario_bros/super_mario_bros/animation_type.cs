/*********************************************************************
*
*   Class:
*       animation_type
*
*   Description:
*       Contains data for an animation
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

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

public class animation_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  Texture2D[]                 textures;
public  List<animation_frame_type>  frames;
public  int                         frame_cnt;
public  int                         tick_cnt;
public  int                         frame_idx;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       animation_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public animation_type( Texture2D[] texture_list  )
{
textures = texture_list;
reset();
frames = new List<animation_frame_type>();
} /* animation_type() */


/***********************************************************
*
*   Method:
*       add_frame
*
*   Description:
*       Adds frame to the animation.
*
***********************************************************/

public void add_frame( animation_frame_type frame )
{
int last_idx = frames.Count - 1;

if( 0 <= last_idx )
    {
    frame.rolling_cnt = frames[last_idx].rolling_cnt + frame.cnt;
    }
else
    {
    frame.rolling_cnt = frame.cnt;
    }

frames.Add( frame );

frame_cnt += frame.cnt;

} /* add_frame() */


/***********************************************************
*
*   Method:
*       get_sprite
*
*   Description:
*       Returns the current sprite for the animation.
*
***********************************************************/

public Texture2D get_sprite()
{
return textures[frames[frame_idx].sprite_id];
} /* get_sprite() */


/***********************************************************
*
*   Method:
*       update
*
*   Description:
*       Increment the frame count.
*
***********************************************************/

public void update()
{
tick_cnt++;

if( frames[frame_idx].rolling_cnt < tick_cnt )
    {
    frame_idx++;

    if( frame_idx == frames.Count )
        {
        reset();
        }
    }
} /* update() */


/***********************************************************
*
*   Method:
*       reset
*
*   Description:
*       Resets the animation.
*
***********************************************************/

public void reset()
{
frame_idx = 0;
tick_cnt = 0;
} /* reset() */


}
}
