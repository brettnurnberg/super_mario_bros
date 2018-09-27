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

public class map_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

public  block_type[,]    blocks;
public  List<decor_type> decors;
public  int              width;
public  int              height;
public  int              min_height;
public  int              max_height;
public  int              animation_count;

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
int x = 0;

height = 13;
width = 213;
blocks = new block_type[width, height];
block_type cobble = new block_red_cobble_type();
block_type stair = new block_stair_type();

animation_count = 0;

min_height = Blocks.size.Height * ( height - 1 ) + 8;
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


add_stairs( 134, 10, 4, stair, true );
add_stairs( 140, 10, 4, stair, false );

add_stairs( 148, 10, 4, stair, true );
for( int j = 7; j < 11; j++ )
    {
    blocks[152, j] = stair;
    }
add_stairs( 155, 10, 4, stair, false );

add_stairs( 181, 10, 8, stair, true );
for( int j = 3; j < 11; j++ )
    {
    blocks[189, j] = stair;
    }

decors = new List<decor_type>();
while( x < width * Blocks.size.Width )
    {
    decors.Add( new decor_cloud_type( 136 + x, 17, 1 ) );
    decors.Add( new decor_cloud_type( 312 + x, 1,  1 ) );
    decors.Add( new decor_cloud_type( 440 + x, 17, 3 ) );
    decors.Add( new decor_cloud_type( 584 + x, 1,  2 ) );
    decors.Add( new decor_bush_type(  184 + x, 160, 3 ) );
    decors.Add( new decor_bush_type(  377 + x, 160, 1 ) );
    decors.Add( new decor_bush_type(  664 + x, 160, 2 ) );
    decors.Add( new decor_hill_type(  0   + x, 141 ) );
    decors.Add( new decor_hill_type(  241 + x, 157 ) );
    decors.Add( new decor_hill_type(  768 + x, 141 ) );

    x += 768;
    }

} /* map_type() */


/***********************************************************
*
*   Method:
*       add_stairs
*
*   Description:
*       Adds stairs to the map.
*
***********************************************************/

public void add_stairs( int x, int y, int h, block_type block, Boolean up )
{
for( int i = 0; i < h; i++ )
for( int j = 0; j < h; j++ )
    {
    if( i >= j && up )
        {
        blocks[( x + i ), ( y - j ) ] = block;
        }
    if( i < ( h - j ) && !up )
        {
        blocks[( x + i ), ( y - j ) ] = block;
        }
    }

} /* add_stairs() */


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
foreach( decor_type d in decors )
    {
    d.draw( s );
    }

for( int i = 0; i < width;  i++ )
for( int j = 0; j < height; j++ )
    {
    if( blocks[i, j] != null )
        {
        blocks[i, j].draw( s, i, j, animation_count );
        }
    }
} /* draw() */


}
}
