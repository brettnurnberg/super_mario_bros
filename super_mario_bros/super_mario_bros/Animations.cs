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
int mario_run_rate = 6;

animations = new List<animation_type>();

mario_run = new animation_type( Marios.textures );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK2, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK1, mario_run_rate ) );
mario_run.add_frame( new animation_frame_type( (int)mario_enum.WALK0, mario_run_rate ) );

block_question = new animation_type( Blocks.textures );
block_question.add_frame( new animation_frame_type( (int)block_enum.QUESTION_LIT,  24 ) );
block_question.add_frame( new animation_frame_type( (int)block_enum.QUESTION_MID,  8  ) );
block_question.add_frame( new animation_frame_type( (int)block_enum.QUESTION_DARK, 8  ) );
block_question.add_frame( new animation_frame_type( (int)block_enum.QUESTION_MID,  8  ) );

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


}
}
