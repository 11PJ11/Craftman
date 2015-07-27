using System;

namespace Craftman
{
    public class Message
    {
        protected bool Equals(Message other)
        {
            return string.Equals(UserName, other.UserName) && 
                   string.Equals(Text, other.Text) && 
                   TimeStamp.Equals(other.TimeStamp);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Message) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = UserName.GetHashCode();
                hashCode = (hashCode*397) ^ Text.GetHashCode();
                hashCode = (hashCode*397) ^ TimeStamp.GetHashCode();
                return hashCode;
            }
        }

        public readonly string UserName;
        public readonly string Text;
        public readonly DateTime TimeStamp;

        public Message(
            string userName, 
            string text, 
            DateTime timeStamp)
        {
            UserName = userName;
            Text = text;
            TimeStamp = timeStamp;
        }

        public override string ToString()
        {
            var elapsed = GetElapsedTime(DateTime.Now - TimeStamp);
            return $"{Text} ({elapsed} ago)";
        }

        internal static string GetElapsedTime(TimeSpan messageAge)
        {
            if(messageAge.TotalSeconds < 2)
                return $"1 second";
            if (messageAge.TotalSeconds < 60)
                return $"{Math.Floor(messageAge.TotalSeconds)} seconds";
            if (messageAge.TotalSeconds < 120)
                return $"{Math.Floor(messageAge.TotalMinutes)} minute";
            if (messageAge.TotalSeconds < 3600)
                return $"{Math.Floor(messageAge.TotalMinutes)} minutes";
            if (messageAge.TotalSeconds < 7200)
                return $"{Math.Floor(messageAge.TotalHours)} hour";
            if (messageAge.TotalSeconds < 86400)
                return $"{Math.Floor(messageAge.TotalHours)} hours";
            if (messageAge.TotalSeconds < 172800)
                return $"{Math.Floor(messageAge.TotalDays)} day";
            return $"{Math.Floor(messageAge.TotalDays)} days";
        }
    }
}