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


}
}
