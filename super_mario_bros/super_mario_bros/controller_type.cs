/*********************************************************************
*
*   Class:
*       controller_type
*
*   Description:
*       Contains the game logic
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

public class controller_type {

/*--------------------------------------------------------------------
                           ATTRIBUTES
--------------------------------------------------------------------*/

private model_type model;
private int v_idx;
private char_status_enum prev_location;
private int init_frame_pole_l;

/*--------------------------------------------------------------------
                            METHODS
--------------------------------------------------------------------*/

/***********************************************************
*
*   Method:
*       controller_type
*
*   Description:
*       Constructor.
*
***********************************************************/

public controller_type( model_type m )
{
model = m;
v_idx = 0;
} /* controller_type() */


/***********************************************************
*
*   Method:
*       update
*
*   Description:
*       Updates the game logic.
*
***********************************************************/

public void update()
{
KeyBinding.set_key_states();
Animations.update();

/*----------------------------------------------------------
Update mario status
----------------------------------------------------------*/
switch( model.game_status )
    {
    case game_status_enum.gameplay:
        model.level.mario.status = update_mario();
        break;

    case game_status_enum.level_complete:
        model.level.mario.status = update_mario_level_complete();
        break;

    case game_status_enum.lose_life:
        lose_a_life();
        break;
    }

} /* update() */


/***********************************************************
*
*   Method:
*       update_mario
*
*   Description:
*       Updates mario during game play.
*
***********************************************************/

private mario_status_enum update_mario()
{
physics_type physics = model.level.mario.physics;
char_status_enum location = model.level.mario.ground_status;
mario_status_enum status = model.level.mario.status;

/*----------------------------------------------------------
Update mario Y location on jump
----------------------------------------------------------*/
if( location == char_status_enum.GROUND && KeyBinding.A_BTN_pressed )
    {
    if( model.level.mario.facing_right() )
        {
        status = mario_status_enum.JUMP_R;
        }
    else
        {
        status = mario_status_enum.JUMP_L;
        }

    physics.init_velocity.x = physics.velocity.x;
    physics.init_velocity.y = physics.velocity.y;

    if( KeyBinding.B_BTN_pressed )
        {
        physics.init_velocity.x++;
        }

    v_idx = 0;
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh1 )
        {
        v_idx++;
        }
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh2 )
        {
        v_idx++;
        }

    physics.acceleration.y = MarioPhysics.ay_j_a[v_idx];
    physics.velocity.y     = MarioPhysics.vy_j_init[v_idx];
    }
/*----------------------------------------------------------
Update mario Y location on fall
----------------------------------------------------------*/
else if( prev_location == char_status_enum.GROUND &&
         location == char_status_enum.AIR &&
         physics.velocity.y == 0 )
    {
    if( model.level.mario.facing_right() )
        {
        status = mario_status_enum.FALL_R;
        }
    else
        {
        status = mario_status_enum.FALL_L;
        }

    physics.init_velocity.x = physics.velocity.x;
    physics.init_velocity.y = physics.velocity.y;

    if( KeyBinding.B_BTN_pressed )
        {
        physics.init_velocity.x++;
        }

    v_idx = 0;
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh1 )
        {
        v_idx++;
        }
    if( physics.velocity.x >= MarioPhysics.vy_j_thresh2 )
        {
        v_idx++;
        }

    physics.acceleration.y = MarioPhysics.ay_j_f[v_idx];
    physics.velocity.y += physics.acceleration.y;
    }
/*----------------------------------------------------------
Update mario Y location in air
----------------------------------------------------------*/
else if( location == char_status_enum.AIR )
    {
    update_mario_falling( physics );
    }
