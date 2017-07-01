using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Runtime.InteropServices;

namespace AISWrapper
{
    [Serializable]
    public class AIS_MSG_1
    {
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern System.IntPtr get_ais_msg();

        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void create_ais_msg(string payload, int pad);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void create_empty_ais_msg();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void destroy_ais_msg();

        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_message_id();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_repeat_indicator();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_mmsi();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_nav_status();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float get_rot_raw();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern float get_sog();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_position_accuracy();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double get_pos_long();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double get_pos_lat();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_cog();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_true_heading();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_timestamp();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_special_manoeuvre();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_spare();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_raim();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_sync_state();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_slot_timeout();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int get_received_stations();

        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_message_id(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_repeat_indicator(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_mmsi(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_nav_status(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_rot_raw(float val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_sog(float val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_position_accuracy(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_pos_long(double val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_pos_lat(double val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_cog(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_true_heading(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_timestamp(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_special_manoeuvre(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_spare(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_raim(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_sync_state(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_slot_timeout(int val);
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set_received_stations(int val);

        private static object creation_lock = new object();

        public AIS_MSG_1()
        {
            lock (creation_lock)
            {
                create_empty_ais_msg();
            }
        }

        public AIS_MSG_1(string msg)
        {
            char[] delimiter = { ',' };
            string[] tokens = msg.Split(delimiter, StringSplitOptions.None);
            create_ais_msg(tokens[5], 0);
        }

        ~AIS_MSG_1()
        {
            lock (creation_lock)
            {
                destroy_ais_msg();
            }
        }

        public string get_encoded_msg()
        {
            IntPtr p = get_ais_msg();
            string payload = Marshal.PtrToStringAnsi(p);
            Marshal.FreeHGlobal(p);

            string header = "AIVDM,1,1,,B,";
            string tail = ",0";
            string ais_msg = header + payload + tail;

            char check = ais_msg[0];
            for (int i = 1; i < ais_msg.Length; i++)
            {
                check = (char)(check ^ ais_msg[i]);
            }
            string checksum = "*" + ((int)check).ToString("X2");
            return "!" + ais_msg + checksum;
        }


        public int message_id( )
        {
            return get_message_id();
        }

        public int repeat_indicator( )
        {
            return get_repeat_indicator();
        }

        public int mmsi( ) { return get_mmsi(); }

        public int nav_status( ) { return get_nav_status(); }

        public float rot_raw( ) { return get_rot_raw(); }

        public float sog( ) { return get_sog(); }

        public int position_accuracy( ) { return get_position_accuracy(); }

        public double pos_long( ) { return get_pos_long(); }

        public double pos_lat( ) { return get_pos_lat(); }

        public int cog( ) { return get_cog(); }

        public int true_heading( ) { return get_true_heading(); }

        public int timestamp( ) { return get_timestamp(); }

        public int special_manoeuvre( ) { return get_special_manoeuvre(); }

        public int spare( ) { return get_spare(); }

        public int raim( ) { return get_raim(); }

        public int sync_state( ) { return get_sync_state(); }

        public int slot_timeout( ) { return get_slot_timeout(); }

        public int received_stations( ) { return get_received_stations(); }



        public void message_id(int val)
        {
            lock (creation_lock)
                set_message_id(val);
        }

        public void repeat_indicator(int val)
        {
            lock (creation_lock)
                set_repeat_indicator(val);
        }

        public void mmsi(int val) { lock (creation_lock) set_mmsi(val); }

        public void nav_status(int val) { lock (creation_lock) set_nav_status(val); }

        public void rot_raw(float val) { lock (creation_lock) set_rot_raw(val); }

        public void sog(float val) { lock (creation_lock) set_sog(val); }

        public void position_accuracy(int val) { lock (creation_lock) set_position_accuracy(val); }

        public void pos_long(double val) { lock (creation_lock) set_pos_long(val); }

        public void pos_lat(double val) { lock (creation_lock) set_pos_lat(val); }

        public void cog(int val) { lock (creation_lock) set_cog(val); }

        public void true_heading(int val) { lock (creation_lock) set_true_heading(val); }

        public void timestamp(int val) { lock (creation_lock) set_timestamp(val); }

        public void special_manoeuvre(int val) { lock (creation_lock) set_special_manoeuvre(val); }

        public void spare(int val) { lock (creation_lock) set_spare(val); }

        public void raim(int val) { lock (creation_lock) set_raim(val); }

        public void sync_state(int val) { lock (creation_lock) set_sync_state(val); }

        public void slot_timeout(int val) { lock (creation_lock) set_slot_timeout(val); }

        public void received_stations(int val) { lock (creation_lock) set_received_stations(val); }
    }
}
