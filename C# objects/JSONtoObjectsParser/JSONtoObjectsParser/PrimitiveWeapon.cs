using System;
using System.Collections.Generic;
using System.Text;

namespace WaponJSONParser
{
    public class PrimitiveWeapon
    // only used to get the objects from the .cbd JSON file
    // 
    {
        public int wi_id { get; set; }
        public int wi_weapon_type { get; set; }
        public int wi_weapon_type_zombie { get; set; }
        public int wi_weapon_prop { get; set; }
        public int wi_trigger_type { get; set; }
        public int wi_firing_type { get; set; }
        public int wi_ragdoll_type { get; set; }
        public int wi_notgore_ragdoll_type { get; set; }
        public int wi_debuff_type { get; set; }
        public int wi_projectile_type { get; set; }
        public int wi_projectile_prop { get; set; }
        public int wi_charging_effect_type { get; set; }
        public int wi_charging_time_max { get; set; }
        public int wi_charging_effect_damage { get; set; }
        public int wi_charging_effect_speed { get; set; }
        public int wi_charging_effect_bombrange { get; set; }
        public int wi_charging_effect_accuracy { get; set; }
        public int wi_charging_effect_multi_shot { get; set; }
        public int wi_charging_effect_bomb_timer { get; set; }
        public int wi_charging_effect_debuff { get; set; }
        public int wi_charging_effect_projectile { get; set; }
        public int wi_charging_effect_chainshot { get; set; }
        public int wi_auto_aim { get; set; }
        public int wi_aim_movetype { get; set; }
        public int wi_aim_move_param { get; set; }
        public int wi_aim_init_size { get; set; }
        public int wi_aim_max_size { get; set; }
        public int wi_aim_zoom_size_min { get; set; }
        public int wi_aim_zoom_size_max { get; set; }
        public int wi_aim_zoom2_size_min { get; set; }
        public int wi_aim_zoom2_size_max { get; set; }
        public int wi_aim_jump_size { get; set; }
        public int wi_aim_spread_speed { get; set; }
        public int wi_aim_restore_speed { get; set; }
        public int wi_aim_restore_speed_zoom { get; set; }
        public int wi_aim_moveup_type { get; set; }
        public int wi_aim_moveup_param { get; set; }
        public int wi_aim_moveup_max { get; set; }
        public int wi_aim_moveup_speed { get; set; }
        public int wi_aim_moveup_restore_speed { get; set; }
        public int wi_dam_head { get; set; }
        public int wi_dam_upper { get; set; }
        public int wi_dam_under { get; set; }
        public int wi_dam_zoom_in { get; set; }
        public int wi_rand_dam { get; set; }
        public int wi_hit_rate { get; set; }
        public int wi_miss_dam_rate { get; set; }
        public int wi_critical_rate { get; set; }
        public int wi_critical_damage { get; set; }
        public int wi_zoom_in_level { get; set; }
        public int wi_zoom_fov1 { get; set; }
        public int wi_zoom_fov2 { get; set; }
        public int wi_zoom_fire_ready_time { get; set; }
        public int wi_fire_bullet_count { get; set; }
        public int wi_chainshot_count { get; set; }
        public int wi_chainshot_interval { get; set; }
        public int wi_setup_count { get; set; }
        public int wi_bullet_speed { get; set; }
        public int wi_bullet_max_speed { get; set; }
        public int wi_bullet_accel { get; set; }
        public int wi_bullet_bounce_count { get; set; }
        public int wi_bullet_restitution { get; set; }
        public int wi_range { get; set; }
        public int wi_overheat_up { get; set; }
        public int wi_overheat_down { get; set; }
        public int wi_overheat_penalty_time { get; set; }
        public int wi_bomb_range { get; set; }
        public int wi_bomb_time { get; set; }
        public int wi_bomb_type { get; set; }
        public int wi_detonate_type { get; set; }
        public int wi_sensor_range { get; set; }
        public int wi_ready_fire { get; set; }
        public int wi_fire_run { get; set; }
        public int wi_fire_time { get; set; }
        public int wi_lockon_time { get; set; }
        public int wi_firing_accel_time { get; set; }
        public int wi_firing_hold_time { get; set; }
        public int wi_fire_time_right { get; set; }
        public int wi_reload_time { get; set; }
        public int wi_reload_any_type { get; set; }
        public int wi_knockback { get; set; }
        public int wi_accel_weight { get; set; }
        public int wi_accel_time { get; set; }
        public int wi_max_turning_angle { get; set; }
        public int wi_rate_of_fire_def { get; set; }
        public int wi_rate_of_fire_max { get; set; }
        public int wi_bullet_capacity { get; set; }
        public int wi_bullet_total { get; set; }
        public int wi_change_time { get; set; }
        public int wi_change_skip { get; set; }
        public int wi_change_delay { get; set; }
        public int wi_weaponself_time { get; set; }
        public int wi_ability_a { get; set; }
        public int wi_ability_b { get; set; }
        public int wi_ability_c { get; set; }
        public int wi_ability_d { get; set; }
        public int wi_ability_a_max { get; set; }
        public int wi_ability_b_max { get; set; }
        public int wi_ability_c_max { get; set; }
        public int wi_ability_d_max { get; set; }
        public int wi_weapon_size { get; set; }
        public PrimitiveWeapon()
        {

        }
    }
}
