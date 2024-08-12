using MatchingApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

public class Message
{
    [Key]
    public int Id { get; set; }

    public int SenderId { get; set; }  
    public User Sender { get; set; }

    public int ReceiverId { get; set; } 
    public User Receiver { get; set; }

    public string Content { get; set; }
    public DateTime Date { get; set; }
}
