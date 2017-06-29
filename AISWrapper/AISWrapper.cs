using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Runtime.InteropServices;

namespace AISWrapper
{
    public class AIS_MSG_1
    {
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern System.IntPtr get_ais_msg();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void create_empty_ais_msg();
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void destroy_ais_msg();

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

        public AIS_MSG_1()
        {
            create_empty_ais_msg();
        }

        ~AIS_MSG_1()
        {
            destroy_ais_msg();
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


        public void message_id(int val)
        {
            set_message_id(val);
        }

        public void repeat_indicator(int val)
        {
            set_repeat_indicator(val);
        }

        public void mmsi(int val) { set_mmsi(val); }

        public void nav_status(int val) { set_nav_status(val); }

        public void rot_raw(float val) { set_rot_raw(val); }

        public void sog(float val) { set_sog(val); }

        public void position_accuracy(int val) { set_position_accuracy(val); }

        public void pos_long(double val) { set_pos_long(val); }

        public void pos_lat(double val) { set_pos_lat(val); }

        public void cog(int val) { set_cog(val); }

        public void true_heading(int val) { set_true_heading(val); }

        public void timestamp(int val) { set_timestamp(val); }

        public void special_manoeuvre(int val) { set_special_manoeuvre(val); }

        public void spare(int val) { set_spare(val); }

        public void raim(int val) { set_raim(val); }

        public void sync_state(int val) { set_sync_state(val); }

        public void slot_timeout(int val) { set_slot_timeout(val); }

        public void received_stations(int val) { set_received_stations(val); }
    }
}
