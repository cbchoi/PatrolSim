#include <iostream>
#include <sstream>
#include <windows.h>

#include "libAIVDM.h"


void create_ais_msg(const char* payload, const size_t pad)
{
	ais1_2_3 = new libais::Ais1_2_3(payload, pad);
}

void create_empty_ais_msg()
{
	ais1_2_3 = new libais::Ais1_2_3("1000000000000000000000000000", 0);
}

void destroy_ais_msg()
{
	delete ais1_2_3;
	ais1_2_3 = NULL;
}

int get_message_id()
{
	return ais1_2_3->message_id;
}

int get_repeat_indicator()
{
	return ais1_2_3->repeat_indicator;
}

int get_mmsi()
{
	return ais1_2_3->mmsi;
}

int    get_nav_status()
{
	return ais1_2_3->nav_status;
}

bool   get_rot_over_range()
{
	return ais1_2_3->rot_over_range;
}
int    get_rot_raw()
{
	return ais1_2_3->rot_raw;
}

float  get_rot()
{
	return ais1_2_3->rot;
}

float  get_sog()
{
	return ais1_2_3->sog;
}  // Knots.

int    get_position_accuracy()
{
	return ais1_2_3->position_accuracy;
}

double get_pos_lat()
{
	return ais1_2_3->position.lat_deg;
}

double get_pos_long()
{
	return ais1_2_3->position.lng_deg;
}

float  get_cog()
{
	return ais1_2_3->cog;
}  // Degrees.

int    get_true_heading()
{
	return ais1_2_3->true_heading;
}

int    get_timestamp()
{
	return ais1_2_3->timestamp;
}

int    get_special_manoeuvre()
{
	return ais1_2_3->special_manoeuvre;
}

int    get_spare()
{
	return ais1_2_3->spare;
}

bool   get_raim()
{
	return ais1_2_3->raim;
}

int    get_sync_state()
{
	return ais1_2_3->sync_state;
}  // SOTDMA and ITDMA

bool   get_slot_timeout_valid()
{
	return ais1_2_3->slot_timeout_valid;
}

int    get_slot_timeout()
{
	return ais1_2_3->slot_timeout;
}

bool   get_received_stations_valid()
{
	return ais1_2_3->received_stations_valid;
}

int    get_received_stations()
{
	return ais1_2_3->received_stations;
}

bool   get_slot_number_valid()
{
	return ais1_2_3->slot_number_valid;
}

int    get_slot_number()
{
	return ais1_2_3->slot_number;
}

bool   get_utc_valid()
{
	return ais1_2_3->utc_valid;
}

int    get_utc_hour()
{
	return ais1_2_3->utc_hour;
}

int    get_utc_min()
{
	return ais1_2_3->utc_min;
}

int    get_utc_spare()
{
	return ais1_2_3->spare;
}

bool   get_slot_offset_valid()
{
	return ais1_2_3->slot_offset_valid;
}

int    get_slot_offset()
{
	return ais1_2_3->slot_offset;
}

bool   get_slot_increment_valid()
{
	return ais1_2_3->slot_increment_valid;
}

int    get_slot_increment()
{
	return ais1_2_3->slot_increment;
}

bool   get_slots_to_allocate_valid()
{
	return ais1_2_3->slots_to_allocate_valid;
}

int    get_slots_to_allocate()
{
	return ais1_2_3->slots_to_allocate;
}

bool   get_keep_flag_valid()
{
	return ais1_2_3->keep_flag_valid;
}

bool   get_keep_flag()
{
	return ais1_2_3->keep_flag;
}  // 3.3.7.3.2 Annex 2 ITDMA.  Table 20

