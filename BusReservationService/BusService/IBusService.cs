using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BusService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBusService
    {
        [OperationContract]
        void AddBus(string busName, string src, string dest, string time);

        [OperationContract]
        List<Bus> GetBuses();

        [OperationContract]
        List<Seat> GetSeats(int busId);

        [OperationContract]
        List<Seat> BookSeat(int seatId, string userToken);
    }

    [DataContract]
    public class Bus
    {
        int busId;
        string src;
        string dest;
        string time;
        string busName;

        public Bus(int busId, string busName, string src, string dest, string time)
        {
            this.busId = busId;
            this.busName = busName;
            this.src = src;
            this.dest = dest;
            this.time = time;
        }

        public Bus() { }

        [DataMember]
        public int BusId
        {
            get { return busId; }
            set { busId = value; }
        }

        [DataMember]
        public string BusName
        {
            get { return busName; }
            set { busName = value; }
        }

        [DataMember]
        public string Src
        {
            get { return src; }
            set { src = value; }
        }

        [DataMember]
        public string Dest
        {
            get { return dest; }
            set { dest = value; }
        }

        [DataMember]
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
    }

    [DataContract]
    public class Seat
    {
        int seatId;
        int busId;
        bool isAvailable;

        public Seat(int seatId, int busId, bool isAvailable)
        {
            this.seatId = seatId;
            this.busId = busId;
            this.isAvailable = isAvailable;
        }

        [DataMember]
        public int SeatId
        {
            get { return seatId; }
            set { seatId = value; }
        }
        
        [DataMember]
        public int BusId
        {
            get { return busId; }
            set { busId = value; }
        }

        [DataMember]
        public bool IsAvailable
        {
            get { return isAvailable; }
            set { isAvailable = value; }
        }
    }
}
