/*********************************************************************
*
*   Class:
*       pipe_type
*
*   Description:
*       Contains data for a pipe
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

public class pipe_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

private pipe_type link_p;
private int_vector2_type link_v;
public  Boolean is_vertical;
private int x;
private int y;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       pipe_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public pipe_type( map_type m, int _x, int _y, Boolean vertical, int length )
{
int ofst = 0;

link_p = null;
link_v = null;
is_vertical = vertical;
x = _x;
y = _y;

if( m.get_back_color( x ) == Color.Black )
    {
    ofst = (int)block_enum.PIPE2_HORIZONTAL_B - (int)block_enum.PIPE_HORIZONTAL_B;
    }

if( vertical )
    {
    if( y == 0 )
        {
        m.blocks[x, y]     = new block_pipe_type( this, (int)block_enum.PIPE_VERTICAL_L + ofst );
        m.blocks[x + 1, y] = new block_pipe_type( this, (int)block_enum.PIPE_VERTICAL_R + ofst );
        }
    else
        {
        m.blocks[x, y]     = new block_pipe_type( this, (int)block_enum.PIPE_VERTICAL_ENTRY_L + ofst );
        m.blocks[x + 1, y] = new block_pipe_type( this, (int)block_enum.PIPE_VERTICAL_ENTRY_R + ofst );
        }

    for( int j = y + 1; j < y + length; j++ )
        {
        m.blocks[x, j]     = new block_pipe_type( this, (int)block_enum.PIPE_VERTICAL_L + ofst );
        m.blocks[x + 1, j] = new block_pipe_type( this, (int)block_enum.PIPE_VERTICAL_R + ofst );
        }
    }
else
    {
    m.blocks[x, y]     = new block_pipe_type( this, (int)block_enum.PIPE_HORIZONTAL_ENTRY_T + ofst );
    m.blocks[x, y + 1] = new block_pipe_type( this, (int)block_enum.PIPE_HORIZONTAL_ENTRY_B + ofst );

    for( int i = x + 1; i < x + length - 1; i++ )
        {
        m.blocks[i, y]     = new block_pipe_type( this, (int)block_enum.PIPE_HORIZONTAL_T + ofst );
        m.blocks[i, y + 1] = new block_pipe_type( this, (int)block_enum.PIPE_HORIZONTAL_B + ofst );
        }

    if( ( m.blocks[x + length - 1, y    ].GetType() == typeof( block_pipe_type ) ) &&
        ( m.blocks[x + length - 1, y + 1].GetType() == typeof( block_pipe_type ) ) )
        {
        m.blocks[x + length - 1, y    ] = new block_pipe_type( this, (int)block_enum.PIPE_MESH_T + ofst );
        m.blocks[x + length - 1, y + 1] = new block_pipe_type( this, (int)block_enum.PIPE_MESH_B + ofst );
        }

    }

} /* pipe_type() */


/***********************************************************
*
*   Method:
*       link_pipe
*
*   Description:
*       Adds a destination after entering pipe.
*
***********************************************************/

public void link_pipe( pipe_type destination_pipe )
{
link_p = destination_pipe;
link_v = null;
} /* link_pipe() */

public void link_pipe( int_vector2_type destination )
{
link_v = destination;
link_p = null;
} /* link_pipe() */


/***********************************************************
*
*   Method:
*       is_linked
*
*   Description:
*       Returns true if the pipe is linked.
*
***********************************************************/

public Boolean is_linked( int sss_x, int sss_y )
{
Boolean linked = false;
int block_x = sss_x >> 16;
int block_y = sss_y >> 16;
int pixel_x = ( sss_x >> 12 ) % Blocks.size.Width;
Boolean eligible = false;

if( is_vertical )
    {
    if( ( block_x == x ) && ( block_y == y ) )
        {
        if( pixel_x > 3 )
            {
            eligible = true;
            }
        }
    else if( ( block_x == ( x + 1 ) ) && ( block_y == y ) )
        {
        if( pixel_x < 3 )
            {
            eligible = true;
            }
        }
    }
else
    {
    if( ( block_x == ( x - 1 ) ) && ( block_y == ( y + 1 ) ) )
        {
        eligible = true;
        }
    }

if( eligible )
    {
    if( ( link_v != null ) ||
        ( link_p != null ) )
        {
        linked = true;
        }
    }

return linked;
} /* link_pipe() */


/***********************************************************
*
*   Method:
*       link_is_pipe
*
*   Description:
*       Returns true if the pipe destination is a pipe.
*
***********************************************************/

public Boolean link_is_pipe()
{
return ( link_p != null );
} /* link_is_pipe() */


/***********************************************************
*
*   Method:
*       set_destination
*
*   Description:
*       Sets mario's location to the destination pipe.
*
***********************************************************/

public void set_destination( mario_type m )
{
int viewx = 0;
int viewy = 0;

if( link_v != null )
    {
    m.physics.position.x = link_v.x << 12;
    m.physics.position.y = link_v.y << 12;
    viewx = m.physics.position.x - ( ( 4 * Blocks.size.Width ) << 12 );
    }
else if( link_p != null )
    {
    m.physics.position.x = ( link_p.x << 16 ) + ( 10 << 12 );
    m.physics.position.y = ( link_p.y << 16 ) - ( ( m.physics.hit_box.Height - 1 ) << 12 );
    viewx = ( link_p.x - 3 ) << 16;
    }

m.physics.acceleration.x = 0;
m.physics.acceleration.y = 0;
m.physics.velocity.x = 0;
m.physics.velocity.y = 0;

viewy = 0;
ViewDims.set_view_location( viewx, viewy );

} /* set_destination() */

}
}
