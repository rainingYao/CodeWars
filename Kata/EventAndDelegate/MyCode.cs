namespace EventAndDelegate.MyCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PersonEventArgs : EventArgs
    {
        // implement cusotm event handler wiht Name property (string)
        public string Name { get; set; }
    }

    public class Publisher
    {
        public event /*delegate*/Send ContactNotify;

        public delegate void Send(object source, PersonEventArgs e);

        public Dictionary<string, int> dict = new Dictionary<string, int>();

        public void CountMessages(List<string> peopleList)
        {
            foreach (string person in peopleList)
            {
                // implement your logic to send name of people after apearing 3*n times
                OnContactNotify(person); // Notify subscribers
            }
        }

        public void OnContactNotify(string person)
        {
            if (ContactNotify != null)
            {
                if (!dict.ContainsKey(person)) dict.Add(person, 1);
                else dict[person]++;
                if (dict[person] >= 3)
                {
                    ContactNotify(this, new PersonEventArgs() { Name = person });
                    dict[person] = 0;
                }
            }
        }
    }

    public class NotPublisher
    {
        public void CountMessages(List<string> peopleList)
        {
            foreach (string person in peopleList)
            {
                /*if (some logic to count the person for 3, 6, 9, 12 ... times)
                {
                  SendTextMessage(person);
                  SendEmail(Person)
                }*/
            }
        }
    }

    //send text message
    public class TextMessageSend
    {
        public static string TextMessageList;

        public static void Send(object source, PersonEventArgs e)
        {
            if (TextMessageList != "") TextMessageList += ", ";
            TextMessageList += e.Name;
        }
    }
}