/*----------------------------------------------------------
Update mario Y location on ground
----------------------------------------------------------*/
else
    {
    physics.acceleration.y = 0;
    physics.velocity.y = 0;

    /*----------------------------------------------------------
    Skidding left
    ----------------------------------------------------------*/
    if( ( KeyBinding.D_RIGHT_pressed ) &&
        ( physics.velocity.x < -1 * MarioPhysics.vx_skid_thresh ) &&
        ( location == char_status_enum.GROUND ) )
        {
        physics.acceleration.x = MarioPhysics.ax_skid;
        physics.velocity.x += physics.acceleration.x;
        status = mario_status_enum.SKID_R;
        }
    /*----------------------------------------------------------
    Skidding right
    ----------------------------------------------------------*/
    else if( ( KeyBinding.D_LEFT_pressed ) &&
            ( physics.velocity.x > MarioPhysics.vx_skid_thresh ) &&
            ( location == char_status_enum.GROUND ) )
        {
        physics.acceleration.x = -1 * MarioPhysics.ax_skid;
        physics.velocity.x += physics.acceleration.x;
        status = mario_status_enum.SKID_L;
        }
    /*----------------------------------------------------------
    Running right
    ----------------------------------------------------------*/
    else if( KeyBinding.D_RIGHT_pressed &&
            KeyBinding.B_BTN_pressed &&
            ( location == char_status_enum.GROUND ) )
        {
        if( physics.velocity.x < 0 )
            {
            physics.velocity.x = 0;
            }

        if( physics.velocity.x <= MarioPhysics.vx_walk_max )
            {
            status = mario_status_enum.WALK_R;
            }
        else
            {
            status = mario_status_enum.RUN_R;
            }

        physics.acceleration.x = MarioPhysics.ax_run;
        physics.velocity.x += physics.acceleration.x;

        if( physics.velocity.x > MarioPhysics.vx_run_max )
            {
            physics.velocity.x = MarioPhysics.vx_run_max;
            }

        if( physics.velocity.x < MarioPhysics.vx_walk_min )
            {
            physics.velocity.x = MarioPhysics.vx_walk_min;
            }
        }
    /*----------------------------------------------------------
    Running left
    ----------------------------------------------------------*/
    else if( KeyBinding.D_LEFT_pressed &&
            KeyBinding.B_BTN_pressed &&
            ( location == char_status_enum.GROUND ) )
        {
        if( physics.velocity.x > 0 )
            {
            physics.velocity.x = 0;
            }

        if( physics.velocity.x >= -1 * MarioPhysics.vx_walk_max )
            {
            status = mario_status_enum.WALK_L;
            }
        else
            {
            status = mario_status_enum.RUN_L;
            }

        physics.acceleration.x = -1 * MarioPhysics.ax_run;
        physics.velocity.x += physics.acceleration.x;

        if( physics.velocity.x < -1 * MarioPhysics.vx_run_max )
            {
            physics.velocity.x = -1 * MarioPhysics.vx_run_max;
            }

        if( physics.velocity.x > -1 * MarioPhysics.vx_walk_min )
            {
            physics.velocity.x = -1 * MarioPhysics.vx_walk_min;
            }
        }
    /*----------------------------------------------------------
    Walking right
    ----------------------------------------------------------*/
    else if( KeyBinding.D_RIGHT_pressed &&
            !KeyBinding.B_BTN_pressed &&
            ( location == char_status_enum.GROUND ) )
        {
        status = mario_status_enum.WALK_R;

        physics.acceleration.x = MarioPhysics.ax_walk;
        physics.velocity.x += physics.acceleration.x;

        if( physics.velocity.x > MarioPhysics.vx_walk_max )
            {
            physics.velocity.x = MarioPhysics.vx_walk_max;
            }

        if( physics.velocity.x < MarioPhysics.vx_walk_min )
            {
            physics.velocity.x = MarioPhysics.vx_walk_min;
            }
        }
    /*----------------------------------------------------------
    Walking left
    ----------------------------------------------------------*/
    else if( KeyBinding.D_LEFT_pressed &&
            !KeyBinding.B_BTN_pressed &&
            ( location == char_status_enum.GROUND ) )
        {
        status = mario_status_enum.WALK_L;

        physics.acceleration.x = -1 * MarioPhysics.ax_walk;
        physics.velocity.x += physics.acceleration.x;

        if( physics.velocity.x < -1 * MarioPhysics.vx_walk_max )
            {
            physics.velocity.x = -1 * MarioPhysics.vx_walk_max;
            }

        if( physics.velocity.x > -1 * MarioPhysics.vx_walk_min )
            {
            physics.velocity.x = -1 * MarioPhysics.vx_walk_min;
            }
        }
    /*----------------------------------------------------------
    Sliding right
    ----------------------------------------------------------*/
    else if( ( physics.velocity.x > MarioPhysics.vx_walk_min ) &&
            ( location == char_status_enum.GROUND ) )
        {
        physics.acceleration.x = -1 * MarioPhysics.ax_release;
        physics.velocity.x += physics.acceleration.x;

        if( model.level.mario.facing_right() )
            {
            status = mario_status_enum.STILL_R;
            }
        else
            {
            status = mario_status_enum.STILL_L;
            }
        }
    /*----------------------------------------------------------
    Sliding left
    ----------------------------------------------------------*/
    else if( ( physics.velocity.x < -1 * MarioPhysics.vx_walk_min ) &&
            ( location == char_status_enum.GROUND ) )
        {
        physics.acceleration.x = MarioPhysics.ax_release;
        physics.velocity.x += physics.acceleration.x;

        if( model.level.mario.facing_right() )
            {
            status = mario_status_enum.STILL_R;
            }
        else
            {
            status = mario_status_enum.STILL_L;
            }
        }
    /*----------------------------------------------------------
    Standing still
    ----------------------------------------------------------*/
    else if( location == char_status_enum.GROUND )
        {
        physics.acceleration.x = 0;
        physics.velocity.x = 0;

        if( model.level.mario.facing_right() )
            {
            status = mario_status_enum.STILL_R;
            }
        else
            {
            status = mario_status_enum.STILL_L;
            }
        }
    }

