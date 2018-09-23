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
    if( ( i != 69 && i != 70 && i != 86 ) &&
        ( i != 87 && i != 88 && i != 153 ) && i != 154 )
        {
        blocks[i, j] = cobble;
        }
    }

blocks[16, 7] = new block_question_type();
blocks[20, 7] = new block_brick_type();
blocks[21, 7] = new block_question_type();
blocks[22, 7] = new block_brick_type();
blocks[22, 3] = new block_question_type();
blocks[23, 7] = new block_question_type();
blocks[24, 7] = new block_brick_type();

blocks[77, 7] = new block_brick_type();
blocks[78, 7] = new block_question_type();
blocks[79, 7] = new block_brick_type();

for( int i = 80; i < 88; i++ )
    {
    blocks[i, 3] = new block_brick_type();
    }

for( int i = 91; i < 94; i++ )
    {
    blocks[i, 3] = new block_brick_type();
    }

blocks[94, 3] = new block_question_type();
blocks[94, 7] = new block_brick_type();
blocks[100, 7] = new block_brick_type();
blocks[101, 7] = new block_brick_type();
blocks[106, 7] = new block_question_type();
blocks[109, 7] = new block_question_type();
blocks[109, 3] = new block_question_type();
blocks[112, 7] = new block_question_type();
blocks[118, 7] = new block_brick_type();
blocks[121, 3] = new block_brick_type();
blocks[122, 3] = new block_brick_type();
blocks[123, 3] = new block_brick_type();
blocks[128, 3] = new block_brick_type();
blocks[129, 7] = new block_brick_type();
blocks[130, 7] = new block_brick_type();
blocks[131, 3] = new block_brick_type();
blocks[129, 3] = new block_question_type();
blocks[130, 3] = new block_question_type();
blocks[168, 7] = new block_brick_type();
blocks[169, 7] = new block_brick_type();
blocks[170, 7] = new block_question_type();
blocks[171, 7] = new block_brick_type();

blocks[198, 10] = stair;


/*for( int i = 20; i < 26; i++ )
for( int j = 10; j > 5;  j-- )
    {
    if( j + 15 > i )
        {
        blocks[ ( 46 - i ), j ] = stair;
        }
    }*/

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
