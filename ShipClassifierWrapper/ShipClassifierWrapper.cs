using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShipClassifierWrapper
{
    public class RouteClassifier
    {
        [DllImport("libShipClassifier.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void createInstrance([MarshalAs(UnmanagedType.LPStr)] string path);
        [DllImport("libShipClassifier.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void releaseInstance();

        [DllImport("libShipClassifier.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void setExistingWaypoint(int _id, int x, int y);
        [DllImport("libShipClassifier.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern void setNextWaypoint(int _id, int x, int y);

        [DllImport("libShipClassifier.dll", CallingConvention = CallingConvention.Cdecl)]
        protected static extern System.IntPtr getNextPoint(int _id);

        public RouteClassifier(string path)
        {
            createInstrance(path);
        }

        ~RouteClassifier()
        {
            releaseInstance();
        }

        public void SetWaypoints(int _id, int x, int y)
        {
            setExistingWaypoint(_id, x, y);
        }

        public void SetNextWaypoint(int _id, int x, int y)
        {
            setNextWaypoint( _id, x, y);
        }

        public string GetNextPoint(int _id)
        {
            IntPtr p = getNextPoint(_id);
            string coordinate = Marshal.PtrToStringAnsi(p);
            Marshal.FreeHGlobal(p);

            return coordinate;
        }
    }
}
