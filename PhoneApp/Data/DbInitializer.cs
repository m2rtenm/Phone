using System;
using System.Linq;
using PhoneApp.Models;

namespace PhoneApp.Data
{
    public static class DbInitializer
    {

        public static void Initialize(PhoneContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Events.Any())
            {
                return;
            }

            var eventtypes = new[]
            {
                new EventType {EventTypeID = "Event_pick_up", EventName = "Pick-up"},
                new EventType {EventTypeID = "Event_dial", EventName = "Dialling"},
                new EventType {EventTypeID = "Event_call_established", EventName = "Call Established"},
                new EventType {EventTypeID = "Event_call_end", EventName = "Call End"},
                new EventType {EventTypeID = "Event_hang_up", EventName = "Hang Up"}
            };

            context.EventTypes.AddRange(eventtypes);
            context.SaveChanges();


            /*var calls = new Call[]
            {
                new Call {CallID = 1, Caller = "345214", Receiver = "324644"},
                new Call {CallID = 2, Caller = "325875", Receiver = "354875"},
                new Call {CallID = 3, Caller = "396200", Receiver = "369875"},
                new Call {CallID = 4, Caller = "385100", Receiver = "521000"},
                new Call {CallID = 5, Caller = "369874", Receiver = null},
                new Call {CallID = 6, Caller = "321587", Receiver = "520023"},
                new Call {CallID = 7, Caller = "369852", Receiver = "535353"},
                new Call {CallID = 8, Caller = "325698", Receiver = "533357"},
                new Call {CallID = 9, Caller = "345855", Receiver = "590140"},
                new Call {CallID = 10, Caller = "333222", Receiver = "502344"},
                new Call {CallID = 11, Caller = "321123", Receiver = "533656"},
                new Call {CallID = 12, Caller = "321321", Receiver = "879879"},
                new Call {CallID = 13, Caller = "555666", Receiver = "877789"},
                new Call {CallID = 14, Caller = "552114", Receiver = "812000"},
                new Call {CallID = 15, Caller = "553698", Receiver = "800211"},
                new Call {CallID = 16, Caller = "558996", Receiver = "300600"},
                new Call {CallID = 17, Caller = "558123", Receiver = "366100"},
                new Call {CallID = 18, Caller = "523145", Receiver = "399711"},
                new Call {CallID = 19, Caller = "887998", Receiver = "855200"},
                new Call {CallID = 20, Caller = "881250", Receiver = "500299"},
            };*/

            var calls = new[]
            {
                new Call {CallID = 1, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 2, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 3, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 4, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 5, Caller = Generate().ToString(), Receiver = null},
                new Call {CallID = 6, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 7, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 8, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 9, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 10, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 11, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 12, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 13, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 14, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 15, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 16, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 17, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 18, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 19, Caller = Generate().ToString(), Receiver = Generate().ToString()},
                new Call {CallID = 20, Caller = Generate().ToString(), Receiver = Generate().ToString()},
            };
            

            context.Calls.AddRange(calls);
            context.SaveChanges();

            var events = new[]
            {
                new Event
                {
                    EventID = 1, EventTypeID = "Event_pick_up", RecordDate = new DateTime(2020, 2, 2, 13, 0, 1),
                    CallID = 5
                },
                new Event
                {
                    EventID = 2, EventTypeID = "Event_hang_up", RecordDate = new DateTime(2020, 2, 2, 13, 0, 5),
                    CallID = 5
                },
                new Event
                {
                    EventID = 3, EventTypeID = "Event_pick_up", RecordDate = new DateTime(2020, 2, 3, 8, 12, 13),
                    CallID = 1
                },
                new Event
                {
                    EventID = 4, EventTypeID = "Event_dial", RecordDate = new DateTime(2020, 2, 3, 8, 12, 30),
                    CallID = 1
                },
                new Event
                {
                    EventID = 5, EventTypeID = "Event_call_end", RecordDate = new DateTime(2020, 2, 3, 8, 12, 31),
                    CallID = 1
                },
                new Event
                {
                    EventID = 6, EventTypeID = "Event_hang_up", RecordDate = new DateTime(2020, 2, 3, 8, 12, 35),
                    CallID = 1
                },
                new Event
                {
                    EventID = 7, EventTypeID = "Event_pick_up", RecordDate = new DateTime(2020, 2, 4, 1, 0, 1),
                    CallID = 2
                },
                new Event
                {
                    EventID = 8, EventTypeID = "Event_dial", RecordDate = new DateTime(2020, 2, 4, 1, 0, 10), CallID = 2
                },
                new Event
                {
                    EventID = 9, EventTypeID = "Event_call_established",
                    RecordDate = new DateTime(2020, 2, 4, 1, 0, 20), CallID = 2
                },
                new Event
                {
                    EventID = 10, EventTypeID = "Event_call_end", RecordDate = new DateTime(2020, 2, 4, 1, 1, 10),
                    CallID = 2
                },
                new Event
                {
                    EventID = 11, EventTypeID = "Event_hang_up", RecordDate = new DateTime(2020, 2, 4, 1, 1, 15),
                    CallID = 2
                },
            };

            context.Events.AddRange(events);
            context.SaveChanges();
        }

        public static int Generate()
        {
            int r = 0;
            Random random = new Random();
            switch (random.Next(1,4))
            {
                case 1:
                    r = random.Next(300000, 400000);
                    break;
                case 2:
                    r = random.Next(500000, 600000);
                    break;
                case 3:
                    r = random.Next(800000, 900000);
                    break;
            }
            return r;
        }
    }
}
