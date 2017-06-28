using System;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;

namespace AIVDMTest
{
    class AIS_MSG1
    {
        private BitArray MessageType;
        private BitArray RepeatIndicator;
        private BitArray MMSI;
        private BitArray NavStatus;
        private BitArray RateOfTurn;
        private BitArray SpeedOverGround;
        private BitArray PositionAccuracy;
        private BitArray Longitude;
        private BitArray Latitude;
        private BitArray CourseOverGround;
        private BitArray TrueHeading;
        private BitArray TimeStamp;
        private BitArray ManeuverIndicator;
        private BitArray Spare;
        private BitArray RAIMFlag;
        private BitArray RadioStatus;

        private int _iMessageType;
        private int _iRepeatIndicator;
        private int _iMMSI;
        private int _iNavStatus;
        private int _iRateOfTurn;
        private int _iSpeedOverGround;
        private int _iPositionAccuracy;
        private int _iLongitude;
        private int _iLatitude;
        private int _iCourseOverGround;
        private int _iTrueHeading;
        private int _iTimeStamp;
        private int _iManeuverIndicator;
        private int _iSpare;
        private int _iRAIMFlag;
        private int _iRadioStatus;

        private void BitAllocation()
        {
            MessageType      = new BitArray(6);
            RepeatIndicator  = new BitArray(2);
            MMSI             = new BitArray(30);
            NavStatus        = new BitArray(4);
            RateOfTurn       = new BitArray(8);
            SpeedOverGround  = new BitArray(10);
            PositionAccuracy = new BitArray(1);
            Longitude        = new BitArray(28);
            Latitude         = new BitArray(27);
            CourseOverGround = new BitArray(12);
            TrueHeading      = new BitArray(9);
            TimeStamp        = new BitArray(6);
            ManeuverIndicator = new BitArray(2);
            Spare            = new BitArray(3);
            RAIMFlag         = new BitArray(1);
            RadioStatus      = new BitArray(19);
        }

        public AIS_MSG1()
        {
            BitAllocation();
        }

        private int getIntFromBitArray(BitArray bitArray)
        {
            int value = 0;

            int exp = 0;
            for (int i = (bitArray.Length-1); i >= 0; i--, exp++)
            {
                if (bitArray[i])
                    value += Convert.ToInt32(Math.Pow(2, exp));
            }

            return value;
        }

        private float getFloatFromBitArray(BitArray bitArray)
        {

            if (bitArray.Length > 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            float[] array = new float[1];
            ((ICollection)bitArray).CopyTo(array, 0);
            return array[0];

        }

        void FillPayload(string payload)
        {
            BitArray bitarray = new BitArray(168);
            int index = 0;
            foreach (char c in payload)
            {
                string s = Convert.ToString(c - '0', 2);
                s = s.PadLeft(6, '0');
                for(int i = 0; i < 6; i++)
                    bitarray[index++] = (s[i]-'0') == 1? true: false;
            }

            index = 0;
            for (int i = 0; i < MessageType.Length; i++, index++)
                MessageType[i] = bitarray[index];
            _iMessageType = getIntFromBitArray(MessageType);

            for(int i = 0; i < RepeatIndicator.Length  ; i++, index++)
                RepeatIndicator[i] = bitarray[index];
            _iRepeatIndicator = getIntFromBitArray(RepeatIndicator);

            for (int i = 0; i < MMSI.Length; i++, index++)
                MMSI[i] = bitarray[index];
            _iMMSI = getIntFromBitArray(MMSI);

            for (int i = 0; i < NavStatus.Length; i++, index++)
                NavStatus[i] = bitarray[index];
            for (int i = 0; i < RateOfTurn.Length; i++, index++)
                RateOfTurn[i] = bitarray[index];
            for (int i = 0; i < SpeedOverGround.Length; i++, index++)
                SpeedOverGround[i] = bitarray[index];
            for (int i = 0; i < PositionAccuracy.Length; i++, index++)
                PositionAccuracy[i] = bitarray[index];
            for (int i = 0; i < Longitude.Length; i++, index++)
                Longitude[i] = bitarray[index];
            for (int i = 0; i < Latitude.Length; i++, index++)
                Latitude[i] = bitarray[index];
            for (int i = 0; i < CourseOverGround.Length; i++, index++)
                CourseOverGround[i] = bitarray[index];
            for (int i = 0; i < TrueHeading.Length; i++, index++)
                TrueHeading[i] = bitarray[index];
            for (int i = 0; i < TimeStamp.Length; i++, index++)
                TimeStamp[i] = bitarray[index];
            for (int i = 0; i < ManeuverIndicator.Length; i++, index++)
                ManeuverIndicator[i] = bitarray[index];
            for (int i = 0; i < Spare.Length; i++, index++)
                Spare[i] = bitarray[index];
            for (int i = 0; i < RAIMFlag.Length; i++, index++)
                RAIMFlag[i] = bitarray[index];
            for (int i = 0; i < RadioStatus.Length; i++, index++)
                RadioStatus[i] = bitarray[index];
        }

        public AIS_MSG1(string vdmMsg)
        {
            BitAllocation();
            char[] delimiter = { ',' };
            string[] tokens = vdmMsg.Split(delimiter, StringSplitOptions.None);
            FillPayload(tokens[5]);
        }

    }
    class Program
    {
        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern System.IntPtr get_ais_msg();

        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void create_empty_ais_msg();

        [DllImport("libAIVDM.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void destroy_ais_msg();

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

        static void Main(string[] args)
        {
            create_empty_ais_msg();
            set_message_id(1);
            set_repeat_indicator(0);
            set_mmsi(205412000);
            set_nav_status(0);
            set_rot_raw(0);
            set_sog(0);
            set_position_accuracy(1);
            set_pos_long(-117.96898333333333);
            set_pos_lat(33.15835);
            set_cog(219);
            set_true_heading(13);
            set_timestamp(32);
            set_special_manoeuvre(0);
            set_spare(0);
            set_raim(0);
            set_sync_state(0);
            set_slot_timeout(3);
            set_received_stations(75);

            IntPtr p = get_ais_msg();
            string c = Marshal.PtrToStringAnsi(p);
            Console.WriteLine(c);
            Marshal.FreeHGlobal(p);

            destroy_ais_msg();
        }
    }
}