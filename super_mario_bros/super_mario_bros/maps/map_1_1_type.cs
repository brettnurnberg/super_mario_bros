/*********************************************************************
*
*   Class:
*       map_1_1_type
*
*   Description:
*       Contains the data for the world 1-1 map
*
*   TODO:
*       Instead of setting all blocks to NULL, set to AIR
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

public class map_1_1_type : map_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       map_1_1_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public map_1_1_type()
{
int x = 0;

/*----------------------------------------------------------
Set up level tiers
----------------------------------------------------------*/
tier_count = 2;
tier_widths = new int[tier_count];
tier_colors = new Color[tier_count];

tier_colors[0] = new Color( 92, 147, 255 );
tier_colors[1] = Color.Black;

height = 13;
tier_widths[0] = 225;
tier_widths[1] = 17;

width = 0;
for( int i = 0; i < tier_count; i++ )
    {
    width += tier_widths[i];
    }

min_height = Blocks.size.Height * ( height - 1 ) + 8;
max_height = min_height + ViewDims.view.Height;

flag_loc = 198;
flag_base_y = ( 0 + 10 ) * Blocks.size.Height;
exit_loc_x = ( 204 * Blocks.size.Width + 2 ) << 12;

view_locks.Add( new Rectangle( tier_widths[0] * Blocks.size.Width, 0, 17 * Blocks.size.Width, 13 * Blocks.size.Height ) );

/*----------------------------------------------------------
Set up map sizes
----------------------------------------------------------*/
blocks = new block_type[width, height];

for( int i = 0; i < width;  i++ )
for( int j = 0; j < height; j++ )
    {
    blocks[i, j] = null;
    }

/*----------------------------------------------------------
Add static blocks
----------------------------------------------------------*/
/*----------------------------------------------
Tier 0
----------------------------------------------*/
block_type cobble = new block_red_cobble_type();
block_type stair = new block_stair_type();

for( int i = 0;  i < tier_widths[0];  i++ )
for( int j = 11; j < height; j++ )
    {
    if( ( i != 69 && i != 70 && i != 86 ) &&
        ( i != 87 && i != 88 && i != 153 ) && i != 154 )
        {
        blocks[i, j] = cobble;
        }
    }

blocks[flag_loc, 10] = stair;

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

/*----------------------------------------------
Tier 1
----------------------------------------------*/
block_type blue_cobble = new block_blue_cobble_type();

for( int i = 0;  i < tier_widths[1];  i++ )
for( int j = 11; j < height; j++ )
    {
    blocks[tier_widths[0] + i, j] = blue_cobble;
    }

/*----------------------------------------------------------
Add non-static blocks
----------------------------------------------------------*/
/*----------------------------------------------
Tier 0
----------------------------------------------*/
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

/*----------------------------------------------
Tier 1
----------------------------------------------*/
for( int j = 0; j < height - 2; j++ )
    {
    blocks[tier_widths[0], j] = new block_brick_blue_type();
    }

for( int i = 4; i < 11; i++ )
    {
    blocks[tier_widths[0] + i, 0]  = new block_brick_blue_type();
    blocks[tier_widths[0] + i, 8]  = new block_brick_blue_type();
    blocks[tier_widths[0] + i, 9]  = new block_brick_blue_type();
    blocks[tier_widths[0] + i, 10] = new block_brick_blue_type();
    }

/*----------------------------------------------------------
Add pipes
----------------------------------------------------------*/
/*----------------------------------------------
Tier 0
----------------------------------------------*/
pipes.Add( new pipe_type( this,  28, 9, true, 2 ) );
pipes.Add( new pipe_type( this,  38, 8, true, 3 ) );
pipes.Add( new pipe_type( this,  46, 7, true, 4 ) );
pipes.Add( new pipe_type( this,  57, 7, true, 4 ) );
pipes.Add( new pipe_type( this, 163, 9, true, 2 ) );
pipes.Add( new pipe_type( this, 179, 9, true, 2 ) );

/*----------------------------------------------
Tier 1
----------------------------------------------*/
pipes.Add( new pipe_type( this, tier_widths[0] + 15, 0, true,  11 ) );
pipes.Add( new pipe_type( this, tier_widths[0] + 13, 9, false, 3  ) );

/*----------------------------------------------------------
Add pipe links
----------------------------------------------------------*/
pipes[3].link_pipe( new int_vector2_type( ( tier_widths[0] + 2 ) * Blocks.size.Width, Blocks.size.Height ) );
pipes[7].link_pipe( pipes[4] );

/*----------------------------------------------------------
Add decoration
----------------------------------------------------------*/
x = 0;
for( int i = 0; i < 5; i++ )
    {
    decors.Add( new decor_hill_type(  0   + x, 141    ) );
    decors.Add( new decor_cloud_type( 136 + x, 17,  1 ) );
    decors.Add( new decor_bush_type(  184 + x, 160, 3 ) );
    decors.Add( new decor_hill_type(  241 + x, 157    ) );
    decors.Add( new decor_cloud_type( 312 + x, 1,   1 ) );
    decors.Add( new decor_bush_type(  377 + x, 160, 1 ) );
    decors.Add( new decor_cloud_type( 440 + x, 17,  3 ) );

    if( i < 4 )
        {
        decors.Add( new decor_cloud_type( 584 + x, 1,   2 ) );
        decors.Add( new decor_bush_type(  664 + x, 160, 2 ) );
        }

    x += 768;
    }

decors.Add( new decor_pole_type( flag_loc * Blocks.size.Width, 0 ) );
flag = new decor_flag_type( ( flag_loc * Blocks.size.Width ) - 8, 17 );
decors.Add( flag );

add_small_castle( 202, 10 );

} /* map_1_1_type() */

}
}
