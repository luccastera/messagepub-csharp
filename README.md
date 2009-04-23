# messagepub-csharp

## Description

messagepub-csharp is a C# client library for the messagepub API. Visit [messagepub.com](http://messagepub.com) for more information.

## Features

* Create a new notification with one or more recipients.
* Find a notification from an ID
* Get a list of the last notifications that you've sent via messagepub

## Example

    class MessagePubTester
    {
      public static void Main(string[] args)
      {
        // Create a Notification with two recipients.
        Notification note = new Notification();
        note.Body = "This is the body of the message...";
        note.Escalaction = 10; // Messages will be escalated to the next recipient in the list every 10 minutes.
        note.Subject = "This is the subject of the message (only for emails)";
        
        note.addRecipient(new Recipient(1, "email", "joe@example.com"));
        note.addRecipient(new Recipient(2, "twitter", "sharememeinc"));
        
        Client client = new Client("your api key");
        int httpStatus = client.createNotification(note);
        
        // Get a list of the latest 50 notifications you've sent via messagepub
        List<Notification> allNotes = client.getNotifications();
        
        // Get the notification with ID = 1
        Notification myNotification = client.getNotification(1);
      }
    }    


## LICENSE

(The MIT License)

Copyright (c) 2009 Luc Castera

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
'Software'), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

