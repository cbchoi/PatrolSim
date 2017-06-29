using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatrolSim
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

        private void BitAllocation()
        {
            MessageType = new BitArray(6);
            RepeatIndicator = new BitArray(2);
            MMSI = new BitArray(30);
            NavStatus = new BitArray(4);
            RateOfTurn = new BitArray(8);
            SpeedOverGround = new BitArray(10);
            PositionAccuracy = new BitArray(1);
            Longitude = new BitArray(28);
            Latitude = new BitArray(27);
            CourseOverGround = new BitArray(12);
            TrueHeading = new BitArray(9);
            TimeStamp = new BitArray(6);
            ManeuverIndicator = new BitArray(2);
            Spare = new BitArray(3);
            RAIMFlag = new BitArray(1);
            RadioStatus = new BitArray(19);
        }

        public AIS_MSG1()
        {
            BitAllocation();
        }

        void FillPayload(string payload)
        {
            BitArray bitarray = new BitArray(168);
            string s = Convert.ToString(payload[0] - 48, 2);
        }

        public AIS_MSG1(string vdmMsg)
        {
            BitAllocation();
            char[] delimiter = {','};
            string[] tokens = vdmMsg.Split(delimiter, StringSplitOptions.None);
        }

    }

    class AIVDMHandler
    {
        public AIVDMHandler()
        {
            
        }
    }
}
