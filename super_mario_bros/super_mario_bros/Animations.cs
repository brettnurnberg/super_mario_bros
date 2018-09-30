/*********************************************************************
*
*   Class:
*       Animations
*
*   Description:
*       Static class of animations to make all animations visible
*
*********************************************************************/

/*--------------------------------------------------------------------
                            INCLUDES
--------------------------------------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

public static class Animations {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

static public List<animation_type>  animations;

static public animation_type        mario_walk;
static public animation_type        mario_run;
static public animation_type        block_question;

static public int                   frame_count;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/


/***********************************************************
*
*   Method:
*       Animations
*
*   Description:
*       Constructor.
*
***********************************************************/

static Animations()
{
int mario_run_rate  = 6;
int mario_walk_rate = 9;

frame_count = 0;
animations = new List<animation_type>();

mario_walk = new animation_type();
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK2_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK1_R, mario_walk_rate );
add_frame( mario_walk, (int)mario_enum.WALK0_R, mario_walk_rate );

mario_run = new animation_type();
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK2_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK1_R, mario_run_rate );
add_frame( mario_run, (int)mario_enum.WALK0_R, mario_run_rate );

block_question = new animation_type();
add_frame( block_question, (int)block_enum.QUESTION_LIT,  24 );
add_frame( block_question, (int)block_enum.QUESTION_MID,  8  );
add_frame( block_question, (int)block_enum.QUESTION_DARK, 8  );
add_frame( block_question, (int)block_enum.QUESTION_MID,  8  );

animations.Add( mario_walk );
animations.Add( mario_run );
animations.Add( block_question );
} /* Animations() */


/***********************************************************
*
*   Method:
*       update
*
*   Description:
*       Update animation states.
*
***********************************************************/

static public void update()
{
frame_count++;

foreach( animation_type a in animations )
    {
    a.update();
    }
} /* update() */


/***********************************************************
*
*   Method:
*       add_frame
*
*   Description:
*       Adds a new frame to the given animation.
*
***********************************************************/

static private void add_frame( animation_type a, int sprite_id, int frame_cnt )
{
a.add_frame( new animation_frame_type( sprite_id, frame_cnt ) );
} /* add_frame() */


/***********************************************************
*
*   Method:
*       get_block_offset
*
*   Description:
*       Returns the block offset for a given block and
*       animation start time.
*
***********************************************************/

static public int get_block_offset( int init_frame_cnt )
{
int offset;
int delta_cnt = frame_count - init_frame_cnt;

if( init_frame_cnt == 0 || delta_cnt >= 13 )
    {
    offset = 0;
    }
else if( delta_cnt < 4 )
    {
    offset = ( delta_cnt * 2 ) + 1;
    }
else if( delta_cnt < 8 )
    {
    offset = 9;
    }
else
    {
    offset = ( 11 - delta_cnt ) * 2 + 1;
    }

return offset;
} /* get_block_offset() */


}
}