/*----------------------------------------------------------
Handle all collisions
----------------------------------------------------------*/
int x_pixel = ( ( physics.position.x + physics.velocity.x ) >> 12 ) + physics.hit_box.Width;

if( ( ( model.level.map.flag_loc.X + 6 ) <= x_pixel ) &&
    ( ( x_pixel >> 4 )  < model.level.map.tier_widths[0] ) )
    {
    model.game_status = game_status_enum.level_complete;
    }
if( physics.position.y + physics.velocity.y < 0 )
    {
    physics.position += physics.velocity;
    }
else
    {
    update_hit_box( model.level.mario );
    }

/*----------------------------------------------------------
Check for entering a vertical pipe
----------------------------------------------------------*/
if( KeyBinding.D_DOWN_pressed )
    {
    pipe_type p = on_pipe();

    if( null != p )
        {
        int x = model.level.mario.physics.position.x >> 16;
        int y = ( ( model.level.mario.physics.position.y >> 12 ) + model.level.mario.physics.hit_box.Height ) >> 4;

        p.check_entry( x, y, model.level.mario );
        //don't change position yet, just check (or recieve position here?)
        //then change position after the transition
        //hold in pipe transition until out
        //then transfer back to "in game"
        }
    }

/*----------------------------------------------------------
Never scroll screen left
----------------------------------------------------------*/
if( physics.position.x < ViewDims.view.X )
    {
    physics.position.x = ViewDims.view.X;
    physics.acceleration.x = 0;
    physics.velocity.x = 0;
    }

return status;
} /* update_mario() */


/***********************************************************
*
*   Method:
*       update_mario_level_complete
*
*   Description:
*       Updates mario after level is complete.
*
***********************************************************/

