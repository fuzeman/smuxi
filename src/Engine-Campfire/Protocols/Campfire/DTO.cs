// Smuxi - Smart MUltipleXed Irc
//
// Copyright (c) 2012 Carlos Martín Nieto <cmn@dwim.me>
//
// Full GPL License: <http://www.gnu.org/licenses/gpl.txt>
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA
using System;

namespace Smuxi.Engine.Campfire
{
    public class UserResponse { public User User { get; set; } }
    public class RoomsResponse { public Room[] Rooms { get; set; } }
    public class RoomResponse { public Room Room { get; set; } }
    public class MessagesResponse { public Message[] Messages { get; set; } }
    public class MessageResponse { public Message Message { get; set; } }
    public class MessageWrapper { public MessageSending message { get; set; } }

    public enum MessageType {
        EnterMessage,
        KickMessage,
        TimestampMessage,
        TextMessage,
        PasteMessage,
        SoundMessage,
    }

    public class Room {
        public string Topic { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public bool Locked { get; set; }
        public int MembershipLimit { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User[] Users { get; set; }
    }

    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email_Address { get; set; }
        public bool Admin { get; set; }
        public DateTimeOffset Created_At { get; set; }
        public string Type { get; set; }
        public string Avatar_Url { get; set; }
        public string Api_Auth_Token { get; set; }
    }

    public class MessageSending {
        public MessageType type { get; set; }
        public string body { get; set; }
    }

    public class Message {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Room_Id { get; set; }
        public int User_Id { get; set; }
        public DateTimeOffset Created_At { get; set; }
        public MessageType Type { get; set; }
        public bool Starred { get; set; }
    }
}
