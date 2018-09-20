/*********************************************************************
*
*   Class:
*       map_type
*
*   Description:
*       Contains the data for a level map
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

public class map_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  block_type[,]   blocks;
public  int             width;
public  int             height;
public  int             min_height;
public  int             max_height;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       map_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public map_type()
{
height = 13;
width = 210;
blocks = new block_type[width, height];

min_height = Blocks.size.Height * ( height - 1 );
max_height = min_height + ViewDims.view.Height;

for( int i = 0; i < width;  i++ )
for( int j = 0; j < height; j++ )
    {
    blocks[i, j] = null;
    }

for( int i = 0;  i < width;  i++ )
for( int j = 11; j < height; j++ )
    {
    blocks[i, j] = Blocks.list[(int)block_enum.RED_COBBLE];
    }

for( int i = 8;  i < 13;  i++ )
    {
    blocks[i, 7] = Blocks.list[(int)block_enum.RED_COBBLE];
    }

for( int j = 4;  j < 11;  j++ )
    {
    blocks[16, j] = Blocks.list[(int)block_enum.RED_COBBLE];
    }

} /* map_type() */

/***********************************************************
*
*   Method:
*       draw
*
*   Description:
*       Draw the map.
*
***********************************************************/

public void draw( SpriteBatch s )
{
for( int i = 0; i < width;  i++ )
for( int j = 0; j < height; j++ )
    {
    if( blocks[i, j] != null )
        {
        blocks[i, j].draw( s, i, j );
        }
    }
} /* draw() */


}
}
