/*********************************************************************
*
*   Class:
*       pipe_type
*
*   Description:
*       Contains data for a pipe
*
*   Could have block_pipe_type and it contains a reference to the pipe
*   object. The draw() part of that bock_pipe would get the sprite from
*   this pipe object. Then on pushing right on pipe side entry or down
*   on pipe top entry, we would check the block, then check the corresponding
*   pipe object for a destination pipe.
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

private pipe_type link;
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
link = null;
is_vertical = vertical;
x = _x;
y = _y;

if( vertical )
    {
    m.blocks[x, y]     = new block_pipe_type( this, (int)block_enum.PIPE_VERTICAL_ENTRY_L );
    m.blocks[x + 1, y] = new block_pipe_type( this, (int)block_enum.PIPE_VERTICAL_ENTRY_R );

    for( int j = y + 1; j < y + length; j++ )
        {
        m.blocks[x, j]     = new block_pipe_type( this, (int)block_enum.PIPE_VERTICAL_L );
        m.blocks[x + 1, j] = new block_pipe_type( this, (int)block_enum.PIPE_VERTICAL_R );
        }
    }
else
    {
    m.blocks[x, y]     = new block_pipe_type( this, (int)block_enum.PIPE_HORIZONTAL_ENTRY_T );
    m.blocks[x, y + 1] = new block_pipe_type( this, (int)block_enum.PIPE_HORIZONTAL_ENTRY_B );

    for( int i = x + 1; i < x + length; i++ )
        {
        m.blocks[i, y]     = new block_pipe_type( this, (int)block_enum.PIPE_HORIZONTAL_T );
        m.blocks[i, y + 1] = new block_pipe_type( this, (int)block_enum.PIPE_HORIZONTAL_B );
        }
    }

} /* pipe_type() */


/***********************************************************
*
*   Method:
*       add_destination_pipe
*
*   Description:
*       Adds a destination after entering pipe.
*
***********************************************************/

public void add_destination_pipe( pipe_type destination_pipe )
{
link = destination_pipe;
} /* add_destination_pipe() */

}
}