private mario_status_enum update_mario_level_complete()
{
mario_status_enum status = model.level.mario.status;
physics_type physics = model.level.mario.physics;

//set status to falling when we hit the pole, then make a check if falling here

switch( status )
    {
    case mario_status_enum.FALL_L:
        status = mario_status_enum.FALL_R;
        break;

    case mario_status_enum.JUMP_L:
        status = mario_status_enum.JUMP_R;
        break;

    case mario_status_enum.FALL_R:
    case mario_status_enum.JUMP_R:
        /*----------------------------------------------------------
        Let mario fall till the top of the pole, then start descent
        ----------------------------------------------------------*/
        if( ( ( physics.position.y + physics.hit_box.Height - ( 8 << 12 ) ) >> 16 ) >= ( ( model.level.map.flag_loc.Top ) >> 4 ) )
            {
            status = mario_status_enum.POLE_R;
            }
        else
            {
            update_mario_falling( physics );
            physics.position.y += physics.velocity.y;
            physics.position.x = ( model.level.map.flag_loc.X - physics.hit_box.Width + 6 ) << 12;
            }
        break;

    case mario_status_enum.POLE_R:
    case mario_status_enum.POLE_BOTTOM_R:
        Boolean mario_bottom = ( physics.position.y >> 12 ) + physics.hit_box.Height >= model.level.map.flag_loc.Bottom;
        Boolean flag_bottom = ( model.level.map.flag.y + model.level.map.flag.height + 4 ) >= model.level.map.flag_loc.Bottom;
        /*----------------------------------------------------------
        Slide down pole
        ----------------------------------------------------------*/
        physics.position.x = ( model.level.map.flag_loc.X - physics.hit_box.Width + 6 ) << 12;

        if( !mario_bottom )
            {
            physics.position.y += MarioPhysics.vy_desc_vine;
            }
        else
            {
            status = mario_status_enum.POLE_BOTTOM_R;
            }
        if( !flag_bottom )
            {
            model.level.map.flag.y += ( MarioPhysics.vy_desc_vine >> 12 );
            }

        /*----------------------------------------------------------
        Switch pole sides once mario hits the bottom
        ----------------------------------------------------------*/
        if( mario_bottom && flag_bottom )
            {
            physics.position.y = ( model.level.map.flag_loc.Bottom - physics.hit_box.Height ) << 12;
            physics.position.x += ( ( 2 + physics.hit_box.Width ) << 12 );
            status = mario_status_enum.POLE_L;
            init_frame_pole_l = Animations.frame_count;
            }
        break;

    case mario_status_enum.POLE_L:
        if( Animations.frame_count >= ( init_frame_pole_l + 30 ) )
            {
            status = mario_status_enum.WALK_CTRL_L;
            init_frame_pole_l = Animations.frame_count;
            }
        break;

    case mario_status_enum.WALK_CTRL_L:
        if( Animations.frame_count >= ( init_frame_pole_l + 8 ) )
            {
            status = mario_status_enum.WALK_CTRL_R;
            }
        else if( Animations.frame_count >= ( init_frame_pole_l + 4 ) )
            {
            physics.position.x += ( 2 << 12 );
            physics.position.y += ( ( Animations.frame_count - init_frame_pole_l - 4 ) << 12 );
            }
        else
            {
            physics.position.x += ( 2 << 12 );
            }
        break;

    case mario_status_enum.WALK_CTRL_R:
        physics.position.y = ( model.level.map.flag_loc.Bottom - physics.hit_box.Height + 17 ) << 12;
        physics.position.x += MarioPhysics.vx_walk_no_ctrl_max;
        ViewDims.move_view_location( MarioPhysics.vx_walk_no_ctrl_max );

        if( physics.position.x >= model.level.map.exit_loc_x )
            {
            status = mario_status_enum.STILL_R;
            model.game_status = game_status_enum.level_score;
            }
        break;

    default:
        status = mario_status_enum.POLE_R;
        break;
    }

return status;
}


/***********************************************************
*
*   Method:
*       update_hit_box
*
*   Description:
*       Determines if character is on ground or air.
*
***********************************************************/

private void update_hit_box( character_type c )
{
/*----------------------------------------------------------
Local variables
----------------------------------------------------------*/
int[] x = new int[2];
int[] y = new int[2];
int suby;

/*----------------------------------------------------------
Update y position and find character boundaries
----------------------------------------------------------*/
c.physics.position.y += c.physics.velocity.y;

x[0] = ( c.physics.position.x >> 12 ) / Blocks.size.Width;
x[1] = ( ( c.physics.position.x >> 12 ) + c.physics.hit_box.Width  ) / Blocks.size.Width;
y[0] = ( ( c.physics.position.y >> 12 ) + c.physics.hit_box.Height ) / Blocks.size.Height;
y[1] = ( c.physics.position.y >> 12 ) / Blocks.size.Height;

prev_location = c.ground_status;

/*----------------------------------------------------------
Check for y collisions
----------------------------------------------------------*/
if( contains_block( x, y[1] ) )
    {
    int x_hit;

    push_down( c );

    if( contains_block( x[1], y[1] ) && model.level.mario.facing_right() )
        {
        x_hit = x[1];
        }
    else if( contains_block( x[0], y[1] ) && !model.level.mario.facing_right() )
        {
        x_hit = x[0];
        }
    else if( contains_block( x[1], y[1] ) )
        {
        x_hit = x[1];
        }
    else
        {
        x_hit = x[0];
        }

    if( model.level.map.blocks[ x_hit, y[1] ].hit_bottom() )
        {
        c.physics.velocity.y = MarioPhysics.vy_hard_block;
        }
    }
else if( contains_block( x, y[0] ) )
    {
    push_up( c );
    }
else
    {
    c.ground_status = char_status_enum.AIR;
    }

/*----------------------------------------------------------
Update x position and find character boundaries
----------------------------------------------------------*/
c.physics.position.x += c.physics.velocity.x;

x[0] = ( c.physics.position.x >> 12 ) / Blocks.size.Width;
x[1] = ( ( c.physics.position.x >> 12 ) + c.physics.hit_box.Width  ) / Blocks.size.Width;
y[0] = ( ( c.physics.position.y >> 12 ) + c.physics.hit_box.Height ) / Blocks.size.Height;
y[1] = ( c.physics.position.y >> 12 ) / Blocks.size.Height;
suby = ( c.physics.position.y >> 12 ) % Blocks.size.Height;

if( c.ground_status == char_status_enum.GROUND )
    {
    y[0]--;
    }

/*----------------------------------------------------------
Check for x collisions
----------------------------------------------------------*/
if( contains_block( x[0], y ) )
    {
    push_right( c );
    }
else if( contains_block( x[1], y ) )
    {
    push_left( c );

    /*----------------------------------------------------------
    Check for entering a horizontal pipe
    ----------------------------------------------------------*/
    if( ( model.game_status == game_status_enum.gameplay ) &&
        ( KeyBinding.D_RIGHT_pressed ) &&
        ( model.level.map.blocks[x[1], y[0]] != null ) &&
        ( model.level.map.blocks[x[1], y[0]].GetType() == typeof( block_pipe_type ) ) )
        {
        block_pipe_type p = (block_pipe_type)model.level.map.blocks[x[1], y[0]];
        p.pipe.check_entry( x[1] - 1, y[0], model.level.mario );
        //don't change position yet, just check (or recieve position here?)
        //then change position after the transition
        }
    }

} /* update_hit_box() */


