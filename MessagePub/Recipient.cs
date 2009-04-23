// Recipient.cs created with MonoDevelop
// by Luc Castera at 2:59 PM 4/22/2009


using System;

namespace MessagePub
{

  public class Recipient
  {
  
    // private member variables
    private int id;
    private int position;
    private string channel;
    private string address;
    private string status;
    private string sentAt;
    
    // Constructor
    public Recipient(int pos, string chan, string addr)
    {
      position = pos;
      channel = chan;
      address = addr;
    }
    
    public Recipient() {      
    }
    
    // Properties
    public int Id
    {
      get
      {
        return id;
      }
      
      set
      {
        id = value;
      }
    } 

    public int Position
    {
      get
      {
        return position;
      }
      
      set
      {
        position = value;
      }
    }
    
    public string Channel
    {
      get
      {
        return channel;
      }
      
      set
      {
        channel = value;
      }
    }
    
    public string Address
    {
      get
      {
        return address;
      }
      
      set
      {
        address = value;
      }
    }
    
    public string Status
    {
      get
      {
        return status;
      }
      
      set
      {
        status = value;
      }
    }    
    
    public string SentAt
    {
      get
      {
        return sentAt;
      }
      
      set
      {
        sentAt = value;
      }
    }        
  
  }

}