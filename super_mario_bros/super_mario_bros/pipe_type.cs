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
private Boolean is_vertical;
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
*       check_entry
*
*   Description:
*       Checks if the pipe can be entered. Returns true
*       if the pipe was entered.
*
***********************************************************/

public Boolean check_entry( int _x, int _y, mario_type m )
{
Boolean entered = false;

if( ( m.ground_status == char_status_enum.GROUND ) &&
    ( ( is_vertical && ( _x == x || _x == ( x + 1 ) ) && ( _y == y ) ) ||
    ( !is_vertical && ( _x == ( x - 1 ) ) && ( _y == ( y + 1 ) ) ) ) )
    {
    if( link_v != null )
        {
        m.physics.position.x = link_v.x << 12;
        m.physics.position.y = link_v.y << 12;
        m.ground_status = char_status_enum.AIR;
        }
    else if( link_p != null )
        {
        m.physics.position.x = ( link_p.x << 16 ) + ( 5 << 12 );
        m.physics.position.y = ( link_p.y << 16 ) - ( ( m.physics.hit_box.Height - 1 ) << 12 );
        }
    if( ( link_v != null ) ||
        ( link_p != null ) )
        {
        m.physics.acceleration.x = 0;
        m.physics.acceleration.y = 0;
        m.physics.velocity.x = 0;
        m.physics.velocity.y = 0;

        ViewDims.view.X = ( m.physics.position.x >> 12 ) - 4 * Blocks.size.Width;
        ViewDims.view.Y = 0;
        entered = true;
        }
    }

return entered;
} /* link_pipe() */

}
}