/***********************************************************
*
*   Method:
*       push_down
*
*   Description:
*       Push the character down one block.
*
***********************************************************/

private void push_down( character_type c )
{
int y = ( ( c.physics.position.y >> 12 ) / Blocks.size.Height ) + 1;

c.physics.acceleration.y = 0;
c.physics.velocity.y = 0;
c.physics.position.y = ( y * Blocks.size.Height ) << 12;

c.ground_status = char_status_enum.AIR;

} /* push_down() */


/***********************************************************
*
*   Method:
*       push_up
*
*   Description:
*       Determines if character is on ground or air.
*
***********************************************************/

public void push_up( character_type c )
{
int y    = ( ( c.physics.position.y >> 12 ) + c.physics.hit_box.Height ) / Blocks.size.Height;

c.ground_status = char_status_enum.GROUND;
c.physics.position.y = ( ( ( y * Blocks.size.Height ) - c.physics.hit_box.Height ) + 1 ) << 12;

} /* push_up() */


/***********************************************************
*
*   Method:
*       push_right
*
*   Description:
*       Push the character left one block.
*
***********************************************************/

private void push_right( character_type c )
{
int x = ( c.physics.position.x >> 12 ) / Blocks.size.Width + 1;

c.physics.acceleration.x = 0;
c.physics.velocity.x = 0;
c.physics.position.x = ( x * Blocks.size.Width ) << 12;

} /* push_right() */


/***********************************************************
*
*   Method:
*       push_left
*
*   Description:
*       Push the character down one block.
*
***********************************************************/

private void push_left( character_type c )
{
int x = ( ( c.physics.position.x >> 12 ) + c.physics.hit_box.Width ) / Blocks.size.Width;

c.physics.acceleration.x = 0;
c.physics.velocity.x = 0;
c.physics.position.x = ( ( ( x * Blocks.size.Width ) - c.physics.hit_box.Width ) << 12 ) - 1;

} /* push_left() */


/***********************************************************
*
*   Method:
*       contains_block
*
*   Description:
*       Returns true if the given series of blocks
*       contains a solid block.
*
***********************************************************/

private Boolean contains_block( int[] x, int y )
{
Boolean result = false;

for( int i = x[0]; i <= x[1]; i++ )
    {
    if( check_left_map( i, y ) )
        {
        break;
        }
    else if( model.level.map.blocks[i, y] != null )
        {
        result = true;
        break;
        }
    }

return result;
} /* contains_block() */

private Boolean contains_block( int x, int[] y )
{
Boolean result = false;

for( int j = y[1]; j <= y[0]; j++ )
    {
    if( check_left_map( x, j ) )
        {
        break;
        }
    else if( model.level.map.blocks[x, j] != null )
        {
        result = true;
        break;
        }
    }

return result;
} /* contains_block() */

private Boolean contains_block( int x, int y )
{
return ( model.level.map.blocks[x, y] != null );
} /* contains_block() */


/***********************************************************
*
*   Method:
*       check_left_map
*
*   Description:
*       Returns true if mario has left the map.
*
***********************************************************/

private Boolean check_left_map( int x, int y )
{
Boolean left_map = false;

if( x < 0 || x >= model.level.map.width || y < 0 || y >= model.level.map.height )
    {
    model.game_status = game_status_enum.lose_life;
    left_map = true;
    }

return left_map;
} /* check_left_map() */


/***********************************************************
*
*   Method:
*       lose_a_life
*
*   Description:
*       Lose a life.
*
***********************************************************/

