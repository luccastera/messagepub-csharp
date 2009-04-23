// Main.cs created with MonoDevelop
// by Luc Castera at 2:59 PM 4/22/2009

using System;
using MessagePub;
using System.Collections.Generic;

namespace MessagePubTester
{
	class MessagePubTester
	{
		public static void Main(string[] args)
		{
      // Test Recipient Class
			Recipient rcpt1 = new Recipient(1,"twitter", "luccastera");
			Console.WriteLine("Created recipient with position = {0}, channel = {1}, and address = {2}", rcpt1.Position, rcpt1.Channel, rcpt1.Address);
      
      Recipient rcpt2 = new Recipient(2, "email", "luc.castera@gmail.com");
      Console.WriteLine("Created recipient with position = {0}, channel = {1}, and address = {2}\n", rcpt2.Position, rcpt2.Channel, rcpt2.Address);
      
      // Test Notification Class
      Notification note = new Notification();
      Console.WriteLine("Created a notification. Default escalation = {0}", note.Escalation);
      
      note.Body = "This is the body of my message...";
      note.Subject = "This is the subject of my message...";
      note.Escalation = 0;
      
      Console.WriteLine("Subject:{1}\nBody: {0}\n",note.Subject, note.Body);
      
      note.addRecipient(rcpt1);
      note.addRecipient(rcpt2);
      
      Console.WriteLine("Added {0} recipients to note.", note.getNumberOfRecipients());
      
      Console.WriteLine("XML:");
      Console.WriteLine(note.getXML());
      
      // Test Client.create
      Client client = new Client("your api key");      
      //string status = client.createNotification(note);
      //Console.WriteLine("Created a notification. HTTP Status Response: {0}", status);
      
      // Test Client.getNotification
      Console.WriteLine("\nGetting Notification...\n");
      Notification note2 = client.getNotification(1);
      Console.WriteLine("Notification with body={0}, subject={1}, escalation = {2}, and {3} recipients", note2.Body, note2.Subject, note2.Escalation, note2.getNumberOfRecipients());
      for (int j = 0; j < note2.getNumberOfRecipients(); j++) {
        Recipient r = note2.Recipients[j];
        Console.WriteLine(" * Position: {0}, Channel: {1}, Address: {2}", r.Position, r.Channel, r.Address);
      }
      
      //Test Client.getNotifications
      Console.WriteLine("\nGetting all notifications...\n");
      List<Notification> allNotes = client.getNotifications();
      Console.WriteLine("Found {0} notifications", allNotes.Count);
      for (int i = 0; i < allNotes.Count; i++) {
        Console.WriteLine("Note with {0} recipients: {1}", allNotes[i].getNumberOfRecipients(), allNotes[i].Body);
      }
		}
	}
}