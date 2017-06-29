#pragma once

#include "ais.h"

extern "C" __declspec(dllexport) libais::Ais1_2_3* ais1_2_3 = NULL;

extern "C" __declspec(dllexport) void create_ais_msg(const char* payload, const size_t pad);
extern "C" __declspec(dllexport) void create_empty_ais_msg();
extern "C" __declspec(dllexport) void destroy_ais_msg();

extern "C" __declspec(dllexport) int    get_message_id();
extern "C" __declspec(dllexport) int    get_repeat_indicator();
extern "C" __declspec(dllexport) int    get_mmsi();
extern "C" __declspec(dllexport) int    get_nav_status();
extern "C" __declspec(dllexport) bool   get_rot_over_range();
extern "C" __declspec(dllexport) int    get_rot_raw();
extern "C" __declspec(dllexport) float  get_rot();
extern "C" __declspec(dllexport) float  get_sog();  // Knots.
extern "C" __declspec(dllexport) int    get_position_accuracy();
extern "C" __declspec(dllexport) double get_pos_lat();
extern "C" __declspec(dllexport) double get_pos_long();
extern "C" __declspec(dllexport) float  get_cog();  // Degrees.
extern "C" __declspec(dllexport) int    get_true_heading();
extern "C" __declspec(dllexport) int    get_timestamp();
extern "C" __declspec(dllexport) int    get_special_manoeuvre();
extern "C" __declspec(dllexport) int    get_spare();
extern "C" __declspec(dllexport) bool   get_raim();
extern "C" __declspec(dllexport) int    get_sync_state();  // SOTDMA and ITDMA
extern "C" __declspec(dllexport) bool   get_slot_timeout_valid();
extern "C" __declspec(dllexport) int    get_slot_timeout();
extern "C" __declspec(dllexport) bool   get_received_stations_valid();
extern "C" __declspec(dllexport) int    get_received_stations();
extern "C" __declspec(dllexport) bool   get_slot_number_valid();
extern "C" __declspec(dllexport) int    get_slot_number();
extern "C" __declspec(dllexport) bool   get_utc_valid();
extern "C" __declspec(dllexport) int    get_utc_hour();
extern "C" __declspec(dllexport) int    get_utc_min();
extern "C" __declspec(dllexport) int    get_utc_spare();
extern "C" __declspec(dllexport) bool   get_slot_offset_valid();
extern "C" __declspec(dllexport) int    get_slot_offset();
extern "C" __declspec(dllexport) bool   get_slot_increment_valid();
extern "C" __declspec(dllexport) int    get_slot_increment();
extern "C" __declspec(dllexport) bool   get_slots_to_allocate_valid();
extern "C" __declspec(dllexport) int    get_slots_to_allocate();
extern "C" __declspec(dllexport) bool   get_keep_flag_valid();
extern "C" __declspec(dllexport) bool   get_keep_flag();  // 3.3.7.3.2 Annex 2 ITDMA.  Table 20

extern "C" __declspec(dllexport) void set_message_id(int val);
extern "C" __declspec(dllexport) void set_repeat_indicator(int val);
extern "C" __declspec(dllexport) void set_mmsi(int val);
extern "C" __declspec(dllexport) void set_nav_status(int val);
//extern "C" __declspec(dllexport) void set_rot_over_range(bool val);
extern "C" __declspec(dllexport) void set_rot_raw(float val);
//extern "C" __declspec(dllexport) void set_rot(float val);
extern "C" __declspec(dllexport) void set_sog(float val);  // Knots.
extern "C" __declspec(dllexport) void set_position_accuracy(int val);
extern "C" __declspec(dllexport) void set_pos_lat(double val);
extern "C" __declspec(dllexport) void set_pos_long(double val);
extern "C" __declspec(dllexport) void set_cog(float val);  // Degrees.
extern "C" __declspec(dllexport) void set_true_heading(int val);
extern "C" __declspec(dllexport) void set_timestamp(int val);
extern "C" __declspec(dllexport) void set_special_manoeuvre(int val);
extern "C" __declspec(dllexport) void set_spare(int val);
extern "C" __declspec(dllexport) void set_raim(bool val);
extern "C" __declspec(dllexport) void set_sync_state(int val);  // SOTDMA and ITDMA
extern "C" __declspec(dllexport) void set_slot_timeout_valid(bool val);
extern "C" __declspec(dllexport) void set_slot_timeout(int val);
extern "C" __declspec(dllexport) void set_received_stations_valid(bool val);
extern "C" __declspec(dllexport) void set_received_stations(int val);
extern "C" __declspec(dllexport) void set_slot_number_valid(bool val);
extern "C" __declspec(dllexport) void set_slot_number(int val);
extern "C" __declspec(dllexport) void set_utc_valid(bool val);
extern "C" __declspec(dllexport) void set_utc_hour(int val);
extern "C" __declspec(dllexport) void set_utc_min(int val);
extern "C" __declspec(dllexport) void set_utc_spare(int val);
extern "C" __declspec(dllexport) void set_slot_offset_valid(bool val);
extern "C" __declspec(dllexport) void set_slot_offset(int val);
extern "C" __declspec(dllexport) void set_slot_increment_valid(bool val);
extern "C" __declspec(dllexport) void set_slot_increment(int val);
extern "C" __declspec(dllexport) void set_slots_to_allocate_valid(bool val);
extern "C" __declspec(dllexport) void set_slots_to_allocate(int val);
extern "C" __declspec(dllexport) void set_keep_flag_valid(bool val);
extern "C" __declspec(dllexport) void set_keep_flag(bool val);  // 3.3.7.3.2 Annex 2 ITDMA.  Table 20

extern "C" __declspec(dllexport) char* get_ais_msg();  // 3.3.7.3.2 Annex 2 ITDMA.  Table 20