private void lose_a_life()
{
/* Temporary code. Will need to be replaced with lose a life */
model.level.mario.physics.position.x = model.level.mario.physics.init_position.x;
model.level.mario.physics.position.y = model.level.mario.physics.init_position.y;
model.level.mario.physics.velocity.x = 0;
model.level.mario.physics.velocity.y = 0;
model.level.mario.physics.acceleration.x = 0;
model.level.mario.physics.acceleration.y = 0;
ViewDims.view.X = 0;
ViewDims.view.Y = 0;
model.game_status = game_status_enum.gameplay;
} /* lose_a_life() */


/***********************************************************
*
*   Method:
*       on_pipe
*
*   Description:
*       Returns the pipe mario is standing on,
*       or null if he is not on a pipe.
*
***********************************************************/

private pipe_type on_pipe()
{
pipe_type p = null;
int x0 = model.level.mario.physics.position.x >> 16;
int x1 = ( ( model.level.mario.physics.position.x >> 12 ) + model.level.mario.physics.hit_box.Width ) >> 4;
int y  = ( ( model.level.mario.physics.position.y >> 12 ) + model.level.mario.physics.hit_box.Height ) >> 4;
y++;

if( ( ( null != model.level.map.blocks[x0, y] ) && ( model.level.map.blocks[x0, y].GetType() == typeof( block_pipe_type ) ) ) &&
    ( ( null != model.level.map.blocks[x1, y] ) && ( model.level.map.blocks[x1, y].GetType() == typeof( block_pipe_type ) ) ) )
    {
    block_pipe_type p_block = (block_pipe_type)model.level.map.blocks[x0, y];
    p = p_block.pipe;
    }

return p;
} /* on_pipe() */


/***********************************************************
*
*   Method:
*       update_mario_falling
*
*   Description:
*       Update mario physics while falling.
*
***********************************************************/

private void update_mario_falling( physics_type physics )
{
if( KeyBinding.A_BTN_pressed && physics.velocity.y < 0 )
    {
    physics.acceleration.y = MarioPhysics.ay_j_a[v_idx];
    physics.velocity.y += physics.acceleration.y;
    }
else
    {
    physics.acceleration.y = MarioPhysics.ay_j_f[v_idx];
    physics.velocity.y += physics.acceleration.y;
    }

if( KeyBinding.D_RIGHT_pressed )
    {
    if( physics.velocity.x <= MarioPhysics.vx_walk_max )
        {
        physics.acceleration.x = MarioPhysics.ax_jf_walk;
        }
    else
        {
        physics.acceleration.x = MarioPhysics.ax_jf_run;
        }

    physics.velocity.x += physics.acceleration.x;
    }
else if( KeyBinding.D_LEFT_pressed )
    {
    if( physics.velocity.x >= MarioPhysics.vx_walk_max )
        {
        physics.acceleration.x = MarioPhysics.ax_jb_run;
        }
    else if( ( physics.velocity.x < MarioPhysics.vx_walk_max ) &&
                ( physics.init_velocity.x >= MarioPhysics.vx_j_thresh ) )
        {
        physics.acceleration.x = MarioPhysics.ax_jb_run_walk;
        }
    else
        {
        physics.acceleration.x = MarioPhysics.ax_jb_walk;
        }

    physics.velocity.x += physics.acceleration.x;
    }

/*----------------------------------------------------------
Keep speeds in bounds
----------------------------------------------------------*/
if( ( physics.init_velocity.x <= MarioPhysics.vx_walk_max ) &&
    ( physics.velocity.x > MarioPhysics.vx_walk_max ) )
    {
    physics.velocity.x = MarioPhysics.vx_walk_max;
    }
else if( ( physics.init_velocity.x >= -1 * MarioPhysics.vx_walk_max ) &&
            ( physics.velocity.x < -1 * MarioPhysics.vx_walk_max ) )
    {
    physics.velocity.x = -1 * MarioPhysics.vx_walk_max;
    }

if( physics.velocity.y > MarioPhysics.vy_j_max )
    {
    physics.velocity.y = MarioPhysics.vy_j_max;
    }
if( physics.velocity.x > MarioPhysics.vx_run_max )
    {
    physics.velocity.x = MarioPhysics.vx_run_max;
    }
else if( physics.velocity.x < ( -1 * MarioPhysics.vx_run_max ) )
    {
    physics.velocity.x = -1 * MarioPhysics.vx_run_max;
    }
} /* update_mario_falling() */

}
}
