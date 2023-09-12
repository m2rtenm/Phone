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

            var dateinstance = new RandomDateTime();
            DateTime d1 = dateinstance.Next();
            DateTime d2 = dateinstance.Next();
            DateTime d3 = dateinstance.Next();
            DateTime d4 = dateinstance.Next();
            DateTime d5 = dateinstance.Next();
            DateTime d6 = dateinstance.Next();
            DateTime d7 = dateinstance.Next();
            DateTime d8 = dateinstance.Next();
            DateTime d9 = dateinstance.Next();
            DateTime d10 = dateinstance.Next();
            DateTime d11 = dateinstance.Next();
            DateTime d12 = dateinstance.Next();
            DateTime d13 = dateinstance.Next();
            DateTime d14 = dateinstance.Next();
            DateTime d15 = dateinstance.Next();
            DateTime d16 = dateinstance.Next();
            DateTime d17 = dateinstance.Next();
            DateTime d18 = dateinstance.Next();
            DateTime d19 = dateinstance.Next();
            DateTime d20 = dateinstance.Next();

            var events = new[]
            {
                new Event {EventTypeID = "Event_pick_up", RecordDate = d1, CallID = 5},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d1.AddSeconds(5), CallID = 5},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d2, CallID = 1},
                new Event {EventTypeID = "Event_dial", RecordDate = d2.AddSeconds(5), CallID = 1},
                new Event {EventTypeID = "Event_call_end", RecordDate = d2.AddSeconds(15), CallID = 1},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d2.AddSeconds(20), CallID = 1},
                
                new Event {EventTypeID = "Event_pick_up", RecordDate = d3, CallID = 2},
                new Event {EventTypeID = "Event_dial", RecordDate = d3.AddSeconds(3), CallID = 2},
                new Event {EventTypeID = "Event_call_established", RecordDate = d3.AddSeconds(13), CallID = 2},
                new Event {EventTypeID = "Event_call_end", RecordDate = d3.AddSeconds(75), CallID = 2},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d3.AddSeconds(78), CallID = 2},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d4, CallID = 3},
                new Event {EventTypeID = "Event_dial", RecordDate = d4.AddSeconds(5), CallID = 3},
                new Event {EventTypeID = "Event_call_end", RecordDate = d4.AddSeconds(12), CallID = 3},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d4.AddSeconds(15), CallID = 3},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d5, CallID = 4},
                new Event {EventTypeID = "Event_dial", RecordDate = d5.AddSeconds(3), CallID = 4},
                new Event {EventTypeID = "Event_call_end", RecordDate = d5.AddSeconds(15), CallID = 4},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d5.AddSeconds(17), CallID = 4},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d6, CallID = 6},
                new Event {EventTypeID = "Event_dial", RecordDate = d6.AddSeconds(2), CallID = 6},
                new Event {EventTypeID = "Event_call_established", RecordDate = d6.AddSeconds(22), CallID = 6},
                new Event {EventTypeID = "Event_call_end", RecordDate = d6.AddSeconds(57), CallID = 6},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d6.AddSeconds(61), CallID = 6},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d7, CallID = 7},
                new Event {EventTypeID = "Event_dial", RecordDate = d7.AddSeconds(3), CallID = 7},
                new Event {EventTypeID = "Event_call_established", RecordDate = d7.AddSeconds(25), CallID = 7},
                new Event {EventTypeID = "Event_call_end", RecordDate = d7.AddSeconds(87), CallID = 7},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d7.AddSeconds(90), CallID = 7},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d8, CallID = 8},
                new Event {EventTypeID = "Event_dial", RecordDate = d8.AddSeconds(4), CallID = 8},
                new Event {EventTypeID = "Event_call_established", RecordDate = d8.AddSeconds(35), CallID = 8},
                new Event {EventTypeID = "Event_call_end", RecordDate = d8.AddSeconds(59), CallID = 8},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d8.AddSeconds(65), CallID = 8},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d9, CallID = 10},
                new Event {EventTypeID = "Event_dial", RecordDate = d9.AddSeconds(3), CallID = 10},
                new Event {EventTypeID = "Event_call_established", RecordDate = d9.AddSeconds(40), CallID = 10},
                new Event {EventTypeID = "Event_call_end", RecordDate = d9.AddSeconds(128), CallID = 10},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d9.AddSeconds(131), CallID = 10},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d10, CallID = 9},
                new Event {EventTypeID = "Event_dial", RecordDate = d10.AddSeconds(7), CallID = 9},
                new Event {EventTypeID = "Event_call_established",RecordDate = d10.AddSeconds(35), CallID = 9},
                new Event {EventTypeID = "Event_call_end", RecordDate = d10.AddSeconds(187), CallID = 9},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d10.AddSeconds(193), CallID = 9},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d11, CallID = 18},
                new Event {EventTypeID = "Event_dial", RecordDate = d11.AddSeconds(4), CallID = 18},
                new Event {EventTypeID = "Event_call_established", RecordDate = d11.AddSeconds(16), CallID = 18},
                new Event {EventTypeID = "Event_call_end", RecordDate = d11.AddSeconds(259), CallID = 18},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d11.AddSeconds(265), CallID = 18},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d12, CallID = 19},
                new Event {EventTypeID = "Event_dial", RecordDate = d12.AddSeconds(9), CallID = 19},
                new Event {EventTypeID = "Event_call_established", RecordDate = d12.AddSeconds(43), CallID = 19},
                new Event {EventTypeID = "Event_call_end", RecordDate = d12.AddSeconds(94), CallID = 19},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d12.AddSeconds(100), CallID = 19},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d13, CallID = 20},
                new Event {EventTypeID = "Event_dial", RecordDate = d13.AddSeconds(6), CallID = 20},
                new Event {EventTypeID = "Event_call_established", RecordDate = d13.AddSeconds(45), CallID = 20},
                new Event {EventTypeID = "Event_call_end", RecordDate = d13.AddSeconds(432), CallID = 20},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d13.AddSeconds(439), CallID = 20},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d14, CallID = 11},
                new Event {EventTypeID = "Event_dial", RecordDate = d14.AddSeconds(8), CallID = 11},
                new Event {EventTypeID = "Event_call_established", RecordDate = d14.AddSeconds(25), CallID = 11},
                new Event {EventTypeID = "Event_call_end", RecordDate = d14.AddSeconds(56), CallID = 11},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d14.AddSeconds(61), CallID = 11},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d15, CallID = 12},
                new Event {EventTypeID = "Event_dial", RecordDate = d15.AddSeconds(12), CallID = 12},
                new Event {EventTypeID = "Event_call_established", RecordDate = d15.AddSeconds(58), CallID = 12},
                new Event {EventTypeID = "Event_call_end", RecordDate = d15.AddSeconds(368), CallID = 12},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d15.AddSeconds(375), CallID = 12},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d16, CallID = 13},
                new Event {EventTypeID = "Event_dial", RecordDate = d16.AddSeconds(5), CallID = 13},
                new Event {EventTypeID = "Event_call_established", RecordDate = d16.AddSeconds(29), CallID = 13},
                new Event {EventTypeID = "Event_call_end", RecordDate = d16.AddSeconds(257), CallID = 13},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d16.AddSeconds(264), CallID = 13},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d17, CallID = 14},
                new Event {EventTypeID = "Event_dial", RecordDate = d17.AddSeconds(9), CallID = 14},
                new Event {EventTypeID = "Event_call_established", RecordDate = d17.AddSeconds(45), CallID = 14},
                new Event {EventTypeID = "Event_call_end", RecordDate = d17.AddSeconds(227), CallID = 14},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d17.AddSeconds(231), CallID = 14},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d18, CallID = 15},
                new Event {EventTypeID = "Event_dial", RecordDate = d18.AddSeconds(7), CallID = 15},
                new Event {EventTypeID = "Event_call_established", RecordDate = d18.AddSeconds(34), CallID = 15},
                new Event {EventTypeID = "Event_call_end", RecordDate = d18.AddSeconds(125), CallID = 15},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d18.AddSeconds(127), CallID = 15},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d19, CallID = 16},
                new Event {EventTypeID = "Event_dial", RecordDate = d19.AddSeconds(4), CallID = 16},
                new Event {EventTypeID = "Event_call_established", RecordDate = d19.AddSeconds(20), CallID = 16},
                new Event {EventTypeID = "Event_call_end", RecordDate = d19.AddSeconds(153), CallID = 16},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d19.AddSeconds(159), CallID = 16},

                new Event {EventTypeID = "Event_pick_up", RecordDate = d20, CallID = 17},
                new Event {EventTypeID = "Event_dial", RecordDate = d20.AddSeconds(9), CallID = 17},
                new Event {EventTypeID = "Event_call_established", RecordDate = d20.AddSeconds(23), CallID = 17},
                new Event {EventTypeID = "Event_call_end", RecordDate = d20.AddSeconds(570), CallID = 17},
                new Event {EventTypeID = "Event_hang_up", RecordDate = d20.AddSeconds(575), CallID = 17},

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
