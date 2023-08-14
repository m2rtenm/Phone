using System;
using System.Linq;
using PhoneApp.Models;

namespace PhoneApp.Data
{
    public static class DbInitializer
    {

        public static void Initialize(PhoneContext context)
        {
            context.Database.EnsureDeleted();
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
                    EventID = 1, EventTypeID = "Event_pick_up", RecordDate = DateTime.Now.AddSeconds(-180),
                    CallID = 5
                },
                new Event
                {
                    EventID = 2, EventTypeID = "Event_hang_up", RecordDate = DateTime.Now.AddSeconds(-175),
                    CallID = 5
                },
                new Event
                {
                    EventID = 3, EventTypeID = "Event_pick_up", RecordDate = DateTime.Now.AddSeconds(-170),
                    CallID = 1
                },
                new Event
                {
                    EventID = 4, EventTypeID = "Event_dial", RecordDate = DateTime.Now.AddSeconds(-170),
                    CallID = 1
                },
                new Event
                {
                    EventID = 5, EventTypeID = "Event_call_end", RecordDate = DateTime.Now.AddSeconds(-170),
                    CallID = 1
                },
                new Event
                {
                    EventID = 6, EventTypeID = "Event_hang_up", RecordDate = DateTime.Now.AddSeconds(-170),
                    CallID = 1
                },
                new Event
                {
                    EventID = 7, EventTypeID = "Event_pick_up", RecordDate = DateTime.Now.AddSeconds(-170),
                    CallID = 2
                },
                new Event
                {
                    EventID = 8, EventTypeID = "Event_dial", RecordDate = DateTime.Now.AddSeconds(-170), 
                    CallID = 2
                },
                new Event
                {
                    EventID = 9, EventTypeID = "Event_call_established", RecordDate = DateTime.Now.AddSeconds(-170), 
                    CallID = 2
                },
                new Event
                {
                    EventID = 10, EventTypeID = "Event_call_end", RecordDate = DateTime.Now.AddSeconds(-170),
                    CallID = 2
                },
                new Event
                {
                    EventID = 11, EventTypeID = "Event_hang_up", RecordDate = DateTime.Now.AddSeconds(-170),
                    CallID = 2
                },
                new Event { EventID = 12, EventTypeID = "Event_pick_up", RecordDate = DateTime.Now.AddSeconds(-90), 
                    CallID = 3},
                new Event {EventID =  13, EventTypeID = "Event_dial", RecordDate = DateTime.Now.AddSeconds(-5),
                    CallID = 3}

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
