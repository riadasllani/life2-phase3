namespace MatchingApp.Models.Dtos;

public class SendMessageDto
{
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Content { get; set; }
    
}