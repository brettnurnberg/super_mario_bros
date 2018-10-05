/*********************************************************************
*
*   Class:
*       view_dimension_type
*
*   Description:
*       Contains the dimensions for the view
*
*   TODO:
*       I believe the x and y axes have different scales.
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
public static float         scale;

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
view.X = 0;
view.Y = 0;
view.Width = 256;
view.Height = 200;

window = r;
scale = (float)r.Height / (float)view.Height;

view_scaled.X = 0;
view_scaled.Y = 0;
view_scaled.Height = window.Height;
view_scaled.Width  = (int)( (float)view.Width * scale );

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
*       set_view_location
*
*   Description:
*       Updates the view location to follow mario.
*
***********************************************************/

public static void set_view_location( model_type m )
{
level_type level = m.level;

if( ( view.X + ( 100 << 12 )  ) < level.mario.physics.position.x )
    {
    int mario_x = level.mario.physics.position.x;
    view.X = mario_x - ( 100 << 12 );
    }

check_locks( m );

view_scaled.X = (int)( view.X * scale ) >> 12;

/*----------------------------------------------------------
The comparison seems backwards because max height is
the top, which is -Y
----------------------------------------------------------*/
if( view_scaled.Y < level.map.max_height * ViewDims.scale  )
    {
    view_scaled.Y = (int)( level.map.max_height * ViewDims.scale );
    }
if( view_scaled.Bottom > level.map.min_height * ViewDims.scale )
    {
    view_scaled.Y = (int)( level.map.max_height * ViewDims.scale ) - view_scaled.Height;
    }

view_scaled.X *= -1;
view_scaled.X += left_edge.Width;

} /* set_view_location() */


/***********************************************************
*
*   Method:
*       move_view_location
*
*   Description:
*       Increments the view location.
*
***********************************************************/

public static void move_view_location( int subsubsub_pixel_x )
{
view.X += subsubsub_pixel_x;
view_scaled.X = (int)( view.X * scale ) >> 12;
view_scaled.X *= -1;
view_scaled.X += left_edge.Width;
} /* set_view_location() */


/***********************************************************
*
*   Method:
*       check_locks
*
*   Description:
*       Check for view locks.
*
***********************************************************/

public static void check_locks( model_type m )
{
int_vector2_type position = new int_vector2_type();
position.x = m.level.mario.physics.position.x >> 12;
position.y = m.level.mario.physics.position.y >> 12;

foreach( Rectangle r in m.level.map.view_locks )
    {
    if( r.Contains( position.x, position.y ) )
        {
        view.X = r.X << 12;
        view.Y = r.Y << 12;
        }
    }

} /* check_locks() */


}
}
