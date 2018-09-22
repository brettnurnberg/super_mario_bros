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
block_type cobble = new block_red_cobble_type();
block_type stair = new block_stair_type();

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
    blocks[i, j] = cobble;
    }

for( int i = 8;  i < 13;  i++ )
    {
    blocks[i, 7] = new block_brick_type();
    }

for( int i = 20; i < 26; i++ )
for( int j = 10; j > 5;  j-- )
    {
    if( j + 15 > i )
        {
        blocks[ ( 46 - i ), j ] = stair;
        }
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