void set_message_id(int val) { ais1_2_3->message_id = val; }
void set_repeat_indicator(int val) { ais1_2_3->repeat_indicator; }
void set_mmsi(int val) { ais1_2_3->mmsi = val; }
void set_nav_status(int val){ ais1_2_3->nav_status = val; }
//void set_rot_over_range(bool val){ ais1_2_3->rot_over_range = val; }
void set_rot_raw(float rot)
{
	//rot = pow((rot_raw / 4.733), 2);
	//if (rot_raw < 0) rot = -rot;
	int val = sqrt(abs(rot)) * 4.733;
	if (rot < 0) val = -val;
	
	ais1_2_3->rot_raw = val;
}
//void set_rot(float val){ ais1_2_3->rot = val; }
void set_sog(float val){ ais1_2_3->sog = val; }  // Knots.
void set_position_accuracy(int val){ ais1_2_3->position_accuracy = val; }
void set_pos_lat(double val){ ais1_2_3->position.lat_deg = val; }
void set_pos_long(double val){ ais1_2_3->position.lng_deg = val; }
void set_cog(float val){ ais1_2_3->cog = val; }  // Degrees.
void set_true_heading(int val){ ais1_2_3->true_heading = val; }
void set_timestamp(int val){ ais1_2_3->timestamp = val; }
void set_special_manoeuvre(int val){ ais1_2_3->special_manoeuvre = val; }
void set_spare(int val){ ais1_2_3->spare = val; }
void set_raim(bool val){ ais1_2_3->raim = val; }
void set_sync_state(int val){ ais1_2_3->sync_state = val; }  // SOTDMA and ITDMA
void set_slot_timeout_valid(bool val){ ais1_2_3->slot_timeout_valid = val; }
void set_slot_timeout(int val){ ais1_2_3->slot_timeout = val; }
void set_received_stations_valid(bool val){ ais1_2_3->received_stations_valid = val; }
void set_received_stations(int val){ ais1_2_3->received_stations = val; }
void set_slot_number_valid(bool val){ ais1_2_3->slot_number_valid = val; }
void set_slot_number(int val){ ais1_2_3->slot_number = val; }
void set_utc_valid(bool val){ ais1_2_3->utc_valid = val; }
void set_utc_hour(int val){ ais1_2_3->utc_hour = val; }
void set_utc_min(int val){ ais1_2_3->utc_min = val; }
void set_utc_spare(int val){ ais1_2_3->utc_spare = val; }
void set_slot_offset_valid(bool val){ ais1_2_3->slot_offset_valid = val; }
void set_slot_offset(int val){ ais1_2_3->slot_offset = val; }
void set_slot_increment_valid(bool val){ ais1_2_3->slot_increment_valid = val; }
void set_slot_increment(int val){ ais1_2_3->slot_increment = val; }
void set_slots_to_allocate_valid(bool val){ ais1_2_3->slots_to_allocate_valid = val; }
void set_slots_to_allocate(int val){ ais1_2_3->slots_to_allocate = val; }
void set_keep_flag_valid(bool val){ ais1_2_3->keep_flag_valid = val; }
void set_keep_flag(bool val){ ais1_2_3->keep_flag = val; }  // 3.3.7.3.2 Annex 2 ITDMA.  Table 20

char* get_ais_msg()
{
	std::bitset<6> message_id(ais1_2_3->message_id);
	std::bitset<2> repeat_indicator(ais1_2_3->repeat_indicator);
	std::bitset<30> mmsi(ais1_2_3->mmsi);
	std::bitset<4> NavStatus(ais1_2_3->nav_status);
	std::bitset<8> rot(ais1_2_3->rot_raw);
	std::bitset<10> sog(ais1_2_3->sog *10);

	std::bitset<1> pos_accuracy(ais1_2_3->position_accuracy);
	std::bitset<28> longitude((long)(ais1_2_3->position.lng_deg * 600000.));
	std::bitset<27> latitude((long)(ais1_2_3->position.lat_deg * 600000.));

	std::bitset<12> cog(ais1_2_3->cog*10);

	std::bitset<9> th(ais1_2_3->true_heading);
	std::bitset<6> timestamp(ais1_2_3->timestamp);
	std::bitset<2> maneuverIndicator(ais1_2_3->special_manoeuvre);
	std::bitset<3> spare(ais1_2_3->spare);
	std::bitset<1> raim(ais1_2_3->raim);
	std::bitset<2> sync_state(ais1_2_3->sync_state);
	std::bitset<3> slot_timeout(ais1_2_3->slot_timeout);
	std::bitset<14> received_stations(ais1_2_3->received_stations);
	
	std::stringstream sstream;
	sstream << message_id.to_string() << repeat_indicator.to_string() << mmsi.to_string()
			<<NavStatus.to_string() << rot.to_string() << sog.to_string() << pos_accuracy.to_string()
			<<longitude.to_string() << latitude.to_string() << cog.to_string() << th.to_string() <<
			timestamp.to_string() << maneuverIndicator.to_string() << spare.to_string() << raim.to_string()
			<< sync_state.to_string() <<slot_timeout.to_string() << received_stations.to_string();

	int size = sstream.str().length();
	char* result = (char*)LocalAlloc(LPTR, size/6+1);

	int index = 0;
	
	char ais_char_map[] = "0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVW`abcdefghijklmnopqrstuvw";

	for(int i = 0; i < size; i += 6, index++)
	{
		string temp = sstream.str().substr(i, 6);
		long val = std::bitset<6>(temp).to_ulong();
		result[index] = ais_char_map[(val)];
	}
	
	result[size/6 +1] = '\0';

	return result;
}

//
//int main()
//{
//	//create_ais_msg("133qF`0000oSviTBvBp`SPK00<1;", 0);
//	create_empty_ais_msg();
//
//	set_message_id(1);
//	set_repeat_indicator(0);
//	set_mmsi(205412000);
//	set_nav_status(0);
//	set_rot_raw(0);
//	set_sog(0);
//	set_position_accuracy(1);
//	set_pos_long(-117.96898333333333);
//	set_pos_lat(33.15835);
//	set_cog(219);
//	set_true_heading(13);
//	set_timestamp(32);
//	set_special_manoeuvre(0);
//	set_spare(0);
//	set_raim(0);
//	set_sync_state(0);
//	set_slot_timeout(3);
//	set_received_stations(75);
//
//	get_ais_msg();
//	//std::cout << get_ais_msg() << std::endl;
//	return 0;
//}
