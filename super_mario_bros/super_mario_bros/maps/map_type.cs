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
public  List<pipe_type>  pipes;
public  List<decor_type> decors;
public  List<Rectangle>  view_locks;

public  decor_flag_type  flag;

public  int              tier_count;
public  int[]            tier_widths;
public  Color[]          tier_colors;

public  int              width;
public  int              height;

public  Rectangle        flag_loc;
public  int              exit_loc_x;

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
view_locks = new List<Rectangle>();
pipes = new List<pipe_type>();
decors = new List<decor_type>();
flag_loc = new Rectangle();

} /* map_type() */


/***********************************************************
*
*   Method:
*       add_small_castle
*
*   Description:
*       Adds small castle to the map.
*
***********************************************************/

public void add_small_castle( int x, int y )
{

decors.Add( new decor_block_type( x,     y,     (int)decor_enum.CASTLE ) );
decors.Add( new decor_block_type( x,     y - 1, (int)decor_enum.CASTLE ) );
decors.Add( new decor_block_type( x + 1, y,     (int)decor_enum.CASTLE ) );
decors.Add( new decor_block_type( x + 1, y - 1, (int)decor_enum.CASTLE ) );
decors.Add( new decor_block_type( x + 3, y,     (int)decor_enum.CASTLE ) );
decors.Add( new decor_block_type( x + 3, y - 1, (int)decor_enum.CASTLE ) );
decors.Add( new decor_block_type( x + 4, y,     (int)decor_enum.CASTLE ) );
decors.Add( new decor_block_type( x + 4, y - 1, (int)decor_enum.CASTLE ) );
decors.Add( new decor_block_type( x + 2, y - 3, (int)decor_enum.CASTLE ) );

decors.Add( new decor_block_type( x + 2, y,     (int)decor_enum.CASTLE_DOOR_B ) );
decors.Add( new decor_block_type( x + 2, y - 1, (int)decor_enum.CASTLE_DOOR_T ) );
decors.Add( new decor_block_type( x + 1, y - 3, (int)decor_enum.CASTLE_WINDOW_R ) );
decors.Add( new decor_block_type( x + 3, y - 3, (int)decor_enum.CASTLE_WINDOW_L ) );

decors.Add( new decor_block_type( x,     y - 2, (int)decor_enum.CASTLE_TOP_SKY ) );
decors.Add( new decor_block_type( x + 1, y - 2, (int)decor_enum.CASTLE_TOP ) );
decors.Add( new decor_block_type( x + 2, y - 2, (int)decor_enum.CASTLE_TOP ) );
decors.Add( new decor_block_type( x + 3, y - 2, (int)decor_enum.CASTLE_TOP ) );
decors.Add( new decor_block_type( x + 4, y - 2, (int)decor_enum.CASTLE_TOP_SKY ) );
decors.Add( new decor_block_type( x + 1, y - 4, (int)decor_enum.CASTLE_TOP_SKY ) );
decors.Add( new decor_block_type( x + 2, y - 4, (int)decor_enum.CASTLE_TOP_SKY ) );
decors.Add( new decor_block_type( x + 3, y - 4, (int)decor_enum.CASTLE_TOP_SKY ) );

} /* add_small_castle() */


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
        blocks[i, j].draw( s, i, j );
        }
    }
} /* draw() */


/***********************************************************
*
*   Method:
*       get_back_color
*
*   Description:
*       Draw the map.
*
***********************************************************/

public Color get_back_color( int x )
{
int rolling_width = 0;

for( int i = 0; i < tier_count; i++ )
    {
    rolling_width += tier_widths[i];
    if( x < rolling_width )
        {
        return tier_colors[i];
        }
    }

return Color.Black;
} /* get_back_color() */


}
}
