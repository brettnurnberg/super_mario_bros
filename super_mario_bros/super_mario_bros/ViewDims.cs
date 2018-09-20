/*********************************************************************
*
*   Class:
*       view_dimension_type
*
*   Description:
*       Contains the dimensions for the view
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
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

public static class ViewDims {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public static Rectangle     view;
public static Rectangle     window;
public static Rectangle     view_scaled;
public static Rectangle     left_edge;
public static Rectangle     right_edge;
public static Vector2       matrix_offset;
public static Vector2       scale;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       set_window_size
*
*   Description:
*       Sets the size of the window.
*
***********************************************************/

public static void set_window_size( Rectangle r )
{
float scale_1d;

view.X = 0;
view.Y = 0;
view.Width = 256;
view.Height = 200;

window = r;
scale_1d = (float)r.Height / (float)view.Height;
scale = new Vector2( scale_1d, scale_1d );

view_scaled.X = 0;
view_scaled.Y = 0;
view_scaled.Height = window.Height;
view_scaled.Width  = (int)( (float)view.Width * scale_1d );

if( window.Width > view_scaled.Width )
    {
    left_edge.X = 0;
    left_edge.Y = 0;
    left_edge.Height = view_scaled.Height;
    left_edge.Width  = ( window.Width - view_scaled.Width ) / 2;

    right_edge.Height = left_edge.Height;
    right_edge.Width = left_edge.Width;
    left_edge.X = window.Width - left_edge.Width;
    left_edge.Y = 0;
    }
else
    {
    left_edge.Height = 0;
    left_edge.Width = 0;
    right_edge.Height = 0;
    right_edge.Width = 0;
    }


} /* set_window_size() */

/***********************************************************
*
*   Method:
*       set_window_size
*
*   Description:
*       Sets the size of the window.
*
***********************************************************/

public static void set_view_location( level_type level )
{
//how to fix pixel sized jumps?
//float forward_thresh = 100.0F * scale.X;

if( ( view.X + 100 ) < level.mario.physics.position.X )
    {
    float mario_x = level.mario.physics.position.X;
    view.X = (int)mario_x - 100;
    view_scaled.X = (int)( ( mario_x * scale.X ) - ( 100 * scale.X ) );
    }
else
    {
    view_scaled.X = (int)( view.X * scale.X );
    }

/*----------------------------------------------------------
The comparison seems backwards because max height is
the top, which is -Y
----------------------------------------------------------*/
if( view_scaled.Y < level.map.max_height * ViewDims.scale.Y  )
    {
    view_scaled.Y = (int)( level.map.max_height * ViewDims.scale.Y );
    }
if( view_scaled.Bottom > level.map.min_height * ViewDims.scale.Y )
    {
    view_scaled.Y = (int)( level.map.max_height * ViewDims.scale.Y ) - view_scaled.Height;
    }

view_scaled.X *= -1;
view_scaled.X += left_edge.Width;

} /* set_window_size() */


}
}